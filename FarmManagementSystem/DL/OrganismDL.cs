using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmManagementSystem.BL;
using System.IO;

namespace FarmManagementSystem.DL
{
    class OrganismDL
    {
        private static string path = "inventory.txt";

        private static List<OrganismBL> org_data = new List<OrganismBL>();

        private static List<OrganismBL> org_data_increasing = new List<OrganismBL>();

        private static List<OrganismBL> org_data_decreasing = new List<OrganismBL>();

        internal static List<OrganismBL> Org_data { get => org_data; set => org_data = value; }
        internal static List<OrganismBL> Org_data_increasing { get => org_data_increasing; set => org_data_increasing = value; }
        internal static List<OrganismBL> Org_data_decreasing { get => org_data_decreasing; set => org_data_decreasing = value; }
        public static string Path { get => Path1; set => Path1 = value; }
        public static string Path1 { get => path; set => path = value; }

        public static bool readOrganismData()
        {
            if (File.Exists(Path1))
            {
                StreamReader fp = new StreamReader(Path1);
                string record;
                while ((record = fp.ReadLine()) != null)
                {
                    OrganismBL data = new OrganismBL();
                    data.Name = parseData(record, 1);
                    data.Weight = int.Parse(parseData(record, 2));
                    data.Species = parseData(record, 3);
                    data.Health = parseData(record, 4);
                    data.Price = int.Parse(parseData(record, 5));
                    org_data.Add(data);

                }
                fp.Close();
                return true;
            }
            return false;
        }

        static string parseData(string record, int field)
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

        public static void addOrganismToList(OrganismBL data)
        {
            OrganismBL t = new OrganismBL();
            t.Name = " ";
            t.Species = " ";
            t.Health = " ";
            t.Weight = 0;
            t.Price = 0;
            Org_data.Add(t);
            for (int i = 0; i < Org_data.Count; i++)
            {
                if (Org_data[i].Species != "Animal" && Org_data[i].Species != "Bird")
                {
                    OrganismBL temp = new OrganismBL();
                    temp.Name = data.Name;
                    temp.Species = data.Species;
                    temp.Health = data.Health;
                    temp.Weight = data.Weight;
                    Org_data.RemoveAt(i);
                    Org_data.Add(temp);
                    saveOrganismUpdate();
                    break;
                }
            }
        }

        public static bool chkName(OrganismBL organism)
        {
            foreach (var storedOrganism in org_data)
            {
                if (storedOrganism.Name == organism.Name)
                {
                        return false;
                }
            }
            return true;
        }

        public static void saveOrganismUpdate()
        {
            int temp = 0;
            StreamWriter file = new StreamWriter(Path1, false);

            for (int i = 0; i < org_data.Count; i++)
            {
                    file.Write(org_data[i].Name + "," + org_data[i].Weight + "," + org_data[i].Species + "," + org_data[i].Health + ",");

                    if (org_data[i].Price > 0)
                    {
                        file.WriteLine(org_data[i].Price);
                    }
                    else
                    {

                        file.WriteLine(temp);
                    }
            }
            file.Flush();
            file.Close();
        }
        public static int chkName(string name)
        {
            for (int i = 0; i < org_data.Count; i++)
            {
                if (name == org_data[i].Name)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void sortingIncreasing()
        {
            org_data_increasing = org_data.OrderBy(o => o.Weight).ToList();
        }

        public static void sortingDecreasing()
        {
            org_data_decreasing = org_data.OrderByDescending(o => o.Weight).ToList();
        }
    }
}