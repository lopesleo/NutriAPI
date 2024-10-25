# NutriAPI 🥗

**NutriAPI** é uma aplicação ASP.NET Core desenvolvida como um projeto de estudos para gerenciar nutricionistas e seus pacientes. A aplicação utiliza **Entity Framework Core** com **PostgreSQL** para a persistência de dados e **Swagger** para a documentação da API.

## 🛠️ Tecnologias Utilizadas

- **.NET 8.0**
- **Entity Framework Core**
- **PostgreSQL**
- **Swagger** para a documentação da API

## ⚙️ Requisitos

Certifique-se de que seu ambiente atenda aos seguintes requisitos:

- .NET 8.0 SDK instalado
- PostgreSQL configurado e em execução

## 🚀 Configuração do Projeto

1. Clone o repositório:

   ```bash
   git clone https://github.com/lopesleo/NutriAPI.git
   cd NutriAPI
   ```

2. Configure a string de conexão no arquivo `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=NutriAPI;Username=seu-usuario;Password=sua-senha"
     }
   }
   ```

3. Execute as migrações do Entity Framework Core para criar o banco de dados:

   ```bash
   dotnet ef database update
   ```

## ▶️ Execução

Para executar a aplicação, utilize o comando:

   ```bash
   dotnet run
   ```

A aplicação estará disponível em `https://localhost:5001` e a documentação do Swagger em `https://localhost:5001/swagger`.

## 📂 Estrutura do Projeto

- **Controllers**: Contém os controladores da API.
- **Models**: Contém os modelos de dados.
- **Repositorios**: Contém os repositórios para acesso aos dados.
- **Services**: Contém os serviços de negócio.

## 🔗 Endpoints

### Nutricionista

- `GET /api/nutricionista/{id}/listar-pacientes`: Lista os pacientes de um nutricionista.
- `POST /api/nutricionista/cadastrar`: Cadastra um novo nutricionista.
- `GET /api/nutricionista/{id}`: Busca um nutricionista por ID.
- `PUT /api/nutricionista/{id}`: Atualiza um nutricionista.
- `DELETE /api/nutricionista/{id}`: Exclui um nutricionista.

## 📦 Dependências

- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/)
- [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/)
- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/)

## 🤝 Contribuição

Este projeto é apenas para fins de estudo. No entanto, contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## 📜 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

