using System.ComponentModel.DataAnnotations;


public class User
{
    public int Id { get; set; }      
    public string? Email { get; set; }       
    public string? Password { get; set; }      
    public string? FirstName { get; set; }     
    public string? LastName { get; set; }
    public int? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
}

