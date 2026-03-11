# 🧬 Prototype Pattern

## 1. Định nghĩa
**Prototype** là một mẫu thiết kế thuộc nhóm Creational, cho phép sao chép các đối tượng hiện có mà không làm cho code phụ thuộc vào các lớp của chúng.

> "Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype."

## 2. Bài toán ví dụ (Nhân bản đối tượng)
- Bạn có một đối tượng phức tạp và muốn tạo ra một bản sao chính xác của nó.
- Cách tiếp cận thông thường: Tạo đối tượng mới -> Gán giá trị từng trường từ đối tượng cũ sang đối tượng mới.
- Vấn đề:
  - Không phải tất cả các trường đều public (private fields).
  - Code sao chép trở nên phụ thuộc chặt chẽ vào lớp của đối tượng.
  - Quá trình khởi tạo từ đầu có thể tốn kém tài nguyên (ví dụ: kết nối database, tải file cấu hình).

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Prototype Interface (`Shape`):** Khai báo phương thức `Clone`.
2.  **Concrete Prototype (`Rectangle`, `Circle`):** Thực thi phương thức `Clone`. Phương thức này sao chép dữ liệu của đối tượng hiện tại sang đối tượng mới.

### Cách thức hoạt động:
- Thay vì gọi `new ClassName()`, client gọi phương thức `Clone()` trên đối tượng mẫu (prototype) để tạo ra đối tượng mới.
- Việc sao chép có thể là **Shallow Copy** (copy giá trị reference) hoặc **Deep Copy** (tạo đối tượng mới cho reference).

### UML Diagram (Text-based):
```
       Client
          |
          v
      Prototype <--------------------------+
    + Clone(): Prototype                   |
          ^                                |
          | implements                     | implements
+-----------------------+        +-----------------------+
|                       |        |                       |
ConcretePrototype1      |        ConcretePrototype2      |
+ Clone()               |        + Clone()               |
                        |                                |
                        +--------------------------------+
```

## 4. Shallow Copy vs Deep Copy
- **Shallow Copy (Sao chép nông):** Chỉ sao chép các giá trị của trường (field). Nếu trường là tham chiếu (reference type), nó chỉ sao chép địa chỉ bộ nhớ. Hai đối tượng sẽ trỏ cùng vào một đối tượng con. `MemberwiseClone()` trong C# thực hiện điều này.
- **Deep Copy (Sao chép sâu):** Sao chép toàn bộ đối tượng và đệ quy sao chép tất cả các đối tượng mà nó tham chiếu tới. Hai đối tượng hoàn toàn độc lập.

## 5. Tại sao nên dùng? (Pros)
- **Giảm chi phí khởi tạo:** Sao chép đối tượng có sẵn thường nhanh hơn tạo mới từ đầu (đặc biệt nếu khởi tạo tốn nhiều resource).
- **Tránh việc phân lớp con (Subclassing):** Giảm thiểu việc phải tạo nhiều lớp con chỉ để cấu hình đối tượng khác nhau.
- **Thêm/Xóa đối tượng lúc runtime:** Bạn có thể đăng ký một prototype mới vào hệ thống ngay khi chạy.

## 6. Nhược điểm (Cons)
- **Phức tạp với tham chiếu vòng:** Việc sao chép sâu (Deep Copy) có thể rất phức tạp nếu đối tượng có tham chiếu vòng (circular references).

## 7. So sánh
- **Prototype vs Factory Method:** Prototype không yêu cầu phân lớp (subclassing) nhưng cần khởi tạo một đối tượng mẫu. Factory Method yêu cầu phân lớp Creator.
- **Prototype vs Builder:** Builder tạo đối tượng phức tạp từng bước. Prototype copy đối tượng đã hoàn chỉnh.
