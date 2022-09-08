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
    }
}
