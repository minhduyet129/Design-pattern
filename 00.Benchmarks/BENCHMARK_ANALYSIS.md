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
