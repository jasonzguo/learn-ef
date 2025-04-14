using System.Net.Mime;
using LearnEF.Dtos;
using LearnEF.Mappers;
using LearnEF.Models;
using LearnEF.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnEF.Controllers;

[ApiController]
[Route("api/v1/posts")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;

    private readonly IPostService _postService;


    public PostController(ILogger<PostController> logger, IPostService postService)
    {
        _logger = logger;
        _postService = postService;
    }

    [HttpPost(Name = "CreatePost")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public PostDto CreateOne([FromBody] PostDto postDto)
    {
        var post = PostMapper.ToDomain(postDto);
        return PostMapper.ToDto(_postService.CreateOne(post));
    }

    [HttpGet(Name = "GetPosts")]
    [Produces("application/json")]
    public IEnumerable<PostDto> GetMany()
    {
        return _postService.GetMany().Select(PostMapper.ToDto).ToList();
    }

    [HttpPut("{id}", Name = "UpdatePost")]
    [HttpPut]
    [Consumes("application/json")]
    [Produces("application/json")]
    public PostDto UpdateOne(int id, [FromBody] PostDto postDto)
    {
        var post = PostMapper.ToDomain(postDto);
        return PostMapper.ToDto(_postService.UpdateOne(id, post));
    }
}
