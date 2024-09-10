using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CarfyOrcamento.Exceptions.ExceptionsBase;
using CarfyOrcamento.Communication.Response;

namespace CarfyOrcamento.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CarfyOrcamentoExceptionBase)
        {
            var carfyOrcamentoException = (CarfyOrcamentoExceptionBase)context.Exception;

            context.HttpContext.Response.StatusCode = (int)carfyOrcamentoException.GetStatusCode();
            
            var responseJson = new ResponseErrorJson(carfyOrcamentoException.GetErrorMessages().ToList());

            context.Result = new ObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            Console.WriteLine(context.Exception.Message);
            var list = new List<string> { "Erro interno no servidor"};

            var responseJson = new ResponseErrorJson(list);

            context.Result = new ObjectResult(responseJson);
        }
    }
}