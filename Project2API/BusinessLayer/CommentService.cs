using System;
using RepositoryLayer;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessLayer;
using ModelsLayer;

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
        DateTime current = DateTime.Now;

        /// <summary>
        /// Creates a comment in the database.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="movieid"></param>
        /// <param name="content"></param>
        public async void CreateCommentAsync(Comment comment)
        {
            _context.Add(comment);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes a comment from the database.
        /// </summary>
        /// <param name="commentid"></param>
        public async void DeleteCommentAsync(int commentid)
        {
            var comment = _context.Comments.Where(x => x.CommentId == commentid).FirstOrDefault();
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Updates a comment in the database.
        /// </summary>
        /// <param name="commentid"></param>
        /// <param name="content"></param>
        public async void UpdateCommentAsync(int commentid, string content)
        {
            var comment = _context.Comments.Where(x => x.CommentId == commentid).FirstOrDefault();
            comment.Content = content;
            comment.DateMade = current;
            _context.Update(comment);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all comments for one movie from the database.
        /// </summary>
        /// <param name="movieid"></param>
        /// <returns>Returns a list of strings.</returns>
        public List<string> ReadCommentsForOneMovie(string movieid)
        {
            var comments = _context.Comments.Where(x => x.MovieId == movieid).Select(x => x.Content).ToList();
            return comments;
        }

        /// <summary>
        /// Gets all comments for one user from the database.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>Returns a list of strings.</returns>
        public List<string> ReadCommentsForOneUser(int userid)
        {
            var comments = _context.Comments.Where(x => x.UserId == userid).Select(x => x.Content).ToList();
            return comments;
        }
    }
}