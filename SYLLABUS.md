# Chương Trình Đào Tạo: Advanced .NET Design Patterns Mastery

## 1. Giới thiệu chung & Tầm quan trọng
**Mục tiêu:** Hiểu rõ "Tại sao" cần Design Pattern trước khi học "Như thế nào".
- **Định nghĩa:** Giải pháp tái sử dụng cho các vấn đề phổ biến trong thiết kế phần mềm.
- **Tầm quan trọng:**
  - **Standardized Vocabulary:** Giúp team giao tiếp hiệu quả (e.g., "Dùng Strategy ở đây đi").
  - **Best Practices:** Đúc kết kinh nghiệm từ hàng thập kỷ phát triển phần mềm.
  - **Maintainability:** Code dễ đọc, dễ mở rộng và bảo trì.

## 2. Phân loại 23 GoF Patterns (Kèm ví dụ thực tế .NET)

### Nhóm Creational (Khởi tạo) - 5 Patterns
Quản lý việc tạo đối tượng, giúp hệ thống độc lập với cách đối tượng được tạo ra.
1. **Singleton:** Đảm bảo class chỉ có 1 instance duy nhất.
   - *Ví dụ 1:* `ConfigurationManager` (Load config 1 lần dùng toàn app).
   - *Ví dụ 2:* `Logger` (Ghi log tập trung).
   - *Ví dụ 3:* `DatabaseConnectionPool` (Quản lý kết nối DB).
2. **Factory Method:** Định nghĩa interface tạo object, để subclass quyết định class nào được instance.
   - *Ví dụ:* Hệ thống Logistics (Tạo `Truck` hoặc `Ship` dựa trên vận chuyển đường bộ/biển).
3. **Abstract Factory:** Tạo các họ đối tượng liên quan mà không chỉ định class cụ thể.
   - *Ví dụ:* UI Framework (Tạo Button/Textbox cho Windows và macOS).
4. **Builder:** Tách rời việc xây dựng đối tượng phức tạp khỏi biểu diễn của nó.
   - *Ví dụ:* Tạo `SqlCommand` hoặc `RestRequest` với nhiều tham số tùy chọn.
5. **Prototype:** Tạo đối tượng mới bằng cách copy đối tượng hiện có.
   - *Ví dụ:* Clone cấu hình game settings hoặc report template.

### Nhóm Structural (Cấu trúc) - 7 Patterns
Xử lý việc kết hợp các class và object để tạo cấu trúc lớn hơn.
1. **Adapter:** Cho phép các interface không tương thích làm việc cùng nhau.
   - *Ví dụ:* Tích hợp thư viện thanh toán 3rd party (Stripe/PayPal) vào hệ thống cũ.
2. **Bridge:** Tách rời abstraction khỏi implementation.
   - *Ví dụ:* Hệ thống vẽ hình (Abstraction: Shape) trên các nền tảng khác nhau (Implementation: OpenGL, DirectX).
3. **Composite:** Xử lý nhóm đối tượng giống như một đối tượng đơn lẻ (Cấu trúc cây).
   - *Ví dụ:* Hệ thống quản lý File/Folder hoặc Menu đa cấp.
4. **Decorator:** Thêm hành vi vào đối tượng động mà không thay đổi class gốc.
   - *Ví dụ:* Middleware trong ASP.NET Core (Logging, Auth, Caching request).
5. **Facade:** Cung cấp interface đơn giản cho một hệ thống phức tạp.
   - *Ví dụ:* Class `OrderService` gói gọn quy trình (Check Inventory -> Payment -> Shipping).
6. **Flyweight:** Chia sẻ trạng thái để hỗ trợ lượng lớn đối tượng nhỏ.
   - *Ví dụ:* Quản lý ký tự trong Text Editor hoặc cây cối trong Game.
7. **Proxy:** Đại diện cho một đối tượng khác để kiểm soát truy cập.
   - *Ví dụ:* Lazy Loading trong Entity Framework (Virtual navigation properties).

### Nhóm Behavioral (Hành vi) - 11 Patterns
Quan tâm đến giao tiếp giữa các đối tượng.
1. **Chain of Responsibility:** Chuyền request qua chuỗi các handler.
   - *Ví dụ:* Middleware Pipeline trong ASP.NET Core.
2. **Command:** Đóng gói request thành object.
   - *Ví dụ:* Hệ thống Undo/Redo trong Text Editor hoặc Job Queue.
3. **Interpreter:** Định nghĩa ngữ pháp và bộ dịch cho ngôn ngữ.
   - *Ví dụ:* Regex engine hoặc Expression Trees trong LINQ.
4. **Iterator:** Duyệt qua các phần tử của collection mà không lộ cấu trúc bên trong.
   - *Ví dụ:* `IEnumerable<T>` và `IEnumerator<T>` trong .NET.
5. **Mediator:** Đóng gói cách các đối tượng tương tác (tránh gọi nhau trực tiếp).
   - *Ví dụ:* Chat Room hoặc MediatR library trong .NET.
6. **Memento:** Lưu và khôi phục trạng thái đối tượng.
   - *Ví dụ:* Tính năng "Save Game" hoặc Rollback transaction.
7. **Observer:** Thông báo thay đổi trạng thái cho các đối tượng phụ thuộc.
   - *Ví dụ:* Event Handling trong C# (delegate/event) hoặc Reactive Extensions (Rx.NET).
8. **State:** Cho phép đối tượng thay đổi hành vi khi trạng thái nội bộ thay đổi.
   - *Ví dụ:* Quản lý trạng thái đơn hàng (New -> Processing -> Shipped -> Cancelled).
9. **Strategy:** Định nghĩa họ thuật toán, đóng gói và thay thế lẫn nhau.
   - *Ví dụ:* Các chiến lược giảm giá (DiscountStrategy) hoặc Sort Algorithms.
10. **Template Method:** Định nghĩa khung thuật toán, để subclass thực hiện chi tiết.
    - *Ví dụ:* Quy trình xử lý Data Import (Validate -> Parse -> Save).
11. **Visitor:** Tách thuật toán khỏi cấu trúc đối tượng.
    - *Ví dụ:* Tính thuế hoặc Report cho các loại sản phẩm khác nhau trong giỏ hàng.

## 3. Tiêu chí đánh giá áp dụng Pattern (Evaluation Matrix)

| Criteria | Low Score | High Score | Note |
| :--- | :--- | :--- | :--- |
| **Complexity** | Giải pháp đơn giản, ít class | Cần nhiều class, interface, abstraction | Pattern thường tăng độ phức tạp ban đầu để giảm độ phức tạp về sau. |
| **Maintainability** | Code chặt, khó sửa đổi | Dễ thêm tính năng mới (Open/Closed Principle) | Mục tiêu chính của hầu hết patterns. |
| **Scalability** | Khó mở rộng tải/logic | Hỗ trợ mở rộng tốt (Horizontal/Logic scaling) | Quan trọng cho Cloud-native apps. |
| **Performance** | Overhead thấp | Có overhead (virtual calls, allocations) | Cần benchmark để đánh giá trade-off. |

## 4. Tài nguyên mở rộng (Advanced)
- **Microservices Patterns:** Saga, Circuit Breaker, API Gateway, Strangler Fig.
- **Cloud Patterns:** Retry, Throttling, Valet Key.
- **Tools:** MediatR, AutoMapper, Polly (Resilience).

## 5. Assessment & Project
- **Coding Challenge:** Refactor một đoạn code "Spaghetti" sử dụng Strategy và Factory.
- **Final Project:** Xây dựng hệ thống E-commerce mini sử dụng ít nhất 5 patterns (Repository, UnitOfWork, Strategy, Observer, Decorator).
