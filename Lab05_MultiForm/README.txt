LAB05 - XỬ LÝ SỰ KIỆN, KIỂM TRA DỮ LIỆU VÀ ỨNG DỤNG ĐA FORM
Lê Tuấn Quang - 24000641 - DCCNTT15.C.1

Cách chạy
Giải nén toàn bộ ZIP, mở Lab05_MultiForm.sln, nhấn Ctrl + F5.
Visual Studio 2022: cần workload .NET desktop development và targeting pack
.NET Framework 4.8. Có thể dùng Visual Studio mới hơn với thành phần tương ứng.
Chọn Form .cs rồi Shift + F7 / View Designer để xem giao diện; F4 xem Properties.
Các Form có .cs, .Designer.cs và .resx. Dữ liệu khoa nạp khi chạy.
Build terminal: dotnet build Lab05_MultiForm.csproj -c Release
Chạy: bin/Release/net48/Lab05_MultiForm.exe

Mở từng bài
1-4: Danh mục > Sinh viên.
  - Để trống mã hoặc họ tên rồi Lưu: lỗi xuất hiện cạnh control bằng ErrorProvider.
  - Điểm chỉ nhận chữ số và một dấu chấm/phẩy khi gõ; dán dữ liệu vẫn được
    kiểm tra lại [0,10] khi Lưu. NaN, vô cực, chữ và số ngoài miền bị từ chối.
  - Đổi tên/điểm: Label xem trước và trạng thái tự đổi qua TextChanged.
  - Xem chi tiết: truyền một đối tượng SinhVien bằng constructor.
5: Menu Danh mục / Nghiệp vụ / Hệ thống. Mở Sinh viên hoặc Khoa nhiều lần:
   chỉ giữ một Form MDI của cùng loại, kích hoạt lại Form đang mở.
6: Hệ thống > Đăng nhập. Tài khoản giả sinhvien / 123456.
   Sau 3 lần nhập sai, nút khóa 30 giây, đồng hồ đếm ngược rồi cho thử lại.
   Đóng và mở lại hộp thoại trong cùng phiên không xóa khóa. Thông tin trống
   chỉ nhắc nhập đủ, không tính là lần sai. Đóng app thì trạng thái này mất.
7: Nghiệp vụ > Tìm sinh viên hoặc nút Tìm kiếm trên Form Sinh viên.
   Nhập mã/tên, bấm Tìm, chọn một dòng rồi Chọn. Hủy không trả kết quả.
   Từ Form Sinh viên: kết quả được điền vào ô nhập. Từ menu: mở Form chi tiết.
8: Trên Form Sinh viên, bấm Chọn khoa..., chọn rồi Chọn.
   Form nhận danh sách khoa và trả property KhoaDaChon, không dùng biến toàn cục.
9: Hệ thống > Thoát hoặc đóng cửa sổ chính. Yes thoát, No giữ ứng dụng.
10: Dashboard MDI có MenuStrip, StatusStrip, đồng hồ mỗi giây và Form
    Sinh viên, Khoa, Giới thiệu. Khoa chỉ hiển thị danh sách hiện có.

Dữ liệu thử
Ban đầu 3 sinh viên SV01 Nguyễn An, SV02 Trần Bình, SV03 Lê Chi.
Thử thêm SV04 / Test An / 8.5 / khoa CNTT: danh sách có 4 sinh viên.
Lưu mã SV01: báo trùng. Điểm 0 và 10 hợp lệ; -1, 11, abc không hợp lệ.
Tìm sv04 hoặc An; tìm zzzz để thấy 0 kết quả. Để từ khóa trống để xem tất cả.
Chọn Kinh tế từ hộp thoại, ComboBox của Form gọi cập nhật ngay.
Đăng nhập sai 3 lần, thử đóng/mở hộp thoại, chờ đủ 30 giây rồi đăng nhập đúng.

Tổ chức và giới hạn
DuLieu giữ danh sách trong bộ nhớ, được frmMain sở hữu và truyền qua constructor.
SinhVien chứa dữ liệu hợp lệ; Form chi tiết không đọc control private Form khác.
Nút Lưu chỉ thêm mới, không cập nhật bản ghi sau tìm kiếm; mã trùng sẽ bị chặn.
Đăng nhập là bài mô phỏng riêng, không phải cổng bảo vệ dashboard.
Chưa lưu file/CSDL, thoát app sẽ mất các sinh viên thêm trong phiên.
Bài làm tiếp nối Lab04 nhưng chạy độc lập; Lab06 có thể dùng lại đối tượng
và danh sách để hiển thị DataGridView và tách mô hình ba lớp.

Kiểm thử
39 kiểm tra đạt; build .NET Framework 4.8: 0 lỗi, 0 cảnh báo.
Log: Ket_qua_chay_thu.txt; ảnh Form dựng từ control thật: KetQua.
Chạy lại bộ tự động từ thư mục chứa exe:
Lab05_MultiForm.exe --test duong_dan_thu_muc_ket_qua
Chế độ kiểm thử thay câu trả lời hộp thoại bằng Yes/No và kiểm tra khóa 30
giây bằng các mốc thời gian xác định; không phải chờ thật 30 giây trong test.
