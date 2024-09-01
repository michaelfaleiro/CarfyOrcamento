using System.Net;

namespace CarfyOrcamento.Exceptions.ExceptionsBase;

public class ErrorOnSaveDbException(string message) : CarfyOrcamentoExceptionBase(message)
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.InternalServerError;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string> { Message };
    }
}
