namespace DataFacadeSolutionWeb.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string FaxNumber { get; set; } = string.Empty;
    }
}
