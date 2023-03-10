using System;
using System.Collections.Generic;

namespace HeadEater;

public partial class VacancyRequest
{
    public long ReqId { get; set; }

    public long? VacId { get; set; }

    public long? WorkerId { get; set; }

    public string? Position { get; set; }

    public long? Salary { get; set; }

    public string? Discription { get; set; }

    public long? Status { get; set; }

    public virtual VacancyDatum? Vac { get; set; }

    public virtual WorkerDatum? Worker { get; set; }
}
