namespace MinimalAPI
{
    public class Userdata
    {
        public Userdata(string name, DateTime birthDate, string city, string phone)
        {
            Name = name;
            BirthDate = birthDate;
            City = city;
            Phone = phone;
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
