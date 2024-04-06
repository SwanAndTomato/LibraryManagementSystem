using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<ReaderModel> Readers { get; set; }
        public DbSet<BorrowingModel> Borrowings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BorrowingModel>()
                .HasOne<BookModel>(b => b.Book) // Assuming there's a navigation property 'Book' in BorrowingModel
                .WithMany() // Assuming BookModel does not have a navigation property back to BorrowingModel
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BorrowingModel>()
                .HasOne<ReaderModel>(b => b.Reader) // Assuming there's a navigation property 'Reader' in BorrowingModel
                .WithMany(r => r.BorrowedBooks) // Assuming ReaderModel has a navigation property 'BorrowedBooks'
                .HasForeignKey(b => b.ReaderId);
        }
    }
}
