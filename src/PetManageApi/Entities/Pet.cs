using System;
using System.ComponentModel.DataAnnotations;

namespace PetManageApi.Entities;

public class Pet : BasicClass
{
    public int Id { get; set; }
    [MaxLength(100)]
    public required string PetGuid { get; set; }
    [MaxLength(150)]
    public required string Name { get; set; }
    public DateTime Birthday { get; set; }
    [MaxLength(150)]
    public string? IdNumber { get; set; }
    [MaxLength(150)]
    public string? ChipsetNumber { get; set; }
    [MaxLength(150)]
    public string? ImageSysName  { get; set; }
    [MaxLength(150)]
    public string? ImageOrginalName { get; set; }

    public int PetKindId { get; set; }
    public required PetKind PetKind;
    public required Gender Gender;
}
