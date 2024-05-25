namespace Courses.Infrastructure.Data.Entities;

public class PricesEntity
{
    public string? Currency { get; set; }
    public decimal CurrentPrice { get; set; }
    public decimal DiscountPrice { get; set; }
}


