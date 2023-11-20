using Microsoft.VisualBasic.FileIO;
using System;
using System.Net;

DownloadCsv();
CsvToInsertScript();
Console.WriteLine("Finished");

void DownloadCsv()
{
    using (var client = new WebClient())
    {
        client.DownloadFile("https://latmare.lhei.lv/api/data/contaminants", @"C:\temp\contaminants.csv");
    }
}

void CsvToInsertScript()
{

    using (TextFieldParser parser = new TextFieldParser(@"Csv/contaminants.csv"))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        while (!parser.EndOfData)
        {
            string instertLine = "INSERT INTO public.contaminatns(trip, longitude, latitude, datetime, station, bottdepthm, sampleid, parameter, tissue, species, individuals, value, units, quality)";
            // reads all fields in a line and returns them as a string separated by ";"
            string[] rows = parser.ReadFields();
            if (rows != null)
            {
                bool append = true;
                using (StreamWriter outputFile = new StreamWriter(@"C:\temp\insert_data.sql", append))
                {
                    foreach (string row in rows)
                    {
                        string[] fieldArray = row.Split(";");
                        for (int i = 0; i < fieldArray.Length; i++)
                        {
                            fieldArray[i] = "'" + fieldArray[i] + "'";
                        }
                        string fields = string.Join(", ", fieldArray);
                        outputFile.WriteLine(instertLine);
                        string valuesLine = "VALUES (" + fields + ");";
                        outputFile.WriteLine(valuesLine);
                        outputFile.WriteLine();
                    }
                }
            }
        }
    }
}