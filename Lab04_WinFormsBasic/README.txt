LAB 04 - WINDOWS FORMS CƠ BẢN
Lê Tuấn Quang - 24000641 - DCCNTT15.C.1

Cách chạy
1. Giải nén toàn bộ ZIP, không mở solution bên trong cửa sổ ZIP.
2. Mở Lab04_WinFormsBasic.sln bằng Visual Studio 2022.
3. Máy cần workload .NET desktop development và .NET Framework 4.8 Targeting Pack.
4. Nhấn Ctrl + F5, chọn bài 1-10 trên màn hình chính.
5. Bấm Đóng/Thoát hoặc dấu X để về màn hình chọn bài.
Nếu mở IT3212_Labs.sln chung, chọn Lab04_WinFormsBasic làm Startup Project.
Build bằng terminal: dotnet build Lab04_WinFormsBasic.csproj -c Release
Chạy file bin/Release/net48/Lab04_WinFormsBasic.exe sau khi build.

Các bài
1-5 dùng chung frmSinhVien: mã, tên, ngày sinh, giới tính, khoa, sở thích và ảnh.
1. Hiển thị: đọc control, tạo SinhVien, hiện MessageBox.
2. Load: nạp 3 khoa một lần; chọn khoa đầu, mặc định Nam.
3. Đổi ngày sinh: tuổi tự cập nhật, có xét chưa đến sinh nhật.
4. Tích sở thích, bấm Xem sở thích; không tích thì hiện Chưa chọn.
5. Chọn ảnh mở OpenFileDialog, nhận PNG/JPG/JPEG/BMP, PictureBox Zoom.
6. Nhập hai số, bấm cộng/trừ/nhân/chia; có Làm mới và Thoát.
7. Nhập tài khoản sinhvien / 123456; thử hiện/ẩn và ghi nhớ tên đăng nhập.
8. Nhập chiều cao cm và cân nặng kg, tính BMI và phân loại.
9. Tích học phần: tổng tín chỉ cập nhật ngay; bấm Đăng ký để hiện danh sách.
10. Nhập mã/tên/loại/số lượng/đơn giá/ngày nhập, chọn ảnh và Lập phiếu.

Dữ liệu thử
- Sinh viên mẫu SV01, Nguyễn An, 12/05/2005, khoa CNTT; có thể sửa dữ liệu.
- Để họ tên trống rồi Hiển thị: báo lỗi. Đổi ngày sinh: kiểm tra tuổi.
- Ảnh mẫu nằm trong Images, được tự chép vào thư mục chạy khi build.
- Máy tính: 8 và 2 cho 10, 6, 16, 4. Chia cho 0 và nhập abc báo lỗi.
- Số thập phân chấp nhận dấu chấm hoặc dấu phẩy, không dùng phân cách nghìn.
- Đăng nhập sai hoặc thiếu thông tin: báo trên Label. Đúng: báo thành công.
- BMI 170 cm, 65 kg: 22,49, Bình thường. Giá trị 0 hoặc âm bị từ chối.
- Chọn Lập trình .NET (3) và Tiếng Anh (2): tổng 5 tín chỉ.
- Sản phẩm SP01/Bút bi, giá 5000, số lượng 3: thành tiền 15000.

Tổ chức source
Các Form được tạo control bằng C# trong constructor và dùng TableLayoutPanel.
Không dùng kéo thả Designer; sửa tên/thuộc tính/bố cục ngay trong file Form.
GiaoDien.cs chứa hàm dựng hàng nhập liệu, nút, thông báo và xử lý ảnh chung.
NghiepVu.cs chứa tính tuổi, đọc số, phép toán và BMI.
SinhVien.cs chuyển mô hình Lab02 sang .NET Framework 4.8.
Program.cs khởi động frmMain. Bài 6-10 có Form riêng.

Phạm vi
- Tài khoản ở bài 7 là dữ liệu giả để minh họa, không đăng nhập hệ thống thật.
- Ghi nhớ chỉ lưu tên trong phiên chạy; không lưu mật khẩu. Đóng app thì mất.
- Phiếu sản phẩm/học phần chỉ hiển thị trên Form, chưa ghi CSDL hoặc file.
- Bài 10 cho phép chưa chọn ảnh; đường dẫn được hiển thị khi có ảnh.
- BMI dùng mốc 18,5 / 25 / 30 để minh họa người trưởng thành.
- Bộ ảnh mẫu là avatar hình học, không phải ảnh cá nhân thật.

Kiểm tra đã chạy
Biên dịch .NET Framework 4.8: 0 lỗi, 0 cảnh báo. 41 kiểm tra đạt.
Log thực tế và ảnh dựng từ các control thật nằm trong Ket_qua_chay_thu.txt
và KetQua. Tự chạy lại từ thư mục chứa exe:
Lab04_WinFormsBasic.exe --test duong_dan_thu_muc_ket_qua
Chế độ --test chặn MessageBox để chạy liên tục; không dùng khi trình bày bài.
Hộp thoại chọn tệp và thao tác đóng Form có thể thử trực tiếp khi chạy bình thường.
