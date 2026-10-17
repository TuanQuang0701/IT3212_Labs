LAB 03 - KẾ THỪA, ĐA HÌNH, LỚP TRỪU TƯỢNG VÀ INTERFACE
Lê Tuấn Quang - 24000641 - DCCNTT15.C.1

Cách chạy
Giải nén toàn bộ ZIP, mở Lab03_OOPAdvanced.sln và nhấn Ctrl + F5.
Cần .NET SDK 8 trở lên và Visual Studio 2022 hỗ trợ .NET 8.
Nếu mở solution IT3212_Labs.sln chung, chọn Lab03_OOPAdvanced làm Startup Project.
Hoặc mở terminal ở thư mục project:
dotnet run
Kiểm tra tự động: dotnet run -- --test

Menu
1. Nguoi - SinhVien: constructor gọi base, kế thừa họ tên và ngày sinh.
2. MoTa virtual/override: gọi qua tham chiếu Nguoi.
3. NguoiHoc abstract: nhập tín chỉ và so sánh học phí hai hệ.
4. IValidatable, IPrintable: nhập sinh viên, kiểm tra và in dữ liệu hợp lệ.
5. List<NguoiHoc>: nhiều hệ sinh viên, tổng học phí qua phương thức đa hình.
6. NhanVien abstract: văn phòng, kinh doanh, giảng viên; tính bảng lương mẫu.
7. IMove: nhập quãng đường, so sánh tốc độ, thời gian và chi phí 3 phương tiện.
8. TaiLieu: sách, tạp chí, luận văn; in đúng loại và tìm theo mã hoặc tiêu đề.
9. IPayment: tiền mặt, chuyển khoản, ví; kiểm tra và ghi giao dịch thành công.
10. Thêm/sửa/xóa/tìm/sắp xếp, thống kê theo loại và xuất CSV qua IExportable.
Nhập 0 để quay lại hoặc thoát.

Dữ liệu thử
Có 5 sinh viên: CQ01, LT01, CQ02, LT02, CQ03, gồm chính quy và liên thông.
Học phí chính quy: tín chỉ * 450000. Liên thông: tín chỉ * 520000.
18 tín chỉ: chính quy 8100000, liên thông 9360000.
Danh sách mẫu có tổng học phí 38340000.
Điểm 11, tên rỗng, ngày sinh tương lai, tín chỉ âm: không hợp lệ.
Tìm cq01 hoặc An; thử mã không có; thêm mã trùng để kiểm tra thông báo.
Lương mẫu văn phòng 7500000, kinh doanh 9000000, giảng viên 11000000.
60 km: xe máy 1,5 giờ/42000; ô tô 1 giờ/150000; xe đạp 4 giờ/0.
Tìm thư viện theo S01 hoặc C#; nhập zzzz để thử không có kết quả.
Tiền mặt: thanh toán 150000, đưa 200000, trả lại 50000.
Chuyển khoản có 1000000, ví có 500000. Thử trả quá số dư, lịch sử không thêm.

Quy ước bài tự làm
Bài 6: văn phòng = lương cơ bản + phụ cấp; kinh doanh = lương cơ bản +
doanh số * tỷ lệ hoa hồng; giảng viên = lương cơ bản + số tiết * tiền mỗi tiết.
Bài 7: tốc độ 40/60/15 km/h; chi phí 700/2500/0 đồng mỗi km, chỉ là mô phỏng.
Bài 9 là mô phỏng trong bộ nhớ, không kết nối ngân hàng hoặc thanh toán thật.

Tổ chức và giới hạn
Nguoi -> SinhVien -> NguoiHoc abstract -> SinhVienChinhQuy/SinhVienLienThong.
Tách thông tin chung và các interface để tiếp tục dùng trong lab sau.
IsValid là điểm kiểm tra tập trung; đối tượng nháp có thể chưa hợp lệ,
nhưng không được thêm/sửa vào danh sách quản lý hoặc xuất CSV khi sai.
Dữ liệu và lịch sử chỉ lưu trong lần chạy; bài 9 tạo lại khi vào menu này.
CSV lưu tên sinhvien_lab03.csv tại thư mục chạy, chương trình in đường dẫn.
Chọn xuất lần nữa sẽ cập nhật nội dung file đó. CSV chứa mã/tên/ngày/điểm/loại.
Mã nguồn từng bài, kết quả chạy và báo cáo Word nằm cùng thư mục.
