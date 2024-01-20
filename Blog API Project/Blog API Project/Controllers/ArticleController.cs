using Blog_API_Project.Models;
using Blog_API_Project.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blog_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _Article;
        public ArticleController(IArticleRepository Article)
        {
            _Article = Article ??
                throw new ArgumentNullException(nameof(Article));
        }
        [HttpGet]
        [Route("GetArticle")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Article.GetArticle());
        }
        [HttpGet]
        [Route("GetArticleByID/{Id}")]
        public async Task<IActionResult> GetArticleById(int Id)
        {
            return Ok(await _Article.GetArticleByID(Id));
        }

        [HttpPost]
        [Route("AddArticle")]
        public async Task<IActionResult> PostArticle(String ArticleName, string ArticleContent, int AuthorID)
        {
            Article art = new Article();
            art.Ar_Name = ArticleName;
            art.Ar_Content = ArticleContent;
            art.Ar_AuthorID = AuthorID;
            var result = await _Article.InsertArticle(art);
            if (result.Ar_ID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateArticle")]
        public async Task<IActionResult> PutArticle(Article art)
        {
            await _Article.UpdateArticle(art);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteArticle")]
        public JsonResult DeleteArticle(int id)
        {
         
            _Article.DeleteArticle(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
