using ECom.DAL;
using System;

namespace ECom.BAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> proudctRepositry { get;}
        IRepository<ProductCategory> proudctCategoryRepositry { get; }
        IRepository<ProductAttribute> proudctAttributeRepositry { get; }
        IRepository<ProductAttributeLookup> proudctAttributeLookupRepositry { get; }
        int Save();
    }
}
