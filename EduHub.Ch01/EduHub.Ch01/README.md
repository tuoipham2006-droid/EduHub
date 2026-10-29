# EduHub - Quản lý Câu lạc bộ & Sự kiện (Chương 1)

## 1. Mô tả thiết kế Domain
Hệ thống quản lý EduHub bao gồm các thực thể cốt lõi cho Chương 1:
- **Member**: Đại diện cho sinh viên tham gia hệ thống, quản lý thông tin cá nhân và mã sinh viên.
- **Club**: Đại diện cho Câu lạc bộ sinh viên (`Tech Club`), quản lý danh sách thành viên trực thuộc.
- **Event**: Đại diện cho các sự kiện/workshop do CLB tổ chức (`Workshop AI`), có giới hạn sức chứa (`Capacity`).
- **Registration**: Phiếu đăng ký tham gia sự kiện của thành viên, quản lý trạng thái (`Pending`, `Confirmed`, `Cancelled`).
- **CheckIn**: Ghi nhận việc điểm danh của thành viên khi đến tham gia sự kiện thực tế.

## 2. Cách chạy ứng dụng
1. Mở Terminal tại thư mục chứa project (`EduHub.Ch01/`).
2. Chạy lệnh:
   dotnet run