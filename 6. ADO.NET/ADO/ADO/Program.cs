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


        public static DataTable UserDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID",typeof(int)).AutoIncrement=true;
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.PrimaryKey = new DataColumn[] {dataTable.Columns["ID"]};
            
            return dataTable;
        }


        public static void CreateTablesIntoDatabase(SqlConnection sqlConnection)
        {
            SqlCommand UserBlockListCommand = new SqlCommand(BlockListTable, sqlConnection);
            SqlCommand UserTableComand = new SqlCommand(UserTable, sqlConnection);
            try
            {
                UserTableComand.ExecuteNonQuery();
                UserBlockListCommand.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine("Tables exists in database");
            }
        }

        public static SqlDataAdapter Adapter(SqlConnection sqlConnection)
        {
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
             parameter.SourceVersion = DataRowVersion.Original;
            DataAdapter.DeleteCommand = unitCommand;
            return DataAdapter;
        }
    }


    class Program
    {
        public static string connectionString=null;
        public static string ReadUsers = @"C:\Users\Daniil\Desktop\Database\6. ADO.NET\ADO\Insert.txt";
        public static string UpdateUsers = @"C:\Users\Daniil\Desktop\Database\6. ADO.NET\ADO\Update.txt";
        public static string DeleteUser = @"C:\Users\Daniil\Desktop\Database\6. ADO.NET\ADO\Update.txt";
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
                OperationADO.CreateTablesIntoDatabase(sqlConnection); // create 2 tables
                SqlDataAdapter dataAdapter = OperationADO.Adapter(sqlConnection); // adapter
                DataTable users = OperationADO.UserDataTable(); // CREATE DATATABLE FOR USER


                DataSet dataSet = new DataSet("DefaultConnection");
                dataSet.Tables.Add(users);
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
                            string[] lines = System.IO.File.ReadAllLines(ReadUsers);
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
                            string []line = System.IO.File.ReadAllLines(UpdateUsers);
                            var UserData = line[0].Split(',');
                            var insertData = line[1].Split(',');

                            foreach (DataRow row in users.Rows)
                            {
                                foreach (DataColumn column in users.Columns)
                                {
                                    if (row[column].Equals(UserData[2]))
                                    {
                                        row["FirstName"] = insertData[0];
                                        row["LastName"] = insertData[1];
                                        row["Email"] = insertData[2];
                                        Console.WriteLine("UPDATE OPERATION IS SUCCESFUL");

                                    }
                                }
                            }
                            break;
                        case 4:

                            string[] deleteuser = System.IO.File.ReadAllLines(DeleteUser);
                            var UsertToDelete = deleteuser[0].Split(',');
                            // DELETE
                            foreach (DataRow row in users.Rows)
                            {
                                if(row["Email"].ToString() == UsertToDelete[2])
                                {
                                    row.Delete();
                                    Console.WriteLine("DELETED COMMAND EXECUTED");
                                }
                            }
                            break;
                    }
                    dataAdapter.Update(users); // BASE OPERATION
                }
                
            }
            Console.ReadLine();
        }
    }
}






