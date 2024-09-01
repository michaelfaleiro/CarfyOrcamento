namespace CarfyOrcamento.Core.Entities;

public class StatusOrcamento : Entity
{
    public StatusOrcamento(string nome)
    {
        Nome = nome;
    }
    
    public string Nome { get; set; }
}