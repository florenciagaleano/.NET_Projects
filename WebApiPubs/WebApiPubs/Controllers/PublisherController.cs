using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiPubs.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiPubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PubsContext _context;
        public PublisherController(PubsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            return _context.Publishers.ToList();
        }

        [HttpGet("{pub_id}")]
        public ActionResult<Publisher> Get(string pub_id)
        {
            return _context.Publishers.Find(pub_id);
        }

        [HttpPost]
        public ActionResult Post(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{pub_id}")]
        public ActionResult Put(string pub_id, [FromBody] Publisher publisher)
        {
            if (pub_id != publisher.PubId)
            {
                return BadRequest();
            }

            _context.Entry(publisher).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{pub_id}")]
        public ActionResult<Publisher> Delete(string pub_id)
        {
            var publisher = _context.Publishers.Find(pub_id);

            if (publisher == null)
            {
                return NotFound();
            }

            _context.Publishers.Remove(publisher);
            _context.SaveChanges();

            return publisher;
        }

        [HttpGet("GetByCity/{city}")]
        public IEnumerable<Publisher> GetByCity(string city)
        {
            var publisher = (from p in _context.Publishers where p.City.Contains(city) select p).ToList();
            return publisher;
        }
    }
}
