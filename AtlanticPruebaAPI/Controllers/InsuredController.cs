using AtlanticPruebaAPI.Context;
using AtlanticPruebaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Route("GetAllInsured/{page:int}/{num:int}")]
        public IEnumerable<InsuredModel> GetAllInsured(int num, int page) =>_context.Insured.Skip(num*page).Take(num).ToList();

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

            _context.Insured.Add(insuredToAdd);
            _context.SaveChanges();

            return Ok(insuredToAdd);
        }

        [HttpPut]
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
        public IActionResult DeleteInsured(int id, InsuredModel insured)
        {
            var insuredToDelete = _context.Insured.Find(id);

            if (insuredToDelete == null) { return NotFound(); }

            _context.Insured.Remove(insuredToDelete);

            _context.SaveChanges();

            return Ok(insuredToDelete);
        }

        [HttpGet]
        [Route("GetInsuredById/{id:int}")]
        public IEnumerable<InsuredModel> GetInsuredById (int id)
        {
            return _context.Insured.Where(x => x.Id == id).ToList();
        }

    }
}
