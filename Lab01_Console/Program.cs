using System.Globalization;
using System.Text;

namespace Lab01_Console;

internal static class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        try
        {
            int choice;
            do
            {
                Console.WriteLine("\n===== LAB 01 =====");
                string[] titles = { "Thông tin cá nhân", "Tính toán hình trụ", "Xếp loại học tập",
                    "Menu tính tổng và bảng cửu chương", "Xử lý ngoại lệ phép chia",
                    "Giải phương trình bậc hai", "Thống kê dãy số", "Số nguyên tố",
                    "Đọc số từ 0 đến 99", "Vẽ hình bằng ký tự" };
                for (int i = 0; i < titles.Length; i++) Console.WriteLine($"{i + 1}. {titles[i]}");
                Console.WriteLine("0. Thoát");
                choice = ReadInt("Chọn bài: ", 0, 10);
                switch (choice)
                {
                    case 1: PersonalInfo(); break;
                    case 2: Cylinder(); break;
                    case 3: Grade(); break;
                    case 4: CalculationMenu(); break;
                    case 5: Division(); break;
                    case 6: Quadratic(); break;
                    case 7: Statistics(); break;
                    case 8: Primes(); break;
                    case 9: ReadNumber(); break;
                    case 10: Shapes(); break;
                }
            } while (choice != 0);
        }
        catch (EndOfStreamException) { Console.WriteLine("\nKết thúc nhập dữ liệu."); }
    }

    static string Input(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? throw new EndOfStreamException();
    }

    static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true)
        {
            if (int.TryParse(Input(prompt), out int value) && value >= min && value <= max) return value;
            Console.WriteLine($"Nhập số nguyên từ {min} đến {max}.");
        }
    }

    static double ReadDouble(string prompt)
    {
        while (true)
        {
            string text = Input(prompt).Trim().Replace(',', '.');
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double value)
                && double.IsFinite(value)) return value;
            Console.WriteLine("Nhập số hợp lệ (dấu thập phân . hoặc ,). Không nhập NaN/vô cực.");
        }
    }

    // Bài 1
    static void PersonalInfo()
    {
        string name;
        do { name = Input("Họ và tên: ").Trim(); } while (name.Length == 0);
        int year = ReadInt("Năm sinh: ", 1, DateTime.Now.Year);
        Console.WriteLine($"Xin chào {name}, tuổi gần đúng: {DateTime.Now.Year - year}.");
    }

    // Bài 2
    static void Cylinder()
    {
        double r, h;
        do { r = ReadDouble("Bán kính r (> 0): "); } while (r <= 0);
        do { h = ReadDouble("Chiều cao h (> 0): "); } while (h <= 0);
        double area = 2 * Math.PI * r * h;
        double volume = Math.PI * r * r * h;
        if (!double.IsFinite(area) || !double.IsFinite(volume))
            Console.WriteLine("Dữ liệu quá lớn để tính bằng kiểu double.");
        else Console.WriteLine($"Diện tích xung quanh: {area:F2}; Thể tích: {volume:F2}");
    }

    // Bài 3
    static void Grade()
    {
        double score;
        do { score = ReadDouble("Điểm [0, 10]: "); } while (score < 0 || score > 10);
        if (score >= 9) Console.WriteLine("Xuất sắc");
        else if (score >= 8) Console.WriteLine("Giỏi");
        else if (score >= 6.5) Console.WriteLine("Khá");
        else if (score >= 5) Console.WriteLine("Trung bình");
        else Console.WriteLine("Yếu");
    }

    // Bài 4: menu riêng dùng do-while và switch.
    static void CalculationMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n1. Tổng 1..n\n2. Bảng cửu chương 7\n0. Quay lại");
            choice = ReadInt("Chọn: ", 0, 2);
            switch (choice)
            {
                case 1:
                    int n = ReadInt("n (1..1000000): ", 1, 1_000_000);
                    long sum = 0;
                    for (int i = 1; i <= n; i++) sum += i;
                    Console.WriteLine($"Tổng = {sum}");
                    break;
                case 2:
                    for (int i = 1; i <= 10; i++) Console.WriteLine($"7 x {i} = {7 * i}");
                    break;
            }
        } while (choice != 0);
    }

    // Bài 5: phép chia nguyên, bắt ngoại lệ cụ thể trước ngoại lệ tổng quát.
    static void Division()
    {
        try
        {
            int a = int.Parse(Input("a = "));
            int b = int.Parse(Input("b = "));
            Console.WriteLine($"a / b = {a / b}");
        }
        catch (FormatException) { Console.WriteLine("Dữ liệu phải là số nguyên."); }
        catch (DivideByZeroException) { Console.WriteLine("Không thể chia cho 0."); }
        catch (OverflowException) { Console.WriteLine("Số nhập hoặc kết quả vượt phạm vi int."); }
        catch (EndOfStreamException) { throw; }
        catch (Exception ex) { Console.WriteLine($"Lỗi: {ex.Message}"); }
        finally { Console.WriteLine("Kết thúc phép tính."); }
    }

    // Bài 6
    static void Quadratic()
    {
        double a = ReadDouble("a = "), b = ReadDouble("b = "), c = ReadDouble("c = ");
        if (a == 0)
        {
            if (b == 0) Console.WriteLine(c == 0 ? "Vô số nghiệm." : "Vô nghiệm.");
            else PrintRoot("Phương trình bậc nhất, x", -c / b);
            return;
        }
        // Chuẩn hóa hệ số để hạn chế tràn khi tính delta.
        double scale = Math.Max(Math.Abs(a), Math.Max(Math.Abs(b), Math.Abs(c)));
        a /= scale; b /= scale; c /= scale;
        if (a == 0) { Console.WriteLine("Chênh lệch hệ số vượt độ chính xác double."); return; }
        double delta = b * b - 4 * a * c;
        if (delta < 0) Console.WriteLine("Vô nghiệm thực.");
        else if (delta == 0) PrintRoot("Nghiệm kép x", -b / (2 * a));
        else
        {
            double q = -0.5 * (b + Math.CopySign(Math.Sqrt(delta), b));
            PrintRoot("x1", q / a);
            PrintRoot("x2", c / q);
        }
    }

    static void PrintRoot(string label, double value)
    {
        Console.WriteLine(double.IsFinite(value) ? $"{label} = {(Math.Round(value, 2) == 0 ? 0 : value):F2}"
            : "Nghiệm vượt phạm vi biểu diễn double.");
    }

    // Bài 7
    static void Statistics()
    {
        int n = ReadInt("Số phần tử (1..100000): ", 1, 100_000);
        long sum = 0;
        int max = int.MinValue, min = int.MaxValue, even = 0;
        for (int i = 0; i < n; i++)
        {
            int x = ReadInt($"Số thứ {i + 1}: ");
            sum += x;
            max = Math.Max(max, x); min = Math.Min(min, x);
            if (x % 2 == 0) even++;
        }
        Console.WriteLine($"Tổng: {sum}; Trung bình: {(double)sum / n:F2}");
        Console.WriteLine($"Lớn nhất: {max}; Nhỏ nhất: {min}; Số lượng số chẵn: {even}");
    }

    // Bài 8: chỉ thử ước đến căn bậc hai; dùng x / i để tránh tràn i*i.
    static bool IsPrime(int x)
    {
        if (x < 2) return false;
        for (int i = 2; i <= x / i; i++) if (x % i == 0) return false;
        return true;
    }

    static void Primes()
    {
        int n = ReadInt("n (0..1000000): ", 0, 1_000_000);
        if (n < 2) { Console.WriteLine("Không có số nguyên tố."); return; }
        Console.WriteLine($"Các số nguyên tố không vượt quá {n}:");
        for (int i = 2; i <= n; i++) if (IsPrime(i)) Console.Write($"{i} ");
        Console.WriteLine();
    }

    // Bài 9: dùng switch để chuyển chữ số và các trường hợp đặc biệt.
    static string Digit(int x)
    {
        switch (x)
        {
            case 0: return "không";
            case 1: return "một";
            case 2: return "hai";
            case 3: return "ba";
            case 4: return "bốn";
            case 5: return "năm";
            case 6: return "sáu";
            case 7: return "bảy";
            case 8: return "tám";
            case 9: return "chín";
            default: return "";
        }
    }

    static void ReadNumber()
    {
        int n = ReadInt("Số cần đọc [0, 99]: ", 0, 99);
        if (n < 10) { Console.WriteLine(Digit(n)); return; }
        int tens = n / 10, units = n % 10;
        string result = tens == 1 ? "mười" : Digit(tens) + " mươi";
        switch (units)
        {
            case 0: break;
            case 1: result += tens > 1 ? " mốt" : " một"; break;
            case 5: result += " lăm"; break;
            default: result += " " + Digit(units); break;
        }
        Console.WriteLine(result);
    }

    // Bài 10
    static void Shapes()
    {
        int choice;
        do
        {
            Console.WriteLine("\n1. Tam giác vuông đặc\n2. Tam giác vuông rỗng\n3. Hình vuông rỗng\n0. Quay lại");
            choice = ReadInt("Chọn: ", 0, 3);
            if (choice == 0) continue;
            int n = ReadInt("Kích thước (1..50): ", 1, 50);
            for (int i = 1; i <= n; i++)
            {
                int cols = choice == 3 ? n : i;
                for (int j = 1; j <= cols; j++)
                {
                    bool border = choice == 1 || (choice == 2 ? j == 1 || j == i || i == n
                        : i == 1 || i == n || j == 1 || j == n);
                    Console.Write(border ? "* " : "  ");
                }
                Console.WriteLine();
            }
        } while (choice != 0);
    }
}
