using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
           /* if(searchProduct(product.Product_Name, product.Category, product.Manufacturer))
            {
                return false;
            }*/

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
            sellerUser.Registration_Date = DateTime.Now;
            sellerUser.Password = seller.Password;
            sellerUser.Identity_Number = seller.Identity_Number;

            // adding seller to database
            db.Sellers.InsertOnSubmit(sellerUser);
            db.SubmitChanges(); // submitting changes after adding seller

            return true;
        }

        // @ T GULUBE
        public bool addToCart(int UserId, int productId, int add)
        {
            var dbUser = (from u in db.Users
                          where u.Id == UserId
                          select u).FirstOrDefault();

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
                    int number = 0;

                    if (add == 0)
                    {
                        number = 1 + Convert.ToInt32(total);
                    }
                    else
                    {
                        number = Convert.ToInt32(total) - 1;
                    }

                    if (number == 0)
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
                    dbUser.Cart_Items += productId + "(1) ";
                    db.SubmitChanges();
                    return true;
                }
            }
            else
            {
                dbUser.Cart_Items = Convert.ToString(productId + "(1) ");
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
            //user.User_Type = 0;
            user.Phone = phone;
            user.Registration_Date = DateTime.Now;


            // adding user to database
            db.Users.InsertOnSubmit(user);
            db.SubmitChanges(); // submitting changes after adding user

            return true;
        }

        // // @JS PHALA == USED WHEN ADDING THE PRODUCT
        // Searches whether the product Exists in the database
        public bool searchProduct(string productName, string productCategory, string productManufacturer)
        {
            return true;
        }

        // WCF Function for retrieving Product, using prodName, prodCategory and prodManufacturer
        public Product getProduct(string prodName)
        {


            // Go to the database and get the whole product With the provided prodName, prodCategory and prodManufacturer
            var product = (from p in db.Products
                               where p.Product_Name.Equals(prodName) /*&& p.Category.Equals(prodCategory) && p.Manufacturer.Equals(prodManufacturer)*/
                               select p).FirstOrDefault();

                // Return the whole Reservation 
                return product;
            
        }

        public Product getProductById(int prodID)
        {
            var product = (from p in db.Products
                           where p.Id == prodID /*&& p.Category.Equals(prodCategory) && p.Manufacturer.Equals(prodManufacturer)*/
                           select p).FirstOrDefault();

            // Return the whole Reservation 
            return product;

        }

        public bool editProduct(Product prod)
        {
            dynamic input = (from p in db.Products
                             where (prod.Product_Name.Equals(prod.Product_Name)
                             && prod.Category.Equals(prod.Category) && prod.Manufacturer.Equals(prod.Manufacturer))
                             select p);

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
                if (product.Product_Name.Equals(prod.Product_Name) &&
                    product.Category.Equals(prod.Category) && product.Manufacturer.Equals(prod.Manufacturer))
                {
                    return true; // return true if everything went well/product exists
                }
            }

            return false; // return false if product does not exist
        }

        // ---TO--DO--- // // @JS PHALA === FRONT-END PAGE TO BE DONE OR UPDATE THE SINGLE PRODUCT PAGE (SHOULD ADD WHO IS ABLE TO EDIT THE PRODUCT == MANAGER AND SELLER)
        public bool updateProduct(Product product)
        {

            var prod = (from p in db.Products
                        where p.Id.Equals(product.Id)
                        select p).FirstOrDefault();

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
            prod.Discount_Start_Date = product.Discount_Start_Date;
            prod.Discount_End_Date = product.Discount_End_Date;

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

        //@ T Gulube 219020988
        // RETURNS THE PRODUCT (SINGLE PRODUCT PAGE)
        public Product getProductByID(int Id)
        {
            dynamic prod = (from p in db.Products 
                            where p.Id==Id 
                            select p).FirstOrDefault();

            Product product = (Product)prod;

            return product;
        }

        //@ T Gulube 219020988
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
        /// //@ T Gulube 219020988
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

        public Seller gettingSellerByID(int Id)
        {
            // get user from database
            var seller = (from u in db.Sellers
                          where u.Id == Id
                          select u).FirstOrDefault();

            Seller ret = new Seller
            {
                Username = seller.Username,
                Id = seller.Id,
                Identity_Number = seller.Identity_Number,
                Email = seller.Email,
                Phone = seller.Phone,
                S_Name = seller.S_Name,
                S_Surname = seller.S_Surname,
            };

            return ret;
        }

        public Employee gettingEmployeeByID(int Id)
        {
            // get Employee from database
            var eployee = (from u in db.Employees
                          where u.Id == Id
                          select u).FirstOrDefault();

            Employee ret = new Employee
            {
                Id = eployee.Id,
                Employee_Name = eployee.Employee_Name,
                Surname = eployee.Surname,
                Email = eployee.Email,
                Username = eployee.Username,
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
                Phone = user.Phone,
                First_Name = user.First_Name,
                Surname = user.Surname,
                Cart_Items = user.Cart_Items,
                Last_Active = user.Last_Active,
                News_letter_Subscription = user.News_letter_Subscription,
                Registration_Date = user.Registration_Date,
                Wish_List = user.Wish_List             
            };

            return ret;
        }

        /// <summary>
        /// returns the userID with the provided username and password, integer UserID if the user exists
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>User ID (integer) </returns>
        /// //@ T Gulube 219020988
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
        /// //@ T Gulube 219020988
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

                    for (int x = 0; x < tokens.Length - 1; x++)
                    {
                        // skip adding product to cart list
                        if (x == index)
                        {
                            continue;
                        }
                        newCart += tokens[x] + " ";
                    }

                    if (newCart.Length < 3)
                    {
                        newCart = null;
                    }

                    dbUser.Cart_Items = newCart;
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
        /// //@ T Gulube 219020988
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
           // customer = input;

            // this statement return true if the data for database matches the requested user
            if (customer.Username != null)
            {
                if (customer.Username.Equals(username) &&
                    customer.Password.Equals(password))
                {
                    //input.Last_Active = DateTime.Now;
                    //db.SubmitChanges();
                    return true; // return true if everything went well/user exists
                }
            }

            return false; // return false if user does not exist
        }

        ////@ T Gulube 219020988
        public int getSellerId(string username, string password)
        {
            var user = (from u in db.Sellers
                          where u.Username.Equals(username) && u.Password.Equals(password)
                          select u).FirstOrDefault();

            return user.Id;
        }

        //sets last active date of a Customer upon login
        //@ T Gulube 219020988
        public bool setUserActive(int userId, DateTime date)
        {
            try
            {
                var user = (from u in db.Users where u.Id == userId select u).FirstOrDefault();
                user.Last_Active = date;

                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                e.GetBaseException();
                return false;
            }
        }

        //sets  last active date of the seller upon login
        //@ T Gulube 219020988
        public bool setSellerActive(int sellerId, DateTime date)
        {
            try
            {
                var seller = (from s in db.Sellers where s.Id == sellerId select s).FirstOrDefault();
                seller.Last_Active = date;

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }
        }

        //@ T Gulube 219020988
        public Employee getEmployeeByID(int Id)
        {
            var employee = (from u in db.Employees where u.Id == Id select u).FirstOrDefault();
            Employee emp = new Employee();
            emp = employee;

            return emp;
        }

        public bool addEmployee(Employee employee)
        {
            if(searchEmployee(employee.Username,employee.Password))
            {
                return false;
            }

            db.Employees.InsertOnSubmit(employee);
            db.SubmitChanges();
            return true;
        }

        public bool searchEmployee(string username, string password)
        {
            dynamic input = (from emp in db.Employees
                             where (emp.Username.Equals(username)
                             && emp.Password.Equals(password))
                             select emp);

            //instance of the user
            Employee employee = new Employee();

            // helps assign database information to my instance
            foreach (dynamic item in input)
            {
                employee = item;
            }
            // customer = input;

            // this statement return true if the data for database matches the requested user
            if (employee.Username != null)
            {
                if (employee.Username.Equals(username) &&
                    employee.Password.Equals(password))
                {
                    //input.Last_Active = DateTime.Now;
                    //db.SubmitChanges();
                    return true; // return true if everything went well/user exists
                }
            }

            return false;
        }

        public int getEmployeeID(string username, string password)
        {
            var emp = (from e in db.Employees
                       where
                       e.Username.Equals(username) && e.Password.Equals(password)
                       select e).FirstOrDefault();
            return emp.Id;
        }

        public bool addQuery(Query query)
        {
            try
            {
                db.Queries.InsertOnSubmit(query);
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                e.GetBaseException();
                return false;
            }

        }

        public List<Query> GetQueries()
        {
            List<Query> list = new List<Query>();
            dynamic lst = from q in db.Queries select q;

            foreach(dynamic item in lst)
            {
                list.Add(item);
            }

            return list;
        }

        public Query GetQueryByID(int Id)
        {
            Query query = new Query();
            var dblQuery = (from q in db.Queries where q.Id == Id select q).FirstOrDefault();

            query = dblQuery;

            return query;

        }

        public bool deleteCart(int UserId)
        {
            var user = (from u in db.Users where u.Id == UserId select u).FirstOrDefault();
            user.Cart_Items = null;

            db.SubmitChanges();

            return true;
        }

        public List<Invoice> GetInvoices()
        {
            List<Invoice> list = new List<Invoice>();

            dynamic dbList = (from i in db.Invoices select i);
            
            foreach(dynamic item in dbList)
            {
                list.Add(item);
            }

            return list;
        }

        public Invoice GetInvoiceByID(int ID)
        {
            var inv = (from i in db.Invoices where i.Id == ID select i).FirstOrDefault();

            Invoice invoice = new Invoice();

            invoice = inv;

            return invoice;
        }

        public int addInvoice(Invoice invoice)
        {
            try
            {
                db.Invoices.InsertOnSubmit(invoice);
                db.SubmitChanges();

                var inv = (from i in db.Invoices where invoice.Transaction_Date == i.Transaction_Date
                           && invoice.Email.Equals(i.Email) select i).FirstOrDefault();
                Invoice newInvoice = new Invoice();
                newInvoice = inv;

                return newInvoice.Id;
                //return true;
            }
            catch(Exception e)
            {
                e.GetBaseException();
                return 0;
            }
        }

        public bool markQueryRead(Query query)
        {
            try
            {
                var q = (from t in db.Queries where query.Id == t.Id select t).FirstOrDefault();

                q.Answered = query.Answered;

                db.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public Invoice GetInvoiceByUserID(int Id)
        {
            var inv = (from i in db.Invoices where i.Id == Id select i).FirstOrDefault();
            Invoice invoice = new Invoice();

            invoice = inv;
            return invoice;
        }

        public bool EditPassword(int userId, string newPassword)
        {
            var user = (from u in db.Users where u.Id == userId select u).FirstOrDefault();

            try
            {
                user.Password = newPassword;
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                e?.GetBaseException();
                return false;
            }
        }

        public int getUserIdByEmail(string username, string email)
        {
            var user = (from u in db.Users where u.Username.Equals(username) &&
                        u.Email.Equals(email) select u).FirstOrDefault();

            return user.Id;
        }

        public bool addToWishList(int userId, int productId)
        {
            var dbUser = (from u in db.Users
                          where u.Id == userId
                          select u).FirstOrDefault();

            User user = new User();
            user = getUserById(userId);

            if(user.Wish_List !=null)
            {
                string[] items = user.Wish_List.Split(' ');
                int size = items.Length-1;

                List<string> list = new List<string>();

                if (!items.Contains(productId.ToString()))
                {
                    list = items.ToList();
                    list.Remove("");
                    list.Add(productId.ToString());

                    string newWishList = "";

                    foreach(string item in list)
                    {
                        newWishList += item + " ";
                    }

                    dbUser.Wish_List = newWishList;
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
                dbUser.Wish_List = productId+ " ";
                db.SubmitChanges();
                return true;
            }
        }

        public bool removeFromWishList(int userId, int productId)
        {
            var dbUser = (from u in db.Users
                          where u.Id == userId
                          select u).FirstOrDefault();

            User user = new User();
            user = getUserById(userId);

            if(user.Wish_List !=null)
            {
                string[] items = user.Wish_List.Split(' ');

                int size = items.Length - 1;

                List<string> list = new List<string>();

                list = items.ToList();
                list.Remove("");

                list.Remove(productId.ToString());

                if (list.Count <=1)
                {
                    dbUser.Wish_List = null;
                    db.SubmitChanges();
                    return true;
                }

                string newWishList = "";

                foreach (string item in list)
                {
                    newWishList += item + " ";
                }

                dbUser.Wish_List = newWishList;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return true;
            }
        }

        public bool addCoupon(Coupon coupon)
        {
            db.Coupons.InsertOnSubmit(coupon);
            db.SubmitChanges();
            return true;
        }

        public bool deleteCoupon(string couponValue)
        {
            var coupon = (from c in db.Coupons
                          where c.Coupon_Value.Equals(couponValue)
                          select c).FirstOrDefault();

            try
            {
                coupon.Used = 1;
                coupon.Use_Date = DateTime.Now;
                db.SubmitChanges();

                return true;
            }
            catch(Exception e)
            {
                e.GetBaseException();
                return false;
            }
        }

        public bool addCouponValue(int couponId, string value)
        {
            var coupon = (from c in db.Coupons where c.Id == couponId select c).FirstOrDefault();

            coupon.Coupon_Value = value;
            db.SubmitChanges();
            return true;
        }

        public int getCouponId(int customerId, DateTime creationTime)
        {
            var coupon = (from c in db.Coupons where customerId.Equals(customerId)
                          && c.Creation_Date.Equals(creationTime) select c).FirstOrDefault();

            return coupon.Id;
        }

        public bool ValidateCouponById(int id)
        {
            var coupon = (from c in db.Coupons where c.Id == id 
                          select c).FirstOrDefault();
            
            if(coupon.Used==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal GetCouponPrice(int id)
        {
            var coupon = (from c in db.Coupons
                          where c.Id == id
                          select c).FirstOrDefault();
            return coupon.Price;
        }

        // used for report
        public void onGet()
        {
            List<Product> listProd = new List<Product>();

            try
            {
                String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Product";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product prod = new Product();

                                prod.Id = reader.GetInt32(0);
                                prod.Product_Name = reader.GetString(1);
                                prod.Product_Price = reader.GetInt32(2);
                                prod.Discount_Price = reader.GetInt32(3);
                                prod.Category = reader.GetString(4);
                                prod.Image = reader.GetString(5);
                                prod.Available = reader.GetInt32(6);
                                prod.Seller_ID = reader.GetInt32(7);
                                prod.Color = reader.GetString(8);
                                prod.Description = reader.GetString(9);
                                prod.Weight_KG = reader.GetInt32(10);
                                prod.Dimensions_XYZ = reader.GetString(11);
                                prod.Manufacturer = reader.GetString(12);
                                prod.Discount_Start_Date = reader.GetDateTime(13);
                                prod.Discount_End_Date = reader.GetDateTime(14);

                                listProd.Add(prod);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }


        //  WCF Function to return Product
        public List<Product> getProductReport()
        {
            // Initialise the List array
            List<Product> products = new List<Product>();

            // Go to the database and get the List of products with Available == 1
            dynamic product = (from mi in db.Products
                               where mi.Available == 1
                               select mi).DefaultIfEmpty();

            // Check if the list of product is not null
            if (product != null)
            {
                // Loop through the products
                foreach (Product prod in product)
                {

                    // Create a new MenuItem for getting only the required products Information
                    var newProduct = new Product
                    {
                        Id = prod.Id,
                        Product_Name = prod.Product_Name,
                        Product_Price = prod.Product_Price,
                        Category = prod.Category,
                        Color = prod.Color,
                    };

                    // Add the newMenuItem on the ItemsOnMenu list
                    products.Add(newProduct);
                }

                // returns the list products
                return products;
            }
            else
            {
                // returns null if not able return the list products
                return null;
            }
        }


        //  WCF Function to return Product
        public List<Seller> getSellerReport()
        {
            // Initialise the List array
            List<Seller> sellers = new List<Seller>();

            // Go to the database and get the List of Sellers 
            dynamic seller = (from mi in db.Sellers
                              select mi).DefaultIfEmpty();

            // Check if the list of sellers is not null
            if (seller != null)
            {
                // Loop through the seller
                foreach (Seller sell in seller)
                {

                    // Create a new seller for getting only the required products Information
                    var newSeller = new Seller
                    {
                        Id = sell.Id,
                        S_Name = sell.S_Name,
                        S_Surname = sell.S_Surname,
                        Average_Rating = sell.Average_Rating,
                    };

                    // Add the newSeller on the Seller list
                    sellers.Add(newSeller);
                }

                // returns the list Seller
                return sellers;
            }
            else
            {
                // returns null if not able return the list products
                return null;
            }
        }

        public bool addEmployeee(string employeeName, string surname, string employee_Type, string email, string password, string userName)
        {
            // Create Employee 
            Employee employee = new Employee();

            employee.Employee_Name = employeeName;
            employee.Surname = surname;
            employee.Emploee_Type = Convert.ToInt32(employee_Type);
            employee.Email = email;
            employee.Password = password;
            employee.Username = userName;

            // Adding employee to database
            db.Employees.InsertOnSubmit(employee);
            db.SubmitChanges(); // Submitting changes after adding employee

            return true;
        }

        public bool editUser(User user)
        {
            var Customer = (from u in db.Users
                            where u.Id.Equals(user.Id)
                            select u).FirstOrDefault();

            if (Customer != null)
            {
                Customer.Id = user.Id;
                Customer.Username = user.Username;
                Customer.First_Name = user.First_Name;
                Customer.Surname = user.Surname;
                Customer.Phone = user.Phone;
                Customer.Email = user.Email;
            }

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

        public bool editSellerDetails(Seller seller)
        {
            var seler = (from u in db.Sellers
                            where u.Id.Equals(seller.Id)
                            select u).FirstOrDefault();

            if (seler != null)
            {
                seler.Id = seller.Id;
                seler.S_Name = seller.S_Name;
                seler.S_Surname = seller.S_Surname;
                seler.Username = seller.Username;
                seler.Email = seller.Email;
                seler.Phone = seller.Phone;
                seler.Identity_Number = seller.Identity_Number;
            }

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


        public bool editEmployeeDetails(Employee employee)
        {
            var employe = (from u in db.Employees
                         where u.Id.Equals(employee.Id)
                         select u).FirstOrDefault();

            if (employe != null)
            {
                employe.Id = employee.Id;
                employe.Employee_Name = employee.Employee_Name;
                employe.Surname = employee.Surname;
                employe.Email = employee.Email;
                employe.Username = employee.Username;
            }

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
    }
}
