using CleverAutoApi.Models;

namespace CleverAutoApi.DTOs
{
    public class CustomerCarServiceDTO
    {
        public string Name { get; set; }   =string.Empty;
        public string Phone { get; set; }=string.Empty;
        public string Email { get; set; }= string.Empty;
        public Car Car { get; set; }=new Car();
    }
}
