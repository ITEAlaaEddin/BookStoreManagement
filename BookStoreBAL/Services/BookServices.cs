using BookStoreDAL.Models;
using BookStoreDAL.Repository;

namespace BookStoreBAL.Services
{
    public  class BookServices 
    {
        public BookServices()
        {
            bookRepository = new BookRepository();
        }
        BookRepository bookRepository;
        public void AddDefaultBooks()
        {
            
            var books = new List<Book>()
                    {
                        new Book(){Name = "First Book", Price = 15.2, AvailableCopies=7},
                        new Book(){Name = "Second Book", Price = 18, AvailableCopies=15},
                        new Book(){Name = "Third Book", Price = 17 , AvailableCopies = 5},
                        new Book(){Name = "Fourth Book", Price = 25, AvailableCopies = 40},
                        new Book(){Name = "Fifth Book", Price = 24, AvailableCopies = 1},
                        new Book(){Name = "Sixth Book", Price = 14.6, AvailableCopies = 5},
                        new Book(){Name = "Seventh Book", Price = 8, AvailableCopies = 100},
                    };
               bookRepository.AddMany(books);
        }


        public List<object>? GetInfoForASpecBook(int id)
        {
            if(!IsIdValid(id))
                return null;

            Book book = bookRepository.GetBookById(id);
            var bookInfo = new List<Book>() { book };
            return bookInfo.Select(b => new { b.Id, b.Name, b.Price,b.AvailableCopies }).ToList<object>();
        }
        

        public void ModifyBook(int id,string name , double price)
        {
            var book = bookRepository.GetBookById(id);
            book.Name = name;
            book.Price = price;
            bookRepository.UpdateBook(book);
        }


        public bool DeleteBookById(int id)
        {
            Book book = bookRepository.GetBookById(id);
            if(book is null)
                return false;
            book.IsDeleted = true;
            bookRepository.UpdateBook(book);
            return true;
        }

        public (List<object> BriefInfoAboutBooks,int SumOfAllCopies) GetBriefInfoAboutAllBooks()
        {
            return (bookRepository.GetBriefInfo(), bookRepository.GetSumOfCopies());
        }
        public bool IsIdValid(int id)
        {
            if(id <= 0)
                return false;

            var book = bookRepository.GetBookById(id);
                if ( book is not null)
                    if(!book.IsDeleted)
                        return true;

                return false;
        }

        public int GetCountOfBooksInStore()
        {
            return bookRepository.GetCountOfBooksInStore();
        }

    }
}
