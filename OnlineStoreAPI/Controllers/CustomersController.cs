using Microsoft.AspNetCore.Mvc;
using OnlineStoreAPI.DTOs;
using OnlineStoreAPI.Models;
using OnlineStoreAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        var customerDTOs = customers.Select(c => new CustomerDTO
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Phone = c.Phone
        });
        return Ok(customerDTOs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null) return NotFound();
        var customerDTO = new CustomerDTO
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone
        };
        return Ok(customerDTO);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCustomer(CustomerDTO customerDto)
    {
        var customer = new Customer
        {
            Name = customerDto.Name,
            Email = customerDto.Email,
            Phone = customerDto.Phone
        };
        await _customerService.AddCustomerAsync(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customerDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCustomer(int id, CustomerDTO customerDto)
    {
        if (id != customerDto.Id) return BadRequest();
        var customer = new Customer
        {
            Id = customerDto.Id,
            Name = customerDto.Name,
            Email = customerDto.Email,
            Phone = customerDto.Phone
        };
        await _customerService.UpdateCustomerAsync(customer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return NoContent();
    }
}