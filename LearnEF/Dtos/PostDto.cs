namespace LearnEF.Dtos;

public record PostDto {
    
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    
}