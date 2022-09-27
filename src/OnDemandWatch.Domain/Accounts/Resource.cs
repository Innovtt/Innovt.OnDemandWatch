using System.Diagnostics.Contracts;
using Innovt.Domain.Core.Model;

namespace OnDemandWatch.Domain.Accounts;

public class Resource : Entity<Guid>
{
    public string? Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    public ResourceType? Type { get; set; } 

    //tem que definir aqui o tipo de scalle que tem para cada tipo.  

    //preciso saber o tipo de resource ?/
    //posso ter um agendamento ou ficar escutando e setar um, valor, mudar de ondemand para fixo para nao estourar. 




}