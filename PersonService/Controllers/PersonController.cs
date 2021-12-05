using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PersonService.Data;
using PersonService.Models;

namespace PersonService.Controllers
{
    public class PersonController : ApiController
    {
        private ApplicationDbContextContext db = new ApplicationDbContextContext();

        // GET: api/Person
        public IQueryable<PersonDTO> GetPerson()

        {

            var persons = from p in db.People

                          select new PersonDTO()

                          {

                              Id = p.Id,

                              LastName = p.LastName,

                              FirstName = p.FirstName,

                              SecondName = p.SecondName,

                              Role = p.Title.Role

                          };

            return persons;

        }

        // GET: api/Person/5
        [ResponseType(typeof(PersonDetailDTO))]

        public async Task<IHttpActionResult> GetPerson(int id)

        {

            var person = await db.People.Include(t => t.Title).Select(p =>

                new PersonDetailDTO()

                {

                    Id = p.Id,

                    LastName = p.LastName,

                    FirstName = p.FirstName,

                    SecondName = p.SecondName,

                    Role = p.Title.Role,

                    BirstDate = p.BirstDate,

                    Phone = p.Phone,

                    Email = p.Email

                }).SingleOrDefaultAsync(p => p.Id == id);

            if (person == null)

            {

                return NotFound();

            }

            return Ok(person);

        }

        // PUT: api/Person/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Person
        [ResponseType(typeof(Person))]

        public async Task<IHttpActionResult> PostPerson(Person person)

        {

            if (!ModelState.IsValid)

            {

                return BadRequest(ModelState);

            }

            db.People.Add(person);

            await db.SaveChangesAsync();



            // New code: 

            // Load Title role 

            db.Entry(person).Reference(x => x.Title).Load();

            var dto = new PersonDTO()

            {

                Id = person.Id,

                FirstName = person.FirstName,

                SecondName = person.SecondName,

                LastName = person.LastName,

                Role = person.Title.Role

            };

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, dto);

        }

        // DELETE: api/Person/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> DeletePerson(int id)
        {
            Person person = await db.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            await db.SaveChangesAsync();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.Id == id) > 0;
        }
    }
}