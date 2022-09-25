using BookStoreDAL.Models;
using Microsoft.EntityFrameworkCore;


namespace BookStoreDAL.Data
{
    public class BookStoreDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        private readonly StreamWriter _logStream = new StreamWriter("D:\\mylog.txt", append: true);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(_logStream.WriteLine);
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\ProjectModels; Initial Catalog = BookStoreDatabase");
        }

        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }
    }
}