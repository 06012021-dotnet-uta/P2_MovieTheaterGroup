using System.Collections.Generic;
using ModelsLayer;

namespace BusinessLayer
{
    public interface ICommentService
    {
        void CreateCommentAsync(Comment comment);
        void DeleteCommentAsync(int commentid);
        List<string> ReadCommentsForOneMovie(string movieid);
        List<string> ReadCommentsForOneUser(int userid);
        void UpdateCommentAsync(int commentid, string content);
    }
}