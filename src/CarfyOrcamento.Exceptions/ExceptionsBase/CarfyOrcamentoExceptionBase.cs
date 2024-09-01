using System.Net;

namespace CarfyOrcamento.Exceptions.ExceptionsBase;

public abstract class CarfyOrcamentoExceptionBase(string message) : SystemException(message)
{
    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessages();
}