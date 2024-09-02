using System.ComponentModel.DataAnnotations;

namespace Mouri.Shared
{
    public class AddressInfo
    {
        public int AddressId { get; set; }
        public string? Street { get; set; }
        public string? Zip { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }


    }
}