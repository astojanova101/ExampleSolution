using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApplicationService.Implementations;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        public string DeleteFoodItem(int id)
        {
            if (!fooditemManagementService.Delete(id))
            {
                return "Food Item is not deleted!";
            }
            else
            {
                return "Food Item successfully deleted!";
            }
        }

        public string DeleteBuyer(int id)
        {
            if (!buyerManagementService.Delete(id))
            {
                return "Buyer is not deleted!";
            }
            else
            {
                return "Buyer successfully deleted!";
            }
        }

        public string DeleteOrder(int id)
        {
            if (!orderManagementService.Delete(id))
            {
                return "Order is not deleted!";
            }
            else
            {
                return "Order successfully deleted!";
            }
        }

        public List<FoodItemDTO> GetFoodItem(string query)
        {
            return fooditemManagementService.Get(query);
        }

        public List<BuyerDTO> GetBuyers(string query)
        {
            return buyerManagementService.Get(query);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<OrderDTO> GetOrders(string query)
        {
            return orderManagementService.Get(query);
        }


        private FoodItemManagementService fooditemManagementService = new FoodItemManagementService();

        private BuyerManagementService buyerManagementService = new BuyerManagementService();

        private OrderManagementService orderManagementService = new OrderManagementService();

        public string PostFoodItem(FoodItemDTO fooditemsDTOs)
        {
            if (!fooditemManagementService.Save(fooditemsDTOs))
            {
                return "Food Item is not saved!";
            }
            else
            {
                return "Food Item successfully saved!";
            }
        }


        public string PostBuyer(BuyerDTO buyerDTOs)
        {
            if (!buyerManagementService.Save(buyerDTOs))
            {
                return "Buyer is not saved!";
            }
            else
            {
                return "Buyer successfully saved!";
            }
        }

        public string PostOrder(OrderDTO orderDTOs)
        {
            if (!orderManagementService.Save(orderDTOs))
            {
                return "Order is not saved!";
            }
            else
            {
                return "Order successfully saved!";
            }
        }

        public FoodItemDTO GetFoodItemById(int id)
        {
            return fooditemManagementService.GetById(id);
        }

        public BuyerDTO GetBuyerById(int id)
        {
            return buyerManagementService.GetById(id);
        }

        public OrderDTO GetOrderById(int id)
        {
            return orderManagementService.GetById(id);
        }

      

       
    }

}
