## Sobre o projeto

Desenvolvemos uma API robusta e escalável com **.NET 8**, seguindo os princípios do **DDD**. A arquitetura **RESTful** e a documentação Swagger facilitam a integração com outras aplicações. Utilizamos ferramentas como **AutoMapper**, **FluentAssertions**, **FluentValidation** e **EntityFramework** para garantir a qualidade do código e a eficiência do sistema. A **API** oferece um CRUD completo para gerenciamento de despesas, com validações sólidas e um banco de dados **SQLite** para armazenamento.


### Features

- Domain-Driven Design **(DDD)**: Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
- Testes de Unidade: Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade.
- Geração de Relatórios: Capacidade de exportar relatórios detalhados para **PDF** e **Excel**, oferecendo uma análise visual e eficaz das despesas.
- RESTful API com Documentação Swagger: Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.

## Getting Started
Para obter uma cópia local funcionando, siga estes passos simples.

### Requisitos
* Visual Studio versão 2022+ ou Visual Studio Code
* Windows 10+ ou Linux/MacOS com [.NET SDK](https://dotnet.microsoft.com/pt-br/download/dotnet-framework) instalado
* SQLite
### Instalação
1. Clone o repositório:

    ```sh
        git clone https://github.com/GabrielMilani/CashFlow.git
    ```

2. Preencha as informações no arquivo `appsettings.Development.json`.

3. Execute a API.