using BookStoreDAL.Models;
using BookStoreDAL.Repository;
using System.Text.Json;


namespace BookStoreBAL.Services
{
    public class UserServices
    {
        public UserServices()
        {
            userRepository = new UserRepository();
        }

        UserRepository userRepository;

        public bool CheckLogIn(string userName,string password)
        {
            var user = userRepository.GetUser(userName);

            if (user != null)
                if (password == user.Password)
                    return true;

            return false;
        }

        public List<User> GetFromJSON()
        {
            string contents = File.ReadAllText("Default.json");
            var defaultEmployees = JsonSerializer.Deserialize<List<User>>(contents);
            return defaultEmployees;
        }

        public void AddDefaultUseres()
        {
            List<User> Users=GetFromJSON();
            foreach (var user in Users)
                if (!userRepository.IsExist(user))
                     userRepository.AddUser(user);
        }
    }
}
