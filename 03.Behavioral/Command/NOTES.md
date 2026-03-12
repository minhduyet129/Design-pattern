# 🎮 Command Pattern

## 1. Định nghĩa
**Command** là một mẫu thiết kế thuộc nhóm Behavioral, giúp chuyển đổi một yêu cầu thành một đối tượng độc lập chứa tất cả thông tin về yêu cầu đó. Việc chuyển đổi này cho phép bạn tham số hóa các phương thức với các yêu cầu khác nhau, trì hoãn hoặc xếp hàng đợi thực thi một yêu cầu và hỗ trợ các thao tác không thể hoàn tác (undoable operations).

> "Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations."

## 2. Bài toán ví dụ (Nút bấm trên giao diện)
- Giả sử bạn đang xây dựng một ứng dụng với nhiều nút bấm (Button).
- Mỗi nút bấm sẽ thực hiện một hành động khác nhau (Lưu, Mở, In, Copy...).
- Nếu bạn tạo các lớp con cho từng nút bấm (`SaveButton`, `PrintButton`...), code sẽ trở nên cực kỳ rắc rối và khó tái sử dụng.
- **Giải pháp:** Tách biệt lớp `Button` (Invoker) khỏi logic thực thi. Khi người dùng nhấn nút, `Button` chỉ cần gọi phương thức `Execute()` của một đối tượng `Command` được gán cho nó.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Command Interface (`ICommand`):** Khai báo phương thức `Execute()`.
2.  **Concrete Commands (`SimpleCommand`, `ComplexCommand`):** Thực hiện các hành động cụ thể. Một số lệnh tự thực hiện công việc, một số khác chuyển giao cho Receiver.
3.  **Receiver (`Receiver`):** Chứa logic nghiệp vụ thực tế. Bất kỳ lớp nào cũng có thể làm Receiver.
4.  **Invoker (`Invoker`):** Kích hoạt lệnh. Nó lưu trữ tham chiếu đến đối tượng Command nhưng không biết chi tiết về logic bên trong lệnh đó.
5.  **Client:** Tạo các đối tượng Concrete Command và thiết lập Receiver cho chúng.

### UML Diagram (Text-based):
```
      Invoker -----------------------> ICommand
         |                                ^
         | triggers                       |
         v                                | implements
      ICommand <------------------- ConcreteCommand ----------------> Receiver
    + Execute()                      + Execute()                      + Action()
```

## 4. Tại sao nên dùng? (Pros)
- **Single Responsibility Principle:** Tách biệt lớp kích hoạt hành động khỏi lớp thực hiện hành động.
- **Open/Closed Principle:** Có thể thêm các lệnh mới vào hệ thống mà không làm thay đổi code hiện tại.
- **Hỗ trợ Undo/Redo:** Vì lệnh là một đối tượng, bạn có thể lưu trữ lịch sử các lệnh đã thực hiện để hoàn tác.
- **Xếp hàng và lập lịch:** Có thể lưu trữ các lệnh vào hàng đợi để thực thi sau.

## 5. Nhược điểm (Cons)
- **Tăng độ phức tạp:** Code trở nên rắc rối hơn do có thêm một lớp trung gian giữa Sender và Receiver.

## 6. Lưu ý về Benchmark
Command Pattern chủ yếu tập trung vào việc tổ chức code và tách biệt các thành phần. Việc đóng gói một phương thức vào một đối tượng tốn thêm một chút bộ nhớ và thời gian cấp phát, nhưng trong hầu hết các ứng dụng, overhead này là không đáng kể so với lợi ích về mặt kiến trúc. Do đó, tôi đánh giá **không cần thiết** thực hiện Benchmark cho pattern này.
