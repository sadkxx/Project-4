using System;

class Program
{
    static void Main()
    {
        Console.Write("Görmek istediğiniz projeyi seçiniz :\n" +
        "Proje 1 (Matematiksel Hesaplama Yapan Parametresiz ve Geriye Değer Döndüren Metot)\n" +
        "Proje 2 (Dizideki En Büyük Değeri Bulan Parametreli ve Geriye Değer Döndüren Metot)\n" +
        "Proje 3 (Aşırı Yüklenmiş (Overloaded) Metot ile Farklı Türdeki Verilerin Toplamını Bulma)\n" +
        "Proje 4 (Recursive Metot ile Fibonacci Dizisi Hesaplama)\n" +
        "Proje 5 (Params ile Sınırsız Sayıda Parametre Alarak Ortalama Hesaplama)" +
        "Proje 6 (Dizi Elemanlarını Toplayan ve Filtreleme Şartı Ekleyen Metot)" +
        "Proje 7 (Seçmeli (Optional) Parametre ile Belirli Yaştan Sonraki Yılları Sayma)" +
        "Proje 8 (Geriye Koleksiyon Döndüren ve Veriyi Filtreleyen Metot)" +
        "Seçiminiz :");
        string girdi = Console.ReadLine();
        if (1<=Convert.ToInt16(girdi) && Convert.ToInt16(girdi)<=8)
        {
            int deger = Convert.ToInt16(girdi);
            switch (deger)
            {
                case 1: Console.Clear(); fonk1(); sorgu(); break;
                case 2: Console.Clear(); fonk2(); sorgu(); break;
                case 3: Console.Clear(); fonk3(); sorgu(); break;
                case 4: Console.Clear(); fonk4(); sorgu(); break;
                case 5: Console.Clear(); fonk5(); sorgu(); break;
                case 6: Console.Clear(); fonk6(); sorgu(); break;
                case 7: Console.Clear(); fonk7(); sorgu(); break;
                case 8: Console.Clear(); fonk8(); sorgu(); break;
                default: Console.Clear(); Console.WriteLine("Hatalı Seçim Yaptınız! Lütfen 1-4 arası seçim yapınız."); Main(); break;
            }
        }
        else Console.WriteLine("Hatalı Seçim Yaptınız! Lütfen 1-8 arası seçim yapınız.\n"); Main();
    }

    static void tekrar(Action fonksiyon)
    {
    BASADON:
        Console.Write("Tekrar işlem yapmak ister misiniz? (e ya da h)  ");
        char tekrar_islem = Convert.ToChar(Console.ReadLine());
        if (tekrar_islem == 'e' || tekrar_islem == 'E')
        {
            Console.Clear(); fonksiyon();
        }
        else if (tekrar_islem == 'h' || tekrar_islem == 'H') sorgu();
        else Console.WriteLine("Hatalı cevap!"); goto BASADON;
    }

    static void sorgu()
    {
        BASADON:
        Console.WriteLine("------------------------------------------------");
        Console.Write("Diğer projelere bakmak ister misiniz? (e / h) ");
        char cevap = Convert.ToChar(Console.ReadLine());
        if (cevap == 'h' || cevap == 'H')
        {
            Console.WriteLine("Program 3 saniye içinde kapanacaktır.\nHoşçakalın ! ");
            Thread.Sleep(500);
            Environment.Exit(0);
        }
        else if (cevap == 'e' || cevap == 'E')
        {
            Console.WriteLine("-------------------------");
            Main();
        }
        else
        {
            Console.WriteLine("Hatalı Giriş!"); goto BASADON;
        }
    }

    static void fonk1()
    {
            Console.Write("Üçgenin taban uzunluğunu girin: ");
            double taban = Convert.ToDouble(Console.ReadLine());

            Console.Write("Üçgenin yüksekliğini girin: ");
            double yukseklik = Convert.ToDouble(Console.ReadLine());

            double alan = UcgenAlaniHesapla(taban, yukseklik);

            Console.WriteLine("Üçgenin alanı: {0}",alan);

        static double UcgenAlaniHesapla(double taban, double yukseklik)
        {
            return (taban * yukseklik) / 2;
        }
    }

    static void fonk2()
    {
            int[] sayilar = {5, 10, 3, 21, 7, 15};
            int enBuyukDeger = EnBuyukDegeriBul(sayilar);
            Console.WriteLine("Dizideki en büyük değer: {0}",enBuyukDeger);

        static int EnBuyukDegeriBul(int[] dizi)
        {
            int enBuyuk = dizi[0];
            foreach (int sayi in dizi)
            {
                if (sayi > enBuyuk) enBuyuk = sayi;                 
            }
            return enBuyuk;
        }
    }

