using System;

class Program
{
    public static void Main(string[] args)
    {
        CovidConfig covidConfig = new CovidConfig();
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + covidConfig._config.satuan_suhu);
            double inputSuhu = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
            int inputHariDemam = Convert.ToInt32(Console.ReadLine());

            string satuanSuhu = covidConfig._config.satuan_suhu;

            covidConfig.isSuhuValid(satuanSuhu, inputSuhu, inputHariDemam);
            Console.WriteLine();
            covidConfig.UbahSatuan();
        }
    }
}
