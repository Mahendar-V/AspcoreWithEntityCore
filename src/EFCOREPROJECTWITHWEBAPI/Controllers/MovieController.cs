using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCOREPROJECTWITHWEBAPI.Models;
using EFCOREPROJECTWITHWEBAPI.Controllers;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCOREPROJECTWITHWEBAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    public class MovieController : Controller
    {
        private readonly DatabaseContex _contex;
        private readonly ILogger _logger;
        public MovieController(DatabaseContex context,ILogger<MovieController> logger)
        {
            _contex = context;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<MovieModel> GetMovies()
        {
            _logger.LogDebug("Get The movies List");
            return _contex.Movies;
        }

        [HttpGet("{id}")]
        public MovieModel GetMovie(int id)
        {
            _logger.LogDebug("Get The movie...");
            return _contex.Movies.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public void Post([FromBody]MovieModel value)
        {
            if(ModelState.IsValid)
            {
                _logger.LogDebug("movie Deleted...");
                _contex.Movies.Add(value);
                _contex.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var model = _contex.Movies.FirstOrDefault(s => s.Id == id);
            if (model != null)
            {
                _contex.Movies.Remove(model);
                _contex.SaveChanges();
            }
        }
    }
}
