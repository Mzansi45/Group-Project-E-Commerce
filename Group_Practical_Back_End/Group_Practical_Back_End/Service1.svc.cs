using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Group_Practical_Back_End
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        //@T Gulube 219020988
        public bool addUser(string username, string password, string surname, string name, string email, string phone)
        {
            // use search function to check if user exist
            if (searchUser(username, password))
            {
                return false;
            }

            //create user 
            User user = new User();
            user.First_Name = name;
            user.Surname = surname;
            user.Username = username;
            user.Password = password;
            user.Email = email;
            user.User_Type = 0;
            user.Phone = phone;

            // adding user to database
            db.Users.InsertOnSubmit(user);
            db.SubmitChanges(); // submitting changes after adding user

            return true;
        }

        //@T Gulube 219020988
        public User getUserById(int id)
        { 
            // get user from database
            var user = (from u in db.Users
                        where u.Id ==id
                        select u).FirstOrDefault();

            // creating a user to return
            User ret = new User
            {
                Username = user.Username,
                Id = user.Id,
                Password = user.Password,
                Email = user.Email,
                User_Type = user.User_Type,
                Phone = user.Phone,
                First_Name = user.First_Name,
                Surname = user.Surname,
                Cart_Items = user.Cart_Items,
            };

            return ret;
        }

        public int getUserID(string username, string password)
        {
            var user = (from u in db.Users
                        where u.Username.Equals(username)&& u.Password.Equals(password)
                        select u).FirstOrDefault();
            return user.Id;
        }

        //@T Gulube 219020988
        public bool searchUser(string username, string password)
        {
            dynamic input = (from user in db.Users
                             where (user.Username.Equals(username)
                             && user.Password.Equals(password))
                             select user);

            //instance of the user
            User customer = new User();

            // helps assign database information to my instance
            foreach (dynamic item in input)
            {
                customer = item;
            }

            // this statement return true if the data for database matches the requested user
            if (customer.Username != null)
            {
                if (customer.Username.Equals(username) &&
                    customer.Password.Equals(password))
                {
                    return true; // return true if everything went well/user exists
                }
            }

            return false; // return false if user does not exist
        }
    }
}
