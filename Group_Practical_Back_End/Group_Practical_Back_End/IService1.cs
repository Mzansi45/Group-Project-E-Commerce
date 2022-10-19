using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Group_Practical_Back_End
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool addUser(string username, string password, string surname,string name,string email,string phone);

        [OperationContract]
        User getUserById(int id);

        [OperationContract]
        bool searchUser(string username,string password);

        [OperationContract]
        int getUserID(string username, string password);

        [OperationContract]
        int getSellerId(string username, string password);

        [OperationContract]
        Product getProductByID(int Id);

        [OperationContract]
        Seller getSellerByID(int Id);

        [OperationContract]
        List<Product> getProducts();

        [OperationContract]
        bool addProduct(Product product);

        [OperationContract]
        bool editProduct(Product prod);

        [OperationContract]
        bool updateProduct(Product product);

        [OperationContract]
        Product getProduct(string prodName);

        [OperationContract]
        Product getProductById(int prodID);

        [OperationContract]
        bool addSeller(Seller seller);

        [OperationContract]
        Seller gettingSellerByID(int Id);

        [OperationContract]
        bool searchSeller(string username, string password);

        [OperationContract]
        bool addToCart(int UserId, int productId,int add);

        [OperationContract]
        bool removeFromCart(int UserId, int productId);

        [OperationContract]
        bool searchProduct(string productName, string productCategory, string productManufacturer);

        [OperationContract]
        bool setUserActive(int userId, DateTime date);

        [OperationContract]
        bool setSellerActive(int sellerId, DateTime date);

        [OperationContract]
        Employee getEmployeeByID(int Id);

        [OperationContract]
        bool addEmployee(Employee employee);

        [OperationContract]
        bool searchEmployee(string username, string password);

        [OperationContract]
        int getEmployeeID(string username, string password);

        [OperationContract]
        bool addQuery(Query query);

        [OperationContract]
        List<Query> GetQueries();

        [OperationContract]
        bool markQueryRead(Query query);

        [OperationContract]
        Query GetQueryByID(int Id);

        [OperationContract]
        bool deleteCart(int UserId);

        [OperationContract]
        List<Invoice> GetInvoices();

        [OperationContract]
        Invoice GetInvoiceByID(int ID);

        [OperationContract]
        int addInvoice(Invoice invoice);

        [OperationContract]
        Invoice GetInvoiceByUserID(int Id);

        [OperationContract]
        bool EditPassword(int userId, string newPassword);

        [OperationContract]
        int getUserIdByEmail(string username,string email);

        [OperationContract]
        bool addToWishList(int userId, int productId);

        [OperationContract]
        bool removeFromWishList(int userId, int productId);

        [OperationContract]
        bool addCoupon(Coupon coupon);

        [OperationContract]
        bool deleteCoupon(string couponValue);

        [OperationContract]
        bool addCouponValue(int couponId,string value);

        [OperationContract]
        int getCouponId(int customerId, DateTime creationTime);

        [OperationContract]
        bool ValidateCouponById(int id);

        [OperationContract]
        decimal GetCouponPrice(int id);

        [OperationContract]
        void onGet();

        [OperationContract]
        List<Product> getProductReport();

        [OperationContract]
        List<Seller> getSellerReport();

        [OperationContract]
        bool addEmployeee(string employeeName, string surname, string employee_Type, string email, string password, string userName);

        [OperationContract]
        bool editUser(User prod);

        [OperationContract]
        bool editSellerDetails(Seller seller);

        [OperationContract]
        Employee gettingEmployeeByID(int Id);

        [OperationContract]
        bool editEmployeeDetails(Employee employee);
    }
}
