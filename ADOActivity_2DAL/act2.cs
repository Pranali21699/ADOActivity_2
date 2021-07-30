using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOActivity_2DAL
{
    public class act2
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public void StudentInfoDetails()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * from [myDatabase].[dbo].[StudentInfo]", sqlConObj);
            DataSet Ds = new DataSet();
            da.Fill(Ds);
            DataTable dt = Ds.Tables[0];//dataloaded in table

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"{dr["Name"]} : {dr["CompanyName"]}");
            }
            Console.WriteLine("reading complete");
            Ds = null;
        }

        public int updateName(int inroll, string inname, out int rowaf)
        {
           
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString());
            sqlCmdObj = new SqlCommand("dbo.GetStudent", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@RollNo", inroll);
            sqlCmdObj.Parameters.AddWithValue("@Name", inname);
            try
            {
                sqlConObj.Open();
                SqlParameter pr = sqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                pr.Direction = ParameterDirection.ReturnValue;
                
                int returnValue = (int)pr.Value;
                rowaf = sqlCmdObj.ExecuteNonQuery();
                return returnValue;
            }

            catch (Exception)
            {
                Console.WriteLine("Error occured!");
                rowaf = 0;
                return 0;
            }
            finally
            {
                sqlConObj.Close();
            }
        }

        public int InsertName(int inroll, string inname, string inCompanyName, String inLocation, out int rowaf)
        {
            
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString());
            sqlCmdObj = new SqlCommand("dbo.GetStudent", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@RollNo", inroll);
            sqlCmdObj.Parameters.AddWithValue("@Name", inname);
            sqlCmdObj.Parameters.AddWithValue("@ComapanyName", inCompanyName);
            sqlCmdObj.Parameters.AddWithValue("@Location", inLocation);
            try
            {
                sqlConObj.Open();
                SqlParameter pr = sqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                pr.Direction = ParameterDirection.ReturnValue;
                
                int returnValue = (int)pr.Value;
                rowaf = sqlCmdObj.ExecuteNonQuery(); ;
                return returnValue;
            }

            catch (Exception)
            {
                Console.WriteLine("Error occured!");
                rowaf = 0;
                return 0;
            }
            finally
            {
                sqlConObj.Close();
            }

        }

        public int DeleteName(int inroll, out int rowaf)
        {
            
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString());
            sqlCmdObj = new SqlCommand("dbo.GetStudent", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@RollNo", inroll);

            try
            {
                sqlConObj.Open();
                SqlParameter pr = sqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                pr.Direction = ParameterDirection.ReturnValue;
               
                int returnValue = (int)pr.Value;
                int check = sqlCmdObj.ExecuteNonQuery();

                rowaf = check;
                return returnValue;
            }

            catch (Exception)
            {
                Console.WriteLine("Error occured!");
                rowaf = 0;
                return 0;
            }
            finally
            {
                sqlConObj.Close();
            }

        }

        
        



    }
}
