
using System.Data.Entity.Migrations;

namespace Linkedin.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LinkedinDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(LinkedinDbContext context)
        {
        }
    }
}
