using System;
using System.ComponentModel.DataAnnotations;

namespace PetManageApi.Entities;

public class UserInformation : BasicClass
{
    public int Id { get; set;} 
    [MaxLength(100)] 
    public string? FirstName { get; set; }
    [MaxLength(100)]
    public string? LastName { get; set;}
    [MaxLength(100)]
    public string? Email { get; set; }
    [MaxLength(100)]
    public string? PhoneNumber { get; set; } 
    [MaxLength(500)]
    public string? Address { get; set; }
    [MaxLength(100)]
    public string? UserId { get; set; }
}
