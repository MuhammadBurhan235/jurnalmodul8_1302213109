using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace jurnalmodul8_1302213109
{
    public class Config
    {
        public string lang { get; set; }
        public class transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set;}
        }
        public string[] methods { get; set; }
        public class confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        }

        public Config() { }

        public Config(string lang, int threshold, int low_fee, int high_fee, string[] methods, string en, string id)
        {
            this.lang = lang;

            transfer tf = new transfer();
            tf.threshold = threshold;
            tf.low_fee = low_fee;
            tf.high_fee = high_fee;

            this.methods = methods;

            confirmation cm = new confirmation();
            cm.en = en;
            cm.id = id;
        }
    }

    public class BankTransferConfig
    {
        public Config config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configFileName = "public_class_Config";

        private Config ReadConfig()
        {
            string jsonFromFile = File.ReadAllText(path + '/' + configFileName);
            config = JsonSerializer.Deserialize<Config>(jsonFromFile);
            return config;
        }

        public void SetDefault()
        {
            config = new Config("en", 25000000, 6500, 15000, "RTO", "yes", "en");
        }

        private void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config, options);
            string fullPath = path + '/' + configFileName;
            File.WriteAllText(fullPath, jsonString);
        }

        public BankTransferConfig()
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                SetDefault();
                WriteConfig();
            }
        }

        public void whatapa()
        {
            config.lang = config.lang == "en" ? "id" : "en";
        }

        public string InputValidation(string lang)
        {
            if (config.lang == "en")
            {
                return "Please insert the amount of money to transfer";
            }
            else if (config.lang == "id")
            {
                return "Masukkan jumlah uang yang ingin ditransfer";
            }
            return "Not Provided this Language/ Tidak Terlayani Bahasa ini";
        }
    }
}
