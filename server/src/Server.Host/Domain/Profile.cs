using System;
using System.Collections.Generic;

namespace Server.Host.Domain;

public class Profile
{
    public Guid Id { get; private init; }
    public string Name { get; set; } = string.Empty;
    public List<ProfileField> Fields { get; set; } = new();
}
