using BildingTime.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BildingTime.ViewModel
{
    public static class AppData
    {
        public static TradeEntities db = new TradeEntities();
    }
}
