using SekerTeshis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Home.Responses
{
    public class GetUserFoodListsResponse
    {
        public List<Food> FoodLists { get; set; }
    }
}
