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
    [Route("api-ferreteria/usuario")]
    //Controller base es una herencia para que sea un controlador
    public class UsuarioController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public UsuarioController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //MOSTRAR INFORMACION
        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> findAll()
        {
            return await context.Usuario.ToListAsync();
        }
        //MOSTRAR INFORMACION DE ESTADO TRUE
        //queremos obtener solo la informacion de los de estado "true" habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Usuario>>> findAllCustom()
        {
            return await context.Usuario.Where(x => x.estado == true).ToListAsync();
        }
        //GUARDAR
        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Usuario l)
        {
            var empleadoexiste = await context.Empleado.AnyAsync(x => x.id == l.EmpleadoId);
            if (!empleadoexiste)
            {
                return BadRequest($"No existe el empleado con codigo : {l.EmpleadoId}");
            }
            context.Add(l);
            await context.SaveChangesAsync();
            return Ok();
        }
        //MOSTRAR POR ID
        //cuando queremos buscar informacion por el id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> findById(int id)
        {
            var usuario = await context.Usuario.FirstOrDefaultAsync(x => x.id == id);
            return usuario;
        }

        //ACTUALIZAR
        //cuando queremos actualizar informaion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Usuario l, int id)
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
            var existe = await context.Usuario.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            var usuario = await context.Usuario.FirstOrDefaultAsync(x => x.id == id);
            usuario.estado = false;
            context.Update(usuario);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
