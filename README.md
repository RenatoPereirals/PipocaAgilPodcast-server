# Pipoca Ágil Podcast - Servidor

Bem-vindo ao backend do Pipoca Ágil, um projeto de gerenciamento e apresentação de podcasts desenvolvido com C# e ASP.NET Este projeto faz parte de uma iniciativa voluntária de uma equipe Scrum, composta por um Product Owner, Scrum Master, Quality Assurance, UX/UI Designer e eu, um Desenvolvedor Fullstack.

Este projeto foi criado com o objetivo de tratar as requisições do frontend, proporcionando uma experiência de usuário completa e coesa.

Este projeto incorpora uma variedade de tecnologias e frameworks modernos, incluindo Entity Framework Core para persistência de dados, JWT para autenticação e autorização seguras, e Identity Framework para gerenciamento de identidade. Além disso, utilizamos PostgreSQL como nosso sistema de gerenciamento de banco de dados.

Embora este projeto não tenha fins comerciais e não esteja atualmente hospedado devido a considerações de custo, ele serve como uma demonstração valiosa de nossas habilidades em criar soluções de backend complexas e seguras. Ele destaca nossa capacidade de trabalhar com uma variedade de tecnologias e adaptar nossas soluções para atender às necessidades específicas do projeto.

Por favor, note que este é o backend do projeto e pode sofrer alterações à medida que o projeto avança.

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


## Status dos Testes e Cobertura de Código

Aqui estão as informações de status dos testes e cobertura de código:

## Status dos Testes e Cobertura de Código

Aqui estão as informações de status dos testes e cobertura de código:

<table>
  <thead>
    <tr>
      <th>Testes</th>
      <th>Total de Testes</th>
      <th>Testes Passados</th>
      <th>Cobertura de Código</th>
      <th>Versão do Commit</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Testes de Unidade</td>
      <td><!-- INSERT_TOTAL_TESTS --> </td>
      <td><!-- INSERT_PASSED_TESTS --></td>
      <td><!-- INSERT_COVERAGE --></td>
      <td><!-- INSERT_COMMIT_VERSION --></td>
    </tr>
    <!-- Adicione mais linhas para outros tipos de testes -->
  </tbody>
</table>



## Contribuindo

Agradecemos pelo seu interesse em contribuir para o Pipoca Ágil Podcast! Sinta-se à vontade para enviar pull requests, relatar problemas ou sugerir melhorias. Estamos ansiosos para ver o que você pode adicionar ao projeto.

---
