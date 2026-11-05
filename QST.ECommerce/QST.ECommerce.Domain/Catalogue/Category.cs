using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Domain.Catalogue
{
    // Domain Entity
    public class Category
    {
        public int Id { get; set; }
        public int DeptId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
