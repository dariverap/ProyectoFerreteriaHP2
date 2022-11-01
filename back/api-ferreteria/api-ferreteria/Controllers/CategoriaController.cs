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
    [Route("api-ferreteria/categoria")]
    //Controller base es una herencia para que sea un controlador
    public class CategoriaController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CategoriaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> findAll()
        {
            return await context.Categoria.ToListAsync();
        }
        //queremos obtener solo la informacion de los de estado "true" habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Categoria>>> findAllCustom()
        {
            return await context.Categoria.Where(x => x.estado == true).ToListAsync();
        }
        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Categoria a)
        {
            context.Add(a);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos buscar informacion por el id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria>> findById(int id)
        {
            var categoria = await context.Categoria.FirstOrDefaultAsync(x => x.id == id);
            return categoria;
        }

        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Categoria a, int id)
        {
            if (a.id != id)
            {
                return BadRequest("No se encontro el codigo correspondiente");
            }
            context.Update(a);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos "eliminar" informacion, cambiar el estado de la entidad a FALSO
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Categoria.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            var categoria = await context.Categoria.FirstOrDefaultAsync(x => x.id == id);
            categoria.estado = false;
            context.Update(categoria);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
