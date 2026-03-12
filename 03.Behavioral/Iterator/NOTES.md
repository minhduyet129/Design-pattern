# 🔄 Iterator Pattern

## 1. Định nghĩa
**Iterator** là một mẫu thiết kế thuộc nhóm Behavioral, cho phép bạn duyệt qua các phần tử của một tập hợp (collection) mà không cần để lộ các biểu diễn bên dưới của nó (danh sách, ngăn xếp, cây, v.v.).

> "Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation."

## 2. Bài toán ví dụ (Duyệt danh sách từ ngữ)
- Bạn có một bộ sưu tập các từ ngữ (`WordsCollection`).
- Bạn muốn có khả năng duyệt qua danh sách này theo thứ tự bình thường hoặc thứ tự ngược lại.
- Nếu bạn để Client tự xử lý việc duyệt bằng vòng lặp `for`, Client sẽ phải biết cấu trúc bên trong của bộ sưu tập (ví dụ: nó là một `List`). Nếu sau này bạn đổi sang `Dictionary` hoặc `Tree`, code Client sẽ bị hỏng.
- **Giải pháp:** Tách biệt logic duyệt ra một đối tượng riêng gọi là **Iterator**. Client chỉ cần yêu cầu Iterator và sử dụng các phương thức như `MoveNext()`, `Current()` để lấy dữ liệu.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Iterator Interface (`IEnumerator`):** Định nghĩa các phương thức để duyệt (trong .NET là `MoveNext`, `Reset`, `Current`).
2.  **Concrete Iterator (`AlphabeticalOrderIterator`):** Thực thi thuật toán duyệt cụ thể (duyệt xuôi, duyệt ngược).
3.  **Aggregate Interface (`IEnumerable`):** Khai báo phương thức để tạo ra Iterator.
4.  **Concrete Aggregate (`WordsCollection`):** Chứa dữ liệu thực tế và trả về một instance của Concrete Iterator tương ứng.

### UML Diagram (Text-based):
```
      Aggregate <--------------------------- Iterator (Interface)
    + CreateIterator()                       + Next()
          ^                                  + HasNext()
          |                                  + Current()
          | implements                               ^
          |                                          | implements
  ConcreteAggregate <----------------------- ConcreteIterator
  - items                                    - position
  + CreateIterator()                         + Next()
```

## 4. Tại sao nên dùng? (Pros)
- **Single Responsibility Principle:** Tách biệt thuật toán duyệt phức tạp khỏi lớp tập hợp.
- **Open/Closed Principle:** Có thể thêm các loại Iterator mới để duyệt cùng một tập hợp theo các cách khác nhau mà không cần sửa code cũ.
- **Duyệt song song:** Nhiều iterator có thể duyệt cùng một tập hợp tại cùng một thời điểm vì mỗi iterator lưu trạng thái riêng của nó.

## 5. Nhược điểm (Cons)
- **Quá mức cần thiết (Overkill):** Nếu ứng dụng chỉ làm việc với các danh sách đơn giản, việc dùng Iterator có thể làm code phức tạp hơn mức cần thiết.
- **Hiệu năng:** Duyệt qua iterator có thể chậm hơn một chút so với duyệt trực tiếp qua mảng/list do overhead của việc gọi phương thức.

## 6. Lưu ý về Benchmark
Iterator Pattern là một trong những pattern được sử dụng nhiều nhất (ngầm định qua `foreach` trong C#). Việc sử dụng Iterator tạo ra các đối tượng trung gian và các lời gọi hàm ảo. Tuy nhiên, .NET đã tối ưu hóa `IEnumerator` cực tốt. Tôi đánh giá **không cần thiết** thực hiện Benchmark cho pattern này trừ khi bạn đang làm việc với các bộ sưu tập khổng lồ và yêu cầu hiệu năng ở mức micro-second.
