# 🏭 Abstract Factory Pattern

## 1. Định nghĩa
**Abstract Factory** là một mẫu thiết kế thuộc nhóm Creational, cung cấp một interface để tạo ra các họ đối tượng (families of related objects) mà không cần chỉ định rõ các lớp cụ thể của chúng.

> "Provide an interface for creating families of related or dependent objects without specifying their concrete classes."

## 2. Bài toán ví dụ (Cross-Platform UI)
- Bạn phát triển một thư viện GUI hoạt động trên nhiều hệ điều hành (Windows, macOS, Linux).
- Mỗi hệ điều hành có phong cách hiển thị khác nhau cho các thành phần như Button, Checkbox.
- Bạn cần đảm bảo rằng khi ứng dụng chạy trên Windows, tất cả các thành phần giao diện phải đồng bộ theo phong cách Windows. Không được phép trộn lẫn Button kiểu Mac với Checkbox kiểu Windows.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Abstract Factory (`IGUIFactory`):** Interface khai báo các phương thức tạo ra từng loại sản phẩm abstract (ví dụ: `CreateButton`, `CreateCheckbox`).
2.  **Concrete Factories (`WinFactory`, `MacFactory`):** Các lớp thực thi interface Abstract Factory để tạo ra các sản phẩm cụ thể thuộc về một biến thể (variant).
3.  **Abstract Products (`IButton`, `ICheckbox`):** Interface cho từng loại sản phẩm riêng biệt nhưng có liên quan (Button, Checkbox).
4.  **Concrete Products (`WinButton`, `MacButton`, ...):** Các lớp thực thi interface Abstract Product, được nhóm lại theo biến thể (Windows, Mac).
5.  **Client (`Application`):** Sử dụng chỉ các interface Abstract Factory và Abstract Product. Client không quan tâm đến lớp cụ thể nào được tạo ra.

### UML Diagram (Text-based):
```
       Client
          |
          v
     IGUIFactory <-------------------------+
    + CreateButton(): IButton              |
    + CreateCheckbox(): ICheckbox          |
          ^                                |
          | implements                     | implements
+-----------------------+        +-----------------------+
|                       |        |                       |
WinFactory              |        MacFactory              |
+ CreateButton()        |        + CreateButton()        |
+ CreateCheckbox()      |        + CreateCheckbox()      |
   |        |           |           |        |           |
   v        v           |           v        v           |
WinButton WinCheckbox   |        MacButton MacCheckbox   |
(IButton) (ICheckbox)   |        (IButton) (ICheckbox)   |
                        |                                |
                        +--------------------------------+
```

## 4. Tại sao nên dùng? (Pros)
- **Đảm bảo tính tương thích:** Các sản phẩm được tạo ra từ cùng một factory chắc chắn sẽ tương thích với nhau (cùng style/theme).
- **Decoupling (Giảm phụ thuộc):** Client code không bị ràng buộc vào các lớp cụ thể (Concrete Classes).
- **Single Responsibility Principle:** Gom code khởi tạo vào một nơi (Factory).
- **Open/Closed Principle:** Dễ dàng thêm biến thể mới (ví dụ: Linux Factory) mà không làm ảnh hưởng code hiện có.

## 5. Nhược điểm (Cons)
- **Tăng độ phức tạp:** Số lượng class và interface tăng lên đáng kể.
- **Khó mở rộng Product mới:** Nếu muốn thêm một loại sản phẩm mới (ví dụ: `ITextBox`) vào `IGUIFactory`, bạn phải sửa đổi tất cả các Concrete Factory hiện có.

## 6. So sánh với Factory Method
- **Factory Method:** Dùng để tạo ra **một** loại sản phẩm (hoặc một nhóm sản phẩm nhưng qua inheritance).
- **Abstract Factory:** Dùng để tạo ra **cả một họ** các sản phẩm liên quan (families of products).
