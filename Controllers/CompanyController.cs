using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjektPraktyki_2._0.Models;

namespace ProjektPraktyki_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyContext _dbContext;

        public CompanyController(CompanyContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompany()
        {
            if(_dbContext.Companys == null)
            {
                return NotFound();
            }
            return await _dbContext.Companys.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            if (_dbContext.Companys == null)
            {
                return NotFound();
            }
            var Company = await _dbContext.Companys.FindAsync(id);
            if (Company == null) 
            {
                return NotFound();
            }
            return Company;
        }

        [HttpPost]

        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            _dbContext.Companys.Add(company);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompany), new { id = company.ID }, company);
        }

        [HttpPut]

        public async Task<ActionResult> PutCompany(int id, Company company)
        {
            if(id != company.ID)
            {
                return BadRequest();
            }
            _dbContext.Entry(company).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                if(!CompanyAvailable(id))
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
        private bool CompanyAvailable(int id)
        {
            return (_dbContext.Companys?.Any(x => x.ID == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            if(_dbContext.Companys == null)
            {
                return NotFound();
            }

            var company = await _dbContext.Companys.FindAsync(id);
            if(company == null)
            {
                return NotFound();
            }
            
                _dbContext.Companys.Remove(company);

                await _dbContext.SaveChangesAsync();

                return Ok();
            
        }

    }
}
