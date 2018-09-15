using ECom.DAL;
using System.Collections.Generic;
using System.Linq;

namespace ECom.BAL
{

    public class ProductService 
    {
        public IList<Product> GetProductList(int[] category, string name="")
        {
            using(UnitOfWork _uow = new UnitOfWork())
            {
                if (category==null && name=="")
                {
                    return _uow.proudctRepositry.Get(null, null, "ProductAttributes,ProductAttributes.ProductAttributeLookup").ToList();
                }
                else if (category != null && category.Length> 0 && name == "")
                {
                    return _uow.proudctRepositry.Get(x => category.Contains(x.CategoryId), null, "ProductAttributes,ProductAttributes.ProductAttributeLookup").ToList();
                }
                else if (category==null && name != "")
                {
                    return _uow.proudctRepositry.Get(x => x.Name.ToLower().StartsWith(name.ToLower()), null, "ProductAttributes,ProductAttributes.ProductAttributeLookup").ToList();
                }
                else
                {
                    return _uow.proudctRepositry.Get(x => category.Contains(x.CategoryId) && x.Name.ToLower().StartsWith(name.ToLower()), null, "ProductAttributes,ProductAttributes.ProductAttributeLookup").ToList();
                }
            }
        }

        public IList<ProductCategory> GetCategoryList()
        {
            using (UnitOfWork _uow = new UnitOfWork())
            {
                return _uow.proudctCategoryRepositry.Get().ToList();
            }
        }

        public IList<ProductAttribute> GetroductAttributeList(int ProductId)
        {
            using (IUnitOfWork _uow = new UnitOfWork())
            {
                return _uow.proudctAttributeRepositry.Get(x=> x.ProductId == ProductId).ToList();
            }
        }

        public IList<ProductAttributeLookup> GetroductAttributeLookupList(int CategoryId)
        {
            using (IUnitOfWork _uow = new UnitOfWork())
            {
                return _uow.proudctAttributeLookupRepositry.Get(x => x.ProductCategoryId == CategoryId).ToList();
            }
        }

        public Product GetProduct(int id)
        {
            using (UnitOfWork _uow = new UnitOfWork())
            {
                Product p = _uow.proudctRepositry.Get(x => x.ProductId == id, null, "ProductAttributes").FirstOrDefault();
                return p==null?new Product():p;
            }
        }

        public bool Save(Product P)
        {
            using (UnitOfWork _uow = new UnitOfWork())
            {
                if (P.ProductId == 0)
                {
                    _uow.proudctRepositry.Insert(P);
                }
                else
                {
                    var p = _uow.proudctRepositry.Get(x => x.ProductId == P.ProductId, null, "ProductAttributes").FirstOrDefault();
                    p.ProductAttributes.Clear();
                    p.Name = P.Name;
                    p.Description = p.Description;
                    p.CategoryId = p.CategoryId;
                    foreach (var item in P.ProductAttributes)
                        p.ProductAttributes.Add(item);
                }
                
                _uow.Save();
            }
            return true;
        }
    }
}
