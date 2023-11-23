
namespace Protasker_backend
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TaskModel> Tasks => Set<TaskModel>();
        public DbSet<UserModel> Users => Set<UserModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=pro_tasker;user=root1;password=123456789";
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 28)));
        }
    }
}