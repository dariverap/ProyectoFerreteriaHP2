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
    [Route("api-ferreteria/rol")]
    //Controller base es una herencia para que sea un controlador
    public class RolController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public RolController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Rol>>> findAll()
        {
            return await context.Rol.ToListAsync();
        }
        //queremos obtener solo la informacion de los de estado "true" habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Rol>>> findAllCustom()
        {
            return await context.Rol.Where(x => x.estado == true).ToListAsync();
        }
        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Rol a)
        {
            context.Add(a);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos buscar informacion por el id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Rol>> findById(int id)
        {
            var rol = await context.Rol.FirstOrDefaultAsync(x => x.id == id);
            return rol;
        }
        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Rol a, int id)
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
            var existe = await context.Rol.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            var rol = await context.Rol.FirstOrDefaultAsync(x => x.id == id);
            rol.estado = false;
            context.Update(rol);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
