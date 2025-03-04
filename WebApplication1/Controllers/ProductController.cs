using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    { 
        static List<Product> products = new List<Product>();

        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return products.FirstOrDefault(u=>u.Id==id);

        }

        // POST api/<ProductController>
        [HttpPost]
        public Product Post([FromBody] Product value)
        {
            products.Add(value);
            return value;
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product value)
        {
            int index=products.FindIndex(u=>u.Id==id);
            products[index].Name= value.Name;
            products[index].Description= value.Description;
            products[index].CategoryProduct = value.CategoryProduct;
            return products[index];
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public Product Delete(int id)
        {
            int index = products.FindIndex(u => u.Id == id);
            products.RemoveAt(index);
            return products[index];
        }
    }
}
