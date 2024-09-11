using APIProductos_2._4.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProductos_2._4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        // GET: api/<ValuesController>
        private static readonly Aplicacion app = new Aplicacion();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(app.Get());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(id < 0 || id > app.Get().Count)
            {
                return BadRequest("Id de Producto no valido");
            }
            return Ok(app.Get()[id]);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Producto oProducto)
        {
            if(!Check(oProducto))
            {
                return BadRequest("Faltan datos");
            }
            app.Add(oProducto);
            return Created(new Uri(Request.GetEncodedUrl()+"/"+oProducto.Codigo), oProducto);
        }
        private bool Check(Producto oProducto) 
        {
            if(oProducto == null || string.IsNullOrEmpty(oProducto.Nombre) || oProducto.Precio == 0)
            {
                return false;
            }
            return true;
        }
        // PUT api/<ValuesController>/5
        [HttpPut("{oProducto}")]
        public IActionResult Put([FromBody] Producto oProducto)
        {
            if (!(app.Get().Exists(producto => producto.Codigo == oProducto.Codigo)) || !Check(oProducto))
            {
                return BadRequest("Producto ingresado no valido o faltan datos");
            }
            return Ok(app.Update(oProducto));
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id < 0  || id > app.Get().Count())
            {
                return BadRequest("Id de Producto no valido");
            }
            app.Delete(id);
            return Ok();
        }
    }
}
