using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Data.SqlClient;
using System;

namespace LagerStatusEksamen.Services
{
    public class ServicePackageType : IServicePackageType
    {
        #region Instances
        private string selectByNameSql = "SELECT * FROM PackageTypes WHERE Name = @Name";
        private string selectSql = "SELECT * FROM PackageTypes";
        private string insertSql = "INSERT INTO PackageTypes(Name, Description) Values(@Name, @Description)";
        private string deleteSql = "DELETE FROM PackageTypes WHERE Name = @Name";
        private string updatePackageSql = "UPDATE PackageTypes SET Description  = @Description  WHERE Name = @Name";
        private string _con;
        #endregion

        #region Constructor
        public ServicePackageType() { _con = Secret.ConnectionString; }
        public ServicePackageType(string con) { _con = con; }
        #endregion

        #region Methods
        public PackageType Add(string name, PackageType packagetype)
        {
            if (packagetype == null)
            {
                throw new ArgumentNullException(nameof(packagetype));
            }
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);
                command.Parameters.AddWithValue("@Name", packagetype.Name);
                command.Parameters.AddWithValue("@Description", packagetype.Description);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return packagetype;
        }
        public List<PackageType> GetAll()
        {
            List<PackageType> list = new List<PackageType>();
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                SqlCommand command = new SqlCommand(selectSql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new PackageType(
                        reader["Name"].ToString(),
                        reader["Description"].ToString()
                    ));
                }
            }
            return list;
        }
        public PackageType? Delete(string name)
        {
            PackageType packagetype = GetByName(name);
            if (packagetype == null) { return null; }
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                SqlCommand command = new SqlCommand(deleteSql, connection);
                command.Parameters.AddWithValue("@Name", packagetype.Name);
                command.Parameters.AddWithValue("@Description", packagetype.Description);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return packagetype;
        }
        public PackageType? GetByName(string Name)
        {
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                PackageType? packageType = new PackageType();
                if (Name == null) { return null; }
                try
                {
                    SqlCommand command = new SqlCommand(selectByNameSql, connection);
                    command.Parameters.AddWithValue("@Name", Name);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read()) { packageType = Read(reader); }
                    else { return null; }
                    reader.Close();
                }
                catch (SqlException ex) { throw ex; }
                catch (Exception ex) { throw ex; }
                finally { connection.Close(); }
                return packageType;
            }
        }
        public PackageType? Update(string name, string description)
        {
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                PackageType? packageType = GetByName(name);
                if (packageType == null) { return null; }
                try
                {
                    SqlCommand command = new SqlCommand(updatePackageSql, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Description", description);
                    connection.Open();
                    command.ExecuteNonQuery();

                    packageType = GetByName(name);
                }
                catch (SqlException ex) { throw ex; }
                catch (Exception ex) { throw ex; }
                finally { connection.Close(); }
                return packageType;
            }
        }
        #endregion

        #region Helper functions
        private PackageType Read(SqlDataReader reader)
        {
            string name = reader.IsDBNull(0) ? null : reader.GetString(0);
            string description = reader.IsDBNull(1) ? null : reader.GetString(1);
            return new PackageType(name, description);
        }
        #endregion
    }
}
