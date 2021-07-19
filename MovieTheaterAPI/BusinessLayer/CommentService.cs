using RepositoryLayer;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModelsLayer;
using MapperClasses;

namespace BusinessLayer
{
    /// <summary>
    /// Contains methods for interacting with the Comments table in the database.
    /// </summary>
    public class CommentService : ICommentService
    {
        private readonly P2Context _context;

        /// <summary>
        /// Initializes an instance of the database models.
        /// </summary>
        /// <param name="context"></param>
        public CommentService(P2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a comment in the database.
        /// </summary>
        /// <param name="comment"></param>
        public async Task CreateCommentAsync(CommentMapBasic comment)
        {
            Comment _comment = new();
            _comment.Content = comment.Content;
            _comment.MovieId = comment.MovieId;
            _comment.UserId = comment.UserId;
            _comment.DateMade = System.DateTime.Now;
            _context.Comments.Add(_comment);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all comments for one movie from the database.
        /// </summary>
        /// <param name="movieid"></param>
        /// <returns>Returns a list of a custom data transmission object.</returns>
        public List<CommentMapWithUser> ReadCommentsForOneMovie(string movieid)
        {
            var comments = _context.Comments.Join(_context.Users, comment => comment.UserId, user => user.UserId, (comment, user) => new
            {
                CommentId = comment.CommentId,
                UserId = comment.UserId,
                DateMade = comment.DateMade,
                Content = comment.Content,
                MovieId = comment.MovieId,
                Username = user.Username
            }).Where(z => z.MovieId == movieid).ToList();
            List<CommentMapWithUser> commentlist = new();
            foreach (var result in comments)
            {
                CommentMapWithUser currentcomment = new()
                {
                    CommentId = result.CommentId,
                    UserId = result.UserId,
                    Username = result.Username,
                    DateMade = result.DateMade,
                    Content = result.Content,
                    MovieId = result.MovieId
                };
                commentlist.Add(currentcomment);
            }
            return commentlist;
        }

        /// <summary>
        /// Gets all comments for one user from the database.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>Returns a list of a custom data transmission object.</returns>
        public List<CommentMapWithMovie> ReadCommentsForOneUser(int userid)
        {
            var comments = _context.Comments.Join(_context.Movies, comment => comment.MovieId, movie => movie.MovieId, (comment, movie) => new 
            {
                CommentId = comment.CommentId,
                UserId = comment.UserId,
                DateMade = comment.DateMade,
                Content = comment.Content,
                MovieId = comment.MovieId,
                MovieName = movie.MovieName
            }).Where(z => z.UserId == userid).ToList();
            List<CommentMapWithMovie> commentlist = new();
            foreach (var result in comments)
            {
                CommentMapWithMovie currentcomment = new();
                    currentcomment.CommentId = result.CommentId;
                currentcomment.UserId = result.UserId;
                currentcomment.DateMade = result.DateMade;
                currentcomment.Content = result.Content;
                currentcomment.MovieId = result.MovieId;
                currentcomment.MovieName = result.MovieName;
                commentlist.Add(currentcomment);
            }
            return commentlist;
        }
        /// <summary>
        /// Updates a comment in the database.
        /// </summary>
        /// <param name="newcomment"></param>
        public async Task UpdateCommentAsync(CommentMapUpdate newcomment)
            {
                var comment = _context.Comments.Where(x => x.CommentId == newcomment.CommentId).FirstOrDefault();
                comment.Content = newcomment.Content;
                comment.DateMade = newcomment.DateMade;
                _context.Comments.
                Update(comment);
                await _context.SaveChangesAsync();
            }

            /// <summary>
            /// Deletes a comment from the database.
            /// </summary>
            /// <param name="commentid"></param>
            public async Task DeleteCommentAsync(int commentid)
        {
            var comment = _context.Comments.Where(x => x.CommentId == commentid).FirstOrDefault();
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}