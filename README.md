# Residencia - 4º Período - BackEnd

# Controllers

### Controllers > Classe ControllerBase

A classe está vazia e não contém métodos, propriedades ou atributos.  
Isso significa que, neste estado, ela não oferece nenhuma funcionalidade.

### Controllers > ProfileController.cs

Este controlador implementa as operações **CRUD** (Create, Read, Update, Delete) para gerenciar perfis.

- **Acesso ao Banco de Dados**: 
  Utiliza o **Entity Framework Core** para acessar o banco de dados de forma assíncrona.

- **Métodos Utilizados**:
  - `Include`
  - `ToListAsync`
  - `FirstOrDefaultAsync`
  - `SaveChangesAsync`  
  Esses métodos garantem a manipulação eficiente dos dados.

- **Tratamento de Requisições**:
  O controlador assegura que as requisições são tratadas corretamente, fornecendo respostas adequadas como:
  - `NotFound()`
  - `BadRequest()`
  - `CreatedAtAction()`
  - `NoContent()`

---
# WebAplication1

## .idea

Esta é uma pasta de configuração do ambiente de desenvolvimento **JetBrains** (como o Rider ou IntelliJ).

- **Conteúdo**:
  Contém arquivos de projeto e metadados específicos do IDE.

- **Relevância**:
  Não é diretamente relevante para o funcionamento da aplicação, mas é útil para o desenvolvimento e configuração do ambiente.

### Importância dos Arquivos .idea:

### Configurações Específicas do IDE
- Personalizam e organizam o ambiente de desenvolvimento conforme as preferências do desenvolvedor.
- Não afetam a execução do projeto em ambientes fora do IDE JetBrains.

### Controle de Versão
- A maioria dos arquivos na pasta `.idea` não precisa ser versionada.
- O arquivo `.gitignore` desempenha um papel fundamental em evitar o versionamento de partes desnecessárias.

### Finalidade
- Configuram a execução do projeto.
- Gerenciam preferências de desenvolvimento.
- Personalizam a experiência do desenvolvedor no IDE.

### Impacto no Projeto
- Arquivos como `workspace.xml` são úteis para o desenvolvimento, mas não influenciam diretamente o funcionamento do projeto em produção.
- Podem ser incluídos no controle de versão, mas geralmente são específicos para cada desenvolvedor.
---


# ApiSenac

## Data

### AppDbContext
- *Resumo: AppDbContext*

- **AppDbContext**:
  - Define como as entidades e seus relacionamentos são mapeados para tabelas no banco de dados.

- **Relacionamentos**:
  - Utiliza o `ModelBuilder` para configurar:
    - Relacionamentos, como muitos-para-muitos.
    - Regras de validação e restrições.

- **DeleteBehavior.NoAction**:
  - Evita exclusão em cascata.
  - Exige que a exclusão de registros relacionados seja gerenciada manualmente.

---
### Migrations
- *Resumo: Migrations*

- **Pasta Migrations**:
  - Auxilia no gerenciamento da evolução do esquema do banco de dados ao longo do tempo.

- **Criar Novas Migrações**:
  - É necessário criar uma nova migração sempre que houver mudanças no modelo de dados.

- **AppDbContextModelSnapshot.cs**:
  - Mantém um registro do estado atual do modelo de dados.
  - Facilita a criação de novas migrações ao comparar o estado atual com as mudanças feitas.

---

### Models

- **BaseEntity**:
  - Classe base projetada para ser herdada por outras entidades.
  - Fornece propriedades comuns e reutilizáveis.
  - Propriedades :
    - `Id`: Chave primária da entidade.
    - `DataDeCriacao`: Registra a data de criação do registro.
    - `LastUpdate`: Rastreia a última atualização do registro.
    - `Active`: Permite a exclusão lógica.

- **Custom_Atribute**:
  - `Custom_Atribute` é uma entidade que representa atributos adicionais personalizados.
  - Pode ser associada a **perfis** ou **usuários** para maior flexibilidade.
  - Herdar de `BaseEntity` fornece propriedades comuns, como:
    - `Id`: Identificador único.
    - `Active`: Permite exclusão lógica.
  - Contribui para um código mais organizado e reutilizável.
  - **`Profile_CustomAtributes`**:
    - Define uma relação de muitos-para-muitos com perfis.
  - **`UserProfile_CustomAtributes`**:
    - Estabelece relações de muitos-para-muitos com usuários.
  - Essas relações ampliam as possibilidades de uso dos atributos personalizados em diferentes cenários.


