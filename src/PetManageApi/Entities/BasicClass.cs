using System;
using System.ComponentModel.DataAnnotations;

namespace PetManageApi.Entities;

public class BasicClass
{
    [MaxLength(100)]
    public string? RegisterUserRef { get; set; }
    public DateTime? RegisterTime { get; set; }
    [MaxLength(100)]
    public string? UpdateUserRef { get; set; }
    public DateTime? UpdateTime { get; set; }
    [MaxLength(100)]
    public string? DeleteUserRef { get; set; }
    public DateTime? DeleteTime { get; set; }
    public bool IsDelete { get; set; }
}
