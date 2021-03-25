using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAaaapero.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTO;
using Models;

namespace AaaaperoBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly Context _context;

        public CustomerController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomer()
        {
            return await _context.customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomer_byId(int id)
        {
            var customer = await _context.customers.FindAsync(id);
            if(customer != null)
            {
                return customer;
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomer(Customers customer)
        {
            _context.customers.Add(customer);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }
    }
}