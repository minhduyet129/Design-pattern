# 💾 Memento Pattern

## 1. Định nghĩa
**Memento** là một mẫu thiết kế thuộc nhóm Behavioral, cho phép bạn lưu lưu lại trạng thái của một đối tượng và khôi phục lại trạng thái đó sau này mà không vi phạm quy tắc đóng gói (encapsulation).

> "Without violating encapsulation, capture and externalize an object's internal state so that the object can be restored to this state later."

## 2. Bài toán ví dụ (Trình soạn thảo văn bản)
- Bạn đang xây dựng một trình soạn thảo văn bản có tính năng **Undo (Hoàn tác)**.
- Khi người dùng gõ phím, trạng thái của văn bản thay đổi. Bạn muốn lưu lại các trạng thái này để người dùng có thể quay lại bước trước đó nếu cần.
- Tuy nhiên, trạng thái bên trong của trình soạn thảo (như vị trí con trỏ, định dạng...) có thể rất phức tạp và được đóng gói kỹ. Nếu để lớp khác trực tiếp truy cập và lưu lại các biến này, tính đóng gói sẽ bị phá vỡ.
- **Giải pháp:** Sử dụng Memento. Lớp soạn thảo (**Originator**) tự tạo ra một đối tượng lưu trữ (**Memento**) chứa bản sao trạng thái của chính nó. Lớp quản lý lịch sử (**Caretaker**) sẽ lưu giữ danh sách các Memento này nhưng không thể xem hay sửa nội dung bên trong chúng.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Originator (`Editor`):** Đối tượng có trạng thái cần lưu. Nó tạo ra Memento chứa trạng thái hiện tại và sử dụng Memento để khôi phục lại trạng thái cũ.
2.  **Memento (`IMemento`, `ConcreteMemento`):** Đối tượng lưu trữ trạng thái của Originator. Nó đóng vai trò là một hộp đen đối với các đối tượng khác.
3.  **Caretaker (`History`):** Chịu trách nhiệm lưu giữ các Memento. Nó không bao giờ thao tác hay xem nội dung của Memento.

### UML Diagram (Text-based):
```
      Originator <--------------------------- Caretaker
    - state                                    - mementos: List<Memento>
    + Save(): Memento                          + Backup()
    + Restore(memento)                         + Undo()
          |                                          |
          | creates                                  | works with
          v                                          v
       Memento <-------------------------------------+
    - state
    + GetState() (only for Originator)
```

## 4. Tại sao nên dùng? (Pros)
- **Đảm bảo tính đóng gói:** Originator tự quản lý trạng thái của mình, không để lộ chi tiết triển khai ra ngoài.
- **Dễ dàng triển khai Undo/Redo:** Cung cấp một cơ chế chuẩn để quay lại các trạng thái trước đó.
- **Đơn giản hóa Originator:** Originator không cần phải quản lý lịch sử các phiên bản trạng thái, trách nhiệm đó thuộc về Caretaker.

## 5. Nhược điểm (Cons)
- **Tốn bộ nhớ:** Nếu trạng thái của đối tượng quá lớn hoặc việc lưu trữ xảy ra quá thường xuyên, bộ nhớ sẽ bị chiếm dụng rất nhiều.
- **Chi phí vòng đời:** Việc tạo và hủy Memento liên tục có thể ảnh hưởng đến hiệu năng.

## 6. Lưu ý về Benchmark
Memento Pattern có ảnh hưởng trực tiếp đến **RAM** vì nó lưu trữ các bản sao trạng thái. Trong ví dụ đơn giản này, chi phí là không đáng kể. Tuy nhiên, trong các ứng dụng thực tế với dữ liệu khổng lồ, việc tối ưu hóa Memento (chỉ lưu các thay đổi thay vì toàn bộ trạng thái) là rất quan trọng. Tôi đánh giá **không cần thiết** thực hiện Benchmark cho ví dụ này, nhưng bạn nên lưu ý về dung lượng bộ nhớ khi áp dụng cho các object lớn.
