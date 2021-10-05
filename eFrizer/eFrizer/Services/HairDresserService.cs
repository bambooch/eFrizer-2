﻿using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairDresserService : BaseCRUDService<Model.HairDresser, Database.HairDresser, HairDresserSearchRequest, HairDresserInsertRequest, HairDresserUpdateRequest>, IHairDresserService
    {
        public HairDresserService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }


        public async override Task<List<Model.HairDresser>> Get(HairDresserSearchRequest search = null)
        {
            var entity = Context.Set<Database.HairDresser>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                entity = entity.Where(x => x.Name.Contains(search.Name));
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<Model.HairDresser>>(list);
        }
    }
}
