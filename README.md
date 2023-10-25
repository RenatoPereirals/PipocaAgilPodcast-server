# Pipoca Ágil Podcast - Servidor

Bem-vindo ao repositório do servidor do Pipoca Ágil Podcast! Este é o coração do nosso projeto multimídia, onde você pode ouvir podcasts, ler artigos e participar de eventos relacionados à metodologia ágil. A aplicação também oferece a capacidade de se cadastrar como usuário comum ou como usuário administrador. Se você é um usuário administrador, terá acesso a informações detalhadas sobre os eventos, podcasts e artigos mais populares, bem como informações sobre o conteúdo mais curtido, comentado e compartilhado.

## Tecnologias Principais

- .NET 7
- ASP.NET Core
- Entity Framework Core (EF Core)
- JWT (JSON Web Tokens)

## Começando

Siga estas etapas para configurar e executar o servidor em sua máquina local:

1. **Clonando o Repositório**:

   Abra o terminal e execute o seguinte comando para clonar este repositório:

   ```bash
   git clone https://github.com/seu-usuario/pipoca-agil-podcast-server.git
   ```

2. **Configurando o Ambiente**:

   Certifique-se de que você possui o SDK .NET 7 instalado na sua máquina. Caso contrário, você pode baixá-lo no [site oficial da Microsoft](https://dotnet.microsoft.com/download/dotnet/7.0).

3. **Variáveis de Ambiente**:

   Você precisará configurar as variáveis de ambiente para a aplicação funcionar corretamente. Consulte o arquivo `.env.example` para obter informações sobre as variáveis necessárias e crie um arquivo `.env` na raiz do projeto com os valores apropriados.

4. **Banco de Dados**:

   Configure a conexão do banco de dados no arquivo `appsettings.json`. Utilizamos o Entity Framework Core para interagir com o banco de dados. Você pode criar o banco de dados executando as migrações com o seguinte comando:

   ```bash
   dotnet ef database update
   ```

5. **Executando o Servidor**:

   Agora você pode executar o servidor com o seguinte comando:

   ```bash
   dotnet run
   ```

   O servidor estará disponível em `https://localhost:5001` (ou no endereço especificado no arquivo de configuração).

## Endpoints da API

A API oferece uma variedade de endpoints para acessar e manipular os dados relacionados a eventos, podcasts, artigos e usuários. Consulte a documentação da API para obter detalhes sobre esses endpoints.

## Testes Automatizados

Para obter informações detalhadas sobre os testes automatizados, consulte o [README de Testes](tests/README.md).

## Contribuindo

Agradecemos pelo seu interesse em contribuir para o Pipoca Ágil Podcast! Sinta-se à vontade para enviar pull requests, relatar problemas ou sugerir melhorias. Estamos ansiosos para ver o que você pode adicionar ao projeto.

---
