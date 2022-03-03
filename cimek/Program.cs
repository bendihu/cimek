namespace cimek;

public class Program
{
    static List<string> lista = new List<string>();
    static string[] ip2 = new string[8];
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //1. feladat
        Beolvas();

        //2. feladat
        Feladat2();

        //3. feladat
        Feladat3();

        //4. feladat
        Feladat4();

        //5. feladat
        Feladat5();

        //6. feladat
        Feladat6();

        //7. feladat
        Feladat7();

        Console.ReadKey();
    }
    private static void Beolvas()
    {
        string[] adatok = File.ReadAllLines(@"ip.txt");
        lista.AddRange(adatok);
    }
    private static void Feladat2()
    {
        Console.WriteLine("2. feladat");
        Console.WriteLine($"Az állományban {lista.Count} adatsor van.");
        Console.WriteLine();
    }
    private static void Feladat3()
    {
        Console.WriteLine("3. feladat");
        Console.WriteLine("A legalacsonyabb tárolt IP-cím: ");

        string min = lista[0];

        for (int i = 0; i < lista.Count; i++)
        {
            if (String.Compare(min, lista[i]) > 0) min = lista[i];
        }

        Console.WriteLine(min);
        Console.WriteLine();
    }
    private static void Feladat4()
    {
        Console.WriteLine("4. feladat");

        int doc = 0, glob = 0, loc = 0;

        foreach (var item in lista)
        {
            if (item.StartsWith("2001:0db8")) doc++;
            else if(item.StartsWith("2001:0e")) glob++;
            else if (item.StartsWith("fc") || item.StartsWith("fd")) loc++;
        }

        Console.WriteLine($"Dokumentációs cím: {doc} darab");
        Console.WriteLine($"Globális egyedi cím: {glob} darab");
        Console.WriteLine($"Helyi egyedi cím: {loc} darab ");
        Console.WriteLine();
    }
    private static void Feladat5()
    {
        StreamWriter sw = new StreamWriter(@"sok.txt");
        int count = 0;

        foreach (var item in lista)
        {
            char[] line = item.ToCharArray();
            int nullak = 0;
            count++;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '0') nullak++;
            }

            if (nullak >= 18)
            {
                sw.WriteLine($"{count} {item}");
            }
        }

        sw.Close();
    }
    private static void Feladat6()
    {
        Console.WriteLine("6. feladat");

        Console.Write("Kérek egy sorszámot: ");
        int bSzam = int.Parse(Console.ReadLine()) - 1;

        string eredeti = lista[bSzam];
        string[] ip = lista[bSzam].Split(':');
        int count = 0;
        bool rovid = false;

        foreach (var item in ip)
        {
            string resz = item;

            if (item.StartsWith("0"))
            { 
                int i = 0;
                rovid = true;

                while (resz.StartsWith("0") && i < 3)
                {
                    resz = resz.Remove(0, 1);
                    i++;
                }
            }

            ip2[count] = resz;
            count++;
        }

        Console.WriteLine(eredeti);
        if (rovid) Console.WriteLine(String.Join(":", ip2));
        else Console.WriteLine("Nem rövidíthető tovább.");
        Console.WriteLine();  
    }
    private static void Feladat7()
    {
        Console.WriteLine("7. feladat");

        string[] minIp = new string[ip2.Length];
        int count = 0;
        bool rovid = false;

        foreach (var item in ip2)
        {
            string resz = item;

            if (resz == "0")
            {
                resz = resz.Remove(0, 1);
                rovid = true;
            }

            minIp[count] = resz;
            count++;
        }

        for (int i = 0; i < minIp.Length - 1; i++)
        {
            if (minIp[i] == "" && minIp[i + 1] != "") minIp[i] = null;
        }

        if (rovid) Console.WriteLine(String.Join(":", minIp.Where(x => x != "")));
        else Console.WriteLine("Nem rövidíthető tovább.");
    }
}