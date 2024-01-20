using Blog_API_Project.Models;
using Blog_API_Project.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blog_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository _Authors;
        private readonly IArticleRepository _Article;
        public AuthorsController(IAuthorsRepository Authors, IArticleRepository Article)
        {
            _Authors = Authors ??
                throw new ArgumentNullException(nameof(Authors));
            _Article = Article ??
                throw new ArgumentNullException(nameof(Article));
        }

        [HttpGet]
        [Route("GetAuthors")]
        public async Task<IActionResult> GetTheAuthors()
        {
            return Ok(await _Authors.GetAuthors());
        }
        [HttpGet]
        [Route("GetAuthorsByID/{Id}")]
        public async Task<IActionResult> GetAuthorsByID(int Id)
        {
            return Ok(await _Authors.GetAuthorsByID(Id));
        }
        [HttpPost]
        [Route("AddAuthors")]
        public async Task<IActionResult> PostAuthors(String AuthorName , int AuthorAge, String AuthorAddress)
        {
            Authors ar= new Authors();
            ar.A_Name = AuthorName;
            ar.A_AGE = AuthorAge;
            ar.A_Address = AuthorAddress;

            var result = await _Authors.InsertAuthors(ar);
            if (result.A_ID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateAuthors")]
        public async Task<IActionResult> PutAuthors(int id, String AuthorName, int AuthorAge, String AuthorAddress)
        {
            Authors ar = new Authors();
            ar.A_ID = id;
            ar.A_Name = AuthorName;
            ar.A_AGE = AuthorAge;
            ar.A_Address = AuthorAddress;
            await _Authors.UpdateAuthors(ar);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteAuthors")]
        public JsonResult DeleteAuthors(int id)
        {
            var result = _Authors.DeleteAuthors(id);
            return new JsonResult("Deleted Successfully");
        }

        [HttpGet]
        [Route("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthorsNames()
        {
            return Ok(await _Authors.GetAuthors());
        }
    }
}
