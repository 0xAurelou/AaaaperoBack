using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using DTO;
using Models;

namespace Aaaapero.Controllers
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
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _context.customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> GetCustomer_byId(int id)
        {
            var order = from orders in _context.orders
                join product in _context.products on orders.product_id equals product.product_id
                join customer in _context.customers on orders.customer_id equals customer.id
                select new OrderDTO
                {
                    customer_id = customer.id,
                    price = product.price,
                    order_id = orders.order_id,
                    product_id = product.product_id
                };

            var customers = from customer in _context.customers
                join orders in _context.orders on customer.id equals orders.customer_id
                select new CustomerDetailsDTO
                {
                    Customer_id = customer.id,
                    Name = customer.name,
                    Orders = order.Where(x => x.customer_id == customer.id).ToList()
                };

            var customer_by_id = customers.ToList().Find(x => x.Customer_id == id);

            if (customer_by_id == null)
            {
                return NotFound();
            }
            return customer_by_id;
        }
        
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.customers.Add(customer);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetCustomer", new { id = customer.id }, customer);
        }
    }
}