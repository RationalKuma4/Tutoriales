using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultiPage.Data
{
    public interface ILatLongService
    {
        Task<(double Latitude, double Longitude)> GetLatLong();
    }
}
