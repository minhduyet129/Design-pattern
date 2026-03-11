# 🌳 Composite Pattern

## 1. Định nghĩa
**Composite** là một mẫu thiết kế thuộc nhóm Structural, cho phép bạn soạn thảo các đối tượng thành cấu trúc cây để biểu diễn các phân cấp một phần-toàn bộ (part-whole hierarchies). Composite cho phép các client xử lý các đối tượng đơn lẻ và các thành phần tổng hợp một cách thống nhất.

> "Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly."

## 2. Bài toán ví dụ (Hệ thống tệp tin)
- Hãy tưởng tượng một hệ thống tệp tin bao gồm các **Tệp tin (File)** và các **Thư mục (Folder)**.
- Thư mục có thể chứa cả tệp tin và các thư mục con khác.
- Nếu bạn muốn tính tổng kích thước của một thư mục, bạn phải duyệt qua tất cả các tệp tin và thư mục con bên trong nó.
- Nếu không sử dụng Composite, bạn sẽ phải viết các hàm kiểm tra xem một đối tượng là tệp tin hay thư mục trước khi thực hiện các thao tác, điều này làm cho mã nguồn trở nên phức tạp và khó bảo trì.
- **Giải pháp:** Xây dựng một interface chung (`FileSystemItem`) cho cả tệp tin và thư mục, cho phép Client xử lý chúng theo cùng một cách.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Component (`FileSystemItem`):** Khai báo interface chung cho các đối tượng trong cấu trúc cây. Chứa các phương thức chung như `GetSize()` và `Display()`.
2.  **Leaf (`File`):** Đại diện cho các đối tượng lá trong cấu trúc cây. Một đối tượng lá không có con. Nó thực hiện các chức năng thực tế của interface.
3.  **Composite (`Folder`):** Đại diện cho các đối tượng phức hợp có thể có con. Nó lưu trữ một danh sách các thành phần con và chuyển giao các yêu cầu cho chúng, đồng thời có thể thực hiện thêm các thao tác khác trước/sau khi chuyển giao.

### UML Diagram (Text-based):
```
      Component <--------------------------- Composite
    + Operation()                             + Operation()
          ^                                   + Add(Component)
          |                                   + Remove(Component)
          | extends                           + GetChildren()
          |                                          |
          |                                          v
        Leaf --------------------------------> List<Component>
        + Operation()
```

## 4. Tại sao nên dùng? (Pros)
- **Tính đồng nhất:** Client có thể làm việc với các cấu trúc phức tạp một cách đơn giản, coi chúng như những đối tượng đơn lẻ.
- **Dễ dàng mở rộng:** Bạn có thể thêm các loại Component mới vào cấu trúc cây mà không cần thay đổi code hiện tại.
- **Cấu trúc cây tự nhiên:** Rất phù hợp để biểu diễn các dữ liệu phân cấp như menu, thư mục, tổ chức nhân sự.

## 5. Nhược điểm (Cons)
- **Khó khăn khi hạn chế các loại component:** Đôi khi bạn muốn giới hạn các thành phần con trong một Composite, nhưng với interface chung, việc này phải thực hiện lúc runtime thông qua kiểm tra kiểu dữ liệu.

## 6. Lưu ý về Benchmark
Composite Pattern chủ yếu giải quyết vấn đề về tổ chức cấu trúc dữ liệu. Mặc dù nó sử dụng đệ quy để duyệt cây (có thể gây ra overhead nếu cây quá sâu), nhưng về bản chất, đây là giải pháp thiết kế cấu trúc hơn là tối ưu hóa tốc độ. Do đó, tôi đánh giá **không cần thiết** phải thực hiện Benchmark trừ khi các thao tác trên lá cực kỳ nặng nề hoặc cây có hàng triệu phần tử.
