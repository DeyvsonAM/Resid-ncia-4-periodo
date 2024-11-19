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





