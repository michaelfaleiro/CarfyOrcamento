namespace CarfyOrcamento.Communication.Response;

public class ResponseErrorJson
{
    public ResponseErrorJson(IList<string> errors)
    {
        Errors = errors;
    }
    public IList<string> Errors { get; set; }
    
}