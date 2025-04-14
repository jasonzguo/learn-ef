namespace LearnEF.Models;

public record Comment {
    
    public int Id { get; set; }

    public int PostId { get; set; }

    public string Message { get; set; } = string.Empty;
    
}