# Quy Trình Ra Quyết Định Chọn Design Pattern (Flowchart)

Sử dụng hướng dẫn này để xác định pattern phù hợp nhất cho vấn đề của bạn.

```mermaid
graph TD
    Start[Bắt đầu: Vấn đề của bạn là gì?] --> NeedCreate{Cần tạo đối tượng?}
    
    %% Creational Group
    NeedCreate -- Yes --> ComplexCreation{Việc tạo có phức tạp/nhiều bước?}
    ComplexCreation -- Yes --> Builder[**Builder**: Xây dựng từng bước]
    ComplexCreation -- No --> Family{Cần tạo một họ các đối tượng liên quan?}
    Family -- Yes --> AbstractFactory[**Abstract Factory**: Họ đối tượng]
    Family -- No --> OneInstance{Chỉ cần MỘT instance duy nhất?}
    OneInstance -- Yes --> Singleton[**Singleton**: Duy nhất toàn cục]
    OneInstance -- No --> SubclassDecide{Muốn subclass quyết định loại object?}
    SubclassDecide -- Yes --> FactoryMethod[**Factory Method**: Subclass quyết định]
    SubclassDecide -- No --> Clone{Muốn copy từ mẫu có sẵn?}
    Clone -- Yes --> Prototype[**Prototype**: Clone object]
    
    %% Structural Group
    NeedCreate -- No --> NeedStructure{Cần tổ chức Class/Object?}
    NeedStructure -- Yes --> InterfaceMatch{Interface có khớp không?}
    InterfaceMatch -- No --> Adapter[**Adapter**: Chuyển đổi Interface]
    InterfaceMatch -- Yes --> AddBehavior{Muốn thêm hành vi động?}
    AddBehavior -- Yes --> Decorator[**Decorator**: Thêm hành vi wrapper]
    AddBehavior -- No --> SimplifySystem{Hệ thống con quá phức tạp?}
    SimplifySystem -- Yes --> Facade[**Facade**: Interface đơn giản hóa]
    SimplifySystem -- No --> Hierarchy{Cần xử lý cây phân cấp?}
    Hierarchy -- Yes --> Composite[**Composite**: Cấu trúc cây]
    Hierarchy -- No --> ImplementationSplit{Muốn tách Abstraction & Implementation?}
    ImplementationSplit -- Yes --> Bridge[**Bridge**: Cầu nối Abstraction-Impl]
    ImplementationSplit -- No --> ResourceHeavy{Đối tượng tốn nhiều RAM/Resource?}
    ResourceHeavy -- Yes --> Flyweight[**Flyweight**: Chia sẻ trạng thái]
    ResourceHeavy -- No --> ControlAccess{Cần kiểm soát truy cập?}
    ControlAccess -- Yes --> Proxy[**Proxy**: Đại diện/Lazy Load]
    
    %% Behavioral Group
    NeedStructure -- No --> NeedComm{Cần giao tiếp giữa các Object?}
    NeedComm -- Yes --> Algorithm{Muốn thay đổi thuật toán lúc runtime?}
    Algorithm -- Yes --> Strategy[**Strategy**: Thay thế thuật toán]
    Algorithm -- No --> StateChange{Hành vi đổi theo trạng thái?}
    StateChange -- Yes --> State[**State**: Máy trạng thái]
    StateChange -- No --> Notify{Cần báo cho object khác khi đổi?}
    Notify -- Yes --> Observer[**Observer**: Pub/Sub]
    Notify -- No --> LooseCouple{Muốn giảm sự phụ thuộc trực tiếp?}
    LooseCouple -- Yes --> Mediator[**Mediator**: Trung gian điều phối]
    LooseCouple -- No --> Traverse{Cần duyệt qua collection?}
    Traverse -- Yes --> Iterator[**Iterator**: Duyệt tuần tự]
    Traverse -- No --> Chain{Cần xử lý qua nhiều bước?}
    Chain -- Yes --> ChainOfResp[**Chain of Responsibility**: Chuỗi xử lý]
    Chain -- No --> ActionRequest{Muốn đóng gói request?}
    ActionRequest -- Yes --> Command[**Command**: Undo/Queue]
    ActionRequest -- No --> SaveState{Cần lưu/khôi phục trạng thái?}
    SaveState -- Yes --> Memento[**Memento**: Snapshot]
    SaveState -- No --> TemplateStruct{Có khung thuật toán cố định?}
    TemplateStruct -- Yes --> TemplateMethod[**Template Method**: Khung xương]
    TemplateStruct -- No --> VisitorCheck{Muốn thêm operation mới vào class cũ?}
    VisitorCheck -- Yes --> Visitor[**Visitor**: Thêm hành vi từ ngoài]
```

## Hướng dẫn nhanh
1. **Phân tích vấn đề cốt lõi:** Đừng chọn pattern vì "ngầu", hãy chọn vì nó giải quyết đúng nỗi đau (pain point).
2. **KISS (Keep It Simple, Stupid):** Nếu `if-else` giải quyết được vấn đề và dễ đọc, đừng dùng `Strategy`.
3. **YAGNI (You Aren't Gonna Need It):** Đừng áp dụng `Abstract Factory` nếu bạn chưa có ý định hỗ trợ hệ điều hành thứ 2.
