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


Here's your **API Endpoint Documentation** written in a structured, developer-friendly **README format**, organized by user roles and grouped by functionality:

---

## 📚 API Endpoints – InternGo Platform

All routes are prefixed with: `https://localhost:{PORT}/api/`

---

### 🔐 Authentication

#### POST `/auth/register`

> Register a new user (Student or Company).

**Body:**

```json
{
  "fullName": "John Doe",
  "email": "john@example.com",
  "password": "securePassword123",
  "role": "Student" // or "Company"
}
```

**Response:**

```json
{
  "token": "{jwt_token}",
  "email": "john@example.com",
  "role": "Student"
}
```

---

#### POST `/auth/login`

> Authenticate and receive a JWT token.

**Body:**

```json
{
  "email": "john@example.com",
  "password": "securePassword123"
}
```

**Response:**

```json
{
  "token": "{jwt_token}",
  "email": "john@example.com",
  "role": "Student"
}
```

---

### 👨‍🎓 Student Endpoints

> Requires `Authorization: Bearer <jwt>` and role: **Student**

---

#### GET `/student/profile`

> Get the logged-in student’s profile.

---

#### POST `/student/profile`

> Create a new student profile.

**Body:**

```json
{
  "experience": "2 internships in software development",
  "skills": "teamwork, leadership",
  "programmingLanguages": "C#, JavaScript",
  "coverLetter": "I'm a highly motivated intern...",
  "preferredLocation": "Ramallah",
  "phone": "0599999999"
}
```

---

#### PUT `/student/profile`

> Update the student profile.

(Same body as above.)

---

#### GET `/student/recommendations`

> Get AI-recommended internships based on profile.

**Response:**

```json
[
  {
    "internshipId": "guid",
    "title": "Flutter Internship",
    "description": "Develop mobile apps...",
    "companyName": "TechCorp",
    "matchScore": 0.92
  }
]
```

---

#### POST `/student/applications/apply`

> Apply to an internship.

**Body:**

```json
{
  "internshipId": "guid"
}
```

---

#### GET `/student/applications/my-applications`

> View internships the student has applied to.

---

#### GET `/student/applications/status/{applicationId}`

> Check application status.

---

#### POST `/student/reviews`

> Submit a review for an internship.

**Body:**

```json
{
  "internshipId": "guid",
  "rating": 5,
  "comment": "Great experience!"
}
```

---

#### GET `/student/reviews/{internshipId}`

> View reviews for an internship (public access).

---

#### POST `/student/internships/search`

> Search internships by filters.

**Body:**

```json
{
  "keyword": "flutter",
  "location": "Nablus",
  "minRating": 3
}
```

---

#### GET `/student/companies/{companyId}`

> View public company profile info.

---

### 🏢 Company Endpoints

> Requires `Authorization: Bearer <jwt>` and role: **Company**

---

#### POST `/company/internship`

> Create a new internship posting.

**Body:**

```json
{
  "title": "Backend Internship",
  "description": "Work with ASP.NET Core",
  "capacity": 5,
  "deadline": "2025-07-01",
  "skillsRequired": "dotnet, csharp, sql"
}
```

---

#### PUT `/company/internship`

> Update an internship (same body as above).

---

#### DELETE `/company/internship/{id}`

> Delete an internship posting.

---

#### GET `/company/internship`

> View all internships posted by this company.

---

#### GET `/company/applications/internship/{internshipId}/applicants`

> View students who applied to a specific internship.

---

#### POST `/company/applications/update-status`

> Accept or reject a student’s application.

**Body:**

```json
{
  "applicationId": "guid",
  "status": "Accepted"
}
```

---

### 👩‍💼 Admin Endpoints

> Requires `Authorization: Bearer <jwt>` and role: **Admin**

---

#### GET `/admin/dashboard/users`

> View all users in the system.

---

#### PUT `/admin/dashboard/users/{userId}/toggle`

> Enable or disable a user account.

---

#### GET `/admin/dashboard/internships`

> View all internship listings.

---

#### DELETE `/admin/dashboard/internships/{internshipId}`

> Delete a specific internship.

---

#### GET `/admin/dashboard/applications`

> View all applications submitted by students.

---

#### DELETE `/admin/dashboard/reviews/{reviewId}`

> Delete an inappropriate or reported review.

---



