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
        Product getProductByID(int Id);

        [OperationContract]
        Seller getSellerByID(int Id);

        [OperationContract]
        List<Product> getProducts();

        [OperationContract]
        bool addProduct(Product product);

        [OperationContract]
        bool editProduct(Product product);

        [OperationContract]
        bool addSeller(Seller seller);

        [OperationContract]
        bool searchSeller(string username, string password);

        [OperationContract]
        bool addToCart(int UserId, int productId,int add);

        [OperationContract]
        bool removeFromCart(int UserId, int productId);
    }
}
