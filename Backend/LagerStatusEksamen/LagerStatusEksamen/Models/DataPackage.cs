namespace LagerStatusEksamen.Models
{
    /// <summary>
    /// Data sent from the Raspberry Pi and to the REST Server
    /// </summary>
    public class DataPackage
    {
        public string MAC { get; set; }
        public bool Status { get; set; }
        
        public DataPackage() { MAC = ""; }
        public DataPackage(string MAC, bool status)
        {
            this.MAC = MAC;
            Status = status;
        }
    }
}
