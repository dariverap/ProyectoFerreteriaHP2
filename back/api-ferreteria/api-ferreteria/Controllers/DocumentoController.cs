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
    [Route("api-ferreteria/documento")]
    //Controller base es una herencia para que sea un controlador
    public class DocumentoController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DocumentoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Documento>>> findAll()
        {
            return await context.Documento.ToListAsync();
        }
        //queremos obtener solo la informacion de los de estado "true" habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Documento>>> findAllCustom()
        {
            return await context.Documento.Where(x => x.estado == true).ToListAsync();
        }
        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Documento a)
        {
            context.Add(a);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos buscar informacion por el id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Documento>> findById(int id)
        {
            var documento = await context.Documento.FirstOrDefaultAsync(x => x.id == id);
            return documento;
        }
        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Documento a, int id)
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
            var existe = await context.Documento.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            var documento = await context.Documento.FirstOrDefaultAsync(x => x.id == id);
            documento.estado = false;
            context.Update(documento);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
