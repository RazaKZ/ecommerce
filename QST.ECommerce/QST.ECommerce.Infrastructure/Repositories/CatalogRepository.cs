using QST.ECommerce.Application.Contracts;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Domain.Customer;
using QST.ECommerce.Infrastructure.DbContexts;
using QST.ECommerce.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Infrastructure.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private CatalogDbContext _dbContext;

        public CatalogRepository(CatalogDbContext dbContext) // Constructor Injection
        {
            _dbContext = dbContext;
        }

        #region Department
        public int AddDepartment(Department dept)
        {
            _dbContext.Add(dept);
            return _dbContext.SaveChanges(); //It saves data of Context into DB

        }
        public int UpdateDepartment(Department dept)
        {
            var catFromDB = GetDepartmentById(dept.Id); // it will fetch data from Database 
            catFromDB.Name = dept.Name;
            catFromDB.Description = dept.Description;
            int result = _dbContext.SaveChanges();
            return result;

        }
        public Department GetDepartmentById(int deptId)
        {
            var dept = _dbContext.Departments.FirstOrDefault(d => d.Id == deptId);
            return dept;
        }
        public List<Department> GetAllDepartments()
        {
            var list = _dbContext.Departments.ToList();
            return list;
        }
        #endregion
        #region Catagory
        public int AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            int result = _dbContext.SaveChanges();
            return result;
        }
        public int UpdateCategory(Category category)
        {
            var catFromDB = GetCategoryById(category.Id); // it will fetch data from Database 
            catFromDB.CategoryName = category.CategoryName;
            catFromDB.Description = category.Description;
            int result = _dbContext.SaveChanges();
            return result;
        }
        //public bool DeleteCategory(int categoryId)
        //{
        //    var catFromDB = GetCategoryById(categoryId);
        //    if (catFromDB != null)
        //    {
        //        _dbContext.Categories.Remove(catFromDB);
        //        int result = _dbContext.SaveChanges();
        //        return result > 0;
        //    }
        //    return false;
        //}

        public Category GetCategoryById(int categoryId)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            return category;
        }

        public List<Category> GetAllCategories()
        {
            var list = _dbContext.Categories.ToList();
            return list;

        }



        #endregion
        #region Brand
        public int AddBrand(Brand brand)
        {
            _dbContext.Add(brand);
            int result = _dbContext.SaveChanges(); // It saves data of Context into DB

            return result;
        }

        public int UpdateBrand(Brand brand)
        {
            var fromDB = GetBrandById(brand.Id); // it will fetch data from Database 
            fromDB.Name = brand.Name;
            fromDB.Description = brand.Description;
            int result = _dbContext.SaveChanges();
            return result;
        }
        public Brand GetBrandById(int id)
        {
            var brand = _dbContext.Brands.FirstOrDefault(c => c.Id == id);
            return brand;
        }

        public List<Brand> GetAllBrands()
        {
            var list = _dbContext.Brands.ToList();
            return list;
        }

        #endregion
        #region Product
        public int AddProduct(Product product)
        {
            _dbContext.Products.Add(product); // This line will save product into the Context Class
            int result = _dbContext.SaveChanges(); // It will save Product Into Database
            return result;
        }
        public int UpdateProduct(Product product)
        {
            var fromDB = GetProductById(product.Id); // it will fetch data from Database 
            fromDB.ProductName = product.ProductName;
            fromDB.UnitPrice = product.UnitPrice;
            int result = _dbContext.SaveChanges();
            return result;
        }
        public Product GetProductById(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(c => c.Id == id);
            return product;
        }
        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }



 
 

  
        #endregion
        #region Customer
        public int AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            return _dbContext.SaveChanges();
        }

        public int UpdateCustomer(Customer customer)
        {
            var fromDB = GetCustomerById(customer.Id);
            if (fromDB != null)
            {
                fromDB.Name = customer.Name;
                fromDB.Email = customer.Email;
                fromDB.PhoneNumber = customer.PhoneNumber;
                fromDB.Address = customer.Address;
                fromDB.IsActive = customer.IsActive;
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            return customer!;
        }

        public List<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }
        #endregion

    }
}
