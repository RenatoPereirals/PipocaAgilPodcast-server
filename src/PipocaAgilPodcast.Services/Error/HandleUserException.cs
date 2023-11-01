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

    public static void HandleUserNotFoundException(Exception ex) // usuário não é encontrado no sistema
    {
       throw ex;
    }
    public static void HandlePasswordMismatchException(Exception ex) // senha fornecida não corresponde à senha armazenada no sistema
    {
        throw ex;
    }
    public static void HandleUserAuthenticationException(Exception ex) // erros de autenticação, como falha no login ou problemas com tokens de autenticação
    {
        throw ex;
    }
    public static void HandleUserAuthorizationException(Exception ex) // problemas relacionados às permissões e autorizações do usuário
    {
        throw ex;
    }
    public static void HandleUserAccountLockedException(Exception ex) // usuário foi bloqueado devido a tentativas de login mal sucedidas
    {
        throw ex;
    }
}

public class UserCreationException : UserHandlingException // novo usuário não pôde ser criado no sistema
{
    public UserCreationException(string message, DbException ex) : base(message) { }
}
public class UserUpdatedException : UserHandlingException // atualização das informações do usuário falhou
{
    public UserUpdatedException(string message, DbException ex) : base(message) { }
}
public class UserDeletedException : UserHandlingException // exclusão de um usuário falhou
{
    public UserDeletedException(string message, DbException ex) : base(message) { }
}
public class UserValidationException : UserHandlingException // validações dos campos de usuário não cumpridas
{
    public UserValidationException(string message, ValidationException ex) : base(message) { }
}
public class UserAlreadyExistsException : UserHandlingException // usuário com o mesmo endereço de e-mail já existe no sistema
{
    public UserAlreadyExistsException(string message, Exception ex) : base(message) { }
}
