using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodimax
{
    public class Sales
    {
        public string BranchName { get; set; }
        public decimal Sale { get; set; }
        public Sales()
        {

        }
        public Sales(string branchname, decimal sale)
        {
            BranchName = branchname;
            Sale = sale;
        }
    }
}
