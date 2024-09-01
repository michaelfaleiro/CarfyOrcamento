using System.Net;

namespace CarfyOrcamento.Exceptions.ExceptionsBase;

public class BusinessException(string message) : CarfyOrcamentoExceptionBase(message)
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string> { Message };
    }
}