using Microsoft.EntityFrameworkCore;

namespace Repository.Model
{
    public class MysqlContext : DbContext
    {
        public MysqlContext()
        {

        }

        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options)
        {
            
        }
        public DbSet<PersonDbModel> Persons { get; set; }
    }
}
