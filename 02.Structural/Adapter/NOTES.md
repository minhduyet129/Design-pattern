# 🔌 Adapter Pattern

## 1. Định nghĩa
**Adapter** là một mẫu thiết kế thuộc nhóm Structural, cho phép các đối tượng có giao diện không tương thích có thể làm việc cùng nhau. Nó đóng vai trò như một bộ chuyển đổi giữa hai hệ thống.

> "Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces."

## 2. Bài toán ví dụ (Legacy System)
- Bạn đang phát triển một hệ thống mới sử dụng giao diện `ITarget`.
- Bạn cần tích hợp một thư viện hoặc hệ thống cũ (Legacy System) có những tính năng rất hữu ích nhưng lại có giao diện (`GetSpecificRequest`) hoàn toàn khác với những gì hệ thống mới mong đợi.
- Bạn không thể sửa đổi mã nguồn của hệ thống cũ (vì nó là thư viện bên thứ ba hoặc quá cũ để bảo trì).
- Giải pháp: Tạo ra một lớp **Adapter** để bọc lấy hệ thống cũ và cung cấp giao diện tương thích với hệ thống mới.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Client:** Chứa logic nghiệp vụ của chương trình, làm việc với `Target` interface.
2.  **Target (`ITarget`):** Giao diện mà Client mong đợi.
3.  **Adaptee (`LegacySystem`):** Lớp có giao diện không tương thích cần được chuyển đổi.
4.  **Adapter (`SystemAdapter`):** Lớp thực thi `Target` interface và chứa một tham chiếu đến `Adaptee`. Nó chuyển đổi các lời gọi từ `Target` sang định dạng mà `Adaptee` hiểu được.

### UML Diagram (Text-based):
```
       Client
          |
          v
      ITarget <------------------- SystemAdapter (Adapter)
    + GetRequest()                    |
                                      | calls
                                      v
                                LegacySystem (Adaptee)
                                + GetSpecificRequest()
```

## 4. Tại sao nên dùng? (Pros)
- **Single Responsibility Principle:** Bạn có thể tách biệt mã chuyển đổi giao diện khỏi logic nghiệp vụ của chương trình.
- **Open/Closed Principle:** Bạn có thể thêm các loại Adapter mới vào chương trình mà không làm hỏng mã nguồn Client hiện tại.
- **Tái sử dụng:** Cho phép sử dụng lại các lớp cũ hoặc thư viện bên thứ ba mà không cần thay đổi code của chúng.

## 5. Nhược điểm (Cons)
- **Tăng độ phức tạp:** Tổng thể mã nguồn trở nên phức tạp hơn do phải thêm các interface và lớp mới. Đôi khi việc thay đổi trực tiếp `Adaptee` sẽ đơn giản hơn (nếu có thể).

## 6. Lưu ý về Benchmark
Mẫu thiết kế Adapter chủ yếu giải quyết vấn đề về cấu trúc và sự tương thích của giao diện. Nó **không gây ảnh hưởng đáng kể đến hiệu năng** (chỉ tốn thêm một lời gọi hàm trung gian), do đó không cần thiết phải thực hiện Benchmark cho pattern này trừ khi logic chuyển đổi bên trong Adapter cực kỳ phức tạp.
