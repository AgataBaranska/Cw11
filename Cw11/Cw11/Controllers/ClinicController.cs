using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.DTOs.Requests;
using Cw11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Controllers
{
    [Route("api/clinic")]
    [ApiController]
    public class ClinicController : ControllerBase
    {

        private readonly ClinicDbContext _context;

        public ClinicController(ClinicDbContext context)
        {
            _context = context;
        }

     
        //Pobierz dane lekarzy
        [HttpGet("doctors")]
        public IActionResult GetDoctorsData()
        {
            return Ok(_context.Doctors.ToList());
        }

        //Pobierz dane lekarza o Id
        [HttpGet("{IdDoctor}")]
        public IActionResult GetDoctorData([FromRoute]int IdDoctor)
        {
            var res = _context.Doctors
                .Where(d => d.IdDoctor == IdDoctor)
                .FirstOrDefault();
            if (res == null) return BadRequest($"W bazie nie ma doktora o id {IdDoctor}");

            return Ok(res);
        }

        //Dodaj nowego lekarza
        [HttpPost]
        public IActionResult AddDoctor([FromBody] AddDoctorRequest request)
        {
            var doctor = new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            _context.Doctors.Add(doctor);
            _context.SaveChanges();


            var res = _context.Doctors
              .Where(d => d.FirstName == request.FirstName && d.LastName == request.LastName)
              .FirstOrDefault();
            if (res == null) return BadRequest($"Doktor nie dodany do bazy");

            return Ok("Dodano nowego doktora do bazy " + doctor);
        }

        //Zmodyfikuj dane lekarza o Id
        [HttpPost("{IdDoctor}")]
        public IActionResult ModifyDoctroData([FromBody] UpdateDoctorRequest request, [FromRoute] int IdDoctor)
        {

            var res = _context.Doctors
                .Where(d => d.IdDoctor == IdDoctor)
                .FirstOrDefault();
            if (res == null) return BadRequest($"W bazie nie ma doktora o podanym numerze id: {IdDoctor}");


            var doctor = new Doctor
            {
                IdDoctor = IdDoctor,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email

            };

            _context.Attach(doctor);

            if (request.FirstName != null) _context.Entry(doctor).Property("FirstName").IsModified = true;

            if (request.LastName != null) _context.Entry(doctor).Property("LastName").IsModified = true;



            if (request.Email != null) _context.Entry(doctor).Property("Email").IsModified = true;

            _context.SaveChanges();

            return Ok($"Zmodyfikowano dane Doktora o id: {IdDoctor}" + doctor);

        }

        //Usuń lekarza o Id
        [HttpDelete("{IdDoctor}")]
        public IActionResult DeleteDoctor([FromRoute] int IdDoctor)
        {
            var doctor = new Doctor
            {
                IdDoctor = IdDoctor
            };
            _context.Attach(doctor);
            _context.Remove(doctor);
            _context.SaveChanges();

            return Ok($"Usunięto doktora o id: {IdDoctor} z bazy");
        }

        

    }
}
