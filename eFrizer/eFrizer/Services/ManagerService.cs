﻿using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class ManagerService : BaseCRUDService<Model.Manager, Database.Manager, object, ManagerInsertRequest, ManagerUpdateRequest>, IManagerService
    {
        public ManagerService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }
        
        public override async Task<Model.Manager> Update(int id, ManagerUpdateRequest request)
        {
            var entity = Context.Managers.Find(id);
            _mapper.Map(request, entity);

            await Context.SaveChangesAsync();
            return _mapper.Map<Model.Manager>(entity);
        }

    }
}
