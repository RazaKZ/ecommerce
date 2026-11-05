using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application;
using QST.ECommerce.Application.Contracts;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Domain.Enums;

namespace QST.ECommerce.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICatalogService _prodSvc;
    public ProductController(ICatalogService prodSvc)
    {
        _prodSvc = prodSvc;
    }
    [HttpGet("GetAllProducts")]
    public ActionResult GetAllProducts()
    {
        var list = _prodSvc.GetAllProducts();
        return Ok(list);
    }
    [HttpGet("GetProductById/{id}")]
    public ActionResult GetProductById(int id)
    {
        var product = _prodSvc.GetProductById(id);
        if (product == null)
            return NotFound("Product not found");
        return Ok(product);
    }
    [HttpPost("AddProduct")]
    public ActionResult AddProduct(Product request)
    {
        var result = _prodSvc.ManageProduct(request, DBCommands.Insert);
        return Ok(new { Message = "Product is Added Successfully", Result = result });
    }
    [HttpPost("UpdateProduct")]
    public ActionResult UpdateProduct(Product request)
    {
        var result = _prodSvc.ManageProduct(request, DBCommands.Update);
        return Ok(new { Message = "Product is Updated Successfully", Result = result });
    }
    [HttpDelete("DeleteProduct/{id}")]
    public ActionResult DeleteProduct(int id)
    {
        var product = _prodSvc.GetProductById(id);
        if (product == null)
            return NotFound("Product not found");
        var result = _prodSvc.ManageProduct(product, DBCommands.Delete);
        return Ok(new { Message = "Product is Deleted Successfully", Result = result });
    }
}