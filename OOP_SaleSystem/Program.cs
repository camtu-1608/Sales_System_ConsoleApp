using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Tutorial.SqlConn;
using System.Data.SqlClient;

namespace OOP_SaleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var create = new DBCustomer();
            create.GetAllCustomer();

            Console.WriteLine("Enter Customer ID:");
            int cusID = Convert.ToInt32(Console.ReadLine());
            create.GetAllOrderByCustomerID(cusID);
        }
    }
}
