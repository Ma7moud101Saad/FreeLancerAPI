using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Collections.Generic;

namespace GraduatedProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
       
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        //----------------start tables------------------------
        public virtual DbSet<FreeLancer> FreeLance { get; set; }
        public virtual DbSet<certification> certification { get; set; }
        public virtual DbSet<message> Message { get; set; }
        public virtual DbSet<test_result> test_result { get; set; }
        public virtual DbSet<test> test { get; set; }
        public virtual DbSet<attachment> attachment { get; set; }
        
        public virtual DbSet<proposal> proposal { get; set; }
        public virtual DbSet<PorposalStatus> PorposalStatus { get; set; }
        public virtual DbSet<contract> contract { get; set; }
        public virtual DbSet<payment_type> payment_type { get; set; }
        public virtual DbSet<hire_manager> hire_manager { get; set; }
        public virtual DbSet<company> company { get; set; }
        public virtual DbSet<job> job { get; set; }
        public virtual DbSet<complexity> complexity { get; set; }
        public virtual DbSet<ExpectedDuration> ExpectedDuration { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<UserAnswer> UserAnswer { get; set; }
        public virtual DbSet<OtherSkills> OtherSkills { get; set; }
        public virtual DbSet<contactUs> contactUs { get; set; }
        //--------------------end tables------------------------
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<GraduatedProject.Models.skill> skills { get; set; }
        public Questions QuestionsObj { get; internal set; }

        public System.Data.Entity.DbSet<GraduatedProject.Models.Category> Categories { get; set; }
    }
}