using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace PipocaAgilPodcast.Services.Error;

[Serializable]
public class UserHandlingException : Exception
{
    public UserHandlingException() { }
    public UserHandlingException(string message) : base(message) { }
    public UserHandlingException(string message, Exception inner) : base(message, inner) { }
    protected UserHandlingException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class UserCreationException : UserHandlingException // novo usuário não pôde ser criado no sistema
{
    public int StatusCode { get; set; }
    public UserCreationException(string message, DbException ex, int statusCode)
        : base(message, ex)
    {
        StatusCode = statusCode;
    }
}
public class UserUpdatedException : UserHandlingException // atualização das informações do usuário falhou
{
    public int StatusCode { get; set; }
    public UserUpdatedException(string message, DbException ex, int statusCode)
        : base(message, ex)
    {
        StatusCode = statusCode;
    }
}
public class UserDeletedFailedException : UserHandlingException // exclusão de um usuário falhou
{
    public int StatusCode { get; set; }
    public UserDeletedFailedException(string message, DbException ex, int statusCode)
        : base(message, ex)
    {
        StatusCode = statusCode;
    }
}
public class UserValidationFailedException : UserHandlingException // validações dos campos de usuário não cumpridas
{
    public int StatusCode { get; set; }

    public UserValidationFailedException(string message, ValidationException ex, int statusCode)
        : base(message, ex)
    {
        StatusCode = statusCode;
    }
}

public class UserAlreadyExistsException : UserHandlingException // usuário com o mesmo endereço de e-mail já existe no sistema
{
    public int StatusCode { get; set; }
    public UserAlreadyExistsException(string message, DbException ex, int statusCode)
        : base(message) 
        {
            StatusCode = statusCode;
        }
}
