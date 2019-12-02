using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using estudo_dot_net.Models;

namespace estudo_dot_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentDetailController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDeatil>>> GetPaymentDeatil()
        {
            return await _context.PaymentDeatil.ToListAsync();
        }
        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDeatil>> GetPaymentDeatil(int id)
        {
            var paymentDetail = await _context.PaymentDeatil.FindAsync(id);
            if(paymentDetail == null)
            {
                return NotFound();
            }
            return paymentDetail;
        }
        // PUT: api/PaymentDetail/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDeatil(int id, PaymentDeatil paymentDeatil)
        {
            if (id != paymentDeatil.PMId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDeatil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDeatilExists(id))
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

        // POST: api/PaymentDetail
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PaymentDeatil>> PostPaymentDeatil(PaymentDeatil paymentDeatil)
        {
            _context.PaymentDeatil.Add(paymentDeatil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDeatil", new { id = paymentDeatil.PMId }, paymentDeatil);
        }
       
        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDeatil>> DeletePaymentDeatil(int id)
        {
            var paymentDeatil = await _context.PaymentDeatil.FindAsync(id);
            if (paymentDeatil == null)
            {
                return NotFound();
            }

            _context.PaymentDeatil.Remove(paymentDeatil);
            await _context.SaveChangesAsync();

            return paymentDeatil;
        }

        private bool PaymentDeatilExists(int id)
        {
            return _context.PaymentDeatil.Any(e => e.PMId == id);
        }
    }
}
