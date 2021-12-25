using Microsoft.AspNetCore.Mvc;
using Middt.Sample.Ocelot.CustomerApi.Model;

namespace Middt.Sample.Ocelot.CustomerApi.Controllers
{


    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new Customer
            {
                Id = index,
                Name = $"Customer Name {index}",
                Node = HttpContext.Request.Host.ToString()
            })
            .ToArray();
        }

    }
}
