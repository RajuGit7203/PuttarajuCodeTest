using System.ComponentModel.DataAnnotations;


namespace Mouri.Shared
{
    public class Patient
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime Dob { get; set; }
        public AddressInfo Address { get; set; }


    }
}
