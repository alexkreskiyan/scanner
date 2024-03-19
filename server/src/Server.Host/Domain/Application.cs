using System;
using System.Collections.Generic;

namespace Server.Host.Domain;

public class Application
{
    public Guid Id { get; private init; }
    public ApplicationStatus Status { get; private init; }
    public List<DocumentTypeConfiguration> DocumentTypes { get; set; } = new();
    public List<Guid> Files { get; set; } = new();
    public List<Document> Documents { get; set; } = new();
}
