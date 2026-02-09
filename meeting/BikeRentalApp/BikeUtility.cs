using System.Collections.Generic;

namespace BikeRentalApp
{
    public class BikeUtility
    {
        // add bike
        public void AddBikeDetails(string model, string brand, int pricePerDay)
        {
            int key = Program.bikeDetails.Count + 1;

            Bike bike = new Bike
            {
                Model = model,
                Brand = brand,
                PricePerDay = pricePerDay
            };

            Program.bikeDetails.Add(key, bike);
        }

        // group bike by brand
        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            SortedDictionary<string, List<Bike>> groupedBikes =
                new SortedDictionary<string, List<Bike>>();

            foreach (var item in Program.bikeDetails.Values)
            {
                if (!groupedBikes.ContainsKey(item.Brand))
                {
                    groupedBikes[item.Brand] = new List<Bike>();
                }

                groupedBikes[item.Brand].Add(item);
            }

            return groupedBikes;
        }
    }
}
