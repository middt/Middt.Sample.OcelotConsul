using Microsoft.AspNetCore.Mvc;
using Middt.Sample.Ocelot.ProductApi.Model;

namespace Middt.Sample.Ocelot.ProductApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new Product
            {
                Id = index,
                Name = $"Product Name {index}",
                Node = HttpContext.Request.Host.ToString()
            })
            .ToArray();
        }

    }
}
