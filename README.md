# .NET Design Patterns Mastery

Chào mừng bạn đến với chương trình học Design Patterns toàn diện dành cho .NET Developer.

## 📚 Tài liệu học tập
1. **[TIẾN ĐỘ HỌC TẬP (LEARNING_PROGRESS.md)](LEARNING_PROGRESS.md):** ✅ Theo dõi bạn đã học đến đâu.
2. **[Lộ trình học (Syllabus)](SYLLABUS.md):** Danh sách 23 Patterns, giải thích chi tiết và ví dụ.
3. **[Quy trình chọn Pattern (Flowchart)](PATTERN_FLOWCHART.md):** Sơ đồ giúp bạn quyết định khi nào dùng Pattern nào.
4. **[Anti-Patterns Checklist](ANTI_PATTERNS.md):** Những sai lầm cần tránh.

## 🔄 Đồng bộ & Tiếp tục học trên máy khác
Khi bạn chuyển sang máy mới (hoặc từ công ty về nhà), hãy làm theo các bước sau:

1. **Lấy code mới nhất:**
   ```powershell
   git pull
   ```
2. **Kiểm tra tiến độ:**
   Mở file `LEARNING_PROGRESS.md` để xem bạn đã dừng ở đâu.

3. **Cài đặt môi trường tự động:**
   Chạy script sau để tự động cài đặt các thư viện cần thiết (.NET SDK, Nuget packages):
   ```powershell
   .\setup.ps1
   ```

4. **Bắt đầu code:**
   Mở folder pattern tiếp theo và thực hành.

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
