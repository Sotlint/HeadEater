using System;
using System.Collections.Generic;

namespace HeadEater;

public partial class Auth
{
    public long LoginId { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public long? Role { get; set; }

    public virtual OrganizationDatum? OrganizationDatum { get; set; }

    public virtual ICollection<WorkerDatum> WorkerData { get; } = new List<WorkerDatum>();
}
