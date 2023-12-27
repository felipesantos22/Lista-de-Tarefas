using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace list.Domain.Entities;

public class Task
{
    [Key]
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public int UserId { get; set; }
    
    [JsonIgnore]
    public User User { get; set; }
    
}