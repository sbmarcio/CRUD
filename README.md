# 🧾 CRUD de Clientes

Aplicação Fullstack para cadastro e gerenciamento de clientes, construída com **React + Vite + TypeScript** no frontend e **.NET 8 com DDD + EF Core** no backend.

---

## 📁 Estrutura do Projeto


---

## 🚀 Funcionalidades

- ✅ Cadastro, edição e exclusão de clientes
- 📋 Validação de formulários com React Hook Form + Yup
- 🔍 Busca e filtragem
- 🌐 Integração com API REST
- 🧱 Backend estruturado com DDD e MediatR
- 🐳 Banco de dados via SQL Server com Docker

---

## 🛠️ Tecnologias

### Frontend
- React
- Vite
- TypeScript
- React Hook Form
- Yup
- React Router

### Backend
- .NET 8
- Entity Framework Core
- SQL Server
- MediatR
- Docker
- DDD e Clean Architecture

---

## 📦 Instalação

### Backend

```bash
cd backend/

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=1a2b3c4d!@#$" \
  -p 1433:1433 --name sqlserver \
  mcr.microsoft.com/mssql/server:2022-latest

dotnet run --project WebAPI

cd frontend/

npm install
npm run dev

🔗 API Endpoints
Método	Rota	Descrição
GET	/api/cliente	Listar clientes
GET	/api/cliente/{id}	Obter cliente por ID
POST	/api/cliente	Criar cliente
PUT	/api/cliente/{id}	Atualizar cliente
DELETE	/api/cliente/{id}	Remover cliente
