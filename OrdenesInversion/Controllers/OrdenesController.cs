using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdenesInversion.Contracts.Orden;
using OrdenesInversion.Models;
using OrdenesInversion.Services.Ordenes;

namespace OrdenesInversion.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class OrdenesController : ControllerBase
{
    private readonly IOrdenService _ordenService;

    public OrdenesController(IOrdenService ordenService)
    {
        _ordenService = ordenService;
    }
    [HttpPost]
    public IActionResult CrearOrden(CrearOrdenRequest request)
    {
        if (request == null) return BadRequest();
        try
        {
            Orden orden = new Orden(
                request.idCuenta,
                request.idActivo,
                request.cantidad,
                GetMontoTotal(request.cantidad, request.idActivo)
                );

            _ordenService.CrearOrden(orden);

            OrdenResponse response = new OrdenResponse(
                orden.Id,
                orden.IdCuenta,
                orden.IdActivo,
                orden.Cantidad,
                GetEstado(orden.Estado),
                orden.MontoTotal,
                orden.FechaCreacion,
                orden.FechaUltimaModificacion
            );
            return CreatedAtAction(
                actionName: nameof(GetOrden),
                routeValues: new { id = orden.Id },
                value: response);
        }
        catch (Exception ex)
        {

            return StatusCode(500,ex);
        }
    }


    [HttpGet("{id:guid}")]
    public IActionResult GetOrden(Guid id)
    {
        if (id == Guid.Empty) return BadRequest();
        try
        {
            Orden orden = _ordenService.GetOrden(id);

            OrdenResponse response = new OrdenResponse(
                    orden.Id,
                    orden.IdCuenta,
                    orden.IdActivo,
                    orden.Cantidad,
                    GetEstado(orden.Estado),
                    orden.MontoTotal,
                    orden.FechaCreacion,
                    orden.FechaUltimaModificacion
                );
            return Ok(response);
        }
        catch (InvalidOperationException ex) 
        {
            return NoContent();
        }  
       
    }
    [HttpPut]
    public IActionResult UpdateOrden(UpdateOrdenRequest request)
    {
        if (request == null) return BadRequest();
        try 
        {
            var orden = _ordenService.UpdateEstado(request.id, request.estadoUpdated);

            OrdenResponse response = new OrdenResponse(
                orden.Id,
                orden.IdCuenta,
                orden.IdActivo,
                orden.Cantidad,
                GetEstado(orden.Estado),
                orden.MontoTotal,
                orden.FechaCreacion,
                orden.FechaUltimaModificacion
            );

            return CreatedAtAction(
                actionName: nameof(GetOrden),
                routeValues: new { id = orden.Id },
                value: response);
        }
        catch(Exception ex) 
        {
            return StatusCode(500,ex);
        }
        
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteOrden(Guid id)
    {
        if (id == Guid.Empty) return BadRequest();
        try
        {
            var orden = _ordenService.DeleteOrden(id);
           

            return Ok("Orden eliminada");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    private float GetMontoTotal(int cantidad, int idActivo)
    {
        var activo = _ordenService.GetActivo(idActivo);
        float montoTotal = 0;
        float comisiones;
        float impuestos;
        float montoParcial;
        switch (activo.TipoActivo)
        {
            case 1:
                montoParcial = activo.PrecioUnitario * cantidad;
                comisiones = (float)(montoParcial * 0.006);
                impuestos = (float)(comisiones * 0.21);
                montoTotal = montoParcial + comisiones + impuestos;
                break;
            case 2:
                montoParcial = activo.PrecioUnitario * cantidad;
                comisiones = (float)(montoParcial * 0.002);
                impuestos = (float)(comisiones * 0.21);
                montoTotal = montoParcial + comisiones + impuestos;
                break;
            case 3:
                montoTotal = activo.PrecioUnitario * cantidad;
                break;
            default:
                break;
        }
        return montoTotal;
    }
    private string GetEstado(int estado)
    {
        return _ordenService.GetEstadoOrden(estado);
    }
}
