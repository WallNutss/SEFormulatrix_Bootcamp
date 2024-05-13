namespace Enum;

public enum Months{ // Lets try to create an enumaration of month of kabisat year
    Jan,
    Feb,
    Mar,
    Apr,
    May,
    Jun,
    Jul,
    Aug,
    Sep,
    Oct,
    Nov,
    Des
}

class Program{
    static void Main(){
        ProcessMonthlyExpenditureData(Months.Feb) // Should output the case no.2
    }

    public static void ProcessMonthlyExpenditureData(Months month){ // Meaning the arguments is must have structure to the enum months type
        switch(month){
            case Months.Jan: // Accsessing directly to the enum
                Console.WriteLine("Processing data for Jan....");
                break;
            case Months.Feb: // Accsessing directly to the enum
                Console.WriteLine("Processing data for Feb....");
                break;
            case Months.Mar: // Accsessing directly to the enum
                Console.WriteLine("Processing data for Mar....");
                break;
            default:
                throw new Exception("Invalid, out of the months topic!");
        }
    }
}
