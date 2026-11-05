using QST.ECommerce.Application.Contracts;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Domain.Enums;
using QST.ECommerce.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QST.ECommerce.Application.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catRepo;
        public CatalogService(ICatalogRepository catRepo) 
        {
            _catRepo = catRepo;
        }

        #region Department

        public int ManageDepartment(Department department, DBCommands dbCommand)
        {

            //int resutl = _catRepo.AddDepartment(department);
            //return resutl;
            int result = 0;
            if (dbCommand == DBCommands.Insert)
            {
                result = _catRepo.AddDepartment(department);
            }
            else if (dbCommand == DBCommands.Update)
            {
                department.IsActive = true;
                //int UpdateDapartment(Department dept);
                result = _catRepo.UpdateDepartment(department);
            }
            else if (dbCommand == DBCommands.Delete)
            {
                department.IsActive = false;
                result = _catRepo.UpdateDepartment(department);
            }
            return result;
        }
        public Department GetDepartmentById(int id)
        {
            return _catRepo.GetDepartmentById(id);
        }

        public List<Department> GetAllDepartments()
        {
            var list = _catRepo.GetAllDepartments();
            return list;
            // Implement logic to retrieve all departments from the database
            //throw new NotImplementedException();
        }

        #endregion

        #region Category 

        public int ManageCategory(Category cateogry, DBCommands dbCommand)
        {
            int result = 0;
            if (dbCommand == DBCommands.Insert)
            {
                result = _catRepo.AddCategory(cateogry);
            }
            else if (dbCommand == DBCommands.Update)
            {
                cateogry.IsActive = true;
                result = _catRepo.UpdateCategory(cateogry);
            }
            else if (dbCommand == DBCommands.Delete)
            {
                cateogry.IsActive = false;
                result = _catRepo.UpdateCategory(cateogry);
            }
            return result;
        }
        public Category GetCategoryById(int id)
        {
            return _catRepo.GetCategoryById(id);
        }
        public List<Category> GetAllCategories()
        {
            return _catRepo.GetAllCategories();
        }

        #endregion

        #region Brand

        public int ManageBrand(Brand brand, DBCommands dbCommand)
        {
            //return _catRepo.AddBrand(brand);
            int result = 0;
            if (dbCommand == DBCommands.Insert)
            {
                result = _catRepo.AddBrand(brand);
            }
            else if (dbCommand == DBCommands.Update)
            {
                brand.IsActive = true;
                //int UpdateDapartment(Department dept);
                result = _catRepo.UpdateBrand(brand);
            }
            else if (dbCommand == DBCommands.Delete)
            {
                brand.IsActive = false;
                result = _catRepo.UpdateBrand(brand);
            }
            return result;

        }
        public Brand GetBrandById(int id)
        {
            return _catRepo.GetBrandById(id);
        }
        public List<Brand> GetAllBrands()
        {
            return _catRepo.GetAllBrands();
        }

        #endregion

        #region Product

        public int ManageProduct(Product product, DBCommands dbCommand)
        {
            int result = 0;
            if (dbCommand == DBCommands.Insert)
            {
                product.CreatedOn = DateTime.UtcNow;
                product.IsActive = true;
                result = _catRepo.AddProduct(product);
            }
            else if (dbCommand == DBCommands.Update)
            {
                product.ModifiedOn = DateTime.UtcNow;
                result = _catRepo.UpdateProduct(product);
            }
            else if (dbCommand == DBCommands.Delete)
            {
                product.IsActive = false; // Soft Delete
                product.ModifiedOn = DateTime.UtcNow;
                result = _catRepo.UpdateProduct(product);
            }
            return result;
        }

        public Product GetProductById(int id)
        {
            return _catRepo.GetProductById(id);
        }

        public List<Product> GetAllProducts()
        {
            return _catRepo.GetAllProducts();
        }

        #endregion
        #region Customer
        public int ManageCustomer(Customer customer, DBCommands dbCommand)
        {
            int result = 0;
            if (dbCommand == DBCommands.Insert)
            {
                result = _catRepo.AddCustomer(customer);
            }
            else if (dbCommand == DBCommands.Update)
            {
                customer.IsActive = true;
                result = _catRepo.UpdateCustomer(customer);
            }
            else if (dbCommand == DBCommands.Delete)
            {
                customer.IsActive = false; // Soft Delete
                result = _catRepo.UpdateCustomer(customer);
            }
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            return _catRepo.GetCustomerById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _catRepo.GetAllCustomers();
        }
        #endregion

    }
}
