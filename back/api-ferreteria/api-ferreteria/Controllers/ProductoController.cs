using api_ferreteria.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_ferreteria.Controllers
{
    //indiacmos que es un controlador
    [ApiController]
    //definir la ruta de acceso al controlador
    [Route("api-ferreteria/producto")]
    //Controller base es una herencia para que sea un controlador
    public class ProductoController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> findAll()
        {
            return await context.Producto.ToListAsync();
        }
        //queremos obtener solo la informacion de los de estado "true" habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Producto>>> findAllCustom()
        {
            return await context.Producto.Where(x => x.estado == true).ToListAsync();
        }

        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Producto l)
        {
            var categoriaexiste = await context.Categoria.AnyAsync(x => x.id == l.CategoriaId);
            if (!categoriaexiste)
            {
                return BadRequest($"No existe la categoria con codigo : {l.CategoriaId}");
            }
            context.Add(l);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos buscar informacion por el id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> findById(int id)
        {
            var producto = await context.Producto.FirstOrDefaultAsync(x => x.id == id);
            return producto;
        }

        //cuando queremos actualizar informaion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Producto l, int id)
        {
            if (l.id != id)
            {
                return BadRequest("No se encontro el codigo correspondiente");
            }
            context.Update(l);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos "eliminar" informacion, cambiar el estado de la entidad a FALSO
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Producto.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            var producto = await context.Producto.FirstOrDefaultAsync(x => x.id == id);
            producto.estado = false;
            context.Update(producto);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
