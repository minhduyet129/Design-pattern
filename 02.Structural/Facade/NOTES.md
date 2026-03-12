# 🏛️ Facade Pattern

## 1. Định nghĩa
**Facade** là một mẫu thiết kế thuộc nhóm Structural, cung cấp một giao diện đơn giản hóa cho một hệ thống phức tạp gồm nhiều lớp, thư viện hoặc framework.

> "Provide a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use."

## 2. Bài toán ví dụ (Chuyển đổi Video)
- Giả sử bạn cần sử dụng một thư viện chuyển đổi video cực kỳ phức tạp.
- Thư viện này yêu cầu bạn phải khởi tạo hàng chục đối tượng (`VideoFile`, `CodecFactory`, `BitrateReader`, `AudioMixer`...), thiết lập các codec (`MPEG4`, `Ogg`), quản lý bộ đệm và xử lý âm thanh riêng biệt.
- Nếu mỗi khi cần chuyển đổi video, Client đều phải viết lại toàn bộ các bước này, code sẽ cực kỳ rác và dễ lỗi.
- **Giải pháp:** Tạo một lớp `VideoConverter` (Facade). Client chỉ cần gọi một phương thức duy nhất `ConvertVideo(filename, format)`. Toàn bộ sự phức tạp bên dưới sẽ được Facade che giấu.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Facade (`VideoConverter`):** Cung cấp các chức năng tiện ích cho một phần cụ thể của hệ thống con. Nó biết nơi để gửi yêu cầu của khách hàng và cách kết nối tất cả các bộ phận di động.
2.  **Additional Facade:** Bạn có thể tạo nhiều Facade để tránh làm cho một Facade duy nhất trở nên quá tải với quá nhiều tính năng.
3.  **Complex Subsystem:** Bao gồm hàng chục lớp khác nhau. Để làm cho tất cả chúng làm điều gì đó hữu ích, bạn thường phải đi sâu vào các chi tiết triển khai của hệ thống con.
4.  **Client:** Sử dụng Facade thay vì gọi trực tiếp các đối tượng của hệ thống con.

### UML Diagram (Text-based):
```
      Client -----------------------> Facade
                                         |
                                         | uses
                                         v
                +----------------------------------------------+
                |              Complex Subsystem               |
                |  [Class A]    [Class B]    [Class C]         |
                |  [Class D]    [Class E]    [Class F]         |
                +----------------------------------------------+
```

## 4. Tại sao nên dùng? (Pros)
- **Cô lập Client:** Client không bị ảnh hưởng bởi những thay đổi trong các lớp của hệ thống con.
- **Dễ sử dụng:** Cung cấp một giao diện đơn giản cho các tác vụ phổ biến nhất.
- **Giảm phụ thuộc:** Giúp giảm thiểu sự phụ thuộc giữa Client và các lớp phức tạp bên dưới (Low Coupling).

## 5. Nhược điểm (Cons)
- **Nguy cơ trở thành God Object:** Một Facade có thể trở thành một đối tượng quá lớn, nắm giữ quá nhiều trách nhiệm nếu không được thiết kế tốt.

## 6. Lưu ý về Benchmark
Facade Pattern là một mẫu thiết kế thuần túy về cấu trúc và tính đóng gói. Nó **không gây ra overhead đáng kể** về hiệu năng (chỉ tốn thêm một vài lời gọi hàm chuyển tiếp). Lợi ích chính của nó là tiết kiệm thời gian phát triển và giảm thiểu lỗi, do đó **không cần thiết** thực hiện Benchmark.
