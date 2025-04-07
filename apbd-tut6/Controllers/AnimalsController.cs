using apbd_tut6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apbd_tut6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        // GET api/animals
        [HttpGet]
        public IActionResult Get()
        {
            var animals = Database.Animals;
            return Ok(animals);
        }

        // GET api/animals/{id}
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
            return Ok(animal);
        }
        
        // POST api/animals {}
        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
            Database.Animals.Add(animal);
            return Created();
        }

        // PUT api/animals/{id} {}
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Animal newAnimal)
        {
            Animal? animal = Database.Animals.FirstOrDefault(x => x.Id == id);
            if (animal == null)
                return NoContent();
            Database.Animals.Remove(animal);
            Database.Animals.Insert(id, newAnimal);
            return Ok(newAnimal);
        }
        
        // DELETE api/animals/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
            Database.Animals.Remove(animal);
            return Ok(animal);
        }
    }
}
