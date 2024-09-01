using System.Net;

namespace CarfyOrcamento.Exceptions.ExceptionsBase;

public class ErrorOnValidateException(IList<string> messages) : CarfyOrcamentoExceptionBase(string.Empty)
{
    public override IList<string> GetErrorMessages()
    {
        return messages;
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }
}
