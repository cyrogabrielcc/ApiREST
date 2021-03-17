using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        //passando dos parametros
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons {get; set;}
    }
}
