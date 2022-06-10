using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            var objfromDb=_db.Products.FirstOrDefault(p => p.Id == obj.Id);
            if(objfromDb != null)
            {
                objfromDb.Title = obj.Title;
                objfromDb.ISBN = obj.ISBN;
                objfromDb.ListPrice = obj.ListPrice;
                objfromDb.Price = obj.Price;
                objfromDb.Price100 = obj.Price100;
                objfromDb.Price50 = obj.Price50;
                objfromDb.Description = obj.Description;
                objfromDb.Author = obj.Author;
                objfromDb.CoverTypeId = obj.CoverTypeId;
                if(obj.ImageUrl != null)
                {
                    objfromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
