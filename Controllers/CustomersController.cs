using kolosB.Models;
using kolosB.Models.DTOs;
using kolosB.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace kolosB.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CustomersController : ControllerBase
{
    
    private readonly ICustomerService _customerSerive;

    public CustomersController(ICustomerService customerSerive)
    {
        _customerSerive = customerSerive;
    }
    
    [HttpGet("{CustomerId}/purchases")]
    public async Task<IActionResult> GetInfoForCustomerAsync(int CustomerId, CancellationToken token)
    {
        var result = await _customerSerive.GetInfoForCustomerAsync(CustomerId, token);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> InsertCustomerAndPurchasesAsync(RequestDTO request, CancellationToken token)
    {
        await _customerSerive.InsertCustomerAndPurchasesAsync(request, token);
        return Created();
    }
}