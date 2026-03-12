# 🪶 Flyweight Pattern

## 1. Định nghĩa
**Flyweight** là một mẫu thiết kế thuộc nhóm Structural, cho phép bạn chứa nhiều đối tượng hơn vào lượng RAM có sẵn bằng cách chia sẻ các phần trạng thái chung giữa nhiều đối tượng thay vì giữ tất cả dữ liệu trong mỗi đối tượng.

> "Use sharing to support large numbers of fine-grained objects efficiently."

## 2. Bài toán ví dụ (Mô phỏng Rừng cây)
- Bạn muốn tạo một trò chơi mô phỏng một khu rừng với hàng triệu cây xanh.
- Mỗi đối tượng `Tree` có các thuộc tính: tọa độ (`x`, `y`), tên cây, màu sắc và kết cấu (texture).
- Tọa độ `x`, `y` là duy nhất cho mỗi cây (**Extrinsic State**).
- Tên, màu sắc và texture thường giống nhau cho hàng ngàn cây cùng loại (**Intrinsic State**).
- Nếu mỗi cây lưu trữ toàn bộ dữ liệu này, bộ nhớ RAM sẽ bị quá tải nhanh chóng.
- **Giải pháp:** Tách dữ liệu dùng chung (Flyweight) ra khỏi dữ liệu riêng biệt (Context). Các đối tượng cây sẽ chỉ lưu tọa độ và một tham chiếu đến đối tượng chứa dữ liệu chung.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Flyweight (`TreeType`):** Chứa phần trạng thái chung (intrinsic state) có thể chia sẻ giữa nhiều đối tượng.
2.  **Context (`Tree`):** Chứa phần trạng thái riêng biệt (extrinsic state) duy nhất cho mỗi đối tượng và một tham chiếu đến Flyweight.
3.  **Flyweight Factory (`TreeFactory`):** Quản lý các đối tượng Flyweight, đảm bảo các đối tượng được chia sẻ chính xác và không tạo trùng lặp.
4.  **Client (`Forest`):** Tính toán hoặc lưu trữ trạng thái ngoại vi và phối hợp giữa các đối tượng.

### UML Diagram (Text-based):
```
      Client -----------------------> FlyweightFactory
         |                                |
         | uses                           | manages
         v                                v
      Context (Tree) ---------------> Flyweight (TreeType)
    - extrinsicState                 - intrinsicState
    + Operation()                    + Operation(extrinsicState)
```

## 4. Tại sao nên dùng? (Pros)
- **Tiết kiệm RAM cực lớn:** Giảm thiểu đáng kể dung lượng bộ nhớ khi làm việc với số lượng đối tượng khổng lồ.
- **Cải thiện hiệu năng:** Giảm bớt gánh nặng cho Garbage Collector do tạo ít đối tượng lớn hơn.

## 5. Nhược điểm (Cons)
- **Tăng độ phức tạp của code:** Cần tách biệt trạng thái nội vi và ngoại vi, làm code khó hiểu hơn.
- **Đánh đổi CPU:** Có thể tốn thêm một chút thời gian CPU để tìm kiếm và tham chiếu đến các đối tượng flyweight.

## 6. Kết quả Benchmark
Flyweight là một trong những pattern có ảnh hưởng rõ rệt nhất đến hiệu năng. Trong các bài kiểm tra thực tế:
- **Bộ nhớ:** Có thể giảm từ 50% - 90% dung lượng RAM tùy thuộc vào kích thước của Intrinsic State.
- **Tốc độ:** Việc giảm thiểu cấp phát bộ nhớ (Allocation) giúp ứng dụng chạy mượt mà hơn.