- **Permition**:
   - `Permition` é uma entidade que representa uma ação ou conjunto de ações que usuários ou perfis podem executar dentro do sistema.
   - `Sistema`:
    - Conecta a permissão a um sistema específico, fornecendo contexto ou escopo.
  - `Profile_Permitions`:
    - Relaciona permissões a diferentes perfis de usuário.
    - Simplifica o gerenciamento de permissões em sistemas com múltiplos usuários e funções.    


- **Profile_CustomAtribute**: 
  - `Profile_CustomAtribute` é uma entidade de junção que define o relacionamento de muitos-para-muitos entre Profile e Custom_Atribute.
  - Conecta as entidades **Profile** e **Custom_Atribute** em um relacionamento de muitos-para-muitos.
  -  `CustomAtributeId` e `ProfileId`: Estabelecem o relacionamento no banco de dados.



- **Profile_Permition**: 
  - `Profile_Permition` é usada para implementar um relacionamento de muitos-para-muitos entre as entidades **Profile** e **Permition**.
    - Permite que:
      - Um **Profile** tenha várias **Permitions** (permissões).
      - Uma **Permition** seja associada a vários **Profiles**.


- **Profile**:
  - Representa os dados e relacionamentos de um perfil de usuário.
  - Inclui informações como:
    - **Nome** do perfil.
    - **Sistema** associado.
    - Coleções de **permissões** e **atributos personalizados**.
  - Suporte a relacionamentos complexos, como:
    - Muitos-para-muitos entre **usuários**, **permissões** e **atributos personalizados**.
  - Permite personalizar o comportamento e acesso baseado no perfil.


- **Sistema**:
  - **Construtor**:
  - Inicializa o **nome do sistema**.
  - Pode ser usado para definir outras propriedades, como `LastUpdate`.
  - **Método de Atualização**:
  - Oferece uma forma segura para modificar o **nome do sistema**.
  - **Encapsulamento**:
  - Protege a propriedade **Nome** contra modificações diretas externas, garantindo controle sobre as alterações.


- **User_Profile**:
  - Conecta as entidades **User** e **Profile** em um relacionamento de muitos-para-muitos.
  - `UserId` e `ProfileId`: Estabelecem o relacionamento no banco de dados.
  - `UserProfile_CustomAtributes`: Permite associar atributos personalizados ao par **User-Profile**, adicionando flexibilidade às relações.


- **User**:
  - A classe `User` representa os usuários no sistema, com informações como **nome** e **e-mail**.
  - Permite associações com:
    - **Perfis** através da classe `User_Profile`.
    - **Atributos personalizados** através da classe `UserProfile_CustomAtribute`.


- **UserProfile_CustomAtribute**
  - Representa um relacionamento de muitos-para-muitos entre **User_Profile** e **Custom_Atribute**.
  - **`UserProfileId`** e **`CustomAtributeId`**:
    - Estabelecem a conexão entre as entidades no banco de dados.

---    

## Properties

### Conteúdo:
  - Contém arquivos de configuração específicos do projeto no .NET.
  - Inclui, por exemplo, o arquivo **`launchSettings.json`**.

- **launchSettings**:

- **Perfis de Execução**:
  - Permite configurar diferentes modos de execução para o projeto, como:
    - Uso do **IIS Express** para depuração no Visual Studio.
    - Execução direta da aplicação usando **HTTP** ou **HTTPS**.

- **URLs e Portas**:
  - Especifica as portas e URLs para acessar a aplicação durante o desenvolvimento.

- **Variáveis de Ambiente**:
  - Define o ambiente de execução, como **Development**, ativando ou desativando recursos específicos, como logs de depuração.

### **Como Usar**

- **Durante o Desenvolvimento**:
  - Utilizado pelo **Visual Studio** ou **.NET CLI** para configurar:
    - Ambiente de execução.
    - Portas e URLs de acesso.

- **Para Depuração**:
  - Configurações como:
    - **`launchBrowser`**: Abre automaticamente o navegador ao iniciar a aplicação.
    - **`launchUrl`**: Define o endereço inicial, útil para navegar diretamente à documentação da API.


### **Importância**
- Facilita a configuração e execução da aplicação durante o desenvolvimento.
- Centraliza as definições de inicialização, melhorando a produtividade e consistência do time.

