

namespace DotnetCoding.Core.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int ProductId {  get; set; }
        public int ProductPrice { get; set; }
        public int PreviousPrice {  get; set; }
        public string ProductName { get; set; }
        public string RequestType { get; set; } // Create, Update, Delete
        public string RequestReason { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
