

namespace DotnetCoding.Core.Models
{
    public class RequestQueue
    {
        public int Id { get; set; }
        public int ProductId {  get; set; }
        public int ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string RequestType { get; set; }
        public string RequestReason { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
