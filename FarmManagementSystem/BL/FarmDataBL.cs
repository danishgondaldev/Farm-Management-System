using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagementSystem.BL
{
    class FarmDataBL
    {
        private int fodder_animals;
        private int fodder_birds;
        private int fodder_counter;
        private int eggs;
        private int eggs_price;
        private int milk;
        private int milk_price;
        private int farm_sales;
        public FarmDataBL()
        {
            fodder_animals = 0;
            fodder_birds = 0;
            fodder_counter = 0;
            eggs = 0;
            eggs_price = 0;
            milk = 0;
            milk_price = 0;
            Farm_sales = 0;
        }

        public int Fodder_animals { get => fodder_animals; set => fodder_animals = value; }
        public int Fodder_birds { get => fodder_birds; set => fodder_birds = value; }
        public int Fodder_counter { get => fodder_counter; set => fodder_counter = value; }
        public int Eggs { get => eggs; set => eggs = value; }
        public int Eggs_price { get => eggs_price; set => eggs_price = value; }
        public int Milk { get => milk; set => milk = value; }
        public int Milk_price { get => milk_price; set => milk_price = value; }
        public int Farm_sales { get => farm_sales; set => farm_sales = value; }
    }
}
