﻿using System;
using System.Collections.Generic;

namespace DPA.Ticona.API.Models;

public partial class Reservas
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public string? ClienteNombre { get; set; }

    public int CanchaId { get; set; }

    public virtual Canchas Cancha { get; set; } = null!;
}
