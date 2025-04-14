namespace LearnEF.Dtos;

public record CommentDto {
    
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;
    
}