using DataAccsessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tekno_Yazılım.ViewComponents.Writer
{
    internal class EFWriteDal : IWriterDal
    {
        public void Delete(EntityLayer.Concrete.Writer t)
        {
            throw new NotImplementedException();
        }

        public EntityLayer.Concrete.Writer GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<EntityLayer.Concrete.Writer> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<EntityLayer.Concrete.Writer> GetListAll(Expression<Func<EntityLayer.Concrete.Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(EntityLayer.Concrete.Writer t)
        {
            throw new NotImplementedException();
        }

        public void Update(EntityLayer.Concrete.Writer t)
        {
            throw new NotImplementedException();
        }
    }
}