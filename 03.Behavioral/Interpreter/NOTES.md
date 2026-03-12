# 🗣️ Interpreter Pattern

## 1. Định nghĩa
**Interpreter** là một mẫu thiết kế thuộc nhóm Behavioral, dùng để định nghĩa một biểu diễn ngôn ngữ cho một ngữ pháp và một trình thông dịch sử dụng biểu diễn đó để thông dịch các câu trong ngôn ngữ đó.

> "Given a language, define a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language."

## 2. Bài toán ví dụ (Tính toán biểu thức toán học)
- Bạn cần xây dựng một chương trình để tính giá trị của các biểu thức toán học dạng chuỗi, ví dụ: `(a + b) - c`.
- Ngôn ngữ này có các quy tắc (ngữ pháp): số, biến, phép cộng, phép trừ.
- **Giải pháp:** Mỗi thành phần của ngữ pháp sẽ được đại diện bởi một lớp (`TerminalExpression` cho số/biến, `NonTerminalExpression` cho phép toán). Khi kết hợp chúng lại, bạn sẽ tạo ra một cấu trúc cây đại diện cho biểu thức đó. Việc gọi phương thức `Interpret()` từ gốc cây sẽ cho ra kết quả cuối cùng.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Abstract Expression (`IExpression`):** Khai báo phương thức `Interpret()`.
2.  **Terminal Expression (`NumberExpression`, `VariableExpression`):** Thực thi phương thức `Interpret()` cho các ký hiệu kết thúc trong ngữ pháp (không chứa các biểu thức khác bên trong).
3.  **Non-terminal Expression (`AddExpression`, `SubtractExpression`):** Đại diện cho các quy tắc phức tạp hơn, chứa các biểu thức con.
4.  **Context (`Context`):** Chứa thông tin toàn cục, chẳng hạn như giá trị của các biến.
5.  **Client:** Xây dựng (hoặc nhận) cấu trúc cây các biểu thức và gọi phương thức thông dịch.

### UML Diagram (Text-based):
```
      Client -----------------------> Context
         |                                
         | calls                          
         v                                
      AbstractExpression <----------------+
    + Interpret(Context)                  |
          ^                               |
          | implements                    | references
+---------+---------+            +--------+---------+
|                   |            |                  |
TerminalExpression  |      NonTerminalExpression    |
+ Interpret()       |      + Interpret()            |
                    |                               |
                    +-------------------------------+
```

## 4. Tại sao nên dùng? (Pros)
- **Dễ dàng thay đổi/mở rộng ngữ pháp:** Việc thêm các quy tắc mới chỉ đơn giản là tạo thêm các lớp mới.
- **Tách biệt logic:** Mã nguồn xử lý từng phần của ngôn ngữ được tách biệt rõ ràng.

## 5. Nhược điểm (Cons)
- **Khó bảo trì với ngữ pháp phức tạp:** Khi ngữ pháp trở nên quá lớn, số lượng lớp sẽ bùng nổ và cấu trúc cây trở nên cực kỳ khó quản lý.
- **Hiệu năng:** Việc duyệt cây đệ quy có thể chậm hơn so với các phương pháp phân tích cú pháp khác (như dùng parser generator).

## 6. Lưu ý về Benchmark
Interpreter Pattern chủ yếu tập trung vào việc giải quyết các bài toán về ngôn ngữ và ngữ pháp. Do bản chất của nó là duyệt cây đệ quy, nó **có thể tốn kém CPU và RAM** nếu cây biểu thức quá sâu hoặc được thực hiện quá nhiều lần. Tuy nhiên, trong ví dụ toán học đơn giản này, overhead là không đáng kể. Tôi đánh giá **không cần thiết** thực hiện Benchmark cho pattern này trừ khi bạn đang xây dựng một bộ máy xử lý quy tắc (Rule Engine) với hàng triệu biểu thức phức tạp.
