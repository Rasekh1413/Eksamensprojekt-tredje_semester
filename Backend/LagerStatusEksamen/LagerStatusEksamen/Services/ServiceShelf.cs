using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Data.SqlClient;
using System;

namespace LagerStatusEksamen.Services
{
    public class ServiceShelf : IServiceShelf
    {
        #region Instances
        private string selectSql = "SELECT * FROM Shelves";
        private string filterBySensorSql = "SELECT * FROM Shelves WHERE MAC = @MAC";
        private string insertSql = "INSERT INTO Shelves(MAC, PackageTypeName , IsStocked) Values(@MAC, @PackageTypeName , @IsStocked)";
        private string deleteSql = "DELETE FROM Shelves WHERE MAC = @MAC";
        private string updatePackageSql = "UPDATE Shelves SET PackageTypeName  = @PackageTypeName  WHERE MAC = @MAC";
        private string updateStatusSql = "UPDATE Shelves SET IsStocked = @IsStocked WHERE MAC = @MAC";
        private string _con;
        #endregion

        #region Constructor
        public ServiceShelf() { _con = Secret.ConnectionString; }
        public ServiceShelf(string con) { _con = con; }
        #endregion

        #region Methods
        public Shelf Add(Shelf shelf)
        {
            Shelf addedShelf = new Shelf();
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(insertSql, connection);
                    command.Parameters.AddWithValue("MAC", shelf.MAC);
                    command.Parameters.AddWithValue("PackageTypeName ", shelf.PackageTypeName);
                    command.Parameters.AddWithValue("IsStocked", shelf.IsStocked);
                    connection.Open();
                    command.ExecuteNonQuery();

                    addedShelf = GetByMAC(shelf.MAC);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw ex;
                }
                catch (Exception ex) { throw ex; }
                finally { connection.Close(); }
                return addedShelf;
            }
        }

        public Shelf? Delete(string mac)
        {
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                Shelf? deleteShelf = GetByMAC(mac);
                if (deleteShelf == null) { return null; }
                try
                {
                    SqlCommand command = new SqlCommand(deleteSql, connection);
                    command.Parameters.AddWithValue("@MAC", mac);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex) { throw ex; }
                catch (Exception ex) { throw ex; }
                finally { connection.Close(); }
                return deleteShelf;
            }
        }

        public List<Shelf> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                List<Shelf> shelves = new List<Shelf>();
                try
                {
                    SqlCommand command = new SqlCommand(selectSql, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string mac = reader.GetString(1);
                        string packageTypeName = reader.GetString(2);
                        bool isStocked = reader.GetBoolean(0);


                        Shelf shelf = new Shelf(mac, packageTypeName, isStocked);
                        shelves.Add(shelf);
                    }
                    reader.Close();
                }
                catch (SqlException ex) { throw ex; }
                catch (Exception ex) { throw ex; }
                finally { connection.Close(); }
                return shelves;
            }
        }

        public Shelf? GetByMAC(string mac)
        {
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                Shelf? shelf = new Shelf();
                if (mac == null) { return null; }
                try
                {
                    SqlCommand command = new SqlCommand(filterBySensorSql, connection);
                    command.Parameters.AddWithValue("@MAC", mac);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string getPackageTypeName = reader.GetString(2);
                        bool getIsStocked = reader.GetBoolean(0);
                        shelf = new Shelf(mac, getPackageTypeName, getIsStocked);
                    }
                    reader.Close();
                }
                catch (SqlException ex) { throw ex; }
                catch (Exception ex) { throw ex; }
                finally { connection.Close(); }
                return shelf;
            }
        }

        public Shelf? UpdatePackageType(string mac, string type)
        {
            using(SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                Shelf? shelf = GetByMAC(mac);
                if (shelf == null) { return null; }
                try
                {
                    SqlCommand command = new SqlCommand(updatePackageSql, connection);
                    command.Parameters.AddWithValue("@MAC", mac);
                    command.Parameters.AddWithValue("@PackageTypeName ", type);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex) { throw ex; }
                catch (Exception ex) { throw ex; }
                finally { connection.Close(); }
                return shelf;
            }
        }

        public Shelf? UpdateStatus(string mac, bool status)
        {
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                Shelf? shelf = GetByMAC(mac);
                if (shelf == null) { return null; }
                try
                {
                    SqlCommand command = new SqlCommand(updateStatusSql, connection);
                    command.Parameters.AddWithValue("@MAC", mac);
                    command.Parameters.AddWithValue("@IsStocked", status);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex) { throw ex; }
                catch (Exception ex) { throw ex; }
                finally { connection.Close(); }
                return shelf;
            }
        }
        #endregion
    }
}