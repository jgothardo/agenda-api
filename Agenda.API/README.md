# Agenda API

## Descri��o

A **Agenda API** � uma aplica��o que permite gerenciar eventos de uma agenda escolar. A API suporta opera��es CRUD (Create, Read, Update, Delete) para eventos e armazena os dados tanto em um banco de dados em mem�ria quanto em um arquivo Excel.

Esta API foi criada como parte de uma mentoria na escola **EE Bar�o de Jundia�**.

## Funcionalidades

- **Adicionar Evento**: Adiciona um novo evento � agenda.
- **Listar Eventos**: Retorna todos os eventos da agenda.
- **Obter Evento por ID**: Retorna um evento espec�fico com base no ID fornecido.
- **Atualizar Evento**: Atualiza os detalhes de um evento existente.
- **Excluir Evento**: Remove um evento da agenda.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para constru��o da API.
- **Entity Framework Core**: ORM para acesso ao banco de dados.
- **InMemoryDatabase**: Banco de dados em mem�ria para simplifica��o.
- **EPPlus**: Biblioteca para manipula��o de arquivos Excel.
- **Swagger**: Ferramenta para documenta��o e teste da API.

## Endpoints

### Adicionar Evento na Agenda

- **URL**: `/api/agenda`
- **M�todo**: `POST`
- **Corpo da Requisi��o**:
  
  
### Listar Eventos na Agenda

- **URL**: `/api/agenda`
- **M�todo**: `GET`

### Obter Evento na Agenda por ID

- **URL**: `/api/agenda/{id}`
- **M�todo**: `GET`

### Atualizar Evento na Agenda

- **URL**: `/api/eventos/{id}`
- **M�todo**: `PUT`
- **Corpo da Requisi��o**:
  
  
### Excluir Evento na Agenda

- **URL**: `/api/agenda/{id}`
- **M�todo**: `DELETE`

## Como Executar a Aplica��o

1. **Clone o reposit�rio**:
   git clone https://github.com/jgothardo/agenda-api.git cd agenda-api
   
2. **Instale as depend�ncias**:
   
   dotnet restore

3. **Execute a aplica��o**:
   dotnet run
   
4. **Acesse a documenta��o do Swagger**:
   - Abra o navegador e v� para `https://localhost:5001/swagger` para visualizar e testar os endpoints da API.

## Inicializa��o dos Dados

Quando a aplica��o � iniciada, os dados s�o carregados de um arquivo Excel (`Agenda.xlsx`). 
Se o arquivo n�o existir, ele ser� criado com a estrutura b�sica. 
Os dados do Excel s�o carregados na mem�ria e no banco de dados em mem�ria para facilitar o acesso e a manipula��o.

## Contribui��o

Se voc� deseja contribuir para este projeto, sinta-se � vontade para abrir issues e pull requests. Toda contribui��o � bem-vinda!

## Licen�a

Este projeto est� licenciado sob a [MIT License](LICENSE).

   
