using System.Diagnostics.Contracts;
using Innovt.Domain.Core.Model;

namespace OnDemandWatch.Domain.CloudProviders;

public class Service : Entity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    public ServiceType? Type { get; set; }

    //preciso saber o tipo de resource ?/
    //posso ter um agendamento ou ficar escutando e setar um, valor, mudar de ondemand para fixo para nao estourar. 




}