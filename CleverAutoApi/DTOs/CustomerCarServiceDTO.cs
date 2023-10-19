using CleverAutoApi.Models;

namespace CleverAutoApi.DTOs
{
    public class CustomerCarServiceDTO
    {
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public Service Service { get; set; }
    }
}
