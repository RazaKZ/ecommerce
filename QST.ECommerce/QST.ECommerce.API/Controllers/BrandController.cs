using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application;
using QST.ECommerce.Application.Contracts;
using QST.ECommerce.Domain.Catalogue;
using System.Net.NetworkInformation;

namespace QST.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ICatalogService catSvc;

        public BrandController(ICatalogService brandSvc) // brandSvc = new BrandService();
        {
            catSvc = brandSvc;
        }

        [HttpPost]
        public ActionResult AddBrand(Brand request)
        {
            var result = catSvc.ManageBrand(request, Domain.Enums.DBCommands.Insert);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAllBrands()
        {
            var list = catSvc.GetAllBrands();
            return Ok(list);
        }



    }
}
