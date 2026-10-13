LAB 01 - LẬP TRÌNH .NET

1. Cách chạy
Máy cần có .NET SDK 10 và Visual Studio hỗ trợ .NET 10.
Mở solution IT3212_Labs.sln bằng Visual Studio.
Chọn Lab01_Console làm Startup Project, nhấn Ctrl + F5 để chạy.
Chọn bài từ 1 đến 10, nhập dữ liệu theo hướng dẫn. Chọn 0 để thoát.
Bài 4 và bài 10 có menu riêng; chọn 0 để quay lại menu chính.
Cũng có thể mở terminal ở thư mục này và chạy:
dotnet run --project Lab01_Console

2. Dữ liệu dùng để thử
Bài 1: Nguyễn Văn An, năm sinh 2006.
Bài 2: Bán kính 3, chiều cao 5; thử thêm số 0 và số âm.
Bài 3: Điểm 9, 8, 6.5, 5, 4; thử -1 và 11 để kiểm tra giới hạn.
Bài 4: Tính tổng với n = 10 (kết quả 55), xem bảng cửu chương,
       chọn 0 để thoát.
Bài 5: 10 và 2 (kết quả 5); 10 và 0; nhập chữ để kiểm tra lỗi.
Bài 6: (a, b, c) = (1, -3, 2): hai nghiệm 1.00 và 2.00.
       (1, 2, 1): nghiệm kép -1.00; (1, 0, 1): không có nghiệm thực.
       (0, 2, -4): nghiệm 2.00; (0, 0, 0): vô số nghiệm;
       (0, 0, 1): vô nghiệm.
Bài 7: n = 5, dãy 1, 2, 3, 4, 5: tổng 15, trung bình 3,
       lớn nhất 5, nhỏ nhất 1, có 2 số chẵn.
Bài 8: n = 20: in 2, 3, 5, 7, 11, 13, 17, 19; n = 1: không có.
Bài 9: Thử các số 0, 5, 10, 15, 21, 25, 99.
Bài 10: Kích thước 5; thử từng kiểu tam giác và hình vuông rỗng.

3. Phần đã hoàn thành
Đã làm đủ 10 bài trong đề. Build không có lỗi và cảnh báo.
Đã chạy 12 lượt kiểm thử, kết quả ghi trong Ket_qua_chay_thu.txt.
Báo cáo ngắn nằm trong Bao_cao_ngan.txt.

4. Lưu ý
Bài 5 dùng phép chia số nguyên theo code mẫu (7 / 2 = 3).
Bài 6 xét nghiệm thực, in nghiệm với 2 chữ số thập phân.
Chấp nhận dấu chấm hoặc dấu phẩy khi nhập số thực.
Giới hạn nhập để tránh chạy quá lâu: tổng và số nguyên tố tới 1.000.000;
dãy số tối đa 100.000 phần tử; kích thước hình tối đa 50.
