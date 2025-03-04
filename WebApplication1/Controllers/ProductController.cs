using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static List<Product> products = new List<Product>()
        {
            new Product { Id = 1,Name="Bisli",Description="cfghcdtk",CategoryProduct=new Category{Id=1,Name="חטיפים" }},
            new Product { Id = 2,Name="bamba",Description="cfghcdtk",CategoryProduct=new Category{Id=1,Name="חטיפים" }},
            new Product { Id = 1,Name="Cola",Description="cfghcdtk",CategoryProduct=new Category{Id=2,Name="שתייה" }},
        };

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Product p = products.FirstOrDefault(u => u.Id == id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return NotFound("Id is not valid");
            }

        }

        // POST api/<ProductController>
        [HttpPost]
        public Product Post([FromBody] Product value)
        {
            products.Add(value);
            return value;
        }


        [HttpPost("createDataSave/{path}")]
        public IActionResult Post(string path)
        {
            if (!path.Contains(".txt")){
                return BadRequest("you should provide txt file");
            }


            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Product product in products)
                {
                    sw.Write(product.Name);
                    sw.Write(product.Description);
                    sw.Write(product.Price);
                    sw.WriteLine();
                }
            }
            return Ok("success");


        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product value)
        {
            int index = products.FindIndex(u => u.Id == id);
            products[index].Name = value.Name;
            products[index].Description = value.Description;
            products[index].Price = value.Price;
            products[index].CategoryProduct = value.CategoryProduct;
            return products[index];
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            int index = products.FindIndex(u => u.Id == id);
            products.RemoveAt(index);
            return "sucess";
        }
        [HttpGet("find")]
        public List<Product> Find(string query)
        {
            Console.WriteLine(query);
            return null;
        }
    }
}
