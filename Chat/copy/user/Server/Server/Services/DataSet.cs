using Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Services
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnNameAttribute : Attribute
    {
        public string Name { get; }
        public ColumnNameAttribute(string name) => Name = name;
    }

    public class DataSet<T> : Entity where T : class
    {
        private readonly SqlQueryBuilder sqlQuery;
        private readonly SqlConnection conn;
        private readonly SqlCommand cmd;
        private readonly string table;

        public DataSet()
        {
            table = typeof(T).Name;
            sqlQuery = new SqlQueryBuilder(table);
            conn = DatabaseConnection.GetConnection();
            cmd = new SqlCommand { Connection = conn };
        }

        public int Insert(T o,bool newId=false)
        {
            Entity entity = o as Entity;
            var data = entity.json;
            return newId? ExecuteScalar(sqlQuery.BuildInsertQuery(data) + "; SELECT SCOPE_IDENTITY();", data):  ExecuteNonQuery(sqlQuery.BuildInsertQuery(data), data);
        }

        public int Update(T o)
        {
            Entity entity = o as Entity;
            var data = entity.json;
            string primaryKeyColumn = data.ContainsKey("id") ? "id" : "phone";
            return ExecuteNonQuery(sqlQuery.BuildUpdateQuery(data, primaryKeyColumn), data);
        }

        public int Delete(T o)
        {
            Entity entity = o as Entity;
            var data = entity.json;
            string primaryKeyColumn = data.ContainsKey("id") ? "id" : "phone";
            return ExecuteNonQuery(sqlQuery.BuildDeleteQuery(primaryKeyColumn), new Dictionary<string, object> { { primaryKeyColumn, data[primaryKeyColumn] } });
        }

        public DataTable SelectAsDataTable(IEnumerable<string> columns = null, List<Tuple<string, object, string>> whereConditions = null)
        {
            var dt = new DataTable();
            try
            {
                dt.Load(ExecuteReader(sqlQuery.BuildSelectQuery(columns, whereConditions), whereConditions));
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
            return dt;
        }

        public IEnumerable<T> Select(IEnumerable<string> columns = null, List<Tuple<string, object, string>> whereConditions = null)
        {
            var entities = new List<T>();

            try
            {

                using (var reader = ExecuteReader(sqlQuery.BuildSelectQuery(columns, whereConditions), whereConditions))
                {
                    if (reader == null) return entities;
                    entities = MapEntities(reader).ToList();
                }
             
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
             Close();
            }
            return entities;
        }
        public T SelectOne(IEnumerable<string> columns = null, List<Tuple<string, object, string>> whereConditions = null)
        {
            string query = sqlQuery.BuildSelectQuery(columns, whereConditions);
          
            using (var reader = ExecuteReader(query, whereConditions))
            {
                try
                {
                    bool notNull = reader != null && reader.Read();
                   

                    return notNull ? MapEntity(reader) : null;
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"ex:=>{ex.Message}");
                    return null;
                }
                finally
                {
                    Close();
                }
            }
        }

        private int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            int result = -1;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            AddParameters(parameters);

            try
            {
                Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               Close();
            }

            return result;
        }
        private int ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            int result = -1;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            AddParameters(parameters);

            try
            {
                Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }

            return result;
        }

        private SqlDataReader ExecuteReader(string query, List<Tuple<string, object, string>> whereConditions)
        {
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            AddParameters(whereConditions);
          
            try
            {
                Open();
              
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
        }
        void Open()
        {
            if(conn.State!= ConnectionState.Open)
            {
                conn.Open();
            }
        }
        void Close()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        private void AddParameters(Dictionary<string, object> parameters)
        {
            if (parameters != null)
            {
                foreach (var kvp in parameters)
                {
                    cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value ?? DBNull.Value);
                }
            }
        }

        private void AddParameters(List<Tuple<string, object, string>> whereConditions)
        {
            if (whereConditions != null)
            {
                foreach (var condition in whereConditions)
                {
                    cmd.Parameters.AddWithValue($"@{condition.Item1}", condition.Item2 ?? DBNull.Value);
                }
            }
        }

        private IEnumerable<T> MapEntities(DbDataReader reader)
        {
            var entities = new List<T>();
            var properties = typeof(T).GetProperties();
            var columnNames = Enumerable.Range(0, reader.FieldCount)
                                        .Select(reader.GetName)
                                        .ToHashSet(StringComparer.OrdinalIgnoreCase);

            while (reader.Read())
            {
                var entity = Activator.CreateInstance<T>();

                foreach (var prop in properties)
                {
                    var columnName = sqlQuery.GetColumnName(prop);
                    if (!columnNames.Contains(columnName)) continue;

                    var value = reader[columnName];
                    if (value == DBNull.Value) value = null;

                    if (value != null)
                    {
                        var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        value = Convert.ChangeType(value, targetType);
                    }

                    prop.SetValue(entity, value);
                }

                entities.Add(entity);
            }

            return entities;
        }
        private T MapEntity(DbDataReader reader)
        {
            var entity = Activator.CreateInstance<T>();
            var properties = typeof(T).GetProperties();
            var columnNames = Enumerable.Range(0, reader.FieldCount)
                                        .Select(reader.GetName)
                                        .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (var prop in properties)
            {
                var columnName = sqlQuery.GetColumnName(prop);
                if (!columnNames.Contains(columnName)) continue;

                var value = reader[columnName];
                if (value == DBNull.Value) value = null;

                try
                {
                    if (value != null)
                    {
                        var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        value = Convert.ChangeType(value, targetType);
                    }
                    prop.SetValue(entity, value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ خطأ في تعيين قيمة الحقل '{columnName}' للخاصية '{prop.Name}': {ex.Message}");
                }
            }

            return entity;
        }
        public List<Dictionary<string, object>> Procedure(string procedureName, Dictionary<string, object> parameters)
        {
            var result = new List<Dictionary<string, object>>();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            cmd.Parameters.Clear();
            AddParameters(parameters);

            try
            {

                Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                    }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing stored procedure: {ex.Message}");
                return null;
            }
            finally
            {
                Close();
            }
        
            return result;
        }
    }
}
