LAB 02 - OOP CƠ BẢN
Lê Tuấn Quang - 24000641

Cách chạy
- Cài .NET SDK 10. Mở IT3212_Labs.sln bằng Visual Studio có hỗ trợ .NET 10.
- Chọn Lab02_OOPBasics làm Startup Project, nhấn Ctrl + F5.
- Hoặc mở terminal ở thư mục solution:
  dotnet run --project Lab02_OOPBasics
- Chọn bài từ 1 đến 10; nhập 0 để thoát hoặc quay lại.

Nội dung
1-5: SinhVien, constructor, đóng gói, tính tuổi, xếp loại, danh sách và tìm mã.
6: SanPham, kiểm tra giá và số lượng, tính thành tiền.
7: TaiKhoanNganHang, nạp/rút/chuyển tiền, kiểm tra số dư.
8: NhanVien, tính lương cơ bản * hệ số + phụ cấp, in bảng lương mẫu.
9: HinhChuNhat, kiểm tra cạnh dương, tính chu vi và diện tích.
10: Quản lý sinh viên: thêm, sửa, xóa, tìm mã, sắp xếp và thống kê.
Mỗi lớp đặt trong một file riêng. Program.cs xử lý menu và nhập liệu.

Dữ liệu thử
- Có sẵn SV01 đến SV05, điểm lần lượt 9.2; 8.2; 6.8; 5.5; 4.0.
- Tìm sv03 sẽ ra Lê Chi. Mã không phân biệt chữ hoa/thường.
- Thêm SV06, sửa điểm rồi tìm lại; xóa SV06 và kiểm tra danh sách.
- Điểm 11 hoặc tên chỉ có khoảng trắng bị từ chối.
- Sản phẩm giá 5000, số lượng 3: thành tiền 15000.
- TK01 có 1000000, TK02 có 500000. Nạp 200000, rút 100000,
  chuyển 300000 từ TK01 sang TK02: hai tài khoản đều còn 800000.
- Rút vượt số dư bị từ chối, số dư không thay đổi.
- Lương cơ bản 5000000, hệ số 2, phụ cấp 500000: lương 10500000.
- Hình chữ nhật 3 x 4: chu vi 14, diện tích 12; cạnh 0 bị từ chối.

Kiểm thử
  dotnet run --project Lab02_OOPBasics -- --test
KiemThu.cs có 38 trường hợp kiểm tra tự động. Đã chạy đạt 38/38;
10 kịch bản chạy menu cũng đạt. Kết quả đầy đủ: Ket_qua_chay_thu.txt.

Lưu ý
- Ngày sinh nhập dd/MM/yyyy. Số tiền không có dấu phân cách hàng nghìn.
- Điểm và cạnh có thể dùng dấu chấm hoặc dấu phẩy thập phân.
- Tuổi thay đổi theo ngày chạy chương trình.
- Sắp xếp theo toàn bộ họ tên tăng dần hoặc điểm giảm dần.
- Danh sách sinh viên lưu trong bộ nhớ, thoát chương trình sẽ mất thay đổi.
- Hai tài khoản ngân hàng được tạo lại mỗi lần chọn bài 7.
- Bài 8 in bảng lương 3 nhân viên mẫu; không có chức năng quản lý nhân viên.

Đã làm đủ 10 bài trong ảnh đề. Báo cáo ngắn và mã nguồn đi kèm.
