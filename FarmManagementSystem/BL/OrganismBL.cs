using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagementSystem.BL
{
    class OrganismBL
    {
        private string name;
        private int weight;
        private string species;
        private string health;
        private int price;
        private int fodder;

        public string Name { get => name; set => name = value; }
        public int Weight { get => weight; set => weight = value; }
        public string Species { get => species; set => species = value; }
        public string Health { get => health; set => health = value; }
        public int Price { get => price; set => price = value; }
        public int Fodder { get => fodder; set => fodder = value; }

        public OrganismBL()
        {

        }
        public OrganismBL(string name, int weight, string species, string health, int price)
        {
            this.name = name;
            this.weight = weight;
            this.species = species;
            this.health = health;
            this.price = price;
        }

        public OrganismBL(string name, int weight, string species, string health)
        {
            this.name = name;
            this.weight = weight;
            this.species = species;
            this.health = health;
        }

        public bool checkHealth()
        {
            if (health == "Good")
            {
                return true;
            }
            return false;
        }
    }
}
