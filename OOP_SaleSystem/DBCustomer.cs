using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace OOP_SaleSystem
{
    class DBCustomer
    {

        SQLConnect db;
        public DBCustomer()
        { db = new SQLConnect(); }

        public void GetAllCustomer()
        {
            foreach (DataRow row in db.ExecuteQueryDataSet("Select * from Customer", CommandType.Text, null).Tables[0].Rows) 
            {
                Console.WriteLine(row["customer_id"] + ",  " + row["customer_name"]) ;
            }
            Console.WriteLine();
        }

        public void GetAllOrderByCustomerID(int customerID)
        {
            foreach (DataRow row in db.ExecuteQueryDataSet("Select * from Orders where customer_id=" + customerID, CommandType.Text, null).Tables[0].Rows)
            {
                Console.WriteLine(row["order_id"] + ",  " + row["order_date"] + ",  " + row["customer_id"] + ",  " + row["employee_id"] + ",  " + row["total"]);
            }
            Console.WriteLine();
        }

    }
}
