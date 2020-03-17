using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ADO
{

    public class OperationADO
    {

        public static SqlDataAdapter DataAdapter = new SqlDataAdapter();
        public static string BlockListTable =
                @"CREATE TABLE BlockList
	            (   ID_BlockedUser BIGINT IDENTITY (1,1) NOT NULL,
		            Email VARCHAR(255),
		            BlockedDate DATETIME2 DEFAULT GETDATE(),
		            UnblockedDate DATETIME2 DEFAULT NULL,
		            PRIMARY KEY(ID_BlockedUser)
	            )";
        public static string UserTable = @"CREATE TABLE [User]
	            (   ID BIGINT IDENTITY(1,1) NOT NULL,
		            FirstName VARCHAR(255) NOT NULL,
		            LastName VARCHAR(255)NOT NULL,
		            Email VARCHAR(255) NOT NULL UNIQUE, 
		            PRIMARY KEY (ID)
	            )";


        public static SqlDataAdapter Adapter(SqlConnection sqlConnection)
        {
            //CREATE TABLES INTO DATABASE
            SqlCommand UserBlockListCommand = new SqlCommand(BlockListTable, sqlConnection);
            SqlCommand UserTableComand = new SqlCommand(UserTable, sqlConnection);
            // QUERY TO CREATE TABLES

            //UserTableComand.ExecuteNonQuery();
            //UserBlockListCommand.ExecuteNonQuery();

            //INSERT 

            SqlCommand unitCommand = new SqlCommand(
            @"INSERT INTO [dbo].[User] (FirstName,LastName,Email) VALUES (@FirstName,@LastName, @Email); SET @ID = @@IDENTITY;", sqlConnection);
            unitCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 255, "FirstName");
            unitCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 255, "LastName");
            unitCommand.Parameters.Add("@Email", SqlDbType.VarChar, 255, "Email");
            SqlParameter parameter = unitCommand.Parameters.Add("@ID", SqlDbType.BigInt, 1, "ID");
            DataAdapter.InsertCommand = unitCommand;


            // SELECT
            unitCommand = new SqlCommand("SELECT * FROM [dbo].[User]", sqlConnection);
            DataAdapter.SelectCommand = unitCommand;

            //UPDATE

            unitCommand = new SqlCommand(
                @"UPDATE [dbo].[User] SET FirstName = @FirstName, LastName=@LastName, Email=@Email WHERE ID = @ID", sqlConnection);
            unitCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 255, "FirstName");
            unitCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 255, "LastName");
            unitCommand.Parameters.Add("@Email", SqlDbType.VarChar, 255, "Email");
            parameter = unitCommand.Parameters.Add("@ID", SqlDbType.BigInt, 1, "ID");
            parameter.SourceVersion = DataRowVersion.Original;
            DataAdapter.UpdateCommand = unitCommand;

            //DELETE 
            unitCommand = new SqlCommand(@"DELETE FROM  [dbo].[User] WHERE Email = @Email", sqlConnection);
            unitCommand.Parameters.Add("@Email", SqlDbType.VarChar, 255, "Email");

            // parameter = unitCommand.Parameters.Add("@ID", SqlDbType.BigInt, 1, "ID");
            parameter.SourceVersion = DataRowVersion.Original;
            DataAdapter.DeleteCommand = unitCommand;
            return DataAdapter;
        }
    }


    class Program
    {
        public static string connectionString;
        static Program()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        static void Main(string[] args)
        {
            DataTable UserTable = new DataTable();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter dataAdapter = OperationADO.Adapter(sqlConnection); // adapter
                DataTable users = new DataTable(); // OPERATION FOR USER
                dataAdapter.Fill(users);
                while (true)
                {
                    int i = Convert.ToInt32(Console.ReadLine());
                    switch (i)
                    {
                        
                        case 1:
                            // SELECT
                            foreach(DataRow row in users.Rows)
                            {
                                Console.WriteLine("++++");
                                foreach (DataColumn column in users.Columns)
                                {
                                    Console.WriteLine(row[column]);
                                }
                                Console.WriteLine("++++");
                            }
                            
                            dataAdapter.Update(users); 
                            break;
                        case 2:
                            // INSERT
                            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Daniil\Desktop\Database\6. ADO.NET\ADO\Insert.txt");
                            foreach(var c in lines)
                            {
                                var datas = c.Split(',').ToList();
                                DataRow row = users.NewRow();
                                row["FirstName"] = datas[0];
                                row["LastName"] = datas[1];
                                row["Email"] = datas[2];
                                users.Rows.Add(row);
                            }
                            break;
                        case 3:

                            //UPDATE
                            foreach (DataRow row in users.Rows)
                            {
                                foreach (DataColumn column in users.Columns)
                                {
                                    if (row[column].Equals("lascodaniiil@gmail.com"))
                                    {
                                        // read from file
                                    }
                                }
                                Console.WriteLine("++++");
                            }

                            
                            break;
                        case 4:

                            // DataRow deleted = users.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["ID"]) == 6);
                            //  deletedRow.Delete();
                            //DELETE
                            foreach (DataRow row in users.Rows)
                            {
                                Console.WriteLine("++++");
                                foreach (DataColumn column in users.Columns)
                                {
                                    if (row[column].Equals("ignateugeniu@gmail.com")) // read from file
                                    {
                                        Console.WriteLine(row[column]);
                                        row.Delete();
                                    }
                                }
                                Console.WriteLine("++++");
                            }

                            break;
                    }
                    dataAdapter.Update(users); // BASE OPERATION

                }
                sqlConnection.Close();
            }
            Console.ReadLine();
        }
    }
}






