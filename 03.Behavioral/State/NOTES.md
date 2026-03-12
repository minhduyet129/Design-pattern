# 🔄 State Pattern

## 1. Định nghĩa
**State** là một mẫu thiết kế thuộc nhóm Behavioral, cho phép một đối tượng thay đổi hành vi của nó khi trạng thái nội bộ của nó thay đổi. Đối tượng sẽ giống như thể nó đã thay đổi lớp của chính mình.

> "Allow an object to alter its behavior when its internal state changes. The object will appear to change its class."

## 2. Bài toán ví dụ (Máy bán kẹo tự động)
- Hãy tưởng tượng một máy bán kẹo (Gumball Machine) có các trạng thái: `Hết kẹo`, `Chờ bỏ xu`, `Đã bỏ xu`, `Đang bán kẹo`.
- Tùy vào trạng thái hiện tại mà các hành động như `Bỏ xu`, `Quay cần gạt`, `Trả xu` sẽ có kết quả khác nhau.
- Nếu không dùng State Pattern, bạn sẽ phải viết hàng chục câu lệnh `if (state == ...)`, khiến code cực kỳ khó bảo trì và mở rộng.
- **Giải pháp:** Đóng gói mỗi trạng thái vào một lớp riêng. Máy bán kẹo (**Context**) sẽ ủy thác các hành động cho đối tượng trạng thái hiện tại. Khi thực hiện xong hành động, trạng thái này có thể tự chuyển đổi máy sang trạng thái mới.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Context (`VendingMachine`):** Lưu trữ một tham chiếu đến trạng thái hiện tại và ủy thác các yêu cầu từ Client cho trạng thái đó.
2.  **State Interface/Abstract Class (`StateBase`):** Khai báo các phương thức chung cho tất cả trạng thái.
3.  **Concrete States (`NoCoinState`, `HasCoinState`, ...):** Thực thi các hành vi cụ thể cho từng trạng thái.

### UML Diagram (Text-based):
```
      Context (VendingMachine) ----------------> State (Interface)
    - state                                      + Handle1()
    + Request1()                                 + Handle2()
    + TransitionTo(State)                               ^
                                                        |
                                         +--------------+--------------+
                                         |                             |
                                  ConcreteStateA                ConcreteStateB
                                  + Handle1()                   + Handle1()
```

## 4. Tại sao nên dùng? (Pros)
- **Single Responsibility Principle:** Gom các hành vi liên quan đến một trạng thái cụ thể vào một lớp duy nhất.
- **Open/Closed Principle:** Dễ dàng thêm các trạng thái mới mà không ảnh hưởng đến code cũ.
- **Loại bỏ if-else:** Giúp code sạch sẽ, dễ đọc và tránh lỗi logic phức tạp.

## 5. Nhược điểm (Cons)
- **Số lượng lớp tăng:** Có thể làm hệ thống trở nên quá mức cần thiết nếu máy trạng thái quá đơn giản (chỉ có 2-3 trạng thái).

## 6. Lưu ý về Benchmark
State Pattern chủ yếu giải quyết vấn đề về tổ chức code và logic nghiệp vụ. Việc chuyển đổi giữa các trạng thái và gọi hàm thông qua đa hình (polymorphism) tốn thêm một chút tài nguyên CPU nhưng hoàn toàn không đáng kể so với lợi ích về mặt kiến trúc. Do đó, tôi đánh giá **không cần thiết** thực hiện Benchmark cho pattern này.
