

namespace DotnetCoding.Core.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public bool IsActive { get; set; } 
        public DateTime PostDate { get; set; }

    }
}
