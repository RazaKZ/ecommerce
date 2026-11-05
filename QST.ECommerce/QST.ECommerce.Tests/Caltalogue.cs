using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Tests
{
    public class Caltalogue
    {
        [Fact]
        public void Test_Department()
        {
            List<Department> deptList = new List<Department>();
            List<Category> categories = new List<Category>();
            List<Product> products = new List<Product>();
            

            Department dept = new Department();
            dept.Id = 1;
            dept.Name = "Electronics";
            dept.Description = "Electronic Devices";

            deptList.Add(dept);

            categories.Add(new Category { DeptId = 1, Id = 1, CategoryName = "Accessories & Supplies" });
            categories.Add(new Category { DeptId = 1, Id = 2, CategoryName = "Camera & Photo" });
            categories.Add(new Category { DeptId = 1, Id = 3, CategoryName = "Car & Vehicle Electronics" });

            // products belonging to first department & first category
            products.Add(new Product { Id = 1, ProductName = "Bluetooth Tracker Tags for iOS & Android", UnitPrice = 9139 });
            products.Add(new Product { 
                Id = 2, 
                ProductName = "Hybrid Active Noise Cancelling Wireless Ear Buds 80 Hrs Playtime Hi-Res Stereo Quality Bluetooth Earbuds with Transparency Mode Headphones Bluetooth Earhooks ANC Earphones for Work Sports Travel\r\n", 
                UnitPrice = 9139 
            });


            dept = new Department();
            dept.Id = 2;
            dept.Name = "Computers";
            deptList.Add(dept);

            categories.Add(new Category { DeptId = 2, Id = 4, CategoryName = "Computer Accessories & Peripherals" });
            categories.Add(new Category { DeptId = 2, Id = 5, CategoryName = "Computer Componenets" });
            categories.Add(new Category { DeptId = 2, Id = 6, CategoryName = "Computers & Tablets" });

            
            dept = new Department();
            dept.Id = 3;
            dept.Name = "Smart Home";
            deptList.Add(dept);


        }

        [Fact]
        public void Test_Cateogry()
        {
            List<Category> categories = new List<Category>();

            // Electronics
            categories.Add(new Category { DeptId = 1, Id = 1, CategoryName = "Accessories & Supplies" });
            categories.Add(new Category { DeptId = 1, Id = 2, CategoryName = "Camera & Photo" });
            categories.Add(new Category { DeptId = 1, Id = 3, CategoryName = "Car & Vehicle Electronics" });

            // Computers
            categories.Add(new Category { DeptId = 2, Id = 4, CategoryName = "Computer Accessories & Peripherals" });
            categories.Add(new Category { DeptId = 2, Id = 5, CategoryName = "Computer Componenets" });
            categories.Add(new Category { DeptId = 2, Id = 6, CategoryName = "Computers & Tablets" });
        }
    }
}