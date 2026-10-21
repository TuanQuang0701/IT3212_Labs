using System;
using System.Globalization;

namespace Lab04_WinFormsBasic
{
    public static class NghiepVu
    {
        public static int TinhTuoi(DateTime sinh, DateTime homNay)
        {
            if (sinh.Date > homNay.Date) throw new ArgumentException("Ngày sinh ở tương lai.");
            int tuoi = homNay.Year - sinh.Year;
            if (sinh.Date > homNay.Date.AddYears(-tuoi)) tuoi--;
            return tuoi;
        }
        public static decimal DocSo(string text)
        {
            decimal so;
            if (!decimal.TryParse(text.Trim().Replace(',', '.'),
                NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture, out so))
                throw new ArgumentException("Hãy nhập số hợp lệ, không có dấu phân cách hàng nghìn.");
            return so;
        }
        public static decimal Tinh(decimal a, decimal b, string phep)
        {
            switch (phep)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "×": return a * b;
                case "÷": if (b == 0) throw new ArgumentException("Không thể chia cho 0."); return a / b;
                default: throw new ArgumentException("Phép tính không hợp lệ.");
            }
        }
        public static double TinhBmi(decimal caoCm, decimal nangKg)
        {
            if (caoCm <= 0 || nangKg <= 0) throw new ArgumentException("Chiều cao và cân nặng phải lớn hơn 0.");
            double m = (double)caoCm / 100;
            return (double)nangKg / (m * m);
        }
        // Ngưỡng phân loại BMI người trưởng thành, chỉ dùng minh họa bài tập.
        public static string PhanLoaiBmi(double bmi)
        { return bmi < 18.5 ? "Thiếu cân" : bmi < 25 ? "Bình thường" : bmi < 30 ? "Thừa cân" : "Béo phì"; }
    }
}
