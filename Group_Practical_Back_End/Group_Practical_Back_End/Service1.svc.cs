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

        public bool addProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool addSeller(Seller seller)
        {
            throw new NotImplementedException();
        }

        public bool addToCart(int UserId, int productId,int add)
        {
            var dbUser = (from u in db.Users where u.Id == UserId select u).FirstOrDefault();

            User user = new User();
            user = getUserById(UserId);

            string cart = user.Cart_Items;
            if (cart!=null)
            {
                string[] tokens = cart.Split(' ');

                int index = -1;

                for (int x = 0; x < tokens.Length; x++)
                {
                    if (tokens[x].StartsWith(productId + "("))
                    {
                        index = x;
                        break;
                    }
                }

                if(index !=-1)
                {
                    int startAt = tokens[index].IndexOf('(');

                    string total = tokens[index].Substring(startAt + 1);
                    total = total.Replace(")", string.Empty);

                    string newCart = "";
                    int number = 0;

                    if (add==0)
                    {
                        number = 1 + Convert.ToInt32(total);
                    }
                    else
                    {
                         number = Convert.ToInt32(total) -1;        
                    }

                    if(number==0)
                    {
                        return removeFromCart(UserId, productId);
                    }
                    
                    tokens[index] = productId + "(" + number + ")";

                    foreach (string token in tokens)
                    {
                        newCart += token + " ";
                    }
                    string tocart = newCart.Trim() + " ";

                    dbUser.Cart_Items = tocart;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    dbUser.Cart_Items += productId+"(1) ";
                    db.SubmitChanges();
                    return true;
                }
            }
            else
            {
                dbUser.Cart_Items = Convert.ToString(productId+"(1) ");
                db.SubmitChanges();
                return true;
            }   
        }

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

        public bool editProduct(string username, string password, Product product)
        {
            throw new NotImplementedException();
        }

        public Product getProductByID(int Id)
        {
            dynamic prod = (from p in db.Products where p.Id==Id select p).FirstOrDefault();

            Product product = (Product)prod;

            return product;
        }

        public List<Product> getProducts()
        {
            dynamic products = (from p in db.Products select p);

            List<Product> list = new List<Product>();

            foreach (Product product in products)
            {
                list.Add(product);
            }

            return list;
        }

        public Seller getSellerByID(int Id)
        {
            // get user from database
            var seller = (from u in db.Sellers
                        where u.Id == Id
                        select u).FirstOrDefault();

            Seller ret = new Seller
            {
                Username = seller.Username,
                Id = seller.Id,
                Password = seller.Password,
                Email = seller.Email,
                Phone = seller.Phone,
                S_Name = seller.S_Name,
                S_Surname = seller.S_Surname,
                Average_Rating = seller.Average_Rating
            };

            return ret;
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

        public bool removeFromCart(int UserId, int productId)
        {
            var dbUser = (from u in db.Users where u.Id == UserId select u).FirstOrDefault();

            User user = new User();
            user = getUserById(UserId);

            string cart = user.Cart_Items;
            if (cart != null)
            {
                string[] tokens = cart.Split(' ');

                int index = -1;

                for (int x = 0; x < tokens.Length; x++)
                {
                    if (tokens[x].StartsWith(productId + "("))
                    {
                        index = x;
                        break;
                    }
                }

                if (index != -1)
                {
                    int startAt = tokens[index].IndexOf('(');

                    string total = tokens[index].Substring(startAt + 1);
                    total = total.Replace(")", string.Empty);

                    string newCart = "";

                    for(int x=0; x<tokens.Length;x++)
                    {
                        // skip adding product to cart list
                        if(x ==index)
                        {
                            continue;
                        }

                        newCart += tokens[x] + " ";
                    }

                    string tocart = newCart.Trim() + " ";

                    dbUser.Cart_Items = tocart;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public bool searchSeller(string username, string password)
        {
            dynamic input = (from seller in db.Sellers
                             where (seller.Username.Equals(username)
                             && seller.Password.Equals(password))
                             select seller);

            Seller sel = new Seller();

            foreach(dynamic item in input)
            {
                sel = item;
            }

            // this statement return true if the data for database matches the requested user
            if (sel.Username != null)
            {
                if (sel.Username.Equals(username) &&
                    sel.Password.Equals(password))
                {
                    return true; // return true if everything went well/user exists
                }
            }

            return false; // return false if user does not exist
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
