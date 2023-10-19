namespace CleverAutoApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Car> Cars { get; set; }
    }

    public class Car
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public int CurrentMileage { get; set; }
        public int EstimatedNextServiceMileage { get; set; }
        public int CustomerId { get; set; }
        public List<Service> Services { get; set; }
    }

    public class Service
    {
        public int Id { get; set; }
        public string Type { get; set; } // E.g., Oil Change, Maintenance, etc.
        public DateTime DateOfService { get; set; }
        public int MileageAtService { get; set; }
        public int CarId { get; set; }
    }

}
