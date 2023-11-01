namespace PipocaAgilPodcast.Services.Error;

[Serializable]
public class UserHandlingException : Exception
{
    public UserHandlingException() { }
    public UserHandlingException(string message) : base(message) { }
    public UserHandlingException(string message, Exception inner) : base(message, inner) { }
    protected UserHandlingException(
        Runtime.Serialization.SerializationInfo info,
        Runtime.Serialization.StreamingContext context) : base(info, context) { }

    public static void HandleUserNotFoundException(Exception ex) // usuário não é encontrado no sistema
    {
       throw ex;
    }
    public static void HandlePasswordMismatchException(Exception ex) // senha fornecida não corresponde à senha armazenada no sistema
    {
        throw ex;
    }
    public static void HandleUserNotCreatedException(Exception ex) // novo usuário não pôde ser criado no sistema
    {
        throw ex;
    }
    public static void HandleUserNotUpdatedException(Exception ex) // atualização das informações do usuário falhau
    {
        throw ex;
    }
    public static void HandleUserNotDeletedException(Exception ex)  // exclusão de um usuário falhou
    {
        throw ex;
    }
    public static void HandleUserAlreadyExistsException(Exception ex) // usuário com o mesmo endereço de e-mail já existe no sistema
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
    public static void HandleUserValidationException(Exception ex) // validações dos campos de usuário não cumpridas
    {
        throw ex;
    }
    public static void HandleUserAccountLockedException(Exception ex) // usuário foi bloqueado devido a tentativas de login mal sucedidas
    {
        throw ex;
    }
}
