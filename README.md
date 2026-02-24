# .NET Design Patterns Mastery

Chào mừng bạn đến với chương trình học Design Patterns toàn diện dành cho .NET Developer.

## 📚 Tài liệu học tập
1. **[Lộ trình học (Syllabus)](SYLLABUS.md):** Danh sách 23 Patterns, giải thích chi tiết và ví dụ.
2. **[Quy trình chọn Pattern (Flowchart)](PATTERN_FLOWCHART.md):** Sơ đồ giúp bạn quyết định khi nào dùng Pattern nào.
3. **[Anti-Patterns Checklist](ANTI_PATTERNS.md):** Những sai lầm cần tránh.

## 🛠 Cấu trúc dự án
Source code được tổ chức theo nhóm Pattern của GoF:

- `01.Creational/`: Nhóm khởi tạo (Singleton, Factory, Builder...)
  - `Singleton/`: Ví dụ mẫu về Singleton (Basic, Thread-safe, Real-world).
- `02.Structural/`: Nhóm cấu trúc (Adapter, Facade...)
- `03.Behavioral/`: Nhóm hành vi (Observer, Strategy...)
- `00.Benchmarks/`: Dự án đo lường hiệu năng của các Pattern so với cách code thông thường.

## 🚀 Cách chạy thử
### 1. Chạy ví dụ Singleton
```powershell
cd 01.Creational/Singleton
dotnet run
```

### 2. Chạy Benchmark (Đo hiệu năng)
*Lưu ý: Cần chạy ở chế độ Release để có kết quả chính xác.*
```powershell
cd 00.Benchmarks
dotnet run -c Release
```

## 📝 Bài tập thực hành
Mở file `SYLLABUS.md` để xem danh sách bài tập và yêu cầu cho từng Pattern.

---
*Được thiết kế bởi AI Assistant - Chuyên gia .NET của bạn.*
