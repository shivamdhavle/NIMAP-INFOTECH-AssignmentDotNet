using AssignmentDotNet.Models;

namespace AssignmentDotNet.Controllers
{
    internal class ProductPaginationViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}