using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Group_Practical_Front_End
{
    public class Method_Container
    {
        public static void sendEmail(string message,string subject,string email)
        {
            try
            {
                MailMessage msg = new MailMessage();

                msg.From = new MailAddress("baie.co.za@outlook.com");
                msg.To.Add(email);
                msg.Subject = subject;
                msg.Body = message;

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("baie.co.za@outlook.com", "HTMLites");
                    client.Host = "smtp-mail.outlook.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(msg);
                }
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
            
        }

        public static void addToSessionCart(int id,ref string session, int add)
        {
            string cart = session;
            if (cart != null)
            {
                string[] tokens = cart.Split(' ');

                int index = -1;

                for (int x = 0; x < tokens.Length; x++)
                {
                    if (tokens[x].StartsWith(id + "("))
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
                        removeFromCart(id,ref session);
                        return;
                    }

                    tokens[index] = id + "(" + number + ")";

                    foreach (string token in tokens)
                    {
                        newCart += token + " ";
                    }
                    string tocart = newCart.Trim() + " ";

                    session = tocart;
                }
                else
                {
                    session += id + "(1) ";
                }
            }
            else
            {
                session = Convert.ToString(id + "(1) ");
            }
        }

        public static void removeFromWishList(int productId, ref string session)
        {
            if (session != null)
            {
                string[] items = session.Split(' ');

                int size = items.Length - 1;

                List<string> list = new List<string>();

                list = items.ToList();
                list.Remove("");

                list.Remove(productId.ToString());

                if (list.Count <= 0)
                {
                    session = null;
                    return;
                }

                string newWishList = "";

                foreach (string item in list)
                {
                    newWishList += item + " ";
                }

                session = newWishList;
                return;
            }
            else
            {
                return;
            }
        }

        public static void addToWishList(int productId,ref string session)
        {
            if (session != null)
            {
                string[] items = session.Split(' ');
                int size = items.Length - 1;

                List<string> list = new List<string>();

                if (!items.Contains(productId.ToString()))
                {
                    list = items.ToList();
                    list.Remove("");
                    list.Add(productId.ToString());

                    string newWishList = "";

                    foreach (string item in list)
                    {
                        newWishList += item + " ";
                    }

                    session = newWishList;
                    return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                session = productId + " ";
                return;
            }
        }

        public static void removeFromCart(int id, ref string session)
        {
            string cart = session;
            if (cart != null || !cart.Equals(""))
            {
                string[] tokens = cart.Split(' ');

                int index = -1;

                for (int x = 0; x < tokens.Length - 1; x++)
                {
                    if (tokens[x].StartsWith(id + "("))
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
                    
                    if(newCart.Length < 3)
                    {
                        newCart = null;
                    }

                    session = newCart;
                }   
            }
        }
    }
}