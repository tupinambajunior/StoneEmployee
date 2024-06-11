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

### Endpoints
- Employee
    - Get employee by id: (GET) https://localhost:5001/api/Employee/f8dd54e1-324c-4749-8a3f-0a0b99a2d6cc
    - Delete employee by id: (DELETE) https://localhost:5001/api/Employee/f8dd54e1-324c-4749-8a3f-0a0b99a2d6cc
    - Get employee list: (GET) https://localhost:5001/api/Employee
    - Create employee: (POST) https://localhost:5001/api/employee
      Request Body (JSON): ```{
            "firstName": "",
            "lastName": "",
            "document": "",
            "sector": "",
            "grossSalary": 100.00,
            "admissionDate": "2024-12-31",
            "hasHealthPlan": true,
            "hasDentalPlan": true,
            "hasTransportationVouchers": true
          } ```
    - Update employee: (PUT) https://localhost:5001/api/employee/f8dd54e1-324c-4749-8a3f-0a0b99a2d6cc
        Request Body (JSON): ```{
            "firstName": "",
            "lastName": "",
            "document": "",
            "sector": "",
            "grossSalary": 100.00,
            "admissionDate": "2024-12-31",
            "hasHealthPlan": true,
            "hasDentalPlan": true,
            "hasTransportationVouchers": true
          } ```
- Payslip
    - Get payslip by employee id: (GET) https://localhost:58891/api/Payslip/b7a1057e-82e4-4f63-b276-26deee001617

### Clonar o Repositório

```sh
git clone https://github.com/tupinambajunior/StoneEmployee.git
cd StoneEmployee
