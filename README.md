# 🚀 Ações Invest API

## Olá! Seja bem vindo(a)! 👋🏻

Esta é a API Backend do projeto **Ações Invest**, construída com base em uma arquitetura limpa e robusta, utilizando as tecnologias mais recentes do ecossistema .NET.

### 🎯 Objetivo do Projeto

Esta API possui um duplo propósito:

1.  **Valor de Negócio:** Solucionar um problema real do cotidiano, fornecendo uma plataforma para **registro, gerenciamento e controle de ações** e futuros investimentos (como fundos imobiliários).
2.  **Prática de Desenvolvimento:** Servir como um *showcase* de boas práticas de programação e arquitetura, aplicando conceitos fundamentais como:
    * **CRUD:** (Create, Read, Update, Delete)
    * **Princípios SOLID:** Single Responsibility Principle (Responsabilidade Única), Open-Closed Principle (Aberto-Fechado), Liskov Substitution Principle (Substituição de Liskov), Interface Segregation Principle (Segregação da Interface) e Dependency Inversion Principle (Inversão de Dependência)
    * **Clean Architecture:** (Arquitetura em Camadas)
    * **Design Patterns e Injeção de Dependência** (DI)

Com este projeto, buscamos também demonstrar proficiência na construção de um software **manutenível, escalável e testável**.

---

## 🏗️ Arquitetura e Estrutura do Projeto

A solução foi estruturada em **camadas** bem definidas para promover a **separação de responsabilidades (SoC)**, **manutenibilidade** e **testabilidade**.

**Estrutura de Camadas:**

| Camada | Projeto | Responsabilidade Principal |
| :--- | :--- | :--- |
| **Apresentação** | `Acoes_Invest` | Controllers, Mapeamento de Rotas e Configuração de Startup (.NET 8). |
| **Aplicação** | `AcoesInvest.Application` | Orquestração do fluxo de negócio, validações, DTOs e AutoMapper. |
| **Domínio** | `AcoesInvest.Domain` | Regras de negócio, Entidades (Models), Interfaces de Repositório e Serviços. |
| **Infra.Dados** | `AcoesInvest.Infra.Data` | Implementação do Entity Framework Core (`DbContext`), Migrations e Repositórios. |
| **Infra.IoC** | `AcoesInvest.Infra.IoC` | Registro centralizado de todas as Injeções de Dependência. |


---

## 🛠️ Tecnologias e Ferramentas Utilizadas

O projeto utiliza um *stack* moderno e escalável, ideal para APIs de alta performance.

### **Backend Core**
<br>

* **Linguagem:** C#
* **Framework:** .NET 8.0 
* **Mapeamento:** AutoMapper (Para mapear DTOs para Entidades e vice-versa).
* **Banco de Dados:** SQL Server
* **ORM:** Entity Framework Core

---

## 🚀 Como Executar o Projeto

Siga os passos para configurar e executar a API localmente:

### Pré-requisitos

* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* SQL Server ou SQL Server LocalDB
* Visual Studio 2022 ou Visual Studio Code

### 1. Clonar o Repositório

git clone [https://github.com/allekSamp/Acoes_Invest.git](https://github.com/allekSamp/Acoes_Invest.git)
cd Acoes_Invest

### 2. Configurar o Banco de Dados
Atualize a Connection String: No arquivo appsettings.json, ajuste a ConnectionStrings para apontar para sua instância local do SQL Server.

Executar Migrations: Navegue até o projeto AcoesInvest.Infra.Data e aplique as migrations: dotnet ef database update

### 3. Rodar a Aplicação
Execute o projeto principal Acoes_Invest: dotnet run --project Acoes_Invest

A API estará rodando em https://localhost:7238 (ou uma porta similar).

### 4. Acessar o Swagger
A documentação da API estará disponível em:

https://localhost:7238/swagger

## 📬 Conecte-se Comigo
Compartilhe seu feedback ou tire dúvidas!

<a href="https://www.linkedin.com/in/alleksampaio" target="_blank"> <img src="https://img.shields.io/badge/-LinkedIn-%230077B5?style=for-the-badge&logo=linkedin&logoColor=white" target="_blank"> </a> 
<a href="mailto:alleksamp@gmail.com"> <img src="https://img.shields.io/badge/-Gmail-%23333?style=for-the-badge&logo=gmail&logoColor=Red" target="_blank"> </a>
<a href="https://wa.me/5575991931325" target="_blank"><img src="https://img.shields.io/badge/WhatsApp-25D366?style=for-the-badge&logo=whatsapp&logoColor=white" target="_blank"></a> 









