using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.DAL.Repository
{
    public class UnitOfWork
    {
        CityRepository? cityRepository;
        CoachRepository? coachRepository;
        OrderStatusRepository? orderStatusRepository;
        ProductRepository? productRepository;
        ProductTypeRepository? productTypeRepository;
        PurchaseRepository? purchaseRepository;
        ReviewImageRepository? reviewImageRepository;
        ReviewRepository? reviewRepository;
        UserRepository? userRepository;
        MaterialRepository? materialRepository;
        BrandRepository? brandRepository;

        private readonly DbContext dbContext;
        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CityRepository CityRepository
        {
            get
            {
                if (cityRepository == null)
                {
                    this.cityRepository = new CityRepository(dbContext);
                }
                return cityRepository;
            }
        }

        public CoachRepository CoachRepository
        {
            get
            {
                if (coachRepository == null)
                {
                    this.coachRepository = new CoachRepository(dbContext);
                }
                return coachRepository;
            }
        }

        public OrderStatusRepository OrderStatusRepository
        {
            get
            {
                if (orderStatusRepository == null)
                {
                    this.orderStatusRepository = new OrderStatusRepository(dbContext);
                }
                return orderStatusRepository;
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    this.productRepository = new ProductRepository(dbContext);
                }
                return productRepository    ;
            }
        }

        public ProductTypeRepository ProductTypeRepository
        {
            get
            {
                if (productTypeRepository == null)
                {
                    this.productTypeRepository = new ProductTypeRepository(dbContext);
                }
                return productTypeRepository  ;
            }
        }


        public PurchaseRepository PurchaseRepository
        {
            get
            {
                if (purchaseRepository == null)
                {
                    this.purchaseRepository = new PurchaseRepository(dbContext);
                }
                return purchaseRepository;
            }
        }

        public ReviewImageRepository ReviewImageRepository
        {
            get
            {
                if (reviewImageRepository == null)
                {
                    this.reviewImageRepository = new ReviewImageRepository(dbContext);
                }
                return reviewImageRepository;
            }
        }

        public ReviewRepository ReviewRepository
        {
            get
            {
                if (reviewRepository == null)
                {
                    this.reviewRepository = new ReviewRepository(dbContext);
                }
                return reviewRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    this.userRepository = new UserRepository(dbContext);
                }
                return userRepository;
            }
        }
        public MaterialRepository MaterialRepository
        {
            get
            {
                if (this.materialRepository == null)
                {
                    this.materialRepository = new MaterialRepository(dbContext);
                }
                return materialRepository;
            }
        }
        public BrandRepository BrandRepository
        {
            get
            {
                if (brandRepository == null)
                {
                    this.brandRepository = new BrandRepository(dbContext);
                }
                return brandRepository;
            }
        }
    }
}
