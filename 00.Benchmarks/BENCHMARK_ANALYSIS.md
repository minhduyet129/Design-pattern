# Phân Tích Kết Quả Benchmark - Singleton Pattern

Tài liệu này giải thích cách đọc kết quả từ `BenchmarkDotNet` và đưa ra kết luận về hiệu năng của Singleton Pattern so với các cách tiếp cận khác.

## 1. Kết Quả Mẫu (Sample Result)

Khi chạy benchmark trên máy tính tiêu chuẩn, bạn sẽ nhận được bảng kết quả tương tự như sau:

| Method          | Mean      | Error     | StdDev    | Gen0   | Allocated |
|---------------- |----------:|----------:|----------:|-------:|----------:|
| **NewInstance** | 12.45 ns  | 0.15 ns   | 0.14 ns   | 0.0065 | 24 B      |
| **Singleton**   | 0.02 ns   | 0.01 ns   | 0.01 ns   | -      | -         |
| **StaticCall**  | 0.01 ns   | 0.01 ns   | 0.01 ns   | -      | -         |

## 2. Giải Thích Các Chỉ Số

- **Mean (Trung bình):** Thời gian trung bình để thực thi phương thức 1 lần. Đơn vị thường là `ns` (nanoseconds - 1 phần tỷ giây).
  - Giá trị càng nhỏ càng tốt.
- **Allocated (Đã cấp phát):** Lượng bộ nhớ (RAM) được cấp phát mỗi lần gọi phương thức.
  - `24 B`: Mỗi lần gọi `new NormalClass()` tốn 24 bytes bộ nhớ.
  - `-` (0 bytes): Singleton và Static không cấp phát bộ nhớ mới vì đối tượng/class đã tồn tại.
- **Gen0:** Số lần Garbage Collector (GC) phải chạy dọn dẹp bộ nhớ thế hệ 0 (cho mỗi 1000 lần gọi).
  - Giá trị cao nghĩa là tạo quá nhiều rác, gây áp lực lên hệ thống.

## 3. Kết Luận Về Singleton

### ✅ Ưu điểm (Pros)
1.  **Hiệu năng cao:** Truy cập Singleton (`Singleton.Instance`) cực nhanh, gần như tức thời (0-1ns) vì object đã nằm sẵn trong bộ nhớ.
2.  **Tiết kiệm bộ nhớ:** Không tốn chi phí cấp phát (`new`) và dọn dẹp (GC) liên tục như cách tạo instance thông thường.

### ⚠️ Nhược điểm (Cons)
1.  **Chậm hơn Static một chút:** Truy cập qua Property `Instance` (có check `Lazy` hoặc `lock`) sẽ chậm hơn gọi trực tiếp `Static Method` một chút xíu (không đáng kể trong hầu hết ứng dụng).
2.  **Cạnh tranh tài nguyên (Contention):** Nếu Singleton dùng `lock` để thread-safe, hiệu năng có thể giảm khi có nhiều luồng truy cập cùng lúc (Lock contention).

### 💡 Khi nào nên dùng?
- Dùng **Singleton** khi bạn cần duy trì **trạng thái (state)** (ví dụ: config đã load, connection pool đang mở).
- Dùng **Static Method** khi bạn chỉ cần hàm tiện ích (utility) thuần túy, không lưu trạng thái.
- Tránh dùng **New Instance** liên tục cho các object nặng (như Database Connection) vì tốn RAM và CPU khởi tạo.

---

# Phân Tích Kết Quả Benchmark - Prototype Pattern

## 1. Kết Quả Mẫu (Sample Result)

| Method           | Mean      | Error     | StdDev    | Allocated |
|----------------- |----------:|----------:|----------:|----------:|
| **NewInstance**  | 45.20 ns  | 0.50 ns   | 0.45 ns   | 112 B     |
| **PrototypeClone**| 15.10 ns  | 0.20 ns   | 0.18 ns   | 112 B     |

## 2. Kết Luận Về Prototype

### ✅ Tại sao Prototype lại nhanh hơn?
- **Khởi tạo dữ liệu:** Prototype copy dữ liệu từ một đối tượng đã có sẵn thay vì phải gán lại từng thuộc tính từ đầu.
- **Tính toán phức tạp:** Nếu quá trình khởi tạo một object mới đòi hỏi nhiều tính toán hoặc truy xuất database, việc `Clone()` sẽ tiết kiệm được rất nhiều thời gian.

---

# Phân Tích Kết Quả Benchmark - Builder Pattern

## 1. Kết Quả Mẫu (Sample Result)

| Method              | Mean      | Error     | StdDev    | Allocated |
|-------------------- |----------:|----------:|----------:|----------:|
| **StandardConstructor**| 10.50 ns  | 0.10 ns   | 0.09 ns   | 48 B      |
| **BuilderPattern**    | 25.80 ns  | 0.30 ns   | 0.28 ns   | 48 B      |

## 2. Kết Luận Về Builder

### ⚠️ Đánh đổi (Trade-off)
- **Hiệu năng:** Builder thường **chậm hơn** một chút so với việc sử dụng constructor hoặc object initializer truyền thống vì nó phải qua nhiều bước gọi hàm (`BuildWalls`, `BuildDoors`...) và quản lý trạng thái trung gian trong Builder object.
- **Giá trị thực tế:** Tuy nhiên, lợi ích của Builder không nằm ở tốc độ mà ở **khả năng bảo trì** và **tính linh hoạt** khi xây dựng các đối tượng cực kỳ phức tạp với hàng chục tham số tùy chọn.

---

# Phân Tích Kết Quả Benchmark - Flyweight Pattern

## 1. Kết Quả Mẫu (Sample Result)

| Method             | Mean      | Allocated |
|------------------- |----------:|----------:|
| **StandardApproach**| 12.50 ms  | 15.2 MB   |
| **FlyweightApproach**| 8.20 ms   | 4.8 MB    |

## 2. Kết Luận Về Flyweight

### ✅ Tại sao Flyweight lại tối ưu hơn?
- **Tiết kiệm RAM:** Thay vì mỗi đối tượng lưu trữ một bản sao của dữ liệu nặng (Texture, Color...), Flyweight chỉ lưu trữ dữ liệu đó một lần duy nhất và các đối tượng khác sẽ tham chiếu tới.
- **Giảm áp lực GC:** Việc tạo ít đối tượng lớn hơn giúp Garbage Collector làm việc hiệu quả hơn, giảm thiểu các đợt "Stop-the-world".
- **Hiệu năng:** Ngoài việc tiết kiệm bộ nhớ, Flyweight cũng có thể cải thiện tốc độ xử lý do giảm thiểu việc cấp phát bộ nhớ liên tục.
