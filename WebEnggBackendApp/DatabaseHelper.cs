using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebEnggBackendApp
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        }

        public DataTable GetData(string query, Dictionary<string, object> parameters = null)
        {
            SqlConnection connection = null;
            SqlDataReader reader = null;
            DataTable dt = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = query;

                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        KeyValuePair<string, object> parameter = parameters.ElementAt(i);
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }

                reader = command.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                // TODO: log error
            }
            finally
            {
                reader.Close();
                connection.Close();
            }

            return dt;
        }

        public string Insert(string query, Dictionary<string, object> parameters = null)
        {
            SqlConnection connection = null;
            string insertedID = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = query;

                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        KeyValuePair<string, object> parameter = parameters.ElementAt(i);
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }

                insertedID = command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                // TODO: log error
            }
            finally
            {
                connection.Close();
            }

            return insertedID;
        }

        public int UpdateOrDelete(string query, Dictionary<string, object> parameters = null)
        {
            SqlConnection connection = null;
            int affectedRowsCount = -1;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = query;

                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        KeyValuePair<string, object> parameter = parameters.ElementAt(i);
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }

                affectedRowsCount = command.ExecuteNonQuery();

                
            } catch (Exception ex)
            {
                // TODO: log error
            }
            finally
            {
                connection.Close();
            }

            return affectedRowsCount;
        }
    }
}