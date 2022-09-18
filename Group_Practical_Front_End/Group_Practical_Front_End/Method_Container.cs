using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group_Practical_Front_End
{
    public class Method_Container
    {
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

        public static void removeFromCart(int id, ref string session)
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

                    for (int x = 0; x < tokens.Length; x++)
                    {
                        // skip adding product to cart list
                        if (x == index)
                        {
                            continue;
                        }

                        newCart += tokens[x] + " ";
                    }

                    string tocart = newCart.Trim() + " ";

                    session = tocart;
                }
            }
        }
    }
}