# 🎓 Tiến Độ Học Tập Design Patterns

Sử dụng file này để đánh dấu tiến độ của bạn. Trước khi commit code lên GitHub, hãy đánh dấu `[x]` vào các mục đã hoàn thành.
Khi sang máy khác, bạn chỉ cần `git pull` và mở file này để biết cần học tiếp bài nào.

## 🟢 1. Creational Patterns (Khởi tạo)
- [x] **Singleton**: Đảm bảo class chỉ có 1 instance.
  - [x] Basic Implementation
  - [x] Thread-safe & Lazy Loading
  - [x] Real-world Example (Config, Logger)
  - [x] Benchmark Test
- [x] **Factory Method**: Subclass quyết định khởi tạo.
  - [x] Interface Product (ITransport)
  - [x] Concrete Products (Truck, Ship)
  - [x] Creator & Concrete Creators (Logistics)
  - [x] Demo Client Code
- [x] **Abstract Factory**: Tạo họ đối tượng liên quan.
  - [x] Abstract Factory & Concrete Factories (IGUIFactory, WinFactory, MacFactory)
  - [x] Abstract Products & Concrete Products (IButton, ICheckbox)
  - [x] Client Code Implementation
- [x] **Builder**: Xây dựng đối tượng phức tạp từng bước.
- [x] **Prototype**: Copy đối tượng có sẵn.

## 🟡 2. Structural Patterns (Cấu trúc)
- [x] **Adapter**: Chuyển đổi giao diện.
- [x] **Bridge**: Tách rời Abstraction và Implementation.
- [x] **Composite**: Cấu trúc cây (Menu, Folder).
- [x] **Decorator**: Thêm hành vi động (Wrapper).
- [x] **Facade**: Đơn giản hóa hệ thống phức tạp.
- [x] **Flyweight**: Chia sẻ tài nguyên (RAM optimization).
- [x] **Proxy**: Kiểm soát truy cập (Lazy load, Security).

## 🔵 3. Behavioral Patterns (Hành vi)
- [ ] **Chain of Responsibility**: Chuỗi xử lý request.
- [ ] **Command**: Đóng gói request (Undo/Redo).
- [ ] **Interpreter**: Xử lý ngữ pháp/ngôn ngữ.
- [ ] **Iterator**: Duyệt danh sách.
- [ ] **Mediator**: Điều phối tương tác (Chat room).
- [ ] **Memento**: Lưu trạng thái (Snapshot).
- [ ] **Observer**: Pub/Sub model.
- [ ] **State**: Thay đổi hành vi theo trạng thái.
- [ ] **Strategy**: Thay đổi thuật toán (Sort, Tax).
- [ ] **Template Method**: Khung thuật toán.
- [ ] **Visitor**: Thêm operation mà không sửa class.

## 🏁 Final Project
- [ ] Mini E-commerce System (Kết hợp 5 patterns).
