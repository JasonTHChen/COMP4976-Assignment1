namespace LmycWebSite.Migrations.BoatMigrations
{
	using LmycDataLib.Models;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<LmycDataLib.Models.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			MigrationsDirectory = @"Migrations\BoatMigrations";
		}

		protected override void Seed(LmycDataLib.Models.ApplicationDbContext context)
		{
			SeedAdminUsers(context);
			SeedMembers(context);

            context.Boats.AddOrUpdate(b => b.BoatId, DummyData.GetBoats(context).ToArray());

		}

		private void SeedAdminUsers(ApplicationDbContext context)
		{
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			if (!roleManager.RoleExists("Admin"))
			{
				// Create admin role if it does not existes
				var role = new IdentityRole { Name = "Admin" };
				roleManager.Create(role);
			}

			// Create an Admin user
			var user = new ApplicationUser
			{
				UserName = "a",
				Email = "a@a.a",
				FirstName = "Jason",
				LastName = "Chen",
				Street = "3700 Willingdon Ave",
				City = "Burnaby",
				Province = "BC",
				PostalCode = "V5G 3H2",
				Country = "Canada",
				MobileNumber = "(604) 434-5734",
				SailingExperience = 50
			};

			string password = "P@$$w0rd";
			var result = userManager.Create(user, password);

			// Add default User to Role Admin
			if (result.Succeeded)
			{
				userManager.AddToRole(user.Id, "Admin");
			}
		}

		private void SeedMembers(ApplicationDbContext context)
		{
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			if (!roleManager.RoleExists("Member"))
			{
				// Create member role if it does not existes
				var role = new IdentityRole { Name = "Member" };
				roleManager.Create(role);
			}

			// Create a member
			var user = new ApplicationUser
			{
				UserName = "m",
				Email = "m@m.m",
				FirstName = "Siri",
				LastName = "Apple",
				Street = "3700 Willingdon Ave",
				City = "Burnaby",
				Province = "BC",
				PostalCode = "V5G 3H2",
				Country = "Canada",
				MobileNumber = "(604) 434-5734",
				SailingExperience = 2
			};

			string password = "P@$$w0rd";
			var result = userManager.Create(user, password);

			// Add default User to Role Member
			if (result.Succeeded)
			{
				userManager.AddToRole(user.Id, "Member");
			}
		}
	}
}
