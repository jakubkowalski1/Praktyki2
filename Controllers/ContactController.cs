using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektPraktyki_2._0.Models;
using System;

namespace ProjektPraktyki_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly CompanyContext _dbContext;

        public ContactController(CompanyContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContact()
        {
            return await _dbContext.Contacts.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            if (_dbContext.Contacts == null)
            {
                return NotFound();
            }
            var contact = await _dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return contact;
        }

        [HttpPost]

        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContact), new { id = contact.ID }, contact);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult> PutContact(int id, Contact contact)
        {
            if (id != contact.ID)
            {
                return BadRequest();
            }
            _dbContext.Entry(contact).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();

        }

        private bool ContactAvailable(int id)
        {
            return (_dbContext.Contacts?.Any(x => x.ID == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            if (_dbContext.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _dbContext.Contacts.Remove(contact);

            await _dbContext.SaveChangesAsync();

            return Ok();

        }
    }
}