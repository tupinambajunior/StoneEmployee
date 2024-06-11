![Logo do Projeto](StoneEmployee.API/Assets/stone-co.png)

# API de Gerenciamento de Folha de Pagamento

Este projeto é uma API ASP.NET Core para gerenciamento de folha de pagamento de funcionários, incluindo cálculo de salários, deduções (INSS, IRPF, plano de saúde, plano dental, vale transporte) e geração de contracheques. A API utiliza PostgreSQL como banco de dados e é containerizada usando Docker.

## Funcionalidades

- Gerenciamento de funcionários (operações CRUD)
- Cálculo de salários com detalhamento de deduções
- Migrações automáticas do banco de dados
- Design RESTful API
- Ambiente containerizado para fácil implantação

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Docker
- AutoMapper
- FluentValidation
- xUnit

## Configuração

### Pré-requisitos

- Docker
- Docker Compose

### Clonar o Repositório

```sh
git clone https://github.com/tupinambajunior/StoneEmployee.git
cd StoneEmployee
