# 🎀 Decorator Pattern

## 1. Định nghĩa
**Decorator** là một mẫu thiết kế thuộc nhóm Structural, cho phép bạn gán các hành vi mới cho các đối tượng một cách linh hoạt bằng cách đặt chúng bên trong các đối tượng "vỏ bọc" (wrapper) đặc biệt chứa các hành vi này.

> "Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality."

## 2. Bài toán ví dụ (Hệ thống thông báo)
- Bạn có một lớp `EmailNotifier` để gửi thông báo qua email.
- Sau đó, bạn muốn thêm tính năng gửi qua SMS, Slack, Facebook...
- Nếu sử dụng kế thừa, bạn sẽ gặp tình trạng bùng nổ lớp con (ví dụ: `EmailAndSMSNotifier`, `EmailAndSlackNotifier`, `EmailSMSAndSlackNotifier`...).
- **Giải pháp:** Sử dụng Decorator. Mỗi loại thông báo mới sẽ là một decorator bọc quanh notifier gốc. Bạn có thể kết hợp chúng theo bất kỳ cách nào tại thời điểm chạy (runtime).

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Component (`INotifier`):** Giao diện chung cho cả đối tượng gốc và các decorator.
2.  **Concrete Component (`EmailNotifier`):** Đối tượng gốc mà chúng ta muốn thêm hành vi.
3.  **Base Decorator (`BaseDecorator`):** Lớp trừu tượng chứa một tham chiếu đến đối tượng được bọc (`wrappee`) và thực thi giao diện Component.
4.  **Concrete Decorators (`SMSDecorator`, `SlackDecorator`):** Các lớp thực thi các hành vi bổ sung. Chúng gọi phương thức của đối tượng được bọc trước hoặc sau khi thực hiện hành vi của chính mình.

### UML Diagram (Text-based):
```
      Component <--------------------------- BaseDecorator
    + Operation()                             + Operation()
          ^                                          |
          | implements                               | delegates to
          |                                          v
  ConcreteComponent                           Component (wrappee)
    + Operation()                                    ^
                                                     |
                                            ConcreteDecorator
                                              + Operation()
```

## 4. Tại sao nên dùng? (Pros)
- **Linh hoạt hơn kế thừa:** Bạn có thể thêm/xóa trách nhiệm của đối tượng lúc runtime.
- **Kết hợp nhiều hành vi:** Có thể bọc một đối tượng trong nhiều decorator cùng lúc.
- **Single Responsibility Principle:** Mỗi decorator chỉ tập trung vào một hành vi cụ thể.

## 5. Nhược điểm (Cons)
- **Khó xóa một wrapper cụ thể:** Rất khó để gỡ bỏ một decorator nằm sâu trong ngăn xếp các wrapper.
- **Nhiều đối tượng nhỏ:** Hệ thống có thể có rất nhiều đối tượng nhỏ giống nhau, gây khó khăn khi debug.

## 6. Lưu ý về Benchmark
Decorator Pattern sử dụng Composition và lồng các lời gọi hàm. Trong hầu hết các ứng dụng doanh nghiệp, chi phí của một lời gọi hàm bổ sung là không đáng kể so với các thao tác I/O (gửi email, gọi API). Do đó, tôi đánh giá **không cần thiết** thực hiện Benchmark cho pattern này trừ khi bạn thực hiện hàng triệu phép tính toán nhỏ trong một vòng lặp cực ngắn.
