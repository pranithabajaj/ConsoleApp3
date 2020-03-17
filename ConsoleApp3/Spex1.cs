using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp3
{
    class Spex1
    {
        static void Main(string[] args)
        {
            int i = int.Parse(Console.ReadLine());
            int j = int.Parse(Console.ReadLine());
            SqlConnection Con = new SqlConnection("Password=Admin@123;Persist Security Info=True;User ID=sa;Initial Catalog=Test;Data Source=DESKTOP-583QKG1");
            SqlDataAdapter Adp = new SqlDataAdapter("Example1",Con);

            //to inform clr that we passed a stored procedure not a query
            Adp.SelectCommand.CommandType = CommandType.StoredProcedure;

            //passing input parameters of stored procedures,the names of the parameters shld be same
            Adp.SelectCommand.Parameters.AddWithValue("@a",i);
            Adp.SelectCommand.Parameters.AddWithValue("@b", j);

            //passing output parameters of stored procedures
            SqlParameter P = new SqlParameter("@c",SqlDbType.Int);
            P.Direction = ParameterDirection.Output;
            Adp.SelectCommand.Parameters.Add(P);

            SqlParameter P1 = new SqlParameter("@d", SqlDbType.Int);
            P1.Direction = ParameterDirection.Output;
            Adp.SelectCommand.Parameters.Add(P1);

            DataSet DS = new DataSet();
            Adp.Fill(DS);

            Console.WriteLine(P.Value);
            Console.WriteLine(P1.Value);
            Console.Read();
        }
    }
}
