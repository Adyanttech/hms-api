using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("tokens")]
public partial class Token
{
    [Key]
    [Column("tokenid")]
    public int Tokenid { get; set; }

    [Column("appointmentid")]
    public int Appointmentid { get; set; }

    [Column("tokennumber")]
    public int Tokennumber { get; set; }

    [Column("isserved")]
    public bool Isserved { get; set; }

    [Column("generatedat", TypeName = "timestamp without time zone")]
    public DateTime Generatedat { get; set; }

    [Column("servedat", TypeName = "timestamp without time zone")]
    public DateTime? Servedat { get; set; }

    [ForeignKey("Appointmentid")]
    [InverseProperty("Tokens")]
    public virtual Appointment Appointment { get; set; } = null!;
}