    static void fonk3()
    {
        int toplam1 = CalculateSum(5, 10);
        Console.WriteLine("İki int sayının toplamı: {0}",toplam1);
        double toplam2 = CalculateSum(5.5, 10.2);
        Console.WriteLine("İki double sayının toplamı: {0}",toplam2);
        int toplam3 = CalculateSum(3, 7, 2);
        Console.WriteLine("Üç int sayının toplamı: {0}",toplam3);
        Console.WriteLine("İki int sayının toplamı: " + CalculateSum(5, 10));
        Console.WriteLine("İki double sayının toplamı: " + CalculateSum(5.5, 10.2));
        Console.WriteLine("Üç int sayının toplamı: " + CalculateSum(3, 7, 2));
    }

    //FONKSİYON 3'ÜN METOTLARI
    static int CalculateSum(int a, int b)
    {
        return a + b;
    }

    static double CalculateSum(double a, double b)
    {
        return a + b;
    }

    static int CalculateSum(int a, int b, int c)
    {
        return a + b + c;
    }
    //FONSİYON 3 METOTLARIN SONU


    static void fonk4()
    {
        Console.Write("Fibonacci dizisinde kaçıncı sayıyı hesaplamak istersiniz? ");
        int n = Convert.ToInt32(Console.ReadLine());
        int sonuc = Fibonacci(n);
        Console.WriteLine($"{n}. Fibonacci sayısı: {sonuc}");

        static int Fibonacci(int n)
        {
            if (n <= 1) return n;
            else return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }

    static void fonk5()
    {
        Console.WriteLine("Ortalama hesaplamak için sayıları girin. İşlemi bitirmek için 'bitir' yazın.");
        var numbers = new List<double>();
        string input;
        while (true)
        {
            Console.Write("Sayı girin: ");
            input = Console.ReadLine();
            if (input.ToLower() == "bitir") break;

            if (double.TryParse(input, out double number)) numbers.Add(number);

            else Console.WriteLine("Lütfen geçerli bir sayı girin.");
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("Hiç sayı girmediniz, ortalama hesaplanamadı.");
        }
        else
        {
            double ort = OrtHesapla(numbers.ToArray());
            Console.WriteLine("Girilen sayıların ortalaması: {0}",ort);
        }

        static double OrtHesapla(params double[] numbers)
        {
            if (numbers.Length == 0) throw new ArgumentException("En az bir sayı girmelisiniz!");

            double total = 0;

            foreach (double number in numbers) total += number;

            return total / numbers.Length;
        }
    }

    static void fonk6()
    {
        Console.Write("Dizide kaç eleman olacak? ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Dizinin {0}. elemanını girin: ",i+1);
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.Write("Filtre değeri girin: ");
        int filtre = Convert.ToInt32(Console.ReadLine());
        int toplam = SumFiltered(numbers, filtre);
        Console.WriteLine("Filtre değeri {0} olan elemanların toplamı: {1}",filtre,toplam);

        static int SumFiltered(int[] array, int filtre)
        {
            int total = 0;

            foreach (int number in array)
            {
                if (number > filtre) total += number;
            }
            return total;
        }
    }

    static void fonk7()
    {
        Console.Write("Yaşınızı girin (Varsayılan 18): ");
        string input = Console.ReadLine();
        int age;

        if (int.TryParse(input, out age))
        {
            int fark = farkHesapla(age);
            Console.WriteLine("Yaşınızın 18'den farkı: {0} yıl.",fark);
        }
        else
        {
            int fark = farkHesapla();
            Console.WriteLine("Yaşınızın 18'den farkı: {0} yıl.",fark);
        }

        static int farkHesapla(int age = 18)
        {
            return age - 18;
        }

    }

    static void fonk8()
    {
        string[] kelimeler = {"apple", "kiwi", "banana", "grape", "orange", "fig"};
        List<string> filtreliler = filtrele(kelimeler);
        Console.WriteLine("Uzunluğu 5'ten büyük olan kelimeler:");
        foreach (var kelime in filtreliler)
        {
            Console.WriteLine(kelime);
        }

        static List<string> filtrele(string[] kelimeler)
        {
            List<string> filtreliler = new List<string>();

            foreach (string kelime in kelimeler)
            {
                if (kelime.Length > 5)
                {
                    filtreliler.Add(kelime);
                }
            }

            return filtreliler;
        }
    }

}
