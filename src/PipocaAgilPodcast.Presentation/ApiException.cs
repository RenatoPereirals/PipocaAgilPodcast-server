using Microsoft.AspNetCore.Mvc;

public class ApiException
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public ApiException(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
    public async Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(this)
        {
            StatusCode = StatusCode,
        };

        await objectResult.ExecuteResultAsync(context);
    }
}
