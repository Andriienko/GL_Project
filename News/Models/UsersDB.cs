using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Models
{
    public class UsersDB
    {
        private static List<UserModel> _users;

         static UsersDB()
         {
             _users = new List<UserModel>()
             {
                 new UserModel
                 {
                    UserId = 0,
                    FirstName = "Roman",
                    LastName = "Andriienko",
                    Email = "roman@glo.com",
                    Password = "Pass1@",
                    BirthDate = new DateTime(1993,10,15)
                },
                new UserModel
                 {
                    UserId = 1,
                    FirstName = "Vovan",
                    LastName = "Wander",
                    Email = "lopn@glo.com",
                    Password = "Pass1@",
                    BirthDate = new DateTime(1993,10,15)
                },
                new UserModel
                 {
                    UserId = 2,
                    FirstName = "Porc",
                    LastName = "Giifee",
                    Email = "ger@glo.com",
                    Password = "Pass1@",
                    BirthDate = new DateTime(1993,10,15)
                },
                new UserModel
                 {
                    UserId = 3,
                    FirstName = "Nopevan",
                    LastName = "Cernder",
                    Email = "ppn@glo.com",
                    Password = "Pass1@",
                    BirthDate = new DateTime(1993,10,15)
                }
             };
         }

        public static void AddUser(UserModel user)
        {
            if(user!=null)
                _users.Add(user);
        }
        public static IEnumerable<UserModel> GetAllUsers()
        {
            return _users;
        }
    }
}