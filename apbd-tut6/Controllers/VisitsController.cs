namespace apbd_tut6.Controllers;

using apbd_tut6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    // GET api/visits
    [HttpGet]
    public IActionResult Get()
    {
        var visits = Database.Visits;
        return Ok(visits);
    }

    // Get visits for an animal Id associated with those visits
    // GET api/visits/{animal_id}
    [HttpGet("{id}")]
    public IActionResult GetByAnimalId([FromRoute] int id)
    {
        var visit = Database.Visits.FirstOrDefault(x => x.Animal.Id == id);
        return Ok(visit);
    }
        
    // POST api/visits {}
    [HttpPost]
    public IActionResult Post([FromBody] Visit visit)
    {
        Database.Visits.Add(visit);
        return Created();
    }

    // PUT api/visits/{animal_id} {}
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] int id, [FromBody] Visit newVisit)
    {
        Visit? visit = Database.Visits.FirstOrDefault(x => x.Id == id);
        if (visit == null)
            return NoContent();
        Database.Visits.Remove(visit);
        Database.Visits.Insert(id, newVisit);
        return Ok(newVisit);
    }
        
    // DELETE api/visits/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var visit = Database.Visits.FirstOrDefault(x => x.Id == id);
        Database.Animals.Remove(visit);
        return Ok(visit);
    }
}