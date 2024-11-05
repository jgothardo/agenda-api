# Agenda API

## Descrição

A **Agenda API** é uma aplicação que permite gerenciar eventos de uma agenda escolar. A API suporta operações CRUD (Create, Read, Update, Delete) para eventos e armazena os dados tanto em um banco de dados em memória quanto em um arquivo Excel.

Esta API foi criada como parte de uma mentoria na escola **EE Barão de Jundiaí**.

## Funcionalidades

- **Adicionar Evento**: Adiciona um novo evento à agenda.
- **Listar Eventos**: Retorna todos os eventos da agenda.
- **Obter Evento por ID**: Retorna um evento específico com base no ID fornecido.
- **Atualizar Evento**: Atualiza os detalhes de um evento existente.
- **Excluir Evento**: Remove um evento da agenda.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para construção da API.
- **Entity Framework Core**: ORM para acesso ao banco de dados.
- **InMemoryDatabase**: Banco de dados em memória para simplificação.
- **EPPlus**: Biblioteca para manipulação de arquivos Excel.
- **Swagger**: Ferramenta para documentação e teste da API.

## Endpoints

### Adicionar Evento na Agenda

- **URL**: `/api/agenda`
- **Método**: `POST`
- **Corpo da Requisição**:
  
  
### Listar Eventos na Agenda

- **URL**: `/api/agenda`
- **Método**: `GET`

### Obter Evento na Agenda por ID

- **URL**: `/api/agenda/{id}`
- **Método**: `GET`

### Atualizar Evento na Agenda

- **URL**: `/api/eventos/{id}`
- **Método**: `PUT`
- **Corpo da Requisição**:
  
  
### Excluir Evento na Agenda

- **URL**: `/api/agenda/{id}`
- **Método**: `DELETE`

## Como Executar a Aplicação

1. **Clone o repositório**:
   git clone https://github.com/jgothardo/agenda-api.git cd agenda-api
   
2. **Instale as dependências**:
   
   dotnet restore

3. **Execute a aplicação**:
   dotnet run
   
4. **Acesse a documentação do Swagger**:
   - Abra o navegador e vá para `https://localhost:5001/swagger` para visualizar e testar os endpoints da API.

## Inicialização dos Dados

Quando a aplicação é iniciada, os dados são carregados de um arquivo Excel (`Agenda.xlsx`). 
Se o arquivo não existir, ele será criado com a estrutura básica. 
Os dados do Excel são carregados na memória e no banco de dados em memória para facilitar o acesso e a manipulação.

## Contribuição

Se você deseja contribuir para este projeto, sinta-se à vontade para abrir issues e pull requests. Toda contribuição é bem-vinda!

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

   
