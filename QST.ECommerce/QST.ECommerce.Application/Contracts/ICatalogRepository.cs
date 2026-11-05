using QST.ECommerce.Domain.Catalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QST.ECommerce.Domain.Customer;

namespace QST.ECommerce.Application.Contracts
{
    public interface ICatalogRepository
    {
        #region Department
        int AddDepartment(Department dept);
        int UpdateDepartment(Department dept);
        //int DeleteDepartment(int deptId);
        Department GetDepartmentById(int id);
        List<Department> GetAllDepartments();
        


        #endregion
        #region Category

        int AddCategory(Category category);
        int UpdateCategory(Category category);
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
        

        #endregion
        #region Brand

        int AddBrand(Brand brand);
        int UpdateBrand(Brand brand);
        Brand GetBrandById(int id);
        List<Brand> GetAllBrands();
        


        #endregion
        #region Product

        int AddProduct(Product product);
        int UpdateProduct(Product product);
        //int DeleteProduct(int id);
        Product GetProductById(int id);
        List<Product> GetAllProducts();


        #endregion
        #region Customer
        int AddCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        Customer GetCustomerById(int id);
        List<Customer> GetAllCustomers();
        #endregion
    }
}
