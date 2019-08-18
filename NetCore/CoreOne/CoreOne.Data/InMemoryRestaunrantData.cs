using System.Collections.Generic;
using System.Linq;
using CoreOne.Core;

namespace CoreOne.Data
{
    public class InMemoryRestaunrantData : IRestaurantData
    {
        private List<Restaunrant> restaunrants;
        public InMemoryRestaunrantData()
        {
            restaunrants = new List<Restaunrant>
            {
                new Restaunrant{Id = 1,Name = "lol",Cuisine = CuisineType.Italian,Location = "hola"},
                new Restaunrant{Id = 2,Name = "lol",Cuisine = CuisineType.Mexican,Location = "hola"},
                new Restaunrant{Id = 3,Name = "lol",Cuisine = CuisineType.None,Location = "hola"},
            };
        }

        public IEnumerable<Restaunrant> GetAllRestaunrants()
        {
            return from r in restaunrants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restaunrant> GetRestaurantsByName(string name = null)
        {
            return from r in restaunrants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaunrant GteById(int id)
        {
            return restaunrants.SingleOrDefault(r => r.Id == id);
        }

        public Restaunrant Update(Restaunrant restaunrantUpdate)
        {
            var restaurant = restaunrants
                .SingleOrDefault(r => r.Id == restaunrantUpdate.Id);
            if (restaurant != null)
            {
                restaurant.Name = restaunrantUpdate.Name;
                restaurant.Cuisine = restaunrantUpdate.Cuisine;
                restaurant.Location = restaunrantUpdate.Location;
            }
            return restaurant;
        }

        public Restaunrant Add(Restaunrant restaunrant)
        {
            restaunrant.Id = restaunrants.Max(r => r.Id) + 1;
            restaunrants.Add(restaunrant);
            restaunrant.Id = restaunrants.Max(r => r.Id) + 1;
            return restaunrant;
        }

        public Restaunrant Delete(int id)
        {
            var restaurant = restaunrants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaunrants.Remove(restaurant);
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public int GetCount()
        {
            return restaunrants.Count();
        }
    }
}