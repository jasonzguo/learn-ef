using LearnEF.Dtos;
using LearnEF.Models;

namespace LearnEF.Mappers;

public class PostMapper {

    public static Post ToDomain(PostDto dto) {
        return new Post() {
            Message = dto.Message,
            Comments = dto.Comments.Select(item => {
                return new Comment() {
                    Id = item.Id,
                    Message = item.Message
                };
            }).ToList()
        };
    }

    public static PostDto ToDto(Post domain) {
        return new PostDto() {
            Id = domain.Id,
            Message = domain.Message,
            Comments = domain.Comments.Select(item => {
                return new CommentDto() {
                    Id = item.Id,
                    Message = item.Message
                };
            }).ToList()
        };
    }

}