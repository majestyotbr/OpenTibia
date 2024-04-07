﻿using Microsoft.EntityFrameworkCore;
using OpenTibia.Data.Contexts;
using OpenTibia.Data.Models;
using System.Linq;

namespace OpenTibia.Data.Repositories
{
    public class HouseRepository
    {
        private DatabaseContext context;

        public HouseRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public DbHouse[] GetHouses()
        {
            DbHouse[] houses = context.Houses
                .Include(h => h.Owner)
                .ToArray();

            if (houses.Length > 0)
            {
                context.HouseAccessLists
                    .Load();
            }

            return houses;
        }
    }
}