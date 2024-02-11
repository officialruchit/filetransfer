namespace App
{
    public class Program { 
        
    
    public static void Main(string[] args) {
            Console.WriteLine("|======================================================|");
            Console.WriteLine("  FILE TRANSFER TIME CALCULATION ");
            Console.WriteLine("  Transmission Rate:960 bytes/sec");
            Console.WriteLine("|======================================================|");

            double fileSize = ValidateFileSize();
            string fileUnit = ValidateFileUnit();
            ConvertToKB(fileSize, fileUnit);
           
            fileSize = ConvertToKB(fileSize, fileUnit);
            TimeSpan TransferIntoTime = CalculateTime(fileSize);
            DisplayResult(TransferIntoTime);
        }
        public static TimeSpan CalculateTime(double fileSize)
        {
                int transmissionRate = 960; // bytes/sec
                double fileSizeInBytes = fileSize * 1024; // Convert KB to bytes
                double transferTimeInSeconds = fileSizeInBytes / transmissionRate;
                return TimeSpan.FromSeconds(transferTimeInSeconds);
        }

        public static Double ConvertToKB(double fileSize,string fileUnit) {

            switch (fileUnit) {
                case "B":
                  return  fileSize / 1024;
                case "MB":
                    return fileSize * 1024;
                default:
                    return fileSize;  
            }
        }


    public static double ValidateFileSize() {

            while (true)
            {
                Console.Write("  enter the file size [range:0 to 2147483647]: ");
                string input=Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) {
                    Console.WriteLine("  Entered file size is invalid.");
                    continue;
                   }
                if (!double.TryParse(input, out double fileSize)) {
                    Console.WriteLine("  Entered file size is invalid.");
                    continue;
                }
                if (fileSize < 0 || fileSize > 2147483647)
                {
                    Console.WriteLine("  Entered file size is out of the predefined range.");
                    continue;
                }
                return fileSize;    
            } 
        }
        
        public static string ValidateFileUnit() {
            while (true) {
                Console.Write("  Enter the file size unit [B or KB or MB]:");
                string fileUnit=Console.ReadLine().Trim().ToUpper();
                if (string.IsNullOrEmpty(fileUnit)) {
                    Console.WriteLine("  Entered file size is invalid.");
                    continue;
                }
                if (!IsFileUnit(fileUnit))
                {
                    Console.WriteLine("  Entered file size is invalid.");
                    continue;
                }
                return fileUnit;
            }
        }
    public static bool IsFileUnit(string unit)
        {
            return unit == "B" || unit == "KB"|| unit == "MB";
        }

        static void DisplayResult(TimeSpan transferTime)
        {
            Console.WriteLine("|======================================================9===========|");
            Console.WriteLine("\tCALCULATION RESULT");
            Console.WriteLine("|=================================================================|");
            Console.WriteLine("  File transfer time calculation operation completed successfully.");
            Console.WriteLine($"  Total time required to transfer file: ");
            Console.WriteLine($"\tDays:\t\t{transferTime.Days}");
            Console.WriteLine($"\tHours:\t\t{transferTime.Hours}");
            Console.WriteLine($"\tMinutes:\t{transferTime.Minutes}");
            Console.WriteLine($"\tSeconds:\t{transferTime.Seconds}");
            Console.WriteLine($"\tMilliseconds:\t{transferTime.Milliseconds}");
            Console.WriteLine();
        }

    }

}
