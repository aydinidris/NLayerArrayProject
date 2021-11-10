using System;
using System.Collections.Generic;

namespace NLayerArrayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLength;
            Console.WriteLine("Dizi boyutunu giriniz: ");
            arrayLength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int[] array = new int[arrayLength];

            
            List<int> repeatCount = new List<int>();
            List<int> repeatNumbers = new List<int>();

            int deger = 0;
            int countGecici;
            int gecici;
            int lastCount;
            int response = 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();
            int index = 0;

            foreach (var item in array)
            {
            label:

                Console.Write($"{index + 1}. değeri giriniz: ");
                deger = Convert.ToInt32(Console.ReadLine());

                if (deger <= 0 || deger > 5)
                {
                    Console.WriteLine("Hatalı sayı");
                    deger = 0;
                    goto label;
                }

                array[index] = deger;
                index++;
            }

            if ( array.Length > 1)
            {
                foreach (var item in array)
                {
                    if (dict.ContainsKey(item))
                        dict[item]++;
                    else
                        dict.Add(item, 1);
                }

                foreach (var item in dict)
                {
                    if (item.Value >= 2)
                    {
                        repeatCount.Add(item.Value);
                    }
                }


                // Tekrar Etme Sayılarının Sıralanması

                if ( repeatCount.Count > 0 )
                {
                    for (int i = 0; i <= repeatCount.Count - 1; i++)
                    {
                        for (int j = 1; j <= repeatCount.Count - 1; j++)
                        {
                            if (repeatCount[j - 1] > repeatCount[j])
                            {
                                countGecici = repeatCount[j - 1];
                                repeatCount[j - 1] = repeatCount[j];
                                repeatCount[j] = countGecici;
                            }
                        }
                    }

                    lastCount = repeatCount[repeatCount.Count - 1];

                    foreach (var item in dict)
                    {
                        if (item.Value == lastCount)
                        {
                            repeatNumbers.Add(item.Key);
                        }
                    }


                    if (repeatNumbers.Count == 1)
                    {
                        response = repeatNumbers[0];
                    }

                    // Tekrar Eden elemanların değerinin sıralanması

                    else if (repeatNumbers.Count > 1)
                    {
                        for (int i = 0; i <= repeatNumbers.Count - 1; i++)
                        {
                            for (int j = 1; j <= repeatNumbers.Count - 1; j++)
                            {
                                if (repeatNumbers[j - 1] > repeatNumbers[j])
                                {
                                    gecici = repeatNumbers[j - 1];
                                    repeatNumbers[j - 1] = repeatNumbers[j];
                                    repeatNumbers[j] = gecici;
                                }
                            }
                        }

                        response = repeatNumbers[0];
                    }
                }

                else
                {
                    Console.WriteLine("Tekrar eden eleman bulunamadı");
                }

                string numbers = "";
                foreach (var item in array)
                {
                    numbers += item.ToString();
                }
                Console.WriteLine("Girilen Sayılar: " + numbers);
                Console.WriteLine($"{response}");
            }



            
        }
    }
}
