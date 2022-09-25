using BookStoreBAL.Services;
using BookStoreDAL.Data;

namespace BookStoreMainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BookStoreDBContext())
            {
                context.Database.EnsureCreated();
            }

            var userServices = new UserServices();
            userServices.AddDefaultUseres();

            var bookServices = new BookServices();
            bookServices.AddDefaultBooks();


            while (true)
                ConsoleUINavigation();
        }

        static void ConsoleUINavigation()
        {
            var consoleUI = new ConsoleUI();
            var IsCorrectInfo = false;
            do
            {
                var info = ConsoleUI.LogInPage();
                var userServices = new UserServices();
                IsCorrectInfo = userServices.CheckLogIn(info.userName, info.password);

                if (!IsCorrectInfo)
                    ConsoleUI.ShowIncorrestLogInMsg();

            } while (!IsCorrectInfo);

            consoleUI.ShowNumberOfBook();

            var logOut = false;
            while (!logOut)
            {
                int option = ConsoleUI.HomePage();
                switch (option)
                {
                    case 1: consoleUI.ShowBriefInfo(); break;
                    case 2: consoleUI.ViewInfoForASpecBook(); break;
                    case 3: consoleUI.DeleteBook(); break;
                    case 4: consoleUI.ModifyBook(); break;
                    case 5: logOut = true; break;
                    default: Console.WriteLine("this option is not available"); break;
                }
            }
        }
    }
}