using CRM.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult get()
        {
            var categories =  _dbContext.Category.ToList();
            return Ok(categories);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("Details")]
        public ActionResult get(int id)
        {
            var category = _dbContext.Category.FirstOrDefault(x=>x.Id == id);

            if (category == null) 
            {
                return NotFound();
            }
            return Ok(category);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult Create([FromBody] Models.Category category)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Category.Add(category);
            _dbContext.SaveChanges();
            return Ok(category);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public ActionResult Update([FromBody] Models.Category category)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Category.Update(category);
            _dbContext.SaveChanges();
            return Ok(category);
        }
    }
}
