using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("email")]
    public string? Email { get; set; }

    [Column("phonenumber")]
    public string? Phonenumber { get; set; }

    [Column("passwordhash")]
    public string? Passwordhash { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("hospital_id")]
    public int? HospitalId { get; set; }

    [Column("roleid")]
    public Guid? Roleid { get; set; }

    [ForeignKey("HospitalId")]
    [InverseProperty("Users")]
    public virtual Hospitalregistration? Hospital { get; set; }

    [ForeignKey("Roleid")]
    [InverseProperty("Users")]
    public virtual Role? Role { get; set; }
}
