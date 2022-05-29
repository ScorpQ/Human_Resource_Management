using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HumanResourcesProject
{
    class DataBase
    {
        // connection string and sql connection object. 
        static public string Sqlstr = "Data Source=DESKTOP-OF07IF9;Initial Catalog=HRmanagement;Integrated Security=True";

        // SQL classes.
        public SqlConnection sqlCon = new SqlConnection(Sqlstr);
        SqlCommand CMD1;
        SqlDataReader DR1;
        SqlDataAdapter DA1;
        DataTable DT1;     

        // checking login informations from database
        public int login(string ID, string password, string title)
        {
            sqlCon.Open();
            string queary1 = "select * from tbl_USER where PerID = @id and Password = @passw and Title=@t1";
            CMD1 = new SqlCommand(queary1, sqlCon);
            CMD1.Parameters.AddWithValue("@id", ID);
            CMD1.Parameters.AddWithValue("@passw", password);
            CMD1.Parameters.AddWithValue("@t1", title);
            DR1 = CMD1.ExecuteReader();
            
            try
            {
                if (DR1.Read())
                {
                    sqlCon.Close();
                    return 0;
                }
                else
                {
                    sqlCon.Close();
                    return 1;
                }
            }
            catch (Exception)
            {
                sqlCon.Close();
                return 2;
            }    
        }

        // to print data to a specific datagrid using specific table  
        public void list(DataGridView DATAGRID, string query_SHOW)
        {
            sqlCon.Open();
            DA1 = new SqlDataAdapter(query_SHOW, sqlCon);
            DT1 = new DataTable();
            DA1.Fill(DT1);
            DATAGRID.DataSource = DT1;
            sqlCon.Close();
        }

        //*********************************************************************************************************

        // (tbl_CANDIDATE)
        public void InsertTOtbl_CANDIDATE()
        {

        }

        //  if candidate is in "waiting" that makes turn into it "Approved" (tbl_CANDIDATE)
        public void change_Hire_To_waitingforapproval(string candidate_id)
        {
            sqlCon.Open();
            string query = "update tbl_CANDIDATE set Hire=@p1 where ID=@p2";
            CMD1 = new SqlCommand(query,sqlCon);
            CMD1.Parameters.AddWithValue("@p1", "Approved");
            CMD1.Parameters.AddWithValue("@p2", candidate_id);
            CMD1.ExecuteNonQuery();
            sqlCon.Close();
        }

        // To change status of candidate that did not pass the interview to "Eliminated" (tbl_CANDIDATE)
        public void eliminate_the_candidate(string candidate_id)
        {
            sqlCon.Open();
            string query = "update tbl_CANDIDATE set Hire=@p1 where ID = @p2";
            CMD1 = new SqlCommand(query,sqlCon);
            CMD1.Parameters.AddWithValue("@p1","Eliminated");
            CMD1.Parameters.AddWithValue("@p2", candidate_id);
            CMD1.ExecuteNonQuery();
            sqlCon.Close();
        }

        //*********************************************************************************************************

        //  (tbl_WORKER)


        //*********************************************************************************************************

        // (EXCEPT SQL FUNCTIONS
        public string generateID()
        {
            Random R = new Random();
            int First = R.Next(1,999999999);
            int Second = R.Next(1, 999999999);
            return "0";
        }

    }
}



/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * *****************************************
  public void int ParametersCommand(string query,List<SqlParameter> parameters)
{
    SqlConnection connection = new SqlConnection(ConnectionString);
    try
    {
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {   // for cases where no parameters needed
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }

            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return result;
        }
    }
    catch (Exception ex)
    {
        AddEventToEventLogTable("ERROR in DAL.DataBase.ParametersCommand() method: " + ex.Message, 1);
        return 0;
        throw;
    }

    finally
    {
        CloseConnection(ref connection);
    }
}
*/