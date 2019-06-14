using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BinarySoftCo.DatabaseAccess.SQL
{
    public sealed class DBSQL
    {
        #region Variables
        //
        SqlConnection SqlConnect;
        SqlCommand SqlCom;
        //
        int TimeOut = 10;
        string serverName, databaseName, username, password;

        public string ServerName
        {
            get { return serverName; }
        }
        public string DatabaseName
        {
            get { return databaseName; }
        }
        public string Username
        {
            get { return username; }
        }
        public string Password
        {
            get { return password; }
        }
        //
        public bool Connected
        {
            get
            {
                try
                {
                    return (SqlConnect.State == ConnectionState.Open);
                }
                catch
                {
                    return false;
                }
            }
        }
        //
        #endregion
        //
        #region Constructor

        public DBSQL()
        {
            SqlConnect = new SqlConnection();
        }

        public DBSQL(string Connection)
            : this()
        {
            try
            {
                SqlConnect.ConnectionString = Connection;
                if (SqlConnect.State == ConnectionState.Closed)
                    SqlConnect.Open();
            }
            catch
            {
            }
        }

        public DBSQL(string ServerName, string DatabaseName)
            : this()
        {
            try
            {
                serverName = ServerName;
                databaseName = DatabaseName;
                //
                SqlConnect.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True;TimeOut=" + TimeOut.ToString();
                if (SqlConnect.State == ConnectionState.Closed)
                    SqlConnect.Open();
            }
            catch
            {
            }
        }

        public DBSQL(string ServerName, string Username, string Password)
            : this()
        {
            try
            {
                serverName = ServerName;
                username = Username;
                password = Password;
                //
                SqlConnect.ConnectionString = "Data Source=" + ServerName + ";User ID=" + Username + ";Password=" + Password + ";TimeOut=" + TimeOut.ToString();
                if (SqlConnect.State == ConnectionState.Closed)
                    SqlConnect.Open();
            }
            catch
            {
            }
        }

        public DBSQL(string ServerName, string DatabaseName, string Username, string Password)
            : this()
        {
            try
            {
                serverName = ServerName;
                databaseName = DatabaseName;
                username = Username;
                password = Password;
                //
                SqlConnect.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";User ID=" + Username + ";Password=" + Password;
                if (SqlConnect.State == ConnectionState.Closed)
                    SqlConnect.Open();
            }
#if(DEBUG)
            catch (Exception er)
            {
                MessageBox.Show(er.Message + Environment.NewLine + "in : Connecting to server");
            }
#else
                catch
                {
                    
                }
#endif
        }
        //
        #endregion
        //
        #region Disconnector

        public void Disconnect()
        {
            try
            {
                SqlCom.Cancel();
                SqlCom.Dispose();
                SqlConnect.Close();
                SqlConnect.Dispose();
            }
            catch
            {
            }
        }
        //
        #endregion
        //
        #region Executer

        public Exception ExecuteCommand(string Command)
        {
            try
            {
                if (!Connected)
                    SqlConnect.Open();
                //
                SqlCom = new SqlCommand(Command, SqlConnect);
                SqlCom.ExecuteNonQuery();
                //
                return null;
            }
#if(DEBUG)
            catch (SqlException er)
            {
                MessageBox.Show("متاسفانه ادامه این عملیات امکان پذیر نیست\n\nاحتمالا بعلت استفاده از این رکوردها در قسمتهای دیگر نرم افزار این اشکال رخ داده است", "توقف عملیات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return er;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + Environment.NewLine + "in :" + Environment.NewLine + Command);
                return er;
            }
#else
                catch (Exception er)
                {
                    return er;
                }
#endif
        }

        public DataTable ExecuteCommandReturn(string Command)
        {
            try
            {
                if (!Connected)
                    SqlConnect.Open();
                //
                SqlCom = new SqlCommand(Command, SqlConnect);
                //
                //description for this commention is in ExuteStoredProcReturn in bellow
                //SqlCom.ExecuteNonQuery();
                //
                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCom);
                //
                DataTable dt = new DataTable();
                SqlData.Fill(dt);
                //
                return dt;
            }
#if(DEBUG)
            catch (Exception er)
            {
                MessageBox.Show(er.Message + Environment.NewLine + "in :" + Environment.NewLine + Command);
            }
#else
                catch
                {
                    
                }
#endif
            return null;
        } 

        public Exception ExecuteStoredProc(string StoredProcName)
        {
            return ExecuteStoredProc(StoredProcName, new List<SqlParameter>());
        }

        public Exception ExecuteStoredProc(string StoredProcName, SqlParameter Parameter)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(Parameter);
            //
            return ExecuteStoredProc(StoredProcName, param);
        }

        public Exception ExecuteStoredProc(string StoredProcName, List<SqlParameter> Parameters)
        {
            try
            {
                if (!Connected)
                    SqlConnect.Open();
                //
                SqlCom = new SqlCommand(StoredProcName, SqlConnect);
                SqlCom.CommandType = CommandType.StoredProcedure;
                //
                foreach (SqlParameter sqlp in Parameters)
                    SqlCom.Parameters.AddWithValue(sqlp.ParameterName, sqlp.Value);
                //
                SqlCom.ExecuteNonQuery();
                //
                return null;
            }
#if(DEBUG)
            catch (SqlException er)
            {
                MessageBox.Show("متاسفانه ادامه این عملیات امکان پذیر نیست\n\nاحتمالا بعلت استفاده از این رکوردها در قسمتهای دیگر نرم افزار این اشکال رخ داده است", "توقف عملیات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return er;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + Environment.NewLine + "in StoredProc :" + Environment.NewLine + StoredProcName);
                return er;
            }
#else
                catch (Exception er)
                {
                    return er;
                }
#endif
        }

        public DataTable ExecuteStoredProcReturn(string StoredProcName)
        {
            return ExecuteStoredProcReturn(StoredProcName, new List<SqlParameter>());
        }

        public DataTable ExecuteStoredProcReturn(string StoredProcName, SqlParameter Parameter)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(Parameter);
            //
            return ExecuteStoredProcReturn(StoredProcName, param);
        }

        public DataTable ExecuteStoredProcReturn(string StoredProcName, List<SqlParameter> Parameters)
        {
            try
            {
                if (!Connected)
                    SqlConnect.Open();
                //
                SqlCom = new SqlCommand(StoredProcName, SqlConnect);
                SqlCom.CommandType = CommandType.StoredProcedure;
                //
                foreach (SqlParameter sqlp in Parameters)
                    SqlCom.Parameters.AddWithValue(sqlp.ParameterName, sqlp.Value);
                //
                //if uncomment bellow line of code occurres a problem :
                //in first execute in this line
                //and after it execute again in SqlDataAdapter's constructor (bellow)
                //so execute towice!!!
                //SqlCom.ExecuteNonQuery();
                //
                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCom);
                //
                DataTable dt = new DataTable();
                SqlData.Fill(dt);
                //
                return dt;
            }
#if(DEBUG)
            catch (Exception er)
            {
                MessageBox.Show(er.Message + Environment.NewLine + "in StoredProc :" + Environment.NewLine + StoredProcName);
            }
#else
                catch
                {
                    
                }
#endif
            return null;
        }
        //
        #endregion
    }
}