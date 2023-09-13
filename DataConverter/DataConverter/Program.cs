using System;
using System.Collections.Generic;
class Progam
{
    public static void Main(string[] args)
    {
        string test = "FRMRSD2DT";
        Console.WriteLine(locationGiver(test, @"F:\documents\movetech\code-List.txt"));
        //listWriter();
    }

    //process the raw data and turn it into an uderstandable output.
   
    //takes facility code and location of text file containing the location data
    public static string locationGiver(string internalFacilityCode, string file)
    {
        // Store the path of the textfile in your system
        
        List<string> country = new List<string>();
        List<string> countryDetail = new List<string>();

        // To read a text file line by line
        if (File.Exists(file))
        {
            // Store each line in array of strings
            string[] lines = File.ReadAllLines(file);

            foreach (string ln in lines)
            {
                List<string> tmp = new List<string>();
                tmp = ln.Split(',').ToList<string>();
                string temp = tmp[1]+tmp[2];

                country.Add(temp);

                countryDetail.Add(tmp[3]);
            }

        }
        string Country, terminal, head = "", tail = "";
        Country = internalFacilityCode[0..5];
        terminal = internalFacilityCode[5..];
        string[] terminalList = { "2. tersane limanı" },
                 terminalCodeList = { "D2DT" };

        if (country.Contains(Country))
            head = countryDetail[country.IndexOf( Country)];
        else return "404 Country Code Not Found!";
        if (terminalCodeList.Contains(terminal))
            tail = terminalList[Array.IndexOf(terminalCodeList, terminal)];
        else return "404 Terminal Code Not Found!";
        return head + " " + tail;
    }

}
