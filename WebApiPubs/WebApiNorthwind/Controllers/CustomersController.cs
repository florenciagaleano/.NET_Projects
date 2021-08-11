using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNorthwind.Contexto;
using WebApiNorthwind.Entidades;

namespace WebApiNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            //usamos EF para traer a las personas
            return _context.Customers.ToList();
        }


        //para retornar un objeto usamos el tipo ActionResult<Customer> y usamos EF para buscar la persona por ID
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            //usamos EF para traer a las personas
            return _context.Customers.Find(id);
        }

        //insertar
        [HttpPost]
        public ActionResult Post(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObtenerPersona", new { id = customer.CustomerID }, customer);
        }

        [HttpPut("{CustomerID}")]
        public ActionResult Put(string CustomerID, [FromBody] Customer customer)
        {
            if (CustomerID != customer.CustomerID)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{CustomerID}")]
        public ActionResult<Customer> Delete(string CustomerID)
        {
            var customer = _context.Customers.Find(CustomerID);

            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return customer;
        }

        [HttpGet("GetByContactTitle/{ContactTitle}")]
        public IEnumerable<Customer> GetByCity(string ContactTitle)
        {
            var customer = (from p in _context.Customers where p.ContactTitle.Contains(ContactTitle) select p).ToList();
            return customer;
        }
    }
}
