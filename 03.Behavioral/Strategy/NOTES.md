# 🎯 Strategy Pattern

## 1. Định nghĩa
**Strategy** là một mẫu thiết kế thuộc nhóm Behavioral, cho phép bạn định nghĩa một tập hợp các thuật toán, đóng gói từng thuật toán lại, và làm cho chúng có thể thay thế lẫn nhau. Strategy cho phép thuật toán biến đổi độc lập với các client sử dụng nó.

> "Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it."

## 2. Bài toán ví dụ (Sắp xếp dữ liệu)
- Bạn có một danh sách dữ liệu và muốn sắp xếp nó.
- Có nhiều thuật toán sắp xếp khác nhau: `QuickSort`, `MergeSort`, `BubbleSort`, `BubbleSort`...
- Thay vì viết tất cả các thuật toán trong một lớp duy nhất với hàng loạt câu lệnh `if-else` hoặc `switch-case`, bạn đóng gói mỗi thuật toán vào một lớp riêng.
- **Giải pháp:** Sử dụng Strategy. Lớp **Context** (chứa dữ liệu) sẽ giữ một tham chiếu đến một đối tượng **Strategy** (thuật toán). Client có thể thay đổi chiến lược sắp xếp lúc runtime bằng cách truyền một đối tượng Strategy khác vào Context.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Strategy Interface (`IStrategy`):** Khai báo một giao diện chung cho tất cả các thuật toán được hỗ trợ. Context sử dụng giao diện này để gọi thuật toán được định nghĩa bởi Concrete Strategy.
2.  **Concrete Strategies (`ConcreteStrategySortAscending`, `ConcreteStrategySortDescending`):** Thực thi các thuật toán cụ thể bằng cách triển khai giao diện Strategy.
3.  **Context (`Context`):** Duy trì một tham chiếu đến một đối tượng Strategy. Nó có thể định nghĩa một interface cho phép Strategy truy cập dữ liệu của nó.

### UML Diagram (Text-based):
```
      Context ----------------------> Strategy (Interface)
    - strategy                          + DoAlgorithm()
    + SetStrategy(Strategy)                     ^
    + DoSomething()                             |
                                 +--------------+--------------+
                                 |                             |
                          ConcreteStrategyA             ConcreteStrategyB
                          + DoAlgorithm()               + DoAlgorithm()
```

## 4. Tại sao nên dùng? (Pros)
- **Thay đổi thuật toán lúc runtime:** Có thể tráo đổi các thuật toán bên trong một đối tượng tại thời điểm chạy.
- **Cô lập logic thuật toán:** Tách biệt mã triển khai của một thuật toán khỏi mã sử dụng nó.
- **Open/Closed Principle:** Có thể thêm các chiến lược mới mà không cần thay đổi Context.
- **Tránh kế thừa phức tạp:** Thay vì dùng kế thừa để thay đổi hành vi (dễ dẫn đến bùng nổ lớp con), hãy dùng Composition (Strategy).

## 5. Nhược điểm (Cons)
- **Client phải biết sự khác biệt:** Client phải hiểu rõ các chiến lược khác nhau để chọn cái phù hợp.
- **Tăng số lượng đối tượng:** Mỗi thuật toán là một đối tượng mới, có thể làm tăng bộ nhớ nếu có quá nhiều chiến lược.

## 6. Lưu ý về Benchmark
Strategy Pattern thường được sử dụng để tối ưu hóa hiệu năng bằng cách cho phép chọn thuật toán phù hợp nhất với dữ liệu đầu vào (ví dụ: dùng QuickSort cho mảng lớn, InsertionSort cho mảng nhỏ). Benchmark pattern này thường so sánh thời gian thực thi của các chiến lược khác nhau trên cùng một tập dữ liệu. Tôi đánh giá **không cần thiết** thực hiện Benchmark cho ví dụ đơn giản này, nhưng nó là một công cụ mạnh mẽ để đo lường hiệu quả của các thuật toán khác nhau.
