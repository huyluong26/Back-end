using System;
namespace LAB2
{
    class Program
    {
        public static void NhapMang(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}]: ");
                a[i] = int.Parse(Console.ReadLine());
            }
        }
        public static int TinhTong(int[] a, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
            {
                tong += a[i];
            }
            return tong;
        }
        public static int TongChan(int[] a, int n) 
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
        {   if (a[i] % 2 == 0)
                {
                    tong += a[i];
                }
            }
            return tong;
        }
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        static void SoNguyenTo(int[]a, int n)
        {
            Console.WriteLine("Các số nguyên tố trong mảng:");
            for (int i = 0; i < n; i++)
            {
                if (IsPrime(a[i]))
                {
                    Console.WriteLine($"Chỉ số: {i}, Giá trị: {a[i]}");
                }
            }
        }
        public static (int, int) DemSoAmVaDuong(int[] a, int n)
        {
            int soDuong = 0;
            int soAm = 0;

            for (int i = 0; i < n; i++)
            {
                if (a[i] > 0)
                {
                    soDuong++;
                }
                else if (a[i] < 0)
                {
                    soAm++;
                }
            }
            return (soDuong, soAm);
            
        }
        public static int TimSoLonThuHai(int[] a, int n)
        {
            if (n < 2)
            {
                throw new ArgumentException("Mảng phải có ít nhất 2 phần tử.");
            }

            int max = int.MinValue; // Số lớn nhất
            int secondMax = int.MinValue; // Số lớn thứ hai

            for (int i = 0; i < n; i++)
            {
                if (a[i] > max)
                {
                    secondMax = max; // Cập nhật số lớn thứ hai
                    max = a[i]; // Cập nhật số lớn nhất
                }
                else if (a[i] > secondMax && a[i] != max)
                {
                    secondMax = a[i]; // Cập nhật số lớn thứ hai
                }
            }

            if (secondMax == int.MinValue)
            {
                throw new InvalidOperationException("Không có số lớn thứ hai trong mảng.");
            }

            return secondMax;
        }
        public static void HoanVi(int[] a,int index1, int index2)
        {
            int temp = a[index1];
            a[index1] = a[index2];
            a[index2] = temp;
        }
        public static void SapXepTangDan(int[] a, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        // Hoán đổi
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Khai báo biến n
            int n;
            //Nhập giá trị cho biến n
            Console.Write("Nhập số phần tử của mảng: ");
            n = int.Parse(Console.ReadLine());
            //Khai báo và khởi tạo mảng số nguyên có n phần tử
            int[] a = new int[n];
            //Gọi hàm nhập mảng
            NhapMang(a, n);
            //Gọi hàm Tính Tổng các phần tử trong mảng và hiển thị kết quả ra màn hình
            Console.WriteLine($"Tổng = {TinhTong(a, n)}");
            Console.WriteLine("===============");
            //Gọi hàm tính tổng các phần tử chẵn
            Console.WriteLine($"Tổng số chẵn trong mảng = {TongChan(a, n)}");
            Console.WriteLine("===============");
            //Gọi hàm kiểm tra số nguyên tố
            SoNguyenTo(a, n);
            //Gọi hàm đếm số phần tử âm và dương
            var (soDuong,soAm) = DemSoAmVaDuong(a, n);
            Console.WriteLine($"Số lượng số dương: {soDuong}");
            Console.WriteLine($"Số lượng số âm: {soAm}");
            Console.WriteLine("===============");
            //Tìm số lớn thứ hai trong mảng
            try
            {
                int secondLargest = TimSoLonThuHai(a, n);
                Console.WriteLine($"Số lớn thứ hai trong mảng là: {secondLargest}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("===============");
            //Hoán vị
            Console.Write("Nhập chỉ số của phần tử thứ nhất để hoán vị: ");
            int index1 = int.Parse(Console.ReadLine());

            Console.Write("Nhập chỉ số của phần tử thứ hai để hoán vị: ");
            int index2 = int.Parse(Console.ReadLine());

            // Kiểm tra chỉ số hợp lệ
            if (index1 >= 0 && index1 < n && index2 >= 0 && index2 < n)
            {
                Console.WriteLine($"Trước khi hoán vị: a[{index1}] = {a[index1]}, a[{index2}] = {a[index2]}");

                // Gọi hàm hoán vị
                HoanVi(a, index1, index2);

                Console.WriteLine($"Sau khi hoán vị: a[{index1}] = {a[index1]}, a[{index2}] = {a[index2]}");
            }
            else
            {
                Console.WriteLine("Chỉ số không hợp lệ.");
            }
            //Sắp xếp phần tử trong mảng theo chiều tăng dần
            Console.WriteLine("===============");
            SapXepTangDan(a, n);

            // In ra mảng đã sắp xếp
            Console.WriteLine("Mảng sau khi sắp xếp theo chiều tăng dần:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
        }
    }
    }
    


