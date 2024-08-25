using AtlanticPruebaAPI.Context;
using AtlanticPruebaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AtlanticPruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredController : ControllerBase
    {
        private InsuredContext _context;
        public InsuredController(InsuredContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetInsured")]
        public IEnumerable<InsuredModel> GetInsured(int? id = null)
        {
            if (id.HasValue)
            {
                return _context.Insured.Where(x => x.Id == id).ToList();
            }
            else
            {
                return _context.Insured.ToList();
            }
        }
           

        [HttpPost]
        [Route("AddInsured")]
        public IActionResult AddInsured (InsuredModel insured) {
            var insuredToAdd = new InsuredModel()
            {
                Id = insured.Id,
                FirstName = insured.FirstName,
                SecondName = insured.SecondName,
                FirstLastName = insured.FirstLastName,
                SecondLastName = insured.SecondLastName,
                Email = insured.Email,
                Phone = insured.Phone,
                BirthDate = insured.BirthDate,
                Value = insured.Value,
                Observations = insured.Observations
            };

            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT Insured ON;");
                _context.Insured.Add(insuredToAdd);
                _context.SaveChanges();
                _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT Insured OFF;");
                transaction.Commit();
            }


            return Ok(insuredToAdd);
        }

        [HttpPatch]
        [Route("UpdateInsured/{id:int}")]
        public IActionResult UpdateInsured (int id, InsuredModel insured)
        {
            var insuredToUpdate = _context.Insured.Find(id);

            if (insuredToUpdate == null) { return NotFound(); }

            insuredToUpdate.FirstName = insured.FirstName;
            insuredToUpdate.FirstLastName = insured.FirstLastName;
            insuredToUpdate.SecondName = insured.SecondName;
            insuredToUpdate.SecondLastName = insured.SecondLastName;
            insuredToUpdate.Email = insured.Email;
            insuredToUpdate.Phone = insured.Phone;
            insuredToUpdate.BirthDate = insured.BirthDate;
            insuredToUpdate.Value = insured.Value;
            insuredToUpdate.Observations = insured.Observations;

            _context.SaveChanges();

            return Ok(insuredToUpdate);
        }

        [HttpDelete]
        [Route("DeleteInsured/{id:int}")]
        public IActionResult DeleteInsured(int id)
        {   
            var insuredToDelete = _context.Insured.Find(id);
            if (insuredToDelete == null) { return NotFound(); }
            _context.Insured.Remove(insuredToDelete);
            _context.SaveChanges();
            return Ok(insuredToDelete);
        }

    }
}
