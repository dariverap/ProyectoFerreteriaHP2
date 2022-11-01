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
    [Route("api-ferreteria/detalle")]
    //Controller base es una herencia para que sea un controlador
    public class DetalleController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DetalleController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //MOSTRAR INFORMACION
        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Detalle>>> findAll()
        {
            return await context.Detalle.ToListAsync();
        }
        //MOSTRAR INFORMACION DE ESTADO TRUE
        //queremos obtener solo la informacion de los de estado "true" habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Detalle>>> findAllCustom()
        {
            return await context.Detalle.Where(x => x.estado == true).ToListAsync();
        }

        //GUARDAR
        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Detalle l)
        {
            var comprobanteoexiste = await context.Comprobante.AnyAsync(x => x.id == l.ComprobanteId);
            var productoexiste = await context.Producto.AnyAsync(x => x.id == l.ProductoId);

            if (!comprobanteoexiste)
            {
                return BadRequest($"No existe el comprobante con codigo : {l.ComprobanteId}");
            }
            if (!productoexiste)
            {
                return BadRequest($"No existe el producto con codigo : {l.ProductoId}");
            }

            context.Add(l);
            await context.SaveChangesAsync();
            return Ok();
        }

        //MOSTRAR POR ID
        //cuando queremos buscar informacion por el id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Detalle>> findById(int id)
        {
            var detalle = await context.Detalle.FirstOrDefaultAsync(x => x.id == id);
            return detalle;
        }
        //ACTUALIZAR
        //cuando queremos actualizar informaion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Detalle l, int id)
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
            var existe = await context.Detalle.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            var detalle = await context.Detalle.FirstOrDefaultAsync(x => x.id == id);
            detalle.estado = false;
            context.Update(detalle);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
