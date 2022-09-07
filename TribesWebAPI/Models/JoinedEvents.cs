
public class JoinedEvents
{
    public int Id { get; set; }
    public int UserID { get; set; }
    public int EventID { get; set; }
    public User? User { get; set; }
    public EventModel? Event { get; set; }
}

