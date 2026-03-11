# 🏗️ Builder Pattern

## 1. Định nghĩa
**Builder** là một mẫu thiết kế thuộc nhóm Creational, cho phép bạn xây dựng các đối tượng phức tạp từng bước một. Mẫu thiết kế này cho phép bạn tạo ra các kiểu biểu diễn khác nhau của một đối tượng bằng cách sử dụng cùng một mã xây dựng.

> "Separate the construction of a complex object from its representation so that the same construction process can create different representations."

## 2. Bài toán ví dụ (Xây dựng ngôi nhà)
- Hãy tưởng tượng một đối tượng phức tạp như `House` (Ngôi nhà).
- Để xây một ngôi nhà đơn giản, bạn cần xây tường, sàn, cửa sổ, cửa ra vào, mái nhà.
- Nhưng nếu bạn muốn xây một ngôi nhà lớn hơn, có hồ bơi, tượng, vườn tược?
- Cách tiếp cận đơn giản nhất là mở rộng lớp `House` cơ sở và tạo ra một tập hợp các lớp con để bao gồm tất cả các kết hợp của các tham số. Nhưng điều này sẽ dẫn đến một số lượng lớp con khổng lồ.
- Một cách tiếp cận khác là tạo ra một hàm tạo khổng lồ ngay trong lớp `House` với tất cả các tham số có thể có. Điều này giải quyết vấn đề về lớp con, nhưng lại tạo ra vấn đề khác: đa số các tham số sẽ không được sử dụng, làm cho việc gọi hàm tạo trở nên xấu xí.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Builder (`IHouseBuilder`):** Interface khai báo các bước xây dựng sản phẩm chung cho tất cả các loại builder.
2.  **Concrete Builder (`ConcreteHouseBuilder`):** Cung cấp các triển khai cụ thể cho các bước xây dựng. `ConcreteHouseBuilder` có thể tạo ra các sản phẩm không tuân theo interface chung (mặc dù trong ví dụ này chúng ta trả về `House`).
3.  **Product (`House`):** Là đối tượng phức tạp được tạo ra. Các Concrete Builder khác nhau có thể tạo ra các sản phẩm không liên quan (ví dụ: House bằng gỗ, House bằng đá).
4.  **Director (`HouseDirector`):** Định nghĩa thứ tự gọi các bước xây dựng để tạo ra các cấu hình sản phẩm cụ thể. Director là tùy chọn, Client có thể điều khiển Builder trực tiếp.
5.  **Client (`Program`):** Phải liên kết một đối tượng builder cụ thể với director. Sau đó, director sử dụng builder đó để xây dựng.

### UML Diagram (Text-based):
```
       Client
          |
          v
     Director ---------------------> IBuilder
    + Construct()                        ^
                                         |
                                         | implements
                                 +----------------+
                                 |                |
                           ConcreteBuilder        |
                           + BuildPartA()         |
                           + BuildPartB()         |
                           + GetResult()          |
                                 |                |
                                 v                |
                              Product <-----------+
```

## 4. Tại sao nên dùng? (Pros)
- **Kiểm soát chi tiết:** Bạn có thể kiểm soát quá trình xây dựng từng bước.
- **Tái sử dụng code:** Bạn có thể sử dụng cùng một mã xây dựng cho các biểu diễn khác nhau của sản phẩm.
- **Single Responsibility Principle:** Bạn có thể tách biệt mã xây dựng phức tạp khỏi logic nghiệp vụ của sản phẩm.

## 5. Nhược điểm (Cons)
- **Độ phức tạp tăng:** Mã tổng thể của chương trình có thể trở nên phức tạp hơn do bạn cần tạo nhiều lớp mới.
- **Khối lượng code lớn:** Builder pattern yêu cầu tạo ra nhiều lớp riêng biệt cho từng loại sản phẩm.

## 6. So sánh với Abstract Factory
- **Builder:** Tập trung vào việc xây dựng các đối tượng phức tạp từng bước một. Builder trả về sản phẩm ở bước cuối cùng.
- **Abstract Factory:** Tập trung vào việc tạo ra các gia đình đối tượng liên quan. Abstract Factory trả về sản phẩm ngay lập tức.
