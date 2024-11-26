using System;
using System.ComponentModel.DataAnnotations;

namespace PetManageApi.Entities;

public class PetKind
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string? Name { get; set; }
}
