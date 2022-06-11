using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmManagementSystem.BL;
using System.IO;

namespace FarmManagementSystem.DL
{
    class FarmDataDL
    {
        private static string path = "farmdata.txt";

        private static FarmDataBL data = new FarmDataBL();

        public static string Path { get => path; set => path = value; }
        internal static FarmDataBL Data { get => data; set => data = value; }

        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }

        public static bool readDataFromFile()
        {
            if (File.Exists(Path))
            {
                StreamReader fileVariable = new StreamReader(Path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    int eggs = int.Parse(parseData(record, 1));
                    int eggs_price = int.Parse(parseData(record, 2));
                    int milk = int.Parse(parseData(record, 3));
                    int milk_price = int.Parse(parseData(record, 4));
                    int farm_worth = int.Parse(parseData(record, 5));
                    data.Eggs = eggs;
                    data.Eggs_price = eggs_price;
                    data.Milk = milk;
                    data.Milk_price = milk_price;
                    data.Farm_sales = farm_worth;
                }
                fileVariable.Close();
                return true;
            }
            else
                return false;
        }

        public static void storeFarmDataIntoFile()
        {
            StreamWriter file = new StreamWriter(Path, false);
            file.WriteLine(data.Eggs + "," + data.Eggs_price + "," + data.Milk + "," + data.Milk_price + "," + data.Farm_sales);
            file.Flush();
            file.Close();
        }

    }
}
