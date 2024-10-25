# LanchesIO

## Descrição

LanchesIO é uma aplicação para gerenciar lanches e seus ingredientes. A solução é composta por uma API desenvolvida em ASP.NET Core e um front-end desenvolvido em Angular.

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (versão 18 ou superior)
- [Angular CLI](https://angular.io/cli) (versão 18.0.3 ou superior)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (ou outro banco de dados configurado)

## Configuração da API

### Passos para Instalação

1. Clone o repositório:

git clone https://github.com/seu-usuario/LanchesIO.git

2. Acesse a pasta da API:
```bash
cd LanchesIO/src/LanchesIO.API
```

3. Abra o arquivo `appsettings.json` e configure a conexão com o banco de dados:

```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Server=localhost;Database=LanchesIO;User Id=sa;Password=senha;"
  }
}
```

4. Execute o comando para criar o banco de dados:
dotnet ef database update

5 .Execute a API:
```bash
dotnet run
```

6. Acesse a URL da API:
[https://localhost:5001/swagger](https://localhost:5001/swagger)

A aplicação estará disponível em `http://localhost:4200`.


### Testes da API

Para executar os testes da API, navegue até o diretório `LanchesIO.API.Tests` e execute:

```bash
dotnet test
```

## Configuração do Front-end

### Passos para Instalação

1. Acesse a pasta do front-end:
```bash
cd LanchesIO/src/LanchesIOApp
```
2. Instale as dependências:
```bash
npm install
```

3. Execute o front-end:
```bash
1. ng serve
```


