using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLiabrary.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthrosController : ControllerBase // we could use Controller but that's not usable for APIs
    {
        // As we are not going to change this instance, readyonly is used
        private readonly ICourseLibraryRepository _courseLiabraryRepository;

        public AuthrosController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLiabraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
        }
        // IActionResult deifines a contract that represents a result of an action
        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _courseLiabraryRepository.GetAuthors();
            return Ok(authorsFromRepo);
            // return new JsonResult(authorsFromRepo);
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLiabraryRepository.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(authorFromRepo);
            //return new JsonResult(authorFromRepo);
        }
    }
}
