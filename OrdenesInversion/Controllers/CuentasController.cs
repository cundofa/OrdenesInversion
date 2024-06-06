using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdenesInversion.Contracts.Cuenta;
using OrdenesInversion.Contracts.Orden;
using OrdenesInversion.Models;
using OrdenesInversion.Services.Cuentas;

namespace OrdenesInversion.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class CuentasController : ControllerBase
{
    private readonly ICuentaService _cuentaService;

    public CuentasController(ICuentaService cuentaService)
    {
        _cuentaService = cuentaService;
    }
    [HttpPost]
    public IActionResult CrearCuenta(CrearCuentaRequest request)
    {
        try
        {
            if (request == null) return BadRequest();
            Cuenta cuenta = new Cuenta(
            request.CvuCliente,
            request.NombreCliente,
            request.ApellidoCliente
            );

            _cuentaService.CrearCuenta(cuenta);

            CuentaResponse response = new CuentaResponse(
                cuenta.Id,
                cuenta.CvuCliente,
                cuenta.NombreCliente,
                cuenta.ApellidoCliente
            );
            return CreatedAtAction(
                actionName: nameof(GetCuenta),
                routeValues: new { id = cuenta.Id },
                value: response);
        }
        catch (Exception ex)
        {
            return StatusCode(500,ex);
        }
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetCuenta(Guid id)
    {
        if (id==Guid.Empty) return BadRequest();
        return Ok(id);
    }
}
