using SekerTeshis.Core.DataAcess.EFCore;
using SekerTeshis.Core.EntityFramework;
using SekerTeshis.Entity;
using SekerTeshisApp.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Data.Abstract
{
    public interface IDiabetesDal:IEntityRepositoryBase<Diabetes>
    {
    }
}
