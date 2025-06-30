using System;
using System.Collections.Generic;

namespace Data;

public partial class Asistencia
{
    public int Idasistencia { get; set; }

    public int Idinvestigador { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraEntrada { get; set; }

    public TimeOnly? HoraSalida { get; set; }

    public virtual Investigador IdinvestigadorNavigation { get; set; } = null!;
}
