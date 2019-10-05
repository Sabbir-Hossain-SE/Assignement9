using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CustomerInfo.Model;

namespace CustomerInfo.Repository
{
    class CustomerRepositpry
    {
        public bool Save(Customer customer)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CustomerInfo; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO Customers (CustomerCode, Name, Address, Contact, DistrictId) Values ('" + customer.Code + "', '" + customer.Name + "', '" + customer.Address + "', '" + customer.Phone + "', " + customer.DistrictId + ")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
                throw new Exception(exeption.Message);
            }

            return isAdded;

        }

        public bool IsCodeExist(Customer customer)
        {
            bool isExist = false;
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CustomerInfo; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Customers WHERE CustomerCode='" + customer.Code + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return isExist;
        }
        public bool IsPhoneExist(Customer customer)
        {
            bool isExist = false;
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CustomerInfo; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Customers WHERE Contact='" + customer.Phone + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return isExist;
        }


        public DataTable Display()
        {

            //Connection
            string connectionString = @"Server=SABBIR; Database=CustomerInfo; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT c.Id,c.CustomerCode, c.Name ,c.Address, c.Contact, d.Name AS District FROM Customers AS c
LEFT JOIN District AS d ON c.DistrictId = d.Id  ";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            sqlConnection.Close();

            return dataTable;

        }

        public DataTable DistrictCombo()
        {

            //Connection
            string connectionString = @"Server=SABBIR; Database=CustomerInfo; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)

            string commandString = @"SELECT Id, Name FROM District";



            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //if (dataTable.Rows.Count > 0)
            //{
            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    //MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();

            return dataTable;

        }

        public DataTable Search(string value, int key)
        {
            DataTable dataTable = new DataTable();
            try
            {
                //Connection
                string connectionString = @"Server=SABBIR; Database=CustomerInfo; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString="";
                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                if (key == 1)
                {
                     commandString = @"SELECT * FROM Customers WHERE CustomerCode='" + value + "'";
                }
                else if (key == 2)
                {
                     commandString = @"SELECT * FROM Customers WHERE Contact='" + value + "'";
                }

                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                //if (dataTable.Rows.Count > 0)
                //{
                //    //showDataGridView.DataSource = dataTable;
                //}
                //else
                //{
                //    //MessageBox.Show("No Data Found");
                //}

                ////Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                // MessageBox.Show(exeption.Message);
            }

            return dataTable;
        }

        //public bool Update(string name, double price, int id)
        //{
        //    try
        //    {
        //        //Connection
        //        string connectionString = @"Server=SABBIR; Database=CustomerInfo; Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(connectionString);

        //        //Command 
        //        //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
        //        string commandString = @"UPDATE Customer SET Name =  '" + name + "' , Price = " + price + " WHERE ID = " + id + "";
        //        SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

        //        //Open
        //        sqlConnection.Open();

        //        //Insert
        //        int isExecuted = sqlCommand.ExecuteNonQuery();
        //        if (isExecuted > 0)
        //        {
        //            return true;
        //        }
        //        //Close
        //        sqlConnection.Close();


        //    }
        //    catch (Exception exeption)
        //    {
        //        //MessageBox.Show(exeption.Message);
        //    }
        //    return false;
        //}





    }
}
