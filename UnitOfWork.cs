using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository2.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private RestaurantSystemDBContext context = new RestaurantSystemDBContext();

        private GenericRepository<FoodItem> fooditemRepository;
        private GenericRepository<Buyer> buyerRepository;
        private GenericRepository<Order> orderRepository;

        public GenericRepository<FoodItem> FoodItemRepository

        {
            get
            {
                if (this.fooditemRepository == null)
                {
                    this.fooditemRepository = new GenericRepository<FoodItem>(context);
                }
                return fooditemRepository;
            }
        }


        public GenericRepository<Buyer> BuyerRepository
        {
            get
            {
                if (this.buyerRepository == null)
                {
                    this.buyerRepository = new GenericRepository<Buyer>(context);
                }
                return buyerRepository;
            }
        }


        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }




        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable Support
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
        #endregion

    }
}