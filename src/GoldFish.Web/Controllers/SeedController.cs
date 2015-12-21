using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GoldFish.Web.Models;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace GoldFish.Web.Controllers
{
    public class SeedController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        public SeedController(IHostingEnvironment env, UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _env = env;
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var seedFolder = _env.MapPath("seed");
            using (var data = new StreamReader(new FileStream(seedFolder + "/ADUsers.csv", FileMode.Open, FileAccess.Read)))
            {
                var fields = data.ReadLine().Split(',');
                var f = new Dictionary<string, int>();
                for (int i = 0; i < fields.Length; i++)
                {
                    f.Add(fields[i].Trim('"'), i);
                }

                while (!data.EndOfStream)
                {
                    var line = data.ReadLine().Split(',');
                    var user = new ApplicationUser
                    {
                        Email = line[f["mail"]].Trim('"'),
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        NormalizedEmail = line[f["mail"]].Trim('"'),
                        NormalizedUserName = line[f["SamAccountName"]].Trim('"'),
                        PhoneNumber = line[f["OfficePhone"]].Trim('"'),
                        PhoneNumberConfirmed = true,
                        Title = line[f["Title"]].Trim('"'),
                        FirstName = line[f["GivenName"]].Trim('"'),
                        LastName = line[f["Surname"]].Trim('"'),
                        TwoFactorEnabled = false,
                        UserName = line[f["mail"]].Trim('"')
                    };
                    var existingUser = await _userManager.FindByNameAsync(user.UserName);
                    var network =
                        _db.Networks.Include(n => n.Groups).FirstOrDefault(n => n.Id == user.UserName.Split('@')[1]);

                    if (network == null)
                    {
                        network = new Network
                        {
                            Id = user.UserName.Split('@')[1]
                        };
                        _db.Networks.Add(network);
                    }

                    if (!network.Groups.Any())
                    {
                        network.Groups.Add(new Group
                        {
                            Name = "All Company",
                        });

                        network.Groups.Add(new Group
                        {
                            Name = "IT Support",
                        });

                        network.Groups.Add(new Group
                        {
                            Name = "HR"
                        });

                        network.Groups.Add(new Group
                        {
                            Name = "Finance"
                        });
                    }

                    var allCompanyGroup = network.Groups.First(g => g.Name == "All Company");
                    if (existingUser != null)
                    {
                        if (existingUser.Network == null)
                            existingUser.Network = network;

                        if (!_db.UserGroups.Any(u => u.UserId == existingUser.Id))
                            existingUser.Groups.Add(new UserGroup
                            {
                                User = existingUser,
                                Group = allCompanyGroup
                            });
                        continue;
                    }
                    user.Network = network;
                    user.Groups.Add(new UserGroup
                    {
                        User = user,
                        Group = allCompanyGroup
                    });
                    await _userManager.CreateAsync(user, "P@ssw0rd");
                }
            }
            _db.SaveChanges();
            return new HttpOkResult();

        }

    }
}
