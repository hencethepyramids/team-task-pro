# TeamTaskPro — Development Checklist

This is a full-stack checklist to guide development of **TeamTaskPro**, a task and bug-tracking platform using ASP.NET Core, SQL, JavaScript, Python, and Java microservices.

---

## ✅ 1. Environment Setup & Scaffolding
- [x] Install Visual Studio with ASP.NET & EF workloads
- [x] Install SQL Server Express or configure Azure SQL
- [x] Create new ASP.NET Core MVC project
- [x] Set up GitHub repository and push initial commit
- [x] Configure `appsettings.json` with DB connection string
- [x] Scaffold base layout (Bootstrap nav, header, footer)

**Stretch Goals**
- [ ] Add Docker support for backend and DB

---

## ✅ 2. Authentication & User Management
- [x] Add ASP.NET Identity to project
- [ ] Create Register / Login / Logout views
- [ ] Implement role-based access: Admin, Developer, QA, Client
- [ ] Seed default users and roles
- [ ] Restrict views using `[Authorize(Roles = "...")]`

**Stretch**
- [ ] Add user profile page with password change

---

## ✅ 3. Database & EF Core Modeling
- [x] Create models:
  - [x] `User` (linked to Identity)
  - [x] `TaskItem` (title, description, priority, status, assignee)
  - [x] `Comment` (linked to TaskItem and User)
  - [x] `Attachment` (file path, name, linked to TaskItem)
- [x] Configure `DbContext` with relationships
- [ ] Run `Add-Migration InitialCreate` and `Update-Database`

---

## ✅ 4. Task Management (CRUD)
- [ ] Create `TasksController` with:
  - [ ] `Index` (task list)
  - [ ] `Create`
  - [ ] `Edit`
  - [ ] `Details`
  - [ ] `Delete`
- [ ] Use ViewModels to pass related data to views
- [ ] Display tasks in a Bootstrap-styled table
- [ ] Implement status transitions: Open → In Progress → Closed

**Stretch**
- [ ] Add pagination and sorting

---

## ✅ 5. Comments & Attachments
- [ ] Enable users to post comments on tasks
- [ ] Use jQuery + AJAX to submit comments without page reload
- [ ] Allow file uploads (store in `/uploads/`, path in DB)
- [ ] Display attachments as links in task detail view

---

## ✅ 6. AJAX, JSON, and Live Search
- [ ] Add search input to task list
- [ ] Implement jQuery + AJAX to call `/api/tasks/search?q=`
- [ ] Return JSON and update DOM dynamically

**Stretch**
- [ ] Add category/tag filters with live results

---

## ✅ 7. REST API (ASP.NET Web API)
- [ ] Create `TasksApiController`
- [ ] Add endpoints:
  - [ ] `GET /api/tasks`
  - [ ] `POST /api/tasks`
  - [ ] `PUT /api/tasks/{id}`
  - [ ] `DELETE /api/tasks/{id}`
- [ ] Return JSON responses using `[ApiController]`
- [ ] Add basic API key or JWT protection (optional)

---

## ✅ 8. Reporting Microservice (Python)
- [ ] Create Flask or FastAPI app
- [ ] Create endpoint `/report/weekly`
- [ ] Connect to SQL or accept JSON input
- [ ] Use Pandas to:
  - [ ] Count tasks
  - [ ] Calculate average resolution time
  - [ ] Format weekly summary
- [ ] Output downloadable CSV or PDF report

**Stretch**
- [ ] Add job scheduler (cron or APScheduler)

---

## ✅ 9. Java Search Microservice
- [ ] Create Spring Boot project
- [ ] Build `/search?q=` endpoint
- [ ] Simulate full-text search across tasks
- [ ] Return JSON response
- [ ] Call from ASP.NET via `HttpClient` and update view

---

## ✅ 10. Testing & Debugging
- [x] Add unit tests for:
  - [x] Task CRUD
  - [ ] Search logic
  - [x] Comment posting
- [x] Use in-memory DB for integration tests
- [ ] Set breakpoints and use debugging tools in Visual Studio

---

## ✅ 11. Agile Workflow & DevOps
- [ ] Set up Trello or GitHub Projects
- [ ] Track weekly progress with issues/milestones
- [ ] Add `.github/workflows/` CI config for builds/tests
- [ ] Dockerize:
  - [ ] ASP.NET app
  - [ ] Python service
  - [ ] Java service
- [ ] Write `README.md` with setup, architecture, and contributors

---

## 💡 Notes
- Prioritize core features first (task CRUD, auth, and comments)
- Keep commits small and focused
- Write unit tests early, update regularly
- Review each feature from both user and dev perspectives
