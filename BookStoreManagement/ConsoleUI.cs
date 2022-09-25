using BookStoreBAL.Services;
using Extensions;
namespace BookStoreMainApp
{
    public class ConsoleUI
    {
        public ConsoleUI()
        {
            bookServices = new BookServices();
        }
        BookServices bookServices;

        public static int HomePage()
        {
            Console.WriteLine("========================================================================\n"
                             + "Choose one of these options : \n"
                             + "1)Show brief information\n"
                             + "2)View information for a specific book\n"
                             + "3)Delete a specific book\n"
                             + "4)Modify the title and price of a specific book\n"
                             + "5)Log out"
                             );

            var option = Console.ReadLine();
            if (int.TryParse(option, out int optionNumber))
            {
                return optionNumber;
            }
            else
                return int.MaxValue;
        }

        public static (string userName, string password) LogInPage()
        {
            Console.Write("UserName : ");
            string userName = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            return (userName.ToLower(), password);
        }

        public void ShowNumberOfBook()
        {
            Console.WriteLine($"Number of books in the store : {bookServices.GetCountOfBooksInStore()}");
        }

        public void ShowBriefInfo()
        {
            Console.WriteLine("========================================================================\n"
                             + "Brief informations about available books in the store :");

            var infoPluseSum = bookServices.GetBriefInfoAboutAllBooks();
            infoPluseSum.BriefInfoAboutBooks.PrintPropsOfObjsInAlist();

            Console.WriteLine($"The total number of all copies in the repository : {infoPluseSum.SumOfAllCopies}");
        }

        public void ModifyBook()
        {
            var Id = EnterId();
            if (bookServices.IsIdValid(Id))
            {
                Console.Write("Enter new name : ");
                var name = Console.ReadLine();
            ErrorLoop:
                Console.Write("Enter new price : ");
                var priceStr = Console.ReadLine();

                if (double.TryParse(priceStr, out double price))
                {
                    bookServices.ModifyBook(Id, name, price);
                    Console.WriteLine("successfully modified !");

                }
                    
                else
                {
                    Console.WriteLine("Price should be a number  !");
                    goto ErrorLoop;
                }
            }
            else
                Console.WriteLine("Soory this book is not exist");

        }
        public void ViewInfoForASpecBook()
        {
            var Id = EnterId();

            if (bookServices.IsIdValid(Id))
                bookServices.GetInfoForASpecBook(Id).PrintPropsOfObjsInAlist();

            else
                Console.WriteLine("Soory this book is not exist");
        }

        public void DeleteBook()
        {
            var Id = EnterId();
            if (bookServices.IsIdValid(Id))
            {
                bookServices.DeleteBookById(Id);
                Console.WriteLine("Successfully deleted !");
            }

            else
                Console.WriteLine("Soory this book is not exist");
        }

        public static int EnterId()
        {
        ErrorLoop:
            Console.WriteLine("Enter id of the book");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int Id) && Id > 0)
                return Id;
            else
            {
                Console.WriteLine("U should enter a number above 0");
                goto ErrorLoop;
            }
        }

        public static void ShowIncorrestLogInMsg()
        {
            Console.WriteLine("========================================================================\n"
                            + "User name or password is incorrect please try again .....");
        }
    }
}
