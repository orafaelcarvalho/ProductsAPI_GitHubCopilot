using Microsoft.AspNetCore.Mvc;
using ProductsAPI_GitHubCopilot.Domain.Models;

[Route("api/[controller]")]
[ApiController]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SuppliersController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var suppliers = await _supplierService.GetAllSuppliersAsync();
        return Ok(suppliers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var supplier = await _supplierService.GetSupplierByIdAsync(id);
        if (supplier == null) return NotFound();
        return Ok(supplier);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SupplierCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var createdSupplier = await _supplierService.AddSupplierAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = createdSupplier.Id }, createdSupplier);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SupplierUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != model.Id) return BadRequest("ID mismatch");

        var updatedSupplier = await _supplierService.UpdateSupplierAsync(model);
        return Ok(updatedSupplier);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _supplierService.DeleteSupplierAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}