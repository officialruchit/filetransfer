using System;

class Program
{
    static string CalculateTransferTime(string fileSizeStr, string unit)
    {
        if (!double.TryParse(fileSizeStr, out double fileSize))
            return "Error: Entered file size is not a valid number.";

        if (fileSize < 10 || fileSize > 2147483647)
            return "Error: Entered file size is invalid or out of range (10 to 2147483647).";

        double transmissionRate = 960; // bytes/second

        double fileSizeBytes;
        switch (unit.ToUpper())
        {
            case "B":
                fileSizeBytes = fileSize;
                break;
            case "KB":
                fileSizeBytes = fileSize * 1024;
                break;
            case "MB":
                fileSizeBytes = fileSize * 1024 * 1024;
                break;
            default:
                return "Error: Entered file size unit is invalid.";
        }

        double transferTimeSeconds = fileSizeBytes / transmissionRate;

        int milliseconds = (int)(transferTimeSeconds * 1000);
        int days = milliseconds / (1000 * 60 * 60 * 24);
        milliseconds %= (1000 * 60 * 60 * 24);
        int hours = milliseconds / (1000 * 60 * 60);
        milliseconds %= (1000 * 60 * 60);
        int minutes = milliseconds / (1000 * 60);
        milliseconds %= (1000 * 60);
        int seconds = milliseconds / 1000;
        milliseconds %= 1000;

        return $"Transfer time: {days} days, {hours} hours, {minutes} minutes, {seconds} seconds, {milliseconds} milliseconds";
    }

    static void Main(string[] args)
    {
        Console.Write("Enter file size: ");
        string fileSize = Console.ReadLine().Trim();

        Console.Write("Enter file size unit (B/KB/MB): ");
        string fileUnit = Console.ReadLine().Trim().ToUpper();

        if (string.IsNullOrWhiteSpace(fileSize))
        {
            Console.WriteLine("Error: Entered file size is empty.");
            return;
        }

        if (string.IsNullOrWhiteSpace(fileUnit))
        {
            Console.WriteLine("Error: Entered file size unit is empty.");
            return;
        }

        Console.WriteLine(CalculateTransferTime(fileSize, fileUnit));
    }
}
