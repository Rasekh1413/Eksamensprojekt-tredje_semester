using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Models;
using LagerStatusEksamen.Misc;
using Microsoft.Data.SqlClient;

namespace LagerStatusEksamen.Services
{
    public class ServiceShelf : IServiceShelf
    {
        #region Instances
        private string selectSql = "SELECT * FROM Shelves";
        private string filterBySensorSql = "SELECT * FROM Shelves WHERE ID = @ID";
        private string insertSql = "INSERT INTO Shelves(MAC,PackageType,IsStocked) Values(@MAC, @PackageType, @IsStocked)";
        private string deleteSql = "DELETE FROM Shelves WHERE ID = @ID";
        private string updateSql = "UPDATE Shelves SET PackageType = @PackageType, IsStocked = @IsStocked WHERE ID = @ID";
        #endregion

        public Shelf Add(Shelf shelf)
        {
            Shelf addedShelf = new Shelf();
            using (SqlConnection connection = new SqlConnection(Secret.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(insertSql, connection);
                    command.Parameters.AddWithValue("MAC", shelf.MAC);
                    command.Parameters.AddWithValue("PackageType", shelf.PackageTypeName);
                    command.Parameters.AddWithValue("IsStocked", shelf.IsStocked);

                    connection.Open();

                    int numberOfRows = command.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        addedShelf = shelf;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw ex;
                }
                catch (Exception ex) { throw ex; }
                return addedShelf;
            }
        }

        public Shelf? Delete(string mac)
        {
            throw new NotImplementedException();
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
                        string mac = reader.GetString(0);
                        string packageType = reader.GetString(1);
                        bool isStocked = reader.GetBoolean(2);

                        Shelf shelf = new Shelf(mac, packageType, isStocked);
                        shelves.Add(shelf);
                    }
                }
                catch (SqlException ex) { throw ex; }
                catch (Exception ex) { throw ex; }
                return shelves;
            }
        }

        public Shelf? GetByMAC(string mac)
        {
            throw new NotImplementedException();
        }

        public Shelf? UpdatePackageType(string mac, string type)
        {
            throw new NotImplementedException();
        }

        public Shelf? UpdateStatus(string mac, bool status)
        {
            throw new NotImplementedException();
        }
    }
}