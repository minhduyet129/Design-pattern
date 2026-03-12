# 🗨️ Mediator Pattern

## 1. Định nghĩa
**Mediator** là một mẫu thiết kế thuộc nhóm Behavioral, giúp giảm bớt sự phụ thuộc lẫn nhau giữa các lớp bằng cách bắt buộc chúng phải liên lạc thông qua một đối tượng trung gian (mediator).

> "Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently."

## 2. Bài toán ví dụ (Hệ thống điều phối linh kiện)
- Bạn có nhiều lớp (linh kiện) khác nhau trong một hệ thống phức tạp.
- Ví dụ: Trong một form đăng ký, khi chọn một checkbox, một nút bấm có thể bị vô hiệu hóa, và một ô nhập liệu có thể hiện ra.
- Nếu mỗi linh kiện phải biết về tất cả các linh kiện khác để tương tác, hệ thống sẽ trở nên cực kỳ rắc rối và khó bảo trì.
- **Giải pháp:** Tách biệt các linh kiện. Thay vì tương tác trực tiếp, các linh kiện chỉ cần thông báo cho một **Mediator** (người điều phối) về các sự kiện xảy ra. Mediator sẽ chứa logic để quyết định linh kiện nào cần làm gì tiếp theo.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Mediator Interface (`IMediator`):** Khai báo phương thức để các linh kiện thông báo sự kiện (`Notify`).
2.  **Concrete Mediator (`ConcreteMediator`):** Thực thi logic điều phối giữa các linh kiện cụ thể. Nó giữ tham chiếu đến các linh kiện mà nó quản lý.
3.  **Base Component (`BaseComponent`):** Lớp cơ sở chứa một tham chiếu đến Mediator.
4.  **Concrete Components (`Component1`, `Component2`):** Các lớp thực hiện chức năng cụ thể. Chúng không biết về nhau, chỉ biết về Mediator.

### UML Diagram (Text-based):
```
      Component1 <------------------- Mediator (Interface) -------------------> Component2
    + Operation1()                     + Notify()                           + Operation2()
          |                                ^                                    |
          | notifies                       |                                    | notifies
          +--------------------------------+------------------------------------+
```

## 4. Tại sao nên dùng? (Pros)
- **Giảm phụ thuộc (Low Coupling):** Các linh kiện hoàn toàn độc lập với nhau, giúp dễ dàng tái sử dụng và kiểm thử.
- **Single Responsibility Principle:** Gom toàn bộ logic điều phối phức tạp vào một nơi duy nhất (Mediator).
- **Open/Closed Principle:** Có thể thêm các Mediator mới hoặc thay đổi logic điều phối mà không cần sửa đổi mã nguồn của các linh kiện.

## 5. Nhược điểm (Cons)
- **Nguy cơ trở thành God Object:** Nếu không được thiết kế tốt, Mediator có thể trở nên quá lớn và phức tạp vì nó chứa toàn bộ logic tương tác của hệ thống.

## 6. Lưu ý về Benchmark
Mediator Pattern chủ yếu giải quyết vấn đề về kiến trúc phần mềm và sự phụ thuộc giữa các lớp. Việc chuyển tiếp lời gọi qua một đối tượng trung gian tốn thêm một chút thời gian, nhưng trong hầu hết các ứng dụng thực tế, chi phí này là không đáng kể so với lợi ích về mặt bảo trì. Do đó, tôi đánh giá **không cần thiết** thực hiện Benchmark cho pattern này.
