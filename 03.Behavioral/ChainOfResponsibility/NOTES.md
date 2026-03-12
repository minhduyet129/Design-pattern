# 🔗 Chain of Responsibility Pattern

## 1. Định nghĩa
**Chain of Responsibility** là một mẫu thiết kế thuộc nhóm Behavioral, cho phép bạn chuyển các yêu cầu (requests) dọc theo một chuỗi các trình xử lý (handlers). Khi nhận được một yêu cầu, mỗi trình xử lý sẽ quyết định xử lý yêu cầu đó hoặc chuyển nó cho trình xử lý tiếp theo trong chuỗi.

> "Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it."

## 2. Bài toán ví dụ (Hệ thống phê duyệt)
- Giả sử bạn có một hệ thống phê duyệt yêu cầu nghỉ phép.
- Nếu nhân viên xin nghỉ < 2 ngày: Trưởng phòng có thể phê duyệt.
- Nếu từ 2 - 5 ngày: Giám đốc bộ phận phê duyệt.
- Nếu > 5 ngày: Giám đốc điều hành phê duyệt.
- Thay vì sử dụng một đống câu lệnh `if-else` khổng lồ, bạn tạo ra một chuỗi các đối tượng phê duyệt. Mỗi đối tượng chỉ quan tâm đến logic của mình và biết đối tượng tiếp theo là ai.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Handler Interface (`IHandler`):** Khai báo phương thức để thiết lập trình xử lý tiếp theo và phương thức để xử lý yêu cầu.
2.  **Base Handler (`BaseHandler`):** Lớp trừu tượng tùy chọn để thực hiện hành vi mặc định (chuyển yêu cầu cho handler tiếp theo).
3.  **Concrete Handlers (`MonkeyHandler`, `SquirrelHandler`, `DogHandler`):** Chứa logic xử lý thực tế. Nếu không thể xử lý, nó gọi phương thức của lớp cha để chuyển tiếp.
4.  **Client:** Xây dựng chuỗi và gửi yêu cầu đến handler đầu tiên.

### UML Diagram (Text-based):
```
      Client -----------------------> IHandler
                                         ^
                                         |
                        +----------------+----------------+
                        |                                 |
                BaseHandler <----------------------- ConcreteHandler
                - nextHandler                         + Handle()
                + SetNext()
                + Handle()
```

## 4. Tại sao nên dùng? (Pros)
- **Giảm phụ thuộc (Low Coupling):** Người gửi yêu cầu không cần biết ai sẽ xử lý nó.
- **Single Responsibility Principle:** Mỗi lớp chỉ tập trung vào một loại xử lý cụ thể.
- **Open/Closed Principle:** Có thể thêm các handler mới vào chuỗi mà không làm hỏng code hiện tại.
- **Linh hoạt:** Có thể thay đổi thứ tự hoặc thành phần của chuỗi lúc runtime.

## 5. Nhược điểm (Cons)
- **Không đảm bảo xử lý:** Một yêu cầu có thể đi hết chuỗi mà không được ai xử lý.
- **Khó debug:** Chuỗi quá dài có thể gây khó khăn khi theo dõi luồng xử lý.

## 6. Lưu ý về Benchmark
Chain of Responsibility chủ yếu giải quyết vấn đề về sự linh hoạt trong thiết kế. Mặc dù việc duyệt qua một danh sách các đối tượng tốn nhiều thời gian hơn một câu lệnh `switch-case` trực tiếp, nhưng sự khác biệt này là cực kỳ nhỏ trong hầu hết các ứng dụng thực tế. Do đó, tôi đánh giá **không cần thiết** thực hiện Benchmark cho pattern này trừ khi chuỗi xử lý cực kỳ dài (hàng ngàn handler) hoặc tần suất gọi yêu cầu là cực lớn.
