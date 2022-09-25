using BookStoreDAL.Data;
using BookStoreDAL.Models;
using BookStoreDAL.Contracts;

namespace BookStoreDAL.Repository
{
    public class BookRepository :IBookRepository
    {
        public void AddMany(List<Book>? books)
        {
            using(var context =new BookStoreDBContext())
            {
                if (books != null)
                {
                    context.Books.AddRange(books);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateBook(Book book)
        {
            using (var context = new BookStoreDBContext())
            {
                context.Books.Update(book);
                context.SaveChanges();
            }
        }

        public List<object> GetBriefInfo()
        {
            using (var context = new BookStoreDBContext())
            {
                var books = context.Books
                           .Where(b => !b.IsDeleted)
                           .Select(b => new { b.Id, b.Name, b.AvailableCopies })
                           .ToList<object>();

                return books;
            }
        }

        public int GetCountOfBooksInStore()
        {
            using(var context =new BookStoreDBContext())
            {
                return  context.Books
                            .Where(b => !b.IsDeleted)
                            .Count();
            }
            
        }
        public Book? GetBookById(int Id)
        {   
            using(var context = new BookStoreDBContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Id == Id);
                return book;
            }    
        }
        public int GetSumOfCopies()
        {                
            using(var context = new BookStoreDBContext())
            {
                return context.Books
                       .Where(b => !b.IsDeleted)
                       .Select(b => b.AvailableCopies)
                       .Sum();
            }
             
        }
    }
}
