using System;
using System.Collections.Generic;

namespace HeadEater;

public partial class OrganizationDatum
{
    public long OrgId { get; set; }

    public long? LoginId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Mail { get; set; }

    public string? Telephone { get; set; }

    public string? Addres { get; set; }

    public virtual Auth? Login { get; set; }

    public virtual ICollection<VacancyDatum> VacancyData { get; } = new List<VacancyDatum>();
}