---

# APISenac.csproj

# Resumo do `APISenac.csproj`

## **SDK**
- Utiliza **`Microsoft.NET.Sdk.Web`**:
  - Ideal para desenvolver aplicações web com **ASP.NET Core**.

---

## **Propriedades do Projeto**
- **`TargetFramework`**:
  - Configurado para **.NET 8**, garantindo acesso aos recursos mais recentes do .NET.
- **`Nullable`**:
  - Ativado para ajudar a escrever código mais seguro, minimizando erros de nulidade.
- **`ImplicitUsings`**:
  - Reduz a necessidade de declarações explícitas, tornando o código mais limpo.
- **`RootNamespace`**:
  - Define o namespace raiz do projeto.

---

## **Dependências**
- Inclui pacotes essenciais para uma API robusta:
  - **Entity Framework Core**:
    - Fornece suporte para manipulação de banco de dados.
    - Suporte tanto para **SQLite** quanto para **SQL Server**, oferecendo flexibilidade.
  - **Swashbuckle.AspNetCore**:
    - Facilita a geração de documentação interativa da API usando **Swagger**.

---

## **Como Isso Afeta o Projeto**

- **Compilação e Execução**:
  - Configura como o projeto será compilado e quais bibliotecas externas serão utilizadas.
  
- **ORM e Banco de Dados**:
  - Com **Entity Framework Core**, a aplicação pode acessar e manipular dados de forma simplificada, suportando múltiplos bancos de dados

---

# appsettings.Development.json

 **Arquivo de Configuração**:
  - Contém definições específicas para o ambiente de **desenvolvimento**.

- **Logging**:
  - Configura como as mensagens de log são geradas e capturadas.
  - Proporciona informações úteis para depuração, evitando logs excessivamente detalhados.

- **Foco no Desenvolvimento**:
  - Exclusivo para o ambiente de desenvolvimento.
  - Ajuda os desenvolvedores a diagnosticar e resolver problemas durante o processo de construção da aplicação.

---

# appsettings.json

- **Logging**:
  - Define configurações gerais para capturar logs na aplicação.
  - Foco em mensagens importantes e **warnings** do **ASP.NET Core**.

- **ConnectionStrings**:
  - Configura a conexão com o **banco de dados SQL Server**.
  - Utiliza autenticação integrada do Windows.
  - Permite **MARS** (Multiple Active Result Sets), facilitando múltiplas operações simultâneas.

- **Configurações Compartilhadas**:
  - Serve como base para a configuração da aplicação.
  - Pode ser complementado ou sobrescrito por configurações específicas de ambiente.

---

# Banco.sqlite

- **Descrição**:
  - Um banco de dados **SQLite** que armazena os dados da aplicação em um único arquivo.

- **Usado Principalmente Para**:
  - **Desenvolvimento local** e prototipagem.
  - Aplicações que não requerem um sistema de banco de dados complexo.

- **Integração com EF Core**:
  - O **Entity Framework Core** gerencia:
    - O esquema do banco de dados.
    - Os dados armazenados.


---

# Program.cs

- **Responsabilidade**:
  - Configurar e inicializar a aplicação.
  - Configura serviços, middlewares e o pipeline de requisições HTTP.

## **Principais Funções**

### 1. **Configuração de Serviços**:
  - Define os serviços necessários para a aplicação, como:
    - **Entity Framework Core**: Para acesso ao banco de dados.
    - **Swagger**: Para documentação interativa da API.

### 2. **Pipeline de Requisições HTTP**:
  - Configura middlewares essenciais, como:
    - **Redirecionamento HTTPS**.
    - **Mapeamento de controladores** para tratar requisições.

### 3. **Execução**:
  - Inicia a aplicação e o servidor web.
  - Permite que a aplicação processe requisições HTTP.

## **Importância e Fluxo**

### **1. Definição de Serviços**:
  - Todos os serviços necessários, como o **EF Core** e **Swagger**, são configurados antes da execução.

### **2. Pipeline de Execução**:
  - Configura o pipeline para garantir que a aplicação:
    - Responda corretamente às requisições.
    - Aplique **segurança**, como o uso obrigatório de HTTPS.

### **3. Ambiente de Desenvolvimento**:
  - Ativa configurações específicas para desenvolvimento, como:
    - O uso do **Swagger** para facilitar testes e depuração.


--- 

# WebApplication1.http

