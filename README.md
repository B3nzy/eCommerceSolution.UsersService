# eCommerceSolution.UsersService

A secure, isolated microservice built with **.NET Core** handling user authentication, profile management, and relational data persistence within a decoupled e-commerce architecture.

## 🛠️ Tech Stack & Infrastructure
* **Framework:** .NET Core API
* **Database:** PostgreSQL (Relational storage for transactional user records)
* **Containerization:** Docker & Docker Compose
* **Network Isolation:** Runs on a dedicated `user-db-network` (isolated from public database access) and bridges to `inter-service-network` for secure API communications.

## 🏗️ Architecture Role & Data Flow
This service acts as the identity provider for the ecosystem. It manages customer credentials, registration workflows, and profile state.
* **Data Layer:** Uses **PostgreSQL** to maintain strict ACID compliance for user accounts and identity details.
* **Security:** Employs industry-standard data protection/password hashing and secure token-based authentication patterns.

## 📂 System Architecture Overview
This repository is part of a larger, decentralized microservice ecosystem:
1. **[UsersService](https://github.com/B3nzy/eCommerceSolution.UsersService)** (PostgreSQL) - *You are here*
2. **[ProductsService](https://github.com/B3nzy/eCommerceSolution.ProductsService)** (MS SQL Server + Redis)
3. **[OrdersService](https://github.com/B3nzy/eCommerceSolution.OrdersService)** (MongoDB)

## 🚀 How to Run (via Orchestrated Compose)
To run this service alongside the entire ecosystem, navigate to the root configuration containing the `docker-compose.yml` file and execute:
```bash
docker-compose up --build
