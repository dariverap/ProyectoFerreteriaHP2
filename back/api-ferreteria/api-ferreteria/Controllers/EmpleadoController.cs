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
    [Route("api-ferreteria/empleado")]
    //Controller base es una herencia para que sea un controlador
    public class EmpleadoController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmpleadoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //MOSTRAR INFORMACION
        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> findAll()
        {
            return await context.Empleado.ToListAsync();
        }
        //MOSTRAR INFORMACION DE ESTADO TRUE
        //queremos obtener solo la informacion de los de estado "true" habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Empleado>>> findAllCustom()
        {
            return await context.Empleado.Where(x => x.estado == true).ToListAsync();
        }
        //GUARDAR
        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Empleado l)
        {
            var rolexiste = await context.Rol.AnyAsync(x => x.id == l.RolId);
            if (!rolexiste)
            {
                return BadRequest($"No existe el rol con codigo : {l.RolId}");
            }
            context.Add(l);
            await context.SaveChangesAsync();
            return Ok();
        }
        //MOSTRAR POR ID
        //cuando queremos buscar informacion por el id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Empleado>> findById(int id)
        {
            var empleado = await context.Empleado.FirstOrDefaultAsync(x => x.id == id);
            return empleado;
        }
        //ACTUALIZAR
        //cuando queremos actualizar informaion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Empleado l, int id)
        {
            if (l.id != id)
            {
                return BadRequest("No se encontro el codigo correspondiente");
            }
            context.Update(l);
            await context.SaveChangesAsync();
            return Ok();
        }
        // ELIMINAR
        //cuando queremos "eliminar" informacion, cambiar el estado de la entidad a FALSO
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Empleado.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            var empleado = await context.Empleado.FirstOrDefaultAsync(x => x.id == id);
            empleado.estado = false;
            context.Update(empleado);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
