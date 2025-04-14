using LearnEF.DbContexts;
using LearnEF.Models;

namespace LearnEF.Services;

public interface IPostService {
    public Post CreateOne(Post newPost);
    public List<Post> GetMany();
    public Post UpdateOne(int id, Post updatedPost);
}

public class PostService : IPostService {

    private readonly TestDbContext _testDbContext;

    public PostService(TestDbContext testDbContext) {
        _testDbContext = testDbContext;
    }

    public Post CreateOne(Post newPost)
    {
        _testDbContext.Posts.Add(newPost);
        _testDbContext.SaveChanges();
        return newPost;
    }

    public List<Post> GetMany()
    {
        return _testDbContext.Posts.ToList();
    }

    public Post UpdateOne(int id, Post updatedPost)
    {
        var post = _testDbContext.Posts
            .Where(p => p.Id == id)
            .FirstOrDefault();

        if (post is null) {
            throw new ArgumentException($"post not found with id={id}");
        }

        var commentIds = updatedPost.Comments.Select(c => c.Id).ToList();

        var comments = _testDbContext.Comments
            .Where(c => c.PostId == id && !commentIds.Contains(c.Id))
            .AsEnumerable ();
        if (comments.Any()) {
            _testDbContext.Comments.RemoveRange(comments);
        }

        post.Message = updatedPost.Message;
        post.Comments = updatedPost.Comments;

        _testDbContext.SaveChanges();

        return post;
    }
}