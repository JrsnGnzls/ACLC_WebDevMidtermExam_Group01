using ACLC_WebDevMidtermExam_Group01.Models;
using Microsoft.EntityFrameworkCore;

namespace ACLC_WebDevMidtermExam_Group01.DataConnection
{
    public class MySqlDbContext:DbContext
    {
        public DbSet<joborder> form { get; set; }

        public DbSet<Account> user { get; set; }
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) {

        }
    }
}
