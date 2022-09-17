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

        // @JS PHALA === FRONT-END PAGE TO BE DONE OR UPDATE THE REGISTER PAGE
        public bool addProduct(Product product)
        {
            
            // use search function to check if Product exist
            if (searchProduct(product.Product_Name, product.Category, product.Manufacturer))
            {
                return false;
            }

            //create Product 
            Product prod = product;

            // adding Product to database
            db.Products.InsertOnSubmit(prod);
            db.SubmitChanges(); // submitting changes after adding Product
            
            return true;
        }


        // @JS PHALA === FRONT-END PAGE TO BE DONE OR UPDATE THE(SHOULD ADD WHO IS ABLE TO ADD THE SELLER == ONLY THE MANAGER)
        public bool addSeller(Seller seller)
        {

            // use search function to check if seller exist
            if (searchSeller(seller.Username, seller.Password))
            {
                return false;
            }

            //create seller 
            Seller sellerUser = new Seller();

            sellerUser.S_Name = seller.S_Name;
            sellerUser.S_Surname = seller.S_Surname;
            sellerUser.Username = seller.Username;
            sellerUser.Email = seller.Email;
            sellerUser.Phone = seller.Phone;
            sellerUser.Password = seller.Password;
            sellerUser.Identity_Number = seller.Identity_Number;

            // adding seller to database
            db.Sellers.InsertOnSubmit(sellerUser);
            db.SubmitChanges(); // submitting changes after adding seller

            return true;
        }

        // @ T GULUBE
        public bool addToCart(int UserId, int productId,int add)
        {
            var dbUser = (from u in db.Users 
                          where u.Id == UserId 
                          select u).FirstOrDefault();

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

<<<<<<< HEAD

        // // @JS PHALA == USED WHEN ADDING THE PRODUCT
        // Searches whether the product Exists in the database
        public bool searchProduct(string productName, string productCategory, string productManufacturer)
=======
        public bool editProduct(string username, string password, Product product)
>>>>>>> 3991052236d284178aae8b68a1d923ea8e127e0b
        {
            dynamic input = (from prod in db.Products
                             where (prod.Product_Name.Equals(productName)
                             && prod.Category.Equals(productCategory) && prod.Manufacturer.Equals(productManufacturer))
                             select prod);

            //instance of the product
            Product product = new Product();

            // helps assign database information to the instance
            foreach (dynamic produc in input)
            {
                product = produc;
            }

            // this statement return true if the data for database matches the requested product
            if (product.Product_Name != null)
            {
                if (product.Product_Name.Equals(productName) &&
                    product.Category.Equals(productCategory) && product.Manufacturer.Equals(productManufacturer))
                {
                    return true; // return true if everything went well/product exists
                }
            }

            return false; // return false if product does not exist
        }


        // ---TO--DO--- // // @JS PHALA === FRONT-END PAGE TO BE DONE OR UPDATE THE SINGLE PRODUCT PAGE (SHOULD ADD WHO IS ABLE TO EDIT THE PRODUCT == MANAGER AND SELLER)
        public bool editProduct(Product product, string userName, string passWord)
        {

            var prod = (from p in db.Products
                        where p.Id.Equals(product.Id)
                        select p).FirstOrDefault();

            if(searchSeller(userName, passWord))
            {
                // Used for URL-Parameters
                prod.Id = product.Id;
                prod.Product_Name = product.Product_Name;
                prod.Product_Price = product.Product_Price;
                prod.Discount_Price = product.Discount_Price;

                prod.Category = product.Category;

                prod.Image = product.Image;
                prod.Available = product.Available;
                prod.Seller_ID = product.Seller_ID;
                prod.Color = product.Color;
                prod.Description = product.Description;
                prod.Weight_KG = product.Weight_KG;
                prod.Dimensions_XYZ = product.Dimensions_XYZ;
                prod.Manufacturer = product.Manufacturer;

                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (IndexOutOfRangeException eore)
                {
                    eore.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }           
        }

        // RETURNS THE PRODUCT (SINGLE PRODUCT PAGE)
        public Product getProductByID(int Id)
        {
            dynamic prod = (from p in db.Products 
                            where p.Id==Id 
                            select p).FirstOrDefault();

            Product product = (Product)prod;

            return product;
        }


        // RETURN ALL THE PRODUCTS(MENUES)
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


        /// <summary>
        /// returns the seller with the provided ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Seller</returns>
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

        /// <summary>
        /// returns the userID with the provided username and password, integer UserID if the user exists
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>User ID (integer) </returns>
        public int getUserID(string username, string password)
        {
            var user = (from u in db.Users
                        where u.Username.Equals(username)&& u.Password.Equals(password)
                        select u).FirstOrDefault();

            return user.Id;
        }

        /// <summary>
        /// Removes Items from the Cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="productId"></param>
        /// <returns>false if no items, true if item exists in cart</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
