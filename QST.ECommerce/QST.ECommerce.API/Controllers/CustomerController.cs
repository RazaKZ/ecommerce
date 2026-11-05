using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application.Contracts;
using QST.ECommerce.Domain.Customer;
using QST.ECommerce.Domain.Enums;

namespace QST.ECommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICatalogService _catalogService;

    public CustomerController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    [HttpPost("AddCustomer")]
    public IActionResult AddCustomer(Customer customer)
    {
        var result = _catalogService.ManageCustomer(customer, DBCommands.Insert);
        return Ok(new { Message = "Customer added successfully", Result = result });
    }

    [HttpPost("UpdateCustomer")]
    public IActionResult UpdateCustomer(Customer customer)
    {
        var result = _catalogService.ManageCustomer(customer, DBCommands.Update);
        return Ok(new { Message = "Customer updated successfully", Result = result });
    }

    [HttpDelete("DeleteCustomer/{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var customer = _catalogService.GetCustomerById(id);
        if (customer == null)
            return NotFound("Customer not found");

        var result = _catalogService.ManageCustomer(customer, DBCommands.Delete);
        return Ok(new { Message = "Customer deleted successfully", Result = result });
    }

    [HttpGet("GetCustomerById/{id}")]
    public IActionResult GetCustomerById(int id)
    {
        var customer = _catalogService.GetCustomerById(id);
        if (customer == null)
            return NotFound("Customer not found");

        return Ok(customer);
    }

    [HttpGet("GetAllCustomers")]
    public IActionResult GetAllCustomers()
    {
        var list = _catalogService.GetAllCustomers();
        return Ok(list);
    }
}