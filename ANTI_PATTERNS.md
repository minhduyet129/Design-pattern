# Anti-Patterns Checklist & Cách Tránh

Anti-patterns là những giải pháp tưởng chừng như tốt nhưng lại gây ra nhiều vấn đề hơn giải quyết, hoặc là việc áp dụng sai các design pattern.

## 1. The God Object (Đối tượng chúa)
- **Dấu hiệu:** Một class quá lớn (God Class), chứa quá nhiều logic, biết quá nhiều thứ (vi phạm Single Responsibility Principle).
- **Hậu quả:** Khó bảo trì, khó test, tight coupling.
- **Cách tránh:**
  - Áp dụng **Single Responsibility Principle (SRP)**.
  - Chia nhỏ class bằng **Facade** hoặc **Mediator** để phân phối trách nhiệm.

## 2. Spaghetti Code
- **Dấu hiệu:** Luồng điều khiển rối rắm, nhảy lung tung (goto), lạm dụng if-else lồng nhau quá sâu.
- **Hậu quả:** Không thể đọc hiểu, sửa 1 chỗ hỏng 10 chỗ.
- **Cách tránh:**
  - Refactor bằng **Strategy Pattern** (thay thế switch-case phức tạp).
  - Sử dụng **State Pattern** nếu logic phụ thuộc trạng thái.

## 3. Golden Hammer (Cây búa vàng)
- **Dấu hiệu:** "Khi bạn có một cây búa, mọi thứ trông giống cái đinh". Cố ép dùng 1 pattern quen thuộc cho mọi vấn đề.
- **Hậu quả:** Giải pháp cồng kềnh, không tối ưu.
- **Cách tránh:**
  - Học đa dạng patterns.
  - Luôn đặt câu hỏi: "Giải pháp đơn giản nhất là gì?".

## 4. Singleton Abuse (Lạm dụng Singleton)
- **Dấu hiệu:** Dùng Singleton để thay thế Global Variable, làm cho các class phụ thuộc ẩn vào Singleton.
- **Hậu quả:** Khó Unit Test (vì state dính global), khó mock dependency.
- **Cách tránh:**
  - Sử dụng **Dependency Injection (DI)** container thay vì Singleton tĩnh thủ công.
  - Chỉ dùng Singleton cho những thứ thực sự duy nhất (như App Config).

## 5. Boat Anchor (Mỏ neo)
- **Dấu hiệu:** Code hoặc Pattern được để lại "phòng khi cần dùng" nhưng không bao giờ dùng tới.
- **Hậu quả:** Gây nhiễu, tốn công bảo trì code rác.
- **Cách tránh:**
  - **YAGNI** (You Aren't Gonna Need It). Xóa code không dùng ngay lập tức.

## 6. Poltergeist (Ma trơi)
- **Dấu hiệu:** Các class vô dụng, chỉ tồn tại để gọi method của class khác mà không thêm giá trị gì (Controller classes chỉ pass-through).
- **Hậu quả:** Tăng số lượng file, rối cấu trúc.
- **Cách tránh:**
  - Refactor: Loại bỏ các lớp trung gian không cần thiết (Inline Class).

## Checklist Review Code
Khi review code hoặc thiết kế, hãy tự hỏi:
- [ ] Class này có đang làm quá nhiều việc không? (God Object)
- [ ] Có phải chúng ta đang dùng pattern này chỉ vì "thích" không? (Golden Hammer)
- [ ] Việc thêm pattern này có làm code khó đọc hơn giải pháp if-else đơn giản không?
- [ ] Có thể viết Unit Test cho class này dễ dàng không? (Nếu không, coi chừng Singleton/Static coupling).
