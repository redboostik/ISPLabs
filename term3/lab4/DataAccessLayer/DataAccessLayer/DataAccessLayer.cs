using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Transactions;
using OptionsManager;
using Models;
using System.Reflection;

namespace DataAccessLayer
{
    public class DataAccessLayer
    {
        SqlConnection connection;
        public void Log(DateTime date, string message)
        {
            SqlCommand command = new SqlCommand("Log", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("date", date));
            command.Parameters.Add(new SqlParameter("message", message));

            using (TransactionScope scope = new TransactionScope())
            {
                command.ExecuteNonQuery();
                scope.Complete();
            }
        }

        public DataAccessLayer(JsonReader options)
        {
            string connectionString = $"Data Source={options.GetElement<string>("DataSource")}; Database={options.GetElement<string>("Database")}; User={options.GetElement<string>("User")}; Password={options.GetElement<string>("Password")}; Integrated Security={options.GetElement<string>("IntegratedSecurity")}";
            using (var scope = new TransactionScope())
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                scope.Complete();
            }
        }
        public DataAccessLayer(XmlReader options)
        {
            string connectionString = $"Data Source={options.GetElement("DataSource")}; Database={options.GetElement("Database")}; User={options.GetElement("User")}; Password={options.GetElement("Password")}; Integrated Security={options.GetElement("IntegratedSecurity")}";
            using (var scope = new TransactionScope())
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                scope.Complete();
            }
        }

        public List<T> ConvertReader<T>(SqlDataReader reader)
        {
            var res = new List<T>();
            var i = 0;
            while (reader.Read())
            {
                T ans = (T)Activator.CreateInstance(typeof(T));
                for (var j = 0; j < reader.FieldCount; j++) SetValue(ans, reader.GetName(j), reader.GetValue(j));
                res.Add(ans);
            }
            return res;
        }
        static void SetValue(object obj, string name, object value)
        {
            Type type = obj.GetType();
            if (type.GetProperty(name) != null)
            {
                PropertyInfo info = type.GetProperty(name);
                info.SetValue(obj, value);
            }
            else if (type.GetField(name) != null)
            {
                FieldInfo info = type.GetField(name);
                info.SetValue(obj, value);
            }
            else
            {
                throw new Exception("This type doesn't contain member with this name");
            }

        }

        public Address GetAddress(int id)
        {
            SqlCommand command = new SqlCommand("GetAddress", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("id", id));
            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<Address>(command.ExecuteReader());
                scope.Complete();
                if (ans.Count == 0)
                {
                    return new Address();
                }
                else
                {
                    return ans.First();
                }
            }
        }
        public List<Address> GetAddresses()
        {
            SqlCommand command = new SqlCommand("GetAddresses", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<Address>(command.ExecuteReader());
                scope.Complete();
                return ans;
            }
        }
        public List<Address> GetAddressesRange(int startIndex, int count)
        {
            SqlCommand command = new SqlCommand("GetAddressesRange", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("startIndex", startIndex));
            command.Parameters.Add(new SqlParameter("count", count));

            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<Address>(command.ExecuteReader());
                scope.Complete();
                return ans;
            }
        }
        

        public AddressType GetAddressType(int id)
        {
            SqlCommand command = new SqlCommand("GetAddressType", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("id", id));
            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<AddressType>(command.ExecuteReader());
                scope.Complete();
                if (ans.Count == 0)
                {
                    return new AddressType();
                }
                else
                {
                    return ans.First();
                }
            }
        }
        public List<AddressType> GetAddressTypes()
        {
            SqlCommand command = new SqlCommand("GetAddressTypes", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<AddressType>(command.ExecuteReader());
                scope.Complete();
                return ans;
            }
        }
        public List<AddressType> GetAddressTypesRange(int startIndex, int count)
        {
            SqlCommand command = new SqlCommand("GetAddressTypesRange", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("startIndex", startIndex));
            command.Parameters.Add(new SqlParameter("count", count));

            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<AddressType>(command.ExecuteReader());
                scope.Complete();
                return ans;
            }
        }
        public BusinessEntity GetBusinessEntity(int id)
        {
            SqlCommand command = new SqlCommand("GetBusinessEntity", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("id", id));
            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<BusinessEntity>(command.ExecuteReader());
                scope.Complete();
                if (ans.Count == 0)
                {
                    return new BusinessEntity();
                }
                else
                {
                    return ans.First();
                }
            }
        }
        public List<BusinessEntity> GetBusinessesEntities()
        {
            SqlCommand command = new SqlCommand("GetBusinessesEntities", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<BusinessEntity>(command.ExecuteReader());
                scope.Complete();
                return ans;
            }
        }
        public List<BusinessEntity> GetBusinessEntitiesRange(int startIndex, int count)
        {
            SqlCommand command = new SqlCommand("GetBusinessEntitiesRange", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("startIndex", startIndex));
            command.Parameters.Add(new SqlParameter("count", count));

            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<BusinessEntity>(command.ExecuteReader());
                scope.Complete();
                return ans;
            }
        }

        public BusinessEntityAddress GetBusinessEntityAddress(int id)
        {
            SqlCommand command = new SqlCommand("GetBusinessEntityAddress", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("id", id));
            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<BusinessEntityAddress>(command.ExecuteReader());
                scope.Complete();
                if (ans.Count == 0)
                {
                    return new BusinessEntityAddress();
                }
                else
                {
                    return ans.First();
                }
            }
        }
        public List<BusinessEntityAddress> GetBusinessEntityAddresses()
        {
            SqlCommand command = new SqlCommand("GetBusinessEntityAddresses", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<BusinessEntityAddress>(command.ExecuteReader());
                scope.Complete();
                return ans;
            }
        }
        public List<BusinessEntityAddress> GetBusinessesEntitiesRange(int startIndex, int count)
        {
            SqlCommand command = new SqlCommand("GetBusinessesEntitiesRange", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("startIndex", startIndex));
            command.Parameters.Add(new SqlParameter("count", count));

            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<BusinessEntityAddress>(command.ExecuteReader());
                scope.Complete();
                return ans;
            }
        }
        public BusinessEntityContact GetBusinessEntityContact(int id)
        {
            SqlCommand command = new SqlCommand("GetBusinessEntityContact", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("id", id));
            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<BusinessEntityContact>(command.ExecuteReader());
                scope.Complete();
                if (ans.Count == 0)
                {
                    return new BusinessEntityContact();
                }
                else
                {
                    return ans.First();
                }
            }
        }
        public List<BusinessEntityContact> GetBusinessEntityContacts()
        {
            SqlCommand command = new SqlCommand("GetBusinessEntityContacts", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<BusinessEntityContact>(command.ExecuteReader());
                scope.Complete();
                return ans;
            }
        }
        public List<BusinessEntityContact> GetBusinessesEntityContactsRange(int startIndex, int count)
        {
            SqlCommand command = new SqlCommand("GetBusinessesEntityContactsRange", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("startIndex", startIndex));
            command.Parameters.Add(new SqlParameter("count", count));

            using (TransactionScope scope = new TransactionScope())
            {
                var ans = ConvertReader<BusinessEntityContact>(command.ExecuteReader());
                scope.Complete();
                return ans;
            }
        }
    }
}
