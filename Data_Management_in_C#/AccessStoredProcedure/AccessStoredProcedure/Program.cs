using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccessStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Data Source=ABHIJEET-PC\\SQLEXPRESS;Initial Catalog=Testing;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand command = conn.CreateCommand();
            //command.CommandText = "EXECUTE spLastName @FirstCharacter,@FirstCharJob";
            command.CommandText = "EXECUTE spAddMember @Name,@LastName,@JobDetail";
            command.Parameters.Add("@Name", SqlDbType.NVarChar,20).Value="Aditya";
            command.Parameters.Add("@LastName", SqlDbType.NVarChar,30).Value="Mohanthy";
            command.Parameters.Add("@JobDetail", SqlDbType.NVarChar, 40).Value = "Site Engineer";
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
