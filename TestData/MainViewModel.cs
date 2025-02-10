using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TestData
{
    public class MainViewModel
    {

        readonly DbContextOptions<AppDbContext> optionsBuilder;
        const string ConnectionString = "Server=localhost;user=root;password=Omega42;database=testMBQuizGameDb";
        public MainViewModel()
        {
            optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(ConnectionString,ServerVersion.AutoDetect(ConnectionString))
                .Options;
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value; 
            }
        }
        public void AddUser()
        {
            if (optionsBuilder is null) return;
            using (AppDbContext db = new AppDbContext(optionsBuilder))
            {
                User user = db.Users.FirstOrDefault(u => u.UserName == _userName);

                if (user is not null) 
                {
                    //Если есть то не добавляем
                    if (EnCrypt(Password, user.Password))
                    {
                        MessageBox.Show("Проверку прошёл");
                    }
                    else
                    {
                        MessageBox.Show("Пошёл нахуй)");
                    }
                    return;
                }
                string password = Crypt(Password);
                User user1 = new User { UserName = UserName, Password = password };
                db.Users.Add(user1);
                db.SaveChanges();
            }
        }
        private string Crypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return null;
            return PasswordHasher.HashPassword(password);
        }
        private bool EnCrypt(string password, string hashPassword)
        {
            if (string.IsNullOrEmpty(password)) return false;
            return PasswordVerifier.VerifyPassword(password, hashPassword);
        }
    }
}
