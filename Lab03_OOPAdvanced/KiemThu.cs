namespace Lab03_OOPAdvanced;
internal static class KiemThu
{
    static int dat, loi;
    static void Dung(bool ok) { if (!ok) throw new Exception("Kết quả không đúng"); }
    static void Sai<T>(Action a) where T:Exception
    { try { a(); } catch(T) { return; } throw new Exception("Chưa từ chối dữ liệu sai"); }
    static void Thu(string ten, Action a)
    { try { a(); dat++; Console.WriteLine("ĐẠT: " + ten); } catch(Exception ex) { loi++; Console.WriteLine("LỖI: " + ten + " " + ex.Message); } }
    public static void Chay()
    {
        dat=loi=0;
        Thu("Kế thừa và base constructor",()=>{var s=new SinhVien("A","An",new(2005,1,1),8); Dung(s is Nguoi && s.HoTen=="An");});
        Thu("Gọi override qua lớp cha",()=>{Nguoi n=new SinhVien("SV01","An",new(2005,1,1),8);Dung(n.MoTa().Contains("SV01"));});
        Thu("Học phí chính quy",()=>Dung(new SinhVienChinhQuy("A","An",new(2005,1,1),8,18).TinhHocPhi()==8100000));
        Thu("Học phí liên thông",()=>Dung(new SinhVienLienThong("B","Bình",new(2005,1,1),8,15).TinhHocPhi()==7800000));
        Thu("Không nhận tín chỉ âm",()=>Sai<ArgumentException>(()=>new SinhVienChinhQuy("A","An",new(2005,1,1),8,-1).TinhHocPhi()));
        foreach(double diem in new[]{-1d,11d,double.NaN,double.PositiveInfinity})
            Thu("Interface từ chối điểm " + diem,()=>Dung(!new SinhVien("A","An",new(2005,1,1),diem).IsValid(out _)));
        Thu("Interface từ chối mã rỗng",()=>Dung(!new SinhVien("","An",new(2005,1,1),8).IsValid(out _)));
        Thu("Interface từ chối tên rỗng",()=>Dung(!new SinhVien("A"," ",new(2005,1,1),8).IsValid(out _)));
        Thu("Interface từ chối ngày tương lai",()=>Dung(!new SinhVien("A","An",DateTime.Today.AddDays(1),8).IsValid(out _)));
        Thu("IPrintable",()=>{IPrintable p=new SinhVien("A","An",new(2005,1,1),8);Dung(p.ToDisplayText().Contains("Giỏi"));});
        Thu("Danh sách đa hình",()=>{List<NguoiHoc> ds=new(){new SinhVienChinhQuy("A","An",new(2005,1,1),8,18),new SinhVienLienThong("B","Bình",new(2005,1,1),8,15)};Dung(ds.Sum(x=>x.TinhHocPhi())==15900000);});
        Thu("Lương văn phòng",()=>Dung(new NhanVienVanPhong("An",7000000,500000).TinhLuong()==7500000));
        Thu("Lương kinh doanh",()=>Dung(new NhanVienKinhDoanh("Bình",6000000,100000000,.03m).TinhLuong()==9000000));
        Thu("Lương giảng viên",()=>Dung(new GiangVien("Chi",8000000,20,150000).TinhLuong()==11000000));
        Thu("Không nhận tỷ lệ hoa hồng sai",()=>Sai<ArgumentException>(()=>new NhanVienKinhDoanh("A",1,1,2)));
        Thu("Chi phí phương tiện",()=>{Dung(new XeMay().TinhChiPhi(60)==42000);Dung(new OTo().TinhChiPhi(60)==150000);Dung(new XeDap().TinhChiPhi(60)==0);});
        Thu("Thời gian phương tiện",()=>Dung(new OTo().TinhThoiGian(60)==1));
        Thu("Quãng đường âm",()=>Sai<ArgumentException>(()=>new XeMay().TinhChiPhi(-1)));
        Thu("Tài liệu ghi đè đúng loại",()=>{TaiLieu[] ds={new Sach("S","C#",2024,"An"),new TapChi("T","CNTT",2025,1),new LuanVan("L","Thư viện",2025,"Bình")};Dung(ds[0].ToDisplayText().Contains("Sách") && ds[1].ToDisplayText().Contains("Tạp chí") && ds[2].ToDisplayText().Contains("Luận văn"));});
        Thu("Tiền thừa",()=>{var t=new ThanhToanTienMat(200000);t.ThanhToan(150000);Dung(t.TienThua==50000);});
        Thu("Thanh toán thiếu tiền không ghi lịch sử",()=>{var s=new SoGiaoDich();var v=new ViDienTu("V",100);Sai<InvalidOperationException>(()=>s.ThucHien(v,101));Dung(v.SoDu==100 && s.LichSu.Count==0);});
        Thu("Thanh toán thành công ghi đúng giao dịch",()=>{var s=new SoGiaoDich();var v=new ChuyenKhoan("V",100);s.ThucHien(v,60);Dung(v.SoDu==40 && s.LichSu.Single().SoTien==60);});
        Thu("Thanh toán 0 bị từ chối",()=>Sai<ArgumentException>(()=>new ViDienTu("V",100).ThanhToan(0)));
        Thu("Quản lý 5 sinh viên nhiều loại",()=>{var q=QuanLySinhVien.TaoMau();Dung(q.DanhSach.Count==5 && q.DanhSach.Select(x=>x.Loai).Distinct().Count()==2);});
        Thu("Tìm kiếm mã và tên",()=>{var q=QuanLySinhVien.TaoMau();Dung(q.Tim("cq01").Count()==1 && q.Tim("Bình").Count()==1 && !q.Tim("không có").Any());});
        Thu("Không thêm mã trùng",()=>{var q=QuanLySinhVien.TaoMau();Sai<ArgumentException>(()=>q.Them(new SinhVienChinhQuy("cq01","An",new(2005,1,1),8,1)));Dung(q.DanhSach.Count==5);});
        Thu("Không thêm dữ liệu sai",()=>{var q=QuanLySinhVien.TaoMau();Sai<ArgumentException>(()=>q.Them(new SinhVienLienThong("X","An",new(2005,1,1),11,1)));Dung(q.DanhSach.Count==5);});
        Thu("Sửa sai không mất dữ liệu cũ",()=>{var q=QuanLySinhVien.TaoMau();Sai<ArgumentException>(()=>q.Sua("CQ01",new SinhVienChinhQuy("CQ01","Sai",new(2005,1,1),11,1)));Dung(q.Tim("CQ01").Single().HoTen=="Nguyễn An");});
        Thu("Xóa và sắp xếp",()=>{var q=QuanLySinhVien.TaoMau();Dung(q.Xoa("lt01") && !q.Xoa("lt01"));q.SapXep();Dung(q.DanhSach.First().DiemTB==9.1);});
        Thu("CSV thoát dấu ngoặc kép",()=>Dung(new SinhVien("A","An, \"B\"",new(2005,1,1),8).ToCsv().Contains("\"An, \"\"B\"\"\"")));
        Console.WriteLine($"Tổng kết: {dat} đạt, {loi} lỗi."); Environment.ExitCode=loi==0?0:1;
    }
}
