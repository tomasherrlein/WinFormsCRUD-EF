using System;
using System.Collections.Generic;

namespace Data;

public partial class Investigador
{
    public int Idinvestigador { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<Departamento> Iddepartamentos { get; set; } = new List<Departamento>();
}