- **Descrição**:
  - Um arquivo de script HTTP utilizado para realizar requisições à API diretamente do ambiente de desenvolvimento, sem depender de ferramentas externas.

---

## **Principais Funcionalidades**

### 1. **Requisição GET**:
  - Testa o endpoint `/weatherforecast/`.
  - Solicita respostas no formato **JSON**.

### 2. **Facilidade de Manutenção**:
  - Utiliza variáveis de ambiente, tornando o arquivo:
    - Fácil de modificar.
    - Simples de manter para diferentes cenários e configurações.

---

# ProjetoSENAC.sln

- **Organização da Solução**:
  - O arquivo `.sln` agrupa e gerencia múltiplos projetos dentro de uma solução.
  - Neste caso, a solução contém um único projeto chamado **APISenac**.

- **Configurações de Build**:
  - Define as configurações de compilação para a solução e seus projetos:
    - **Debug**: Para desenvolvimento e depuração.
    - **Release**: Para distribuição e produção.

- **Facilidade de Desenvolvimento**:
  - O **Visual Studio** utiliza o arquivo `.sln` para:
    - Abrir e gerenciar todos os arquivos e projetos.
    - Organizar configurações de forma integrada, otimizando a experiência do desenvolvedor.


---

# Package-lock.json
- **Descrição**:
  - Arquivo gerado automaticamente pelo **npm**.
  - Garante a consistência das versões de dependências no projeto.

-----



# **Configuração da Autenticação JWT no Program.cs**

- **Descrição**:
  - A configuração de autenticação JWT foi implementada no arquivo **`Program.cs`** para permitir a validação de tokens JWT e proteger os endpoints da API.

## **Principais Funcionalidades**

### 1. **Registro do Esquema de Autenticação**
  - Foi registrado o esquema de autenticação **JWT Bearer**, utilizando a biblioteca `Microsoft.AspNetCore.Authentication.JwtBearer`.

### 2. **Validação do Token JWT**
  - As configurações de validação foram definidas:
    - **Emissor (`Issuer`)**: O servidor que gera o token.
    - **Público (`Audience`)**: O público esperado para o token.
    - **Tempo de Vida (`Lifetime`)**: Garante que o token não expirou.
    - **Assinatura (`SigningKey`)**: Valida a autenticidade do token.

### 3. **Pipeline de Requisições**
  - Foi adicionado o middleware `UseAuthentication` no pipeline, garantindo que a autenticação seja executada antes da autorização.

# **AuthController.cs**

- **Descrição**:
  - Um controlador criado para lidar com autenticação de usuários e geração de tokens JWT.

## **Principais Funcionalidades**

### 1. **Endpoint de Login**
  - O endpoint `POST /api/auth/login` autentica usuários com base em credenciais (usuário e senha).
  - Gera um **token JWT** para usuários autenticados.

### 2. **Validação de Credenciais**
  - A validação é feita com lógica simplificada (exemplo de credenciais estáticas), mas pode ser adaptada para consultar o banco de dados ou outro sistema de autenticação.

### 3. **Retorno de Token**
  - Responde com o token JWT e a data de expiração quando as credenciais são válidas.
  - Caso contrário, retorna um erro `401 Unauthorized`.

# **Proteção de Endpoints com `[Authorize]`**

- **Descrição**:
  - Endpoints protegidos com o atributo `[Authorize]` requerem um token JWT válido para acesso.

## **Principais Funcionalidades**

### 1. **Proteger Endpoints**
  - O atributo `[Authorize]` foi adicionado aos controladores ou métodos individuais para restringir o acesso.

### 2. **Controle de Acesso Baseado em Funções**
  - Adicionado suporte para roles (funções de usuário) através do atributo `[Authorize(Roles = "Admin")]`.




--------------

Para implementar a **autenticação via Google** em sua aplicação, você precisará usar o serviço de OAuth 2.0 do Google. Ele permite que os usuários façam login na sua aplicação com suas contas do Google. Vamos realizar isso de forma integrada ao esquema existente de autenticação JWT.

Aqui está o passo a passo:

---

## **Passo 1: Configurar Credenciais no Google Cloud Console**

