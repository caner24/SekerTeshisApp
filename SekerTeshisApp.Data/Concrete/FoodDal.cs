using SekerTeshis.Core.DataAcess.EFCore;
using SekerTeshis.Entity;
using SekerTeshisApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Data.Concrete
{
    public class FoodDal : EfRepositoryBase<SekerTeshisAppContext, Food>, IFoodDal
    {
        public FoodDal(SekerTeshisAppContext context) : base(context)
        {
        }
    }
}
