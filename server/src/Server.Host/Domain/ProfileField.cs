using System;

namespace Server.Host.Domain;

public class ProfileField
{
    public Guid Id { get; private init; }
    public Guid ProfileId { get; private init; }
    public Profile Profile { get; private init; } = default!;
}
