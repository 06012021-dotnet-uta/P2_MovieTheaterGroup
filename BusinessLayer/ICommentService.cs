using System.Collections.Generic;
using System.Threading.Tasks;
using MapperClasses;

namespace BusinessLayer
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CommentMapBasic comment);
        List<CommentMapWithUser> ReadCommentsForOneMovie(string movieid);
        List<CommentMapWithMovie> ReadCommentsForOneUser(int userid);
        Task UpdateCommentAsync(CommentMapUpdate newcomment);
        Task DeleteCommentAsync(int commentid);
    }
}