1. Acesse o [Google Cloud Console](https://console.cloud.google.com/).
2. Crie um novo projeto ou selecione um existente.
3. Vá para **APIs e serviços** > **Credenciais**.
4. Clique em **Criar credenciais** > **ID do cliente OAuth 2.0**.
   - Escolha o tipo de aplicação:
     - **Aplicação web**: Para aplicações com back-end.
     - **Aplicação desktop**: Caso necessário.
5. Defina os **URLs de redirecionamento autorizados**:
   - Exemplo: `https://seusite.com/signin-google` (para produção).
   - Para desenvolvimento local: `http://localhost:5000/signin-google`.
6. Copie o **Client ID** e o **Client Secret**.

---

## **Passo 2: Instalar a Biblioteca `Google.Apis.Auth`**

Adicione o pacote NuGet para validar tokens do Google:
```bash
dotnet add package Google.Apis.Auth
```

---

## **Passo 3: Criar Lógica de Validação do Token do Google**

No seu **AuthController**, vamos adicionar um endpoint que recebe um **ID Token** gerado pelo Google e valida esse token. Após validar, você pode gerar um token JWT interno para sua aplicação.

### **Código do Endpoint no AuthController**

Adicione o método para autenticação com Google:

```csharp
using Google.Apis.Auth;

[HttpPost("google-login")]
public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
{
    try
    {
        // Valida o token do Google
        var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new[] { "SeuClientID.apps.googleusercontent.com" } // Substitua pelo seu Client ID
        });

        // Caso o token seja válido, você pode criar um JWT interno para sua aplicação
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, payload.Email),
            new Claim("GoogleId", payload.Subject), // ID único do Google
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuaChaveSecretaMuitoForte"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "https://seusite.com",
            audience: "https://seusite.com",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo,
            email = payload.Email,
            name = payload.Name
        });
    }
    catch (InvalidJwtException)
    {
        return Unauthorized(new { Message = "Token inválido do Google." });
    }
}

// Classe para receber o token do cliente
public class GoogleLoginRequest
{
    public string IdToken { get; set; }
}
```

---

## **Passo 4: Fluxo de Login no Cliente**

Seu cliente (web ou mobile) precisa obter o **ID Token** do Google antes de enviá-lo para o seu servidor. Isso geralmente é feito com as bibliotecas do Google.

### **1. Web (JavaScript)**

Utilize a biblioteca **Google Sign-In**:
1. Adicione o script do Google no seu front-end:
   ```html
   <script src="https://accounts.google.com/gsi/client" async defer></script>
   ```
2. Configure o botão de login no Google:
   ```javascript
   const client = google.accounts.id.initialize({
       client_id: "SeuClientID.apps.googleusercontent.com",
       callback: handleCredentialResponse
   });
   google.accounts.id.renderButton(
       document.getElementById("buttonDiv"),
       { theme: "outline", size: "large" } // Configurações do botão
   );

   function handleCredentialResponse(response) {
       // Envie o ID Token para sua API
       fetch('https://suaapi.com/api/auth/google-login', {
           method: 'POST',
           headers: { 'Content-Type': 'application/json' },
           body: JSON.stringify({ idToken: response.credential })
       })
       .then(response => response.json())
       .then(data => {
           console.log("Token JWT:", data.token);
       })
       .catch(error => console.error("Erro:", error));
   }
   ```

---

## **Passo 5: Testando o Endpoint**

### **Requisição**
Faça uma requisição `POST` para o endpoint `api/auth/google-login` com o seguinte body:

```json
{
  "idToken": "TokenRecebidoDoClienteGoogle"
}
```

### **Resposta de Sucesso**
Se o token do Google for válido, o servidor responderá com um JWT da sua aplicação e informações do usuário:

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiration": "2024-12-01T15:00:00Z",
  "email": "usuario@gmail.com",
  "name": "Usuário do Google"
}
```

### **Resposta de Erro**
Caso o token seja inválido ou expirado:

```json
{
  "message": "Token inválido do Google."
}
```

---

## **Passo 6: Protegendo Endpoints**

Como já temos o esquema JWT implementado, os tokens JWT gerados após o login pelo Google podem ser usados para acessar endpoints protegidos com `[Authorize]`.

---

## **Resumo do Fluxo**

1. **Cliente**: Usuário faz login com Google e obtém o **ID Token**.
2. **Servidor**: Recebe e valida o ID Token com o **Google.Apis.Auth**.
3. **JWT**: Após validação, o servidor gera um JWT interno.
4. **Acesso Protegido**: O JWT é usado para acessar endpoints da API.

Se precisar de ajuda para adaptar essa lógica ao seu projeto, é só avisar! 🚀