using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Domain.Customer;
using QST.ECommerce.Domain.Enums;

namespace QST.ECommerce.Application.Contracts
{
    public interface ICatalogService
    {
        #region Department

        int ManageDepartment(Department department, DBCommands dbCommand);
        Department GetDepartmentById(int id);

        List<Department> GetAllDepartments();

        #endregion

        #region Category 

        int ManageCategory(Category cateogry, DBCommands dbCommand); // Insert, Update and Delete opertaions
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();

        #endregion

        #region Brand

        int ManageBrand(Brand brand, DBCommands dbCommand);
        Brand GetBrandById(int id);
        List<Brand> GetAllBrands();

        #endregion

        #region Product


        int ManageProduct(Product product, DBCommands dbCommand);
        Product GetProductById(int id);

        // Contract Rule 2
        List<Product> GetAllProducts();

        #endregion
        #region Customer
        int ManageCustomer(Customer customer, DBCommands dbCommand);
        Customer GetCustomerById(int id);
        List<Customer> GetAllCustomers();
        #endregion

    }
}
