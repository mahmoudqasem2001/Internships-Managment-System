# 🎓 InternGo – Internship Management Platform

**InternGo** is a role-based internship management system that empowers students to search and apply for internships, companies to manage opportunities, and admins to moderate the platform. Built with clean architecture, it includes AI-powered recommendations based on students’ CVs.

---

## 🚀 Technologies Used

| Tech Stack       | Details                               |
|------------------|----------------------------------------|
| Backend          | ASP.NET Core Web API (.NET 8)          |
| ORM              | Entity Framework Core 8                |
| Database         | Microsoft SQL Server                   |
| Authentication   | JWT Bearer Token                       |
| AI Matching      | Keyword Extraction + Weighted Scoring  |
| API Testing      | Swagger                                |
| Architecture     | Clean Architecture + Unit of Work      |

---

## 👥 User Roles & Features

### 👨‍🎓 Student

- ✅ Register, Login with secure JWT
- ✅ Upload & update structured CV (skills, experience, cover letter, programming languages)
- ✅ View & update profile
- ✅ Apply to internships
- ✅ Track application statuses
- ✅ Rate & review internships
- ✅ View previous reviews
- ✅ Receive AI-driven internship recommendations based on skills & preferred location

---

### 🏢 Company

- ✅ Register, Login with JWT
- ✅ Create, update, delete internships
- ✅ View all received applications
- ✅ Accept/reject applications
- ✅ View ratings/reviews of internships
- ✅ Manage company profile (location, hours, trainee capacity)

---

### 👩‍💼 Admin

- ✅ Secure login with JWT
- ✅ View all users
- ✅ Enable/Disable accounts
- ✅ View all internships
- ✅ View all applications
- ✅ Delete inappropriate reviews

---

## 🔐 Security & Authentication

- JWT Bearer token authentication
- Role-based route protection:  
  - `[Authorize(Roles = "Student")]`  
  - `[Authorize(Roles = "Company")]`  
  - `[Authorize(Roles = "Admin")]`
- Passwords are securely hashed with `PasswordHasher<User>`
- Swagger UI supports token-based testing via `🔐 Authorize`

---

## 🤖 AI Recommendation System

- Matches internships based on:
  - Skills, experience, programming languages, cover letter
  - Synonym normalization (e.g. `.NET`, `aspnet` → `dotnet`)
  - Weighted importance (e.g., `dotnet = 1.5`, `communication = 0.5`)
  - Bonus score for matching preferred location (+20%)
- Results saved in `AIRecommendations` table

---

## 🛠️ Architecture Overview

```plaintext
InternGo.WebAPI          --> Presentation Layer (Controllers)
InternGo.Application     --> Application Layer (DTOs, Interfaces, Services)
InternGo.Domain          --> Core Business Models & Contracts
InternGo.Infrastructure  --> Data Access Layer (EF Core, JWT, Repositories)
