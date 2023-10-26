# BankSlipControlAPI 💻💸

A API BankSlipControl é um projeto desenvolvido para o gerenciamento de boletos bancários. Esta API, conectada a um banco de dados PostgreSQL, implementa algumas operações do CRUD para lidar eficientemente com o cadastro e busca de boletos bancarios e bancos.

## Funcionalidades ⚙

A API oferece os seguintes métodos HTTP:

### Banco
- `HttpPost("v1/bank")` - Metodo que realiza cadastro de novo Banco 
- `HttpGet("v1/bank")` - Metodo que retorna todos os bancos registrados
- `HttpGet("v1/bank/{code}")` - Metodo que faz busca de um único registro utilizando o código do banco como filtro.
  
### Boletos
- `HttpPost("v1/bankslip")` - Metodo que realiza cadastro de novo Boleto
- `HttpGet("v1/bankslip/{id}")` - Metodo que faz busca de um único registro utilizando o id do boleto como filtro.

### Usuario
- `HttpPost("v1/user/register")` - Metodo responsavel por criar um login na aplicação. 
- `HttpPost("v1/user/login")` - Metodo resposavel por realizar o login na aplicação e gerar a chave para acesso de endpoints. 

## Tecnologias, Bibliotecas e Padrões 👨‍💻

O projeto utiliza as seguintes tecnologias, bibliotecas e padrões:

- Linguagem: C# 
- Framework: .NET 6.0
- Conceitos: Arquitetura em Camadas 
- Práticas: Clean Code
- DTO's: Utilizados para transferência de dados entre as camadas da aplicação (InputModels e ViewModels)
- Mapeamento: AutoMapper para mapeamento objeto-objeto
- Banco de Dados: PostgreSQL (Acessando via Entity Framework Core)
- Autenticação: JWT (JSON Web Tokens)
- Validação: FluentValidation
- IDE: Visual Studio 2022

## Configuração e Uso 🛠

1. Clone o repositório do projeto.
2. Abra a solução `BankSlipControl.sln` em sua IDE de preferencia. (Indico Visual Studio 2022)
3. Restaure as dependencias do projeto.
4. Certifique-se de ter o PostgreSQL instalado e ajuste a string de conexão no arquivo appsettings.json.
5. Aplique as migrações do banco de dados para criar as tabelas necessárias.
6. Compile o projeto.
7. Inicie a aplicação

## Contribuições 🤝

Contribuições são bem-vindas! Sintam-se à vontade para abrir uma issue para relatar algum problema ou sugerir melhorias.

----------------------------------------------------------------------------------------------------------------------------------------------------------------------

# BankSlipControlAPI (English)💻💸

The BankSlipControl API is a project developed for the management of bank slips. This API, connected to a PostgreSQL database, implements some CRUD operations to efficiently handle the registration and retrieval of bank slips and banks.

## Features ⚙

The API provides the following HTTP methods:

### Bank
- `HttpPost("v1/bank")` - Method for registering a new bank.
- `HttpGet("v1/bank")` - Method that returns all registered banks.
- `HttpGet("v1/bank/{code}")` - Method that retrieves a single record using the bank code as a filter.
  
### Bank Slips
- `HttpPost("v1/bankslip")` - Method for registering a new bank slip.
- `HttpGet("v1/bankslip/{id}")` - Method that retrieves a single record using the bank slip ID as a filter.

### User
- `HttpPost("v1/user/register")` - Method responsible for creating a user in the application.
- `HttpPost("v1/user/login")` - Method responsible for logging into the application and generating the key for accessing endpoints.

## Technologies, Libraries, and Patterns 👨‍💻

The project utilizes the following technologies, libraries, and patterns:

- Language: C#
- Framework: .NET 6.0
- Concepts: Layered Architecture
- Best Practices: Clean Code
- DTOs: Used for data transfer between application layers (InputModels and ViewModels)
- Mapping: AutoMapper for object-to-object mapping
- Database: PostgreSQL (Accessed via Entity Framework Core)
- Authentication: JWT (JSON Web Tokens)
- Validation: FluentValidation
- IDE: Visual Studio 2022

## Setup and Usage 🛠

1. Clone the project repository.
2. Open the BankSlipControl.sln solution in your preferred IDE (Visual Studio 2022 is recommended).
3. Restore project dependencies.
4. Ensure you have PostgreSQL installed and adjust the connection string in the appsettings.json file.
5. Apply the database migrations to create the necessary tables.
6. Compile the project.
7. Start the application.

## Contributions  🤝

Contributions are welcome! Feel free to open an issue to report any problems or suggest improvements.
