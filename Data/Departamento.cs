using System;
using System.Collections.Generic;

namespace Data;

public partial class Departamento
{
    public int Iddepartamento { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Investigador> Idinvestigadors { get; set; } = new List<Investigador>();
}
