﻿using Animal_Status;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class VaccinationRepository : BaseRepository<Vaccination>
    {
        public VaccinationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
