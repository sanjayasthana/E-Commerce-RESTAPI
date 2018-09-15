using ECom.DAL;
using System;

namespace ECom.BAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private EComModel context = new EComModel();
        public IRepository<Product> proudctRepositry { get; private set; }

        public IRepository<ProductCategory> proudctCategoryRepositry { get; private set; }

        public IRepository<ProductAttribute> proudctAttributeRepositry { get; private set; }
        public IRepository<ProductAttributeLookup> proudctAttributeLookupRepositry { get; private set; }
        public UnitOfWork()
        {
            proudctRepositry = new GenericRepository<Product>(context);
            proudctCategoryRepositry = new GenericRepository<ProductCategory>(context);
            proudctAttributeRepositry = new GenericRepository<ProductAttribute>(context);
            proudctAttributeLookupRepositry = new GenericRepository<ProductAttributeLookup>(context);
        }

        public int Save()
        {
           return context.SaveChanges();
        }

        private bool disposed = false;

        

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
