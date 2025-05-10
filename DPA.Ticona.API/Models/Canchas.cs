using System;
using System.Collections.Generic;

namespace DPA.Ticona.API.Models;

public partial class Canchas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Tipo { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
