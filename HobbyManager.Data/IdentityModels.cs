using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HobbyManager.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Paint> Paints { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectWorkflow> ProjectWorkflows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());

            modelBuilder.Entity<Workflow>()
                .HasRequired(m => m.Primer)
                .WithMany(m => m.Primers)
                .HasForeignKey(m => m.PrimeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Workflow>()
                .HasRequired(m => m.BaseCoat)
                .WithMany(m => m.BaseCoat)
                .HasForeignKey(m => m.BaseCoatId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Workflow>()
                .HasRequired(m => m.Shade)
                .WithMany(m => m.Shade)
                .HasForeignKey(m => m.ShadeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Workflow>()
                .HasRequired(m => m.HighlightOne)
                .WithMany(m => m.HighlightOne)
                .HasForeignKey(m => m.HightlightOneId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Workflow>()
                .HasRequired(m => m.SecondHighlight)
                .WithMany(m => m.SecondHighlight)
                .HasForeignKey(m => m.HighlightTwoId)
                .WillCascadeOnDelete(false);
        }
    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}