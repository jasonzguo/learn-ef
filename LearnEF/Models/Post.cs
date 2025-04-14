namespace LearnEF.Models;

public record Post {
    
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<Comment> Comments { get; set; } = new List<Comment>();
    
}