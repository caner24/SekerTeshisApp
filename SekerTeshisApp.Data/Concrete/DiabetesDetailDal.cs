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
    public class DiabetesDetailDal : EfRepositoryBase<SekerTeshisAppContext, DiabetesDetail>, IDiabetesDetailDal
    {
        public DiabetesDetailDal(SekerTeshisAppContext context) : base(context)
        {
        }
    }
}
