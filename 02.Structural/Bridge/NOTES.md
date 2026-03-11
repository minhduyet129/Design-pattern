# 🌉 Bridge Pattern

## 1. Định nghĩa
**Bridge** là một mẫu thiết kế thuộc nhóm Structural, cho phép bạn chia một lớp lớn hoặc một tập hợp các lớp liên quan chặt chẽ thành hai hệ thống phân cấp riêng biệt—**Abstraction** (Trừu tượng) và **Implementation** (Triển khai)—có thể phát triển độc lập với nhau.

> "Decouple an abstraction from its implementation so that the two can vary independently."

## 2. Bài toán ví dụ (Remote Control)
- Giả sử bạn có một lớp `Shape` với các lớp con `Circle` và `Square`. Bạn muốn thêm màu sắc vào các hình này (Đỏ và Xanh).
- Nếu dùng kế thừa thông thường, bạn sẽ cần 4 lớp: `RedCircle`, `BlueCircle`, `RedSquare`, `BlueSquare`.
- Nếu thêm một hình mới (Tam giác) hoặc một màu mới (Vàng), số lượng lớp con sẽ tăng vọt theo cấp số nhân (Combinatorial Explosion).
- **Giải pháp:** Tách `Shape` (Abstraction) và `Color` (Implementation) thành hai hệ thống riêng biệt. `Shape` sẽ chứa một tham chiếu đến `Color`.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Abstraction (`RemoteControl`):** Cung cấp các chức năng điều khiển cấp cao, dựa trên các phương thức của Implementation.
2.  **Refined Abstraction (`AdvancedRemoteControl`):** Mở rộng các chức năng của Abstraction mà không cần thay đổi Implementation.
3.  **Implementation (`IDevice`):** Giao diện chung cho tất cả các lớp triển khai cụ thể. Nó không nhất thiết phải giống giao diện của Abstraction.
4.  **Concrete Implementation (`Tv`, `Radio`):** Chứa các mã triển khai thực tế cho từng nền tảng/thiết bị cụ thể.

### UML Diagram (Text-based):
```
      Abstraction <--------------------------- Implementation (Interface)
    - implementation -----------------------> + OperationImp()
    + Operation()                                     ^
          ^                                           |
          | extends                                   | implements
          |                                   +-------+-------+
  RefinedAbstraction                          |               |
  + Operation()                       ConcreteImpA    ConcreteImpB
                                      + OperationImp() + OperationImp()
```

## 4. Tại sao nên dùng? (Pros)
- **Tách biệt giao diện và triển khai:** Bạn có thể thay đổi hoặc tráo đổi Implementation lúc runtime.
- **Open/Closed Principle:** Bạn có thể thêm Abstraction mới hoặc Implementation mới mà không làm ảnh hưởng đến phần còn lại.
- **Single Responsibility Principle:** Abstraction tập trung vào logic điều khiển, Implementation tập trung vào logic thực thi chi tiết.
- **Giảm số lượng lớp con:** Tránh được tình trạng bùng nổ lớp con khi có nhiều biến thể.

## 5. Nhược điểm (Cons)
- **Tăng độ phức tạp:** Mã nguồn có thể trở nên khó hiểu hơn đối với những người chưa quen với pattern này do có thêm nhiều lớp và interface trung gian.

## 6. Lưu ý về Benchmark
Bridge Pattern chủ yếu giải quyết vấn đề về cấu trúc lớp và khả năng mở rộng. Nó **không gây ra sự sụt giảm hiệu năng đáng kể** (chỉ tốn thêm một lời gọi hàm thông qua composition), vì vậy không cần thiết phải thực hiện Benchmark trừ khi logic trong các phương thức triển khai rất nặng nề.
