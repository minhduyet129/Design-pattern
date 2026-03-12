# 🛡️ Proxy Pattern

## 1. Định nghĩa
**Proxy** là một mẫu thiết kế thuộc nhóm Structural, cho phép bạn cung cấp một đối tượng thay thế hoặc giữ chỗ cho một đối tượng khác. Một proxy kiểm soát truy cập vào đối tượng gốc, cho phép bạn thực hiện một số việc trước hoặc sau khi yêu cầu được chuyển đến đối tượng gốc.

> "Provide a surrogate or placeholder for another object to control access to it."

## 2. Các loại Proxy phổ biến
- **Virtual Proxy (Lazy Loading):** Chỉ tạo đối tượng thực sự khi cần thiết (tiết kiệm tài nguyên cho các đối tượng nặng).
- **Caching Proxy:** Lưu trữ kết quả của các thao tác tốn kém để trả về ngay lập tức cho các yêu cầu lặp lại.
- **Protection Proxy (Access Control):** Kiểm tra quyền hạn của Client trước khi cho phép truy cập đối tượng gốc.
- **Remote Proxy:** Đại diện cho một đối tượng nằm ở một máy chủ khác hoặc một không gian địa chỉ khác.
- **Logging Proxy:** Lưu lại lịch sử các lần gọi đến đối tượng gốc.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Subject (`IVideoService`):** Giao diện chung cho cả RealSubject và Proxy.
2.  **RealSubject (`YouTubeService`):** Đối tượng thực sự chứa logic nghiệp vụ, thường là đối tượng nặng hoặc tốn thời gian xử lý.
3.  **Proxy (`YouTubeCacheProxy`):** Chứa một tham chiếu đến RealSubject và thực thi cùng giao diện. Nó kiểm soát việc truy cập và có thể thêm logic bổ sung (như Caching).

### UML Diagram (Text-based):
```
      Client -----------------------> Subject (Interface)
                                         ^
                                         |
                        +----------------+----------------+
                        |                                 |
                RealSubject <----------------------- Proxy
                + Operation()        (wraps)         + Operation()
                                                     (adds caching/security)
```

## 4. Tại sao nên dùng? (Pros)
- **Kiểm soát truy cập:** Dễ dàng thêm logic bảo mật hoặc kiểm tra điều kiện.
- **Tối ưu hiệu năng:** Lazy loading và Caching giúp ứng dụng chạy nhanh hơn.
- **Quản lý vòng đời:** Proxy có thể quản lý việc tạo và hủy đối tượng RealSubject mà Client không cần biết.
- **Mã nguồn sạch:** Tuân thủ Single Responsibility Principle bằng cách tách biệt logic nghiệp vụ (RealSubject) và logic điều khiển truy cập (Proxy).

## 5. Nhược điểm (Cons)
- **Tăng độ trễ:** Thêm một lớp trung gian có thể làm chậm yêu cầu một chút (nếu không có cache).
- **Phức tạp:** Code trở nên rắc rối hơn do có thêm nhiều lớp mới.

## 6. Lưu ý về Benchmark
Proxy Pattern thường được dùng để **cải thiện hiệu năng** (thông qua Caching hoặc Lazy Load). Trong ví dụ YouTube, bạn sẽ thấy thời gian truy cập lần thứ hai giảm từ vài giây xuống còn gần như bằng 0 nhờ Cache. Do đó, việc Benchmark pattern này thường tập trung vào so sánh tốc độ xử lý khi có và không có Proxy.
