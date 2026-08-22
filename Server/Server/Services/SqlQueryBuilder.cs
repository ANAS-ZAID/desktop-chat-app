using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    internal class SqlQueryBuilder
    {


        string table;
        public SqlQueryBuilder(string table)
        {
            this.table = table;
        }



        public string BuildInsertQuery(Dictionary<string, object> data)
        {
            if (data == null || data.Count == 0)
                throw new ArgumentException("لا يمكن إنشاء استعلام إدخال بدون بيانات.");

            var (fields, values) = GetColumnWithData(data);

            string sql = $"INSERT INTO {table} ({fields}) VALUES ({values})";

            return sql;
        }

        public string BuildUpdateQuery(Dictionary<string, object> data, string primaryKeyColumn)
        {
            if (data == null || data.Count == 0)
                throw new ArgumentException("لا يمكن إنشاء استعلام تحديث بدون بيانات.");

            var setClauses = data.Where(Kvp => Kvp.Key != primaryKeyColumn).Select(kvp => $"{kvp.Key} = @{kvp.Key}").ToList();

            string sql = $"UPDATE {table} SET {string.Join(", ", setClauses)} WHERE {primaryKeyColumn} = @{primaryKeyColumn}";

            return sql;
        }

        public string BuildDeleteQuery(string primaryKeyColumn)
        {
            if (string.IsNullOrEmpty(primaryKeyColumn))
                throw new ArgumentException("يجب تحديد العمود الأساسي للحذف.");

            string sql = $"DELETE FROM {table} WHERE {primaryKeyColumn} = @{primaryKeyColumn}";

            return sql;
        }

        public string BuildSelectQuery(IEnumerable<string> columns = null, List<Tuple<string, object, string>> whereConditions = null)
        {
            string columnsClause = columns == null || !columns.Any() ? "*" : string.Join(", ", columns);
            string sql = $"SELECT {columnsClause} FROM {table}";

            if (whereConditions != null && whereConditions.Count > 0)
            {
                var whereClauses = whereConditions.Select(kvp => $"{kvp.Item1} = @{kvp.Item1} {kvp.Item3}");
                sql += $" WHERE {string.Join(" ", whereClauses).TrimEnd("AND ".ToCharArray()).TrimEnd("OR ".ToCharArray())}";
            }

            return sql;
        }

        private (string fields, string values) GetColumnWithData(Dictionary<string, object> data)
        {
            var fields = string.Join(", ", data.Keys);
            var values = string.Join(", ", data.Keys.Select(k => $"@{k}")); // استخدم @ لتجنب SQL Injection

            return (fields, values);
        }
        public string GetColumnName(PropertyInfo prop)
        {
            var attribute = prop.GetCustomAttribute<ColumnNameAttribute>();

            return attribute?.Name ?? prop.Name; // استخدم الاسم الافتراضي إذا لم يكن هناك Attribute
        }


    }
}
