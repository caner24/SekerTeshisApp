using Microsoft.EntityFrameworkCore;
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
    public class DiabetesDal : EfRepositoryBase<SekerTeshisAppContext, Diabetes>, IDiabetesDal
    {
        public DiabetesDal(SekerTeshisAppContext context) : base(context)
        {
        }
    }
}
