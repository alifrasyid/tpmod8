using System;
using System.IO;
using System.Text.Json;

public class Config
{
    public string satuan_suhu { get; set; }
    public int batas_hari_demam { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    public Config() { }

    public Config(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
    {
        this.satuan_suhu = satuan_suhu;
        this.batas_hari_demam = batas_hari_demam;
        this.pesan_ditolak = pesan_ditolak;
        this.pesan_diterima = pesan_diterima;
    }
}

public class CovidConfig
{
    public const string FilePath = @"covid_config.json";
    public Config _config;

    public CovidConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch (Exception)
        {
            SetDefault();
            WriteConfigFile();
        }
    }

    public Config ReadConfigFile()
    {
        string configJsonData = File.ReadAllText(FilePath);
        _config = JsonSerializer.Deserialize<Config>(configJsonData);
        return _config;
    }

    public void SetDefault()
    {
        _config = new Config("celcius", 14, "Anda tidak diperbolehkan masuk ke dalam gedung ini", "Anda dipersilahkan untuk masuk ke dalam gedung ini");
    }

    public void WriteConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(_config, options);
        File.WriteAllText(FilePath, jsonString);
    }

    public void UbahSatuan()
    {
        if (_config.satuan_suhu == "celcius")
        {
            _config.satuan_suhu = "fahrenheit";
        }
        else if (_config.satuan_suhu == "fahrenheit")
        {
            _config.satuan_suhu = "celcius";
        }
    }

    public void isSuhuValid(string satuanSuhu, double inputSuhu, int inputHariDemam)
    {
        if (satuanSuhu == "celcius")
        {
            if (36.5 <= inputSuhu && inputSuhu <= 37.5 && inputHariDemam < _config.batas_hari_demam)
            {
                Console.WriteLine(_config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(_config.pesan_ditolak);

            }
        }
        else if (satuanSuhu == "fahrenheit")
        {
            if (97.7 <= inputSuhu && inputSuhu <= 99.5 && inputHariDemam < _config.batas_hari_demam)
            {
                Console.WriteLine(_config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(_config.pesan_ditolak);
            }
        }
    }
}

