using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRatioAnalysis.CashConversionCycle
{
    internal class FiscalYearModel
    {
        public double assets_turnover { get; set; }
        public double current_assets_turnover { get; set; }
        public double ppe_turnover { get; set; }
        public double accounts_receivables_turnover { get; set; }
        public double accounts_payables_turnover { get; set; }
        public double inventory_turnover { get; set; }
    }
}
