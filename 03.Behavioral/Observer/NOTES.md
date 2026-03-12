# 🔔 Observer Pattern

## 1. Định nghĩa
**Observer** là một mẫu thiết kế thuộc nhóm Behavioral, cho phép bạn định nghĩa một cơ chế đăng ký để thông báo cho nhiều đối tượng về bất kỳ sự kiện nào xảy ra với đối tượng mà họ đang theo dõi.

> "Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically."

## 2. Bài toán ví dụ (Bảng tin tuyển dụng)
- Bạn có một trang web tuyển dụng (**JobBoard**).
- Có nhiều ứng viên (**JobSeeker**) muốn nhận thông báo mỗi khi có công việc mới được đăng lên.
- Thay vì mỗi ứng viên phải tự vào kiểm tra trang web liên tục (Polling), họ sẽ đăng ký nhận thông báo.
- Khi có công việc mới, **JobBoard** (Subject) sẽ tự động gửi thông báo đến tất cả các **JobSeeker** (Observers) đã đăng ký.

## 3. Cấu trúc (Implementation)

### Các thành phần chính:
1.  **Subject Interface (`ISubject`):** Khai báo các phương thức để quản lý người đăng ký (`Attach`, `Detach`) và thông báo (`Notify`).
2.  **Concrete Subject (`JobBoard`):** Lưu trữ danh sách các observer và gửi thông báo khi có sự kiện.
3.  **Observer Interface (`IObserver`):** Khai báo phương thức `Update()` mà Subject sẽ gọi.
4.  **Concrete Observers (`JobSeeker`):** Thực thi giao diện để nhận và xử lý thông báo từ Subject.

### UML Diagram (Text-based):
```
      Subject <--------------------------- Observer (Interface)
    - observers: List<Observer>              + Update()
    + Attach(Observer)                               ^
    + Detach(Observer)                               | implements
    + Notify()                                       |
          ^                                 ConcreteObserver
          | implements                      + Update()
    ConcreteSubject
    - state
    + GetState()
```

## 4. Tại sao nên dùng? (Pros)
- **Open/Closed Principle:** Bạn có thể thêm các lớp observer mới mà không cần thay đổi mã nguồn của subject.
- **Mối quan hệ lỏng lẻo:** Subject không cần biết chi tiết về các observer, chỉ cần chúng thực thi đúng giao diện.
- **Hỗ trợ Broadcast:** Một sự kiện duy nhất có thể được gửi đến hàng trăm observer cùng lúc.

## 5. Nhược điểm (Cons)
- **Thứ tự không xác định:** Các observer có thể được thông báo theo thứ tự ngẫu nhiên.
- **Rò rỉ bộ nhớ:** Nếu observer không được `Detach` khi không còn cần thiết, Subject sẽ giữ tham chiếu đến nó mãi mãi, ngăn cản Garbage Collector thu hồi bộ nhớ.

## 6. Lưu ý về Benchmark
Observer Pattern là cơ sở của kiến trúc hướng sự kiện (Event-driven). Việc gọi hàng loạt phương thức `Update()` trong một vòng lặp tốn rất ít tài nguyên CPU. Tuy nhiên, nếu logic xử lý bên trong `Update()` quá nặng hoặc số lượng observer quá lớn, nó có thể làm nghẽn luồng xử lý chính của Subject. Tôi đánh giá **không cần thiết** thực hiện Benchmark cho pattern này trừ khi bạn đang xây dựng một hệ thống xử lý hàng triệu sự kiện mỗi giây.
