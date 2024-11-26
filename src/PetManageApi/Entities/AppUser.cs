using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PetManageApi.Entities;

public class AppUser : IdentityUser
{
    [MaxLength(500)]
    public string? Token { get; set; }
    [MaxLength(10)]
    public string? ForgotPasswordCode { get; set; }
    public  DateTime? ForgotPasswordTimeStamp { get; set; }
    [MaxLength(300)]
    public string? GoogleToken { get; set; }
    public string? ProfileIcon { get; set;}

}
