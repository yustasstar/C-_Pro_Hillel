namespace HW_4._Operator_overload
{
    public class City
    {
        private string _name;
        private int _population;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Population
        {
            get { return _population; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Population cannot be negative");
                _population = value;
            }
        }

        public City(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public static City operator +(City city, int amount)
        {
            city.Population += amount;
            return city;
        }
        public static City operator -(City city, int amount)
        {
            city.Population -= amount;
            return city;
        }
        public static bool operator ==(City city1, City city2) => city1.Population == city2.Population;
        public static bool operator !=(City city1, City city2) => !(city1 == city2);
        public static bool operator >(City city1, City city2) => city1.Population > city2.Population;
        public static bool operator <(City city1, City city2) => city1.Population < city2.Population;
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is City))
                return false;

            City other = (City)obj;
            return this.Population == other.Population;
        }
        public override int GetHashCode() => HashCode.Combine(Name, Population);
        public void PrintCityInfo() => Console.WriteLine($"{Name} - Population: {Population}");

    }
}
