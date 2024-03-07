

using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetCoding.Core.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string RequestType { get; set; } // Create, Update, Delete
        public string RequestReason { get; set; }
        public DateTime RequestDate { get; set; }

        ///  recover the product 

     
        public int? ProductId {  get; set; }
        public string? NewProductName { get; set; }
        public string? NewProductDescription { get; set; }
        public int? NewProductPrice { get; set; }
    }
}
