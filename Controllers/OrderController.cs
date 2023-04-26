using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookstoreAPI.Models;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BookstoreAPIDBContext _context;

        public OrderController(BookstoreAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<Response>> GetOrders()
        {

            var response = new Response();

            if (_context.Orders == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "No orders found";
            }
            else
            {
                response.StatusCode = 200;
                response.StatusDescription = "Orders found";
                response.Orders = await _context.Orders.Include(o => o.Book).ToListAsync();
            }

            return response;
            //if (_context.Orders == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Orders.Include(o => o.Book).ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetOrder(int id)
        {
          //if (_context.Orders == null)
          //{
          //    return NotFound();
          //}
            var order = await _context.Orders.FindAsync(id);
            var response = new Response();
           

            if (order != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "Order was Found! :) ";
                response.Orders.Add(order);
                //return NotFound();
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescription = "Order not Found :(";
            }

            return response;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
          if (_context.Orders == null)
          {
              return Problem("Entity set 'BookstoreAPIDBContext.Orders'  is null.");
          }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
