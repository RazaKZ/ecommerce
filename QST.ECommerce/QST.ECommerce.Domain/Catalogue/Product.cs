using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Domain.Catalogue
{
    // Entity
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }

        //--new fields heree--
        public int DepartmentId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string Status { get; set; } = "Draft"; // Draft / Active / Inactive / Archived

        // Audit Fields:
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
