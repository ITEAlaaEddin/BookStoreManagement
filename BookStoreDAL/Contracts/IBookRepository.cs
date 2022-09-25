using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDAL.Models;

namespace BookStoreDAL.Contracts
{
    internal interface IBookRepository
    {
        public void AddMany(List<Book>? books);
        public void UpdateBook(Book book);
        public List<object> GetBriefInfo();
        public int GetCountOfBooksInStore();
        public Book? GetBookById(int Id);
        public int GetSumOfCopies();

    }
}
