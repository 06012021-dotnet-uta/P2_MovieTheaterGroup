using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer;
using MapperClasses;
using RepositoryLayer;
using Microsoft.AspNetCore.Http;

namespace P2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _comment;
        private readonly P2Context _context;

        public CommentController(ICommentService comment, P2Context context)
        {
            _context = context;
            _comment = (CommentService)comment;
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task PostACommentAsync([FromBody] CommentMapBasic value)
        {
            await _comment.CreateCommentAsync(value);
        }

        // GET api/<CommentController>/5
        [HttpGet("[action]/{movieid}")]
        public List<CommentMapWithUser> GetAllCommentsForMovie(string movieid)
        {
            return _comment.ReadCommentsForOneMovie(movieid);
        }

        // GET api/<CommentController>/5
        [HttpGet("[action]/{userid}")]
        public List<CommentMapWithMovie> GetAllCommentsForUser(int userid)
        {
            return _comment.ReadCommentsForOneUser(userid);
        }

        // PUT api/<CommentController>
        [HttpPut]
        public async Task PutACommentAsync([FromBody] CommentMapUpdate value)
        {
            await _comment.UpdateCommentAsync(value);
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{commentid}")]
        public async Task DeleteACommentAsync(int commentid)
        {
            await _comment.DeleteCommentAsync(commentid);
        }
    }
}
