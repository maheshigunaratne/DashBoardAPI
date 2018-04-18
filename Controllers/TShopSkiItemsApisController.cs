using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NNET_Dashboard_API.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/TShopSkiItemsApis")]
    public class TShopSkiItemsApisController : Controller
    {
        private readonly NumedalAPIContext _context;

        public TShopSkiItemsApisController(NumedalAPIContext context)
        {
            _context = context;
        }
        [EnableCors("CorsPolicy")]
        // GET: api/TShopSkiItemsApis
        [HttpGet]
        public IEnumerable<TShopSkiItemsApi> GetTShopSkiItemsApi()
        {
            return _context.TShopSkiItemsApi;
        }

        [EnableCors("CorsPolicy")]
        // GET: api/TShopSkiItemsApis/5
        [HttpGet("{ApplicationID}")]
        public JsonResult GetTShopSkiItemsApi([FromRoute] Guid ApplicationID)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@ApplicationID", ApplicationID) };
            var results = RDFacadeExtensions.GetModelFromQuery<TShopSkiItemsApi>(_context, "EXEC spShopGetGraph_TicketWise @ApplicationID", parms);
            
            return new JsonResult(results.ToList());

        }
        [EnableCors("CorsPolicy")]
        // GET: api/TShopSkiItemsApis/5
        [HttpGet("{ApplicationID}/paymentmode")]
        public JsonResult GetTShopSkiItemsPaymentMode([FromRoute] Guid ApplicationID)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@ApplicationID", ApplicationID) };
            var results = RDFacadeExtensions.GetModelFromQuery<TShopSkiItemsApi>(_context, "EXEC spShopGetGraph_PaymentWise @ApplicationID", parms);

            return new JsonResult(results.ToList());

        }
        [EnableCors("CorsPolicy")]
        // PUT: api/TShopSkiItemsApis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTShopSkiItemsApi([FromRoute] Guid id, [FromBody] TShopSkiItemsApi tShopSkiItemsApi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tShopSkiItemsApi.ApplicationId)
            {
                return BadRequest();
            }

            _context.Entry(tShopSkiItemsApi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TShopSkiItemsApiExists(id))
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
        [EnableCors("CorsPolicy")]
        // POST: api/TShopSkiItemsApis
        [HttpPost]
        public async Task<IActionResult> PostTShopSkiItemsApi([FromBody] TShopSkiItemsApi tShopSkiItemsApi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TShopSkiItemsApi.Add(tShopSkiItemsApi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TShopSkiItemsApiExists(tShopSkiItemsApi.ApplicationId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTShopSkiItemsApi", new { id = tShopSkiItemsApi.ApplicationId }, tShopSkiItemsApi);
        }
        [EnableCors("CorsPolicy")]
        // DELETE: api/TShopSkiItemsApis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTShopSkiItemsApi([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tShopSkiItemsApi = await _context.TShopSkiItemsApi.SingleOrDefaultAsync(m => m.ApplicationId == id);
            if (tShopSkiItemsApi == null)
            {
                return NotFound();
            }

            _context.TShopSkiItemsApi.Remove(tShopSkiItemsApi);
            await _context.SaveChangesAsync();

            return Ok(tShopSkiItemsApi);
        }

        private bool TShopSkiItemsApiExists(Guid id)
        {
            return _context.TShopSkiItemsApi.Any(e => e.ApplicationId == id);
        }
    }
}