# 📝 Template Method Pattern

## 1. Định nghĩa
**Template Method** là một mẫu thiết kế thuộc nhóm Behavioral, định nghĩa bộ khung (skeleton) của một thuật toán trong một phương thức của lớp cha, nhưng cho phép các lớp con ghi đè (override) các bước cụ thể của thuật toán mà không làm thay đổi cấu trúc của nó.

> "Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure."

## 2. Bài toán ví dụ (Khai thác dữ liệu - Data Mining)
- Bạn cần xây dựng các bộ khai thác dữ liệu từ nhiều loại tệp tin khác nhau: `PDF`, `CSV`, `Doc`...
- Tất cả các bộ khai thác đều có chung một quy trình: `Mở tệp` -> `Trích xuất dữ liệu` -> `Phân tích dữ liệu` -> `Gửi báo cáo` -> `Đóng tệp`.
- Các bước `Phân tích dữ liệu` và `Gửi báo cáo` là giống nhau cho mọi loại tệp.
- Các bước `Mở`, `Trích xuất`, `Đóng` tệp lại khác nhau tùy theo định dạng.
- **Giải pháp:** Sử dụng Template Method. Lớp cha (`DataMiner`) định nghĩa phương thức `Mine()` chứa toàn bộ quy trình. Các bước chung được triển khai ngay tại lớp cha, còn các bước khác biệt sẽ được khai báo là `abstract` để các lớp con tự triển khai.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Abstract Class (`DataMiner`):** Khai báo các phương thức đại diện cho các bước của thuật toán và một phương thức template gọi các bước đó theo một thứ tự nhất định.
2.  **Concrete Classes (`PdfDataMiner`, `CsvDataMiner`):** Ghi đè các bước cần thiết để thực hiện logic cụ thể cho từng phiên bản của thuật toán.

### UML Diagram (Text-based):
```
      AbstractClass
    + TemplateMethod() {
        Step1()
        Step2()
        Step3()
      }
    + Step1() (base implementation)
    # Step2() (abstract)
    # Step3() (abstract)
          ^
          | extends
          |
      ConcreteClass
    # Step2() { ... }
    # Step3() { ... }
```

## 4. Tại sao nên dùng? (Pros)
- **Tái sử dụng mã nguồn:** Tránh lặp lại các đoạn code giống nhau bằng cách đưa chúng lên lớp cha.
- **Dễ bảo trì:** Cấu trúc thuật toán chỉ nằm ở một nơi duy nhất. Nếu cần thay đổi quy trình, bạn chỉ cần sửa ở lớp cha.
- **Linh hoạt:** Cho phép lớp con mở rộng các phần cụ thể của thuật toán mà không ảnh hưởng đến các phần khác.

## 5. Nhược điểm (Cons)
- **Hạn chế cấu trúc:** Một số lớp con có thể bị giới hạn bởi bộ khung mà lớp cha đã định nghĩa.
- **Vi phạm Liskov Substitution Principle:** Nếu lớp con ghi đè một bước mặc định của lớp cha theo cách không mong muốn.

## 6. Lưu ý về Benchmark
Template Method Pattern chủ yếu là một kỹ thuật tái sử dụng code thông qua kế thừa. Overhead của nó chỉ là các lời gọi hàm ảo (virtual calls), vốn đã được tối ưu hóa cực tốt trong môi trường .NET hiện đại. Do đó, tôi đánh giá **không cần thiết** thực hiện Benchmark cho pattern này.
