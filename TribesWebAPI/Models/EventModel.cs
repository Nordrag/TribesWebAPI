using System.ComponentModel.DataAnnotations;

public class EventModel
{
    public int Id { get; set; } 
    public User? CreatedBy { get; set; }
    public string? EventTitle { get; set; }
    public string? EventDescription { get; set; }   
    public DateTime CreatedDate { get; set; }   
    public DateTime StartDate { get; set; }   
    public EventMetaType MetaType { get; set; }
    public List<TagsUsed>? Subtags { get; set; }
    public List<JoinedEvents>? PeopleJoined { get; set; }
    public List<RequestedPeople>? RequestedPeople { get; set; }
    public int MaxAllowed { get; set; } = 1;
}

public enum EventMetaType { Nature, Travel, Drinking, Party, Sports }



