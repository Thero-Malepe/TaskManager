# 🧱 Task Manager

---

## Prerequisites

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- PostgreSQL (local or remote)
- Git
- Visual Studio 2022+ or VS Code (optional)
- EF Core CLI tools: `dotnet tool install --global dotnet-ef`

---

## Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/your-org/TaskManager.git
cd TaskManager
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Configure Database Connection
Update `appsettings.json` with your PostgreSQL connection string:
```json
"ConnectionStrings": {
  "TaskManagerDb": "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=xxxxxx;"
}
```

---

## 🧱 Entity Framework Core Migrations

### Apply Existing Migrations
The project includes initial migration files. To apply them:
```bash
dotnet ef database update
```
---

## ▶️ Run the Application

### Start the Web API
```bash
dotnet run
```
Or press `F5` in Visual Studio to launch the application.

---

## 📚 Documentation

Refer to:
- `Documentation/TaskManager Architecture Overview.docx`
- `Documentation/TaskManagerFlowDiagram.html`

For architectural insights and system flow.

```
