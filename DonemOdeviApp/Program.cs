namespace DonemOdeviApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ogrenci = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Kaç öğrenci kaydetmek istersiniz?");
                    ogrenci = int.Parse(Console.ReadLine());
                    if (ogrenci <= 0)
                    {
                        Console.WriteLine("Lütfen pozitif bir sayı giriniz.");
                        continue;
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hata: Lütfen bir sayı giriniz.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bir hata ile karşılaşıldı.");
                }

            }
            string[,] tablo = new string[ogrenci + 1, 7];

            double toport = 0;

            double[] vizeNotları = new double[ogrenci];
            double[] finalNotları = new double[ogrenci];

            for (int i = 0; i < ogrenci; i++)
            {
                Console.WriteLine($"Öğrenci {i + 1} bilgilerini giriniz:");

                while (true)
                {
                    try
                    {
                        Console.Write("Numara: ");
                        string no = Console.ReadLine();
                        long no1 = long.Parse(no);
                        if (no1 <= 10000000000 || no1 >= 99999999999)
                        {
                            Console.WriteLine("Hata: Lütfen 11 haneli bir numara giriniz.");
                            continue;
                        }
                        tablo[i, 0] = no;
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hata: Lütfen sayı giriniz.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Bir hata ile karşılaşıldı.");
                    }

                }

                while (true)
                {
                    try
                    {
                        Console.Write("Ad: ");
                        string ad = (Console.ReadLine());
                        tablo[i, 1] = ad;
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hata: Lütfen sadece harf ile giriniz.");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Bir hata ile karşılaşıldı.");
                    }


                }
                while (true)
                {
                    try
                    {
                        Console.Write("Soyad: ");
                        string soyad = Console.ReadLine();
                        tablo[i, 2] = soyad;
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hata: Lütfen harf ile giriniz.");
                        continue;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Bir hata ile karşılaşıldı.");
                    }
                }

                double vize = 0;

                while (true)
                {
                    try
                    {
                        Console.Write("Vize Notu: ");
                        vize = double.Parse(Console.ReadLine());
                        tablo[i, 3] = vize.ToString();
                        vizeNotları[i] = vize;
                        if (vize >= 0 && vize <= 100)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hata: 0-100 arasında bir değer giriniz.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hata: Lütfen sayı giriniz.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Bilinmeyen bir hata ile karşılaşıldı.");
                        continue;
                    }
                }

                double final = 0;

                while (true)
                {
                    try
                    {
                        Console.Write("Final Notu: ");
                        final = double.Parse(Console.ReadLine());
                        tablo[i, 4] = final.ToString();
                        finalNotları[i] = final;
                        if (final >= 0 && final <= 100)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hata: 0-100 arasında bir değer giriniz.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hata: Lütfen sayı giriniz.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Bilinmeyen bir hata ile karşılaşıldı.");
                    }
                }

                double ortalama = (vize * 0.4) + (final * 0.6);
                tablo[i, 5] = ortalama.ToString("0.00");
                toport += ortalama;

                if (ortalama >= 85) tablo[i, 6] = "AA";
                else if (ortalama >= 75) tablo[i, 6] = "BA";
                else if (ortalama >= 60) tablo[i, 6] = "BB";
                else if (ortalama >= 50) tablo[i, 6] = "CB";
                else if (ortalama >= 40) tablo[i, 6] = "CC";
                else if (ortalama >= 30) tablo[i, 6] = "DC";
                else if (ortalama >= 20) tablo[i, 6] = "DD";
                else if (ortalama >= 10) tablo[i, 6] = "FD";
                else if (ortalama >= 0) tablo[i, 6] = "FF";
            }
            Console.WriteLine("\nÖğrenci Bilgileri:");
            Console.WriteLine("\tNumara\t\tAd\t\tSoyad\t\tVize Notu\tFinal Notu\tOrtalama\tHarf Notu");

            for (int i = 0; i < ogrenci; i++)
            {
                Console.WriteLine($"{i + 1}\t{tablo[i, 0]}\t{tablo[i, 1]}\t\t{tablo[i, 2]}\t\t{tablo[i, 3]}\t\t{tablo[i, 4]}\t\t{tablo[i, 5]}\t\t{tablo[i, 6]}");
            }

            //double sınıfort = toport / ogrencı;
            Console.WriteLine($"\nSınıf Ortalaması: {toport / ogrenci}");

            double enYuksekVize = vizeNotları[0];
            double enDüşükVize = vizeNotları[0];
            double enYüksekFinal = finalNotları[0];
            double enDüşükFinal = finalNotları[0];

            for (int i = 1; i < ogrenci; i++)
            {
                if (vizeNotları[i] > enYuksekVize) enYuksekVize = vizeNotları[i];
                if (vizeNotları[i] < enDüşükVize) enDüşükVize = vizeNotları[i];

                if (finalNotları[i] > enYüksekFinal) enYüksekFinal = finalNotları[i];
                if (finalNotları[i] < enDüşükFinal) enDüşükFinal = finalNotları[i];
            }

            Console.WriteLine($"En Yüksek Vize Notu: {enYuksekVize}");
            Console.WriteLine($"En Düşük Vize Notu: {enDüşükVize}");
            Console.WriteLine($"En Yüksek Final Notu: {enYüksekFinal}");
            Console.WriteLine($"En Düşük Final Notu: {enDüşükFinal}");
        }
    }
}
