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
    [Route("api-ferreteria/formapago")]
    //Controller base es una herencia para que sea un controlador
    public class FormaPagoController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public FormaPagoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<FormaPago>>> findAll()
        {
            return await context.FormaPago.ToListAsync();
        }
        //queremos obtener solo la informacion de los de estado "true" habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<FormaPago>>> findAllCustom()
        {
            return await context.FormaPago.Where(x => x.estado == true).ToListAsync();
        }
        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(FormaPago a)
        {
            context.Add(a);
            await context.SaveChangesAsync();
            return Ok();
        }
        //cuando queremos buscar informacion por el id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FormaPago>> findById(int id)
        {
            var formapago = await context.FormaPago.FirstOrDefaultAsync(x => x.id == id);
            return formapago;
        }
        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(FormaPago a, int id)
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
            var existe = await context.FormaPago.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            var formapago = await context.FormaPago.FirstOrDefaultAsync(x => x.id == id);
            formapago.estado = false;
            context.Update(formapago);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
