﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MrRondon.Entities;

namespace MrRondon.Services
{
    public class CityService
    {
        public async Task<IList<City>> Get(string search = "")
        {
            var service = new CityService();
            var items = await service.Get(search);

            return items;
        }
    }
}