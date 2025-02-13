﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IReadService<T, TSearch> where T : class where TSearch : class
    {
        public Task<List<T>> Get(TSearch search = null);
        public Task<T> GetById(int id);
    }
    
}
