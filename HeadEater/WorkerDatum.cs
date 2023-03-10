using System;
using System.Collections.Generic;

namespace HeadEater;

public partial class WorkerDatum
{
    public long WorkerId { get; set; }

    public long? LoginId { get; set; }

    public long? Status { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public string? Telephone { get; set; }

    public string? Mail { get; set; }

    public virtual Auth? Login { get; set; }

    public virtual ICollection<VacancyRequest> VacancyRequests { get; } = new List<VacancyRequest>();
}
