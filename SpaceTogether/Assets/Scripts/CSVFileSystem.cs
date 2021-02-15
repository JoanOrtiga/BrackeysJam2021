using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CSVFileSystem
{
    public static void Init()
    {

    }

    public static void ReadCSV()
    {
        StreamReader strReader = new StreamReader("");

        bool endOfFile = false;

        while (!endOfFile)
        {
            string data_String = strReader.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }

            var data_values = data_String.Split(',');

        }
    } 
}

