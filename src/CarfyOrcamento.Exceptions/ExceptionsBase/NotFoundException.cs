using System.Net;

namespace CarfyOrcamento.Exceptions.ExceptionsBase;

public class NotFoundException(string message) : CarfyOrcamentoExceptionBase(message)
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.NotFound;
    }

    public override IList<string> GetErrorMessages()
    {
        return [Message];
    }
}