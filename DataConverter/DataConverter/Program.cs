using DataConverter;
using System;

class Progam
{
    public static void Main(string[] args)
    {
        string test = "FRMRSD2DT";
        Console.WriteLine(translator(test));
        //listWriter(false);
    }

    public static string translator(string internalFacilityCode)
    {
        string country, terminal, head="", tail="";
        country = internalFacilityCode[0..5];
        terminal = internalFacilityCode[5..];
        CountryDetails countryDetails = new CountryDetails();
        string[] terminalList = {"2. tersane limanı"},
                 terminalCodeList = { "D2DT" };
       
        
        if (countryDetails.countryCode.Contains(country))
            head = countryDetails.countryName[Array.IndexOf(countryDetails.countryCode, country)];
        else if (countryDetails.unCountryCode.Contains(country[0..2]))
            head = countryDetails.unCountryName[Array.IndexOf(countryDetails.unCountryCode, country[0..2])];
        else return "404 Country Code Not Found!";
        if (terminalCodeList.Contains(terminal))
            tail = terminalList[Array.IndexOf(terminalCodeList, terminal)];
        else return "404 Terminal Code Not Found!";
        return head+" "+tail;
    }

    //Raw Data işlemek için, outputla ilgisi yok.
    public static void listWriter()
    {
        // Store the path of the textfile in your system
        string file = @"F:\documents\movetech\loc231txt\2023-1 SubdivisionCodes.txt";
        LinkedList<string> country = new LinkedList<string>();
        LinkedList<string> countryDetail = new LinkedList<string>();

        // To read a text file line by line
        if (File.Exists(file))
        {
            // Store each line in array of strings
            string[] lines = File.ReadAllLines(file);

            foreach (string ln in lines)
            {
                country.AddLast(ln[0..6]);
               
                countryDetail.AddLast(ln[7..]);   
            }
                
        }
        string file1 = @"F:\documents\movetech\unLOCODES.txt";
        string cString1 = string.Join("\",\"", country.ToArray());
 
        string cString3 = string.Join("\",\"", countryDetail.ToArray());
        File.WriteAllText(file1, "{\"" + cString1.Replace(" ", "") + "\"}" + "\n" + "{\"" + cString3.Replace(" ","") + "\"}" + "\n");

    }
    //override, farklı formatta data işlemek için.
    public static void listWriter(bool a)
    {
        // Store the path of the textfile in your system
        string file = @"F:\documents\movetech\unLocode.txt";
        LinkedList<string> country = new LinkedList<string>();
        LinkedList<string> countryDetail = new LinkedList<string>();

        // To read a text file line by line
        if (File.Exists(file))
        {
            // Store each line in array of strings
            string[] lines = File.ReadAllLines(file);

            foreach (string ln in lines)
            {
                country.AddLast(ln[0..2]);

                countryDetail.AddLast(ln[3..]);
            }

        }
        string file1 = @"F:\documents\movetech\unCountryCodes.txt";
        string cString1 = string.Join("\",\"", country.ToArray());

        string cString3 = string.Join("\",\"", countryDetail.ToArray());
        File.WriteAllText(file1, "{\"" + cString1 + "\"}" + "\n" + "{\"" + cString3 + "\"}" + "\n");

    }
}