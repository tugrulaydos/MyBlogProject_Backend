﻿using Infrastructure.DataAccess.Abstract;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IGenericRepository<Category>
    {
    }
}
