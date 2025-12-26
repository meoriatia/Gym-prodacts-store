using System.Data;

namespace WebService.DAL
{
    public class ModelFactory
    {
        CityCreator? cityCreator;
        CoachCreator? coachCreator;
        OrderStatusCreator? orderStatusCreator;
        ProductCreator? productCreator;
        ProductPurchaseCreator? productPurchaseCreator;
        ProductTypeCreator? productTypeCreator;
        PurchaseCreator? purchaseCreator;
        ReviewCreator? reviewCreator;
        ReviewImageCreator? reviewImageCreator;
        UserCreator? userCreator;

        public CityCreator CityCreator
        {
            get
            {
                if (CityCreator == null)
                {
                    this.cityCreator = new CityCreator();
                }
                return CityCreator;
            }
        }

        public CoachCreator CoachCreator
        {
            get
            {
                if (CoachCreator == null)
                {
                    this.coachCreator = new CoachCreator();
                }
                return CoachCreator;
            }
        }
        public OrderStatusCreator OrderStatusCreator
        {
            get
            {
                if (OrderStatusCreator == null)
                {
                    this.orderStatusCreator = new OrderStatusCreator();
                }
                return orderStatusCreator;
            }
        }

        public ProductCreator ProductCreator
        {
            get
            {
                if (productCreator == null)
                {
                    this.productCreator = new ProductCreator();
                }
                return productCreator;
            }
        }

        public ProductPurchaseCreator ProductPurchaseCreator
        {
            get
            {
                if (productPurchaseCreator == null)
                {
                    this.productPurchaseCreator = new ProductPurchaseCreator();
                }
                return productPurchaseCreator;
            }
        }

        public ProductTypeCreator ProductTypeCreator
        {
            get
            {
                if (ProductTypeCreator == null)
                {
                    this.productTypeCreator = new ProductTypeCreator();
                }
                return productTypeCreator;
            }
        }

        public PurchaseCreator PurchaseCreator
        {
            get
            {
                if (purchaseCreator == null)
                {
                    this.purchaseCreator = new PurchaseCreator();
                }
                return purchaseCreator;
            }
        }

        public ReviewCreator ReviewCreator
        {
            get
            {
                if (reviewCreator == null)
                {
                    this.reviewCreator = new ReviewCreator();
                }
                return reviewCreator;
            }
        }

        public ReviewImageCreator ReviewImageCreator
        {
            get
            {
                if (reviewImageCreator == null)
                {
                    this.reviewImageCreator = new ReviewImageCreator();
                }
                return reviewImageCreator;
            }
        }
        public UserCreator UserCreator
        {
            get
            {
                if (userCreator == null)
                {
                    this.userCreator = new UserCreator();
                }
                return userCreator;
            }
        }
    }
}
