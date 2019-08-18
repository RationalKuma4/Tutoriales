using System.Collections.Generic;
using System.Linq;
using CoreOne.Core;
using Microsoft.EntityFrameworkCore;

namespace CoreOne.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Restaunrant> GetAllRestaunrants()
        {
            var query = from r in _db.Restaunrants
                        orderby r.Id
                        select r;
            return query;
        }

        public IEnumerable<Restaunrant> GetRestaurantsByName(string name)
        {
            var query = from r in _db.Restaunrants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaunrant GteById(int id)
        {
            return _db.Restaunrants.Find(id);
        }

        public Restaunrant Update(Restaunrant restaunrant)
        {
            var entity = _db.Restaunrants.Attach(restaunrant);
            entity.State = EntityState.Modified;
            return restaunrant;
        }

        public Restaunrant Add(Restaunrant restaunrant)
        {
            _db.Add(restaunrant);
            return restaunrant;
        }

        public Restaunrant Delete(int id)
        {
            var restaurant = GteById(id);

            if (restaurant != null)
            {
                _db.Remove(restaurant);
            }

            return restaurant;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public int GetCount()
        {
            return _db.Restaunrants.Count();
        }
    }
}