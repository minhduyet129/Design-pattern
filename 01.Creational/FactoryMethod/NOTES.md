# 🏭 Factory Method Pattern

## 1. Định nghĩa
**Factory Method** là một mẫu thiết kế thuộc nhóm Creational, cung cấp một interface để tạo đối tượng trong superclass (lớp cha), nhưng cho phép các subclass (lớp con) quyết định kiểu đối tượng sẽ được tạo.

> "Define an interface for creating an object, but let subclasses decide which class to instantiate."

## 2. Bài toán ví dụ (Logistics App)
- Bạn xây dựng ứng dụng vận tải. Ban đầu chỉ có xe tải (`Truck`).
- Sau này phát triển thêm vận tải biển (`Ship`), rồi hàng không (`Airplane`).
- Nếu dùng `new Truck()` rải rác khắp nơi, code sẽ rất khó sửa đổi.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Product (`ITransport`):** Interface chung cho các đối tượng (ví dụ: `Deliver()`).
2.  **Concrete Products (`Truck`, `Ship`):** Các class thực thi interface trên.
3.  **Creator (`Logistics`):** Class cha, định nghĩa phương thức `CreateTransport()` (abstract) và logic nghiệp vụ chung (`PlanDelivery()`).
4.  **Concrete Creators (`RoadLogistics`, `SeaLogistics`):** Class con, override `CreateTransport()` để trả về `new Truck()` hoặc `new Ship()`.

### UML Diagram (Text-based):
```
Creator (Logistics)
   + PlanDelivery() 
   + abstract CreateTransport() : ITransport
         ^
         | inheritance
+-----------------------+
|                       |
RoadLogistics           SeaLogistics
+ CreateTransport()     + CreateTransport()
   |                       |
   v returns               v returns
Truck (ITransport)      Ship (ITransport)
```

## 4. Tại sao nên dùng? (Pros)
- **Decoupling (Giảm phụ thuộc):** Client code (`Logistics.PlanDelivery`) không phụ thuộc vào class cụ thể (`Truck`/`Ship`), chỉ làm việc với interface `ITransport`.
- **Open/Closed Principle:** Muốn thêm loại phương tiện mới (`Airplane`), chỉ cần tạo class mới, không cần sửa code cũ.
- **Single Responsibility:** Gom việc khởi tạo object vào một chỗ, dễ quản lý hơn.

## 5. Khi nào dùng?
- Khi bạn không biết trước chính xác loại đối tượng nào code của mình cần làm việc.
- Khi bạn muốn cung cấp thư viện cho người khác và cho phép họ mở rộng các thành phần bên trong.
- Khi bạn muốn tiết kiệm tài nguyên hệ thống bằng cách tái sử dụng các object thay vì tạo mới mỗi lần (kết hợp với Object Pool).
