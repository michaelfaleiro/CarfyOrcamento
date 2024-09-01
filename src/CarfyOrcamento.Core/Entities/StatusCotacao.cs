namespace CarfyOrcamento.Core.Entities;

public class StatusCotacao : Entity
{
    public StatusCotacao(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
}