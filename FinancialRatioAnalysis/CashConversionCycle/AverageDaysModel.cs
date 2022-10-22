using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRatioAnalysis.CashConversionCycle
{
    internal class AverageDaysModel
    {
        public double inventory_conversion_period { get; set; }
        public double receivables_conversion_period { get; set; }
        public double payables_conversion_period { get; set; }
        public double cash_conversion_cycle { get; set; }
    }
}
