# LanchesIO

## Descrição

LanchesIO é uma aplicação para gerenciar lanches e seus ingredientes. A solução é composta por uma API desenvolvida em ASP.NET Core, um front-end desenvolvido em Angular e um banco de dados SQLite.

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (versão 18 ou superior)
- [Angular CLI](https://angular.io/cli) (versão 18.0.3 ou superior)


## Configuração da API

### Passos para Instalação

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/LanchesIO.git
```
2. Acesse a pasta da API:
```bash
cd LanchesIO/src/LanchesIO.API
```

4. Execute o comando para criar o banco de dados:
dotnet ef database update

5. Execute a API:
```bash
dotnet run
```

6. Acesse a URL da API:
[https://localhost:5001/swagger](https://localhost:5001/swagger)



### Testes da API

Para executar os testes da API, navegue at� o diret�rio `LanchesIO.API.Tests` e execute:

```bash
dotnet test
```

## Configuração do Front-end

### Passos para Instala��o

1. Acesse a pasta do front-end:
```bash
cd LanchesIO/src/LanchesIOApp
```
2. Instale as depend�ncias:
```bash
npm install
```

3. Execute o front-end:
```bash
ng serve
```


