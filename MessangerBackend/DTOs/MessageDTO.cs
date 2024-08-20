namespace MessangerBackend.DTOs;

public class MessageDTO
{
    public int SenderId { get; set; }
    public int ChatId { get; set; }
    public string Text { get; set; }
}

public class ShowMessageDTO
{
    public string Sender { get; set; }
    public DateTime SentAt { get; set; }
    public string Text { get; set; }
}