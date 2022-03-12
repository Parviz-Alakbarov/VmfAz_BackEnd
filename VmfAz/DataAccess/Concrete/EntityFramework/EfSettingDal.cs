﻿using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSettingDal : ISettingDal
    {
        public List<Setting> GetAll()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                return context.Settings.ToList();
            }
        }

        public Setting GetByKey(string key)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from s in context.Settings
                             where s.Key == key
                             select new Setting
                             {
                                 Id = s.Id,
                                 Key = s.Key,
                                 Value = s.Value
                             };
                return result.SingleOrDefault();
            }
        }

        public void Update(Setting setting)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var updateEntity = context.Entry(setting);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
