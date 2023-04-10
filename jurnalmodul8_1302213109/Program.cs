using jurnalmodul8_1302213109;

public class Program
{
    private static void Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig();
        Console.Write("Choose Language/Pilih Bahasa " + config.config.lang + " : ");
        string bahlang = new string(Console.ReadLine());
        config.InputValidation(bahlang);
    }
}