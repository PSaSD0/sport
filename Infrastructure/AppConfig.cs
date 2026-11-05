using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace sport.Infrastructure
{
    public class AppConfig
    {
        public TinyMCE tinyMCE { get; set; } = new TinyMCE();
        public Company company { get; set; } = new Company();
    }

    public class TinyMCE
    {
        public string? APIKey { get; set; }
    }
    public class Company
    {
        public string? CompanyName { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyPhoneShort { get; set; }
        public string? CompanyEmail { get; set; }
    }

}
