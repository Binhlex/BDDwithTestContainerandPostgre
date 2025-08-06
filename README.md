# Example BDD with Reqnroll + PostgreSQL Testcontainers + NUnit

## Yêu cầu
- .NET 8.0+
- Docker
- Docker daemon đang chạy

## Cài đặt
```bash
dotnet restore
```

## Chạy test
```bash
dotnet test
```

Logs sẽ hiển thị test scenario và PostgreSQL container sẽ tự khởi động, chạy test rồi cleanup.

## Mô tả

Dự án này minh họa cách sử dụng:
- **Reqnroll** - Framework BDD (Behavior Driven Development) cho .NET
- **PostgreSQL Testcontainers** - Chạy PostgreSQL trong Docker container cho testing
- **NUnit** - Framework testing
- **Dapper** - Micro ORM cho truy cập database

## Cấu trúc thư mục

```
TestProject/
├── .github/
│   └── workflows/
│       └── ci.yml         # GitHub Actions CI workflow
├── Features/
│   └── CreateUser.feature # BDD feature file
├── Setup/
│   └── TestEnvironment.cs # Setup PostgreSQL container
├── Steps/
│   └── UserSteps.cs       # Step definitions cho BDD
├── UserService.cs         # Service layer cho user operations
├── TestProject.csproj     # Project file
└── README.md             # File này
```

## Cách hoạt động

1. **TestEnvironment.cs** khởi tạo PostgreSQL container khi test bắt đầu
2. **CreateUser.feature** định nghĩa scenario test bằng Gherkin syntax
3. **UserSteps.cs** implement các step definitions
4. **UserService.cs** chứa logic business để tương tác với database
5. Test chạy, verify kết quả, và cleanup container

## CI/CD

Project đã được cấu hình GitHub Actions để tự động chạy test khi có push hoặc pull request.