using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud_Operations_using_.NetCore_WebAPI.Models;

namespace Crud_Operations_using_.NetCore_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandContext _context;

        public BrandsController(BrandContext context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            var brands = await _context.Brands
                .Select(b => new Brand
                {
                    ID = b.ID,
                    Name = b.Name,
                    Category = b.Category,
                    IsActive = b.IsActive
                })
                .ToListAsync();

            return Ok(brands);
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            var brands = new Brand
            {
                ID = brand.ID,
                Name = brand.Name,
                Category = brand.Category,
                IsActive = brand.IsActive
            };

            return Ok(brands);
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            var brands = new Brand
            {
                Name = brand.Name,
                Category = brand.Category,
                IsActive = brand.IsActive
            };

            _context.Brands.Add(brands);
            await _context.SaveChangesAsync();

            // Return the created brand as DTO
            return CreatedAtAction(nameof(GetBrand), new { id = brand.ID }, new Brand
            {
                ID = brand.ID,
                Name = brand.Name,
                Category = brand.Category,
                IsActive = brand.IsActive
            });
        }

        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = brand.ID }, brand);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.ID == id);
        }
    }
}
