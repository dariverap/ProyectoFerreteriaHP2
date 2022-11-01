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
    [Route("api-ferreteria/comprobante")]
    //Controller base es una herencia para que sea un controlador
    public class ComprobanteController:ControllerBase
    {
            
        private readonly ApplicationDbContext context;

        public ComprobanteController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //MOSTRAR INFORMACION
        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Comprobante>>> findAll()
        {
            return await context.Comprobante.ToListAsync();
        }
        //MOSTRAR INFORMACION DE ESTADO TRUE
        //queremos obtener solo la informacion de los de estado "true" habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Comprobante>>> findAllCustom()
        {
            return await context.Comprobante.Where(x => x.estado == true).ToListAsync();
        }
        //GUARDAR
        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Comprobante l)
        {
            var usuariooexiste = await context.Usuario.AnyAsync(x => x.id == l.UsuarioId);
            var clienteexiste = await context.Cliente.AnyAsync(x => x.id == l.ClienteId);
            var formapagoexiste = await context.FormaPago.AnyAsync(x => x.id == l.FormaPagoId);
            var documentoexiste = await context.Documento.AnyAsync(x => x.id == l.DocumentoId);
            if (!usuariooexiste)
            {
                return BadRequest($"No existe el usuario con codigo : {l.UsuarioId}");
            }
            if (!clienteexiste)
            {
                return BadRequest($"No existe el cliente con codigo : {l.ClienteId}");
            }
            if (!formapagoexiste)
            {
                return BadRequest($"No existe la Forma de Pago con codigo : {l.FormaPagoId}");
            }
            if (!documentoexiste)
            {
                return BadRequest($"No existe el Tipo de Documento con codigo : {l.DocumentoId}");
            }
            context.Add(l);
            await context.SaveChangesAsync();
            return Ok();
        }

        //MOSTRAR POR ID
        //cuando queremos buscar informacion por el id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Comprobante>> findById(int id)
        {
            var comprobante = await context.Comprobante.FirstOrDefaultAsync(x => x.id == id);
            return comprobante;
        }
        //ACTUALIZAR
        //cuando queremos actualizar informaion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Comprobante l, int id)
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
            var existe = await context.Comprobante.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            var comprobante = await context.Comprobante.FirstOrDefaultAsync(x => x.id == id);
            comprobante.estado = false;
            context.Update(comprobante);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
