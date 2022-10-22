using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRatioAnalysis.DupontAnalysis
{
    public class DupontAnalyzer
    {
        public string? name { get; set; }
        public double net_income { get; set; }
        public double average_common_equity { get; set; }
        public double sales { get; set; }
        public double average_total_assets { get; set; }
        public double average_total_debt { get; set; }
        public double interest_expense { get; set; }
        public double effective_tax_rate { get; set; }
        public void BasicDupontWriteLine()
        {
            Console.WriteLine(name);
            BasicModel dupontAnalysis = BasicDupontAnalysis();
            foreach (PropertyInfo prop in typeof(BasicModel).GetProperties())
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(dupontAnalysis, null));
            }
            Console.WriteLine("\n");
        }
        public void AdvancedDupontWriteLine()
        {
            Console.WriteLine(name);
            AdvancedModel advancedDupontAnalysis = AdvancedDupontAnalysis();
            foreach (PropertyInfo prop in typeof(AdvancedModel).GetProperties())
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(advancedDupontAnalysis, null));
            }
            Console.WriteLine("\n");
        }
        public double ReturnOnEquity()
        {
            return net_income / average_common_equity;
        }
        public double ReturnOnAssets()
        {
            return net_income / average_total_assets;
        }
        public double ProfitMargin()
        {
            return net_income / sales;
        }
        public double AssetTurnover()
        {
            return sales / average_total_assets;
        }
        public double FinancialLeverage()
        {
            return average_total_assets / average_common_equity;
        }
        public double AddBackInterestExpenseNetOfTaxes()
        {
            return interest_expense * (1 - effective_tax_rate);
        }
        public double NetOperatingIncome()
        {
            return net_income + AddBackInterestExpenseNetOfTaxes();
        }
        public double NetOperatingAssets()
        {
            return average_common_equity + average_total_debt;
        }
        public double RNOA()
        {
            return NetOperatingIncome() / NetOperatingAssets();
        }
        public double Leverage()
        {
            return average_total_debt / average_common_equity;
        }
        public double NBC()
        {
            return AddBackInterestExpenseNetOfTaxes() / average_total_debt;
        }
        public double Spread()
        {
            return RNOA() - NBC();
        }
        public double NonOperatingReturn()
        {
            return Leverage() * Spread();
        }
        public BasicModel BasicDupontAnalysis()
        {
            return new BasicModel()
            {
                profit_margin = ProfitMargin(),
                asset_turnover = AssetTurnover(),
                financial_leverage = FinancialLeverage(),
                ROA = ReturnOnAssets(),
                ROE = ReturnOnAssets() * FinancialLeverage(),
            };
        }
        public AdvancedModel AdvancedDupontAnalysis()
        {
            return new AdvancedModel()
            {
                Leverage = Leverage(),
                Spread = Spread(),
                RNOA = RNOA(),
                NBC = NBC(),
                NonOperatingReturn = NonOperatingReturn(),
                ROE = RNOA() + NonOperatingReturn(),
            };
        }
    }
}
