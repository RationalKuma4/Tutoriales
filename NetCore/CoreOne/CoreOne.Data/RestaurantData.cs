using System.Collections.Generic;
using CoreOne.Core;

namespace CoreOne.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaunrant> GetAllRestaunrants();
        IEnumerable<Restaunrant> GetRestaurantsByName(string name);
        Restaunrant GteById(int id);
        Restaunrant Update(Restaunrant restaunrant);
        Restaunrant Add(Restaunrant restaunrant);
        Restaunrant Delete(int id);
        int Commit();

        int GetCount();
    }
}
