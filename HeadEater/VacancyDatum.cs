using System;
using System.Collections.Generic;

namespace HeadEater;

public partial class VacancyDatum
{
    public long VacId { get; set; }

    public long? OrgId { get; set; }

    public string? Position { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public long? Salary { get; set; }

    public virtual OrganizationDatum? Org { get; set; }

    public virtual ICollection<VacancyRequest> VacancyRequests { get; } = new List<VacancyRequest>();
}
