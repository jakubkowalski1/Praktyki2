namespace ProjektPraktyki_2._0.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string? Company_Name { get; set; }
        public string? Company_Address { get; set; }
        public string? Company_Hr { get; set; }
        public string? Company_Note { get; set; }

    }

    public class Contact
    {
        public int ID { get; set; }
        public string? Contact_Name { get; set; }
        public string? Contact_Telephone { get; set; }
    }
}