using FinancialRatioAnalysis.DupontAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinancialRatioAnalysis.CreditRatios
{
    internal class CreditRatiosAnalyzer
    {
        public string? name { get; set; }
        public double current_assets { get; set; }
        public double current_liabilities { get; set; }
        public double cash { get; set; }
        public double marketable_securities { get; set; }
        public double ending_accounts_receivables { get; set; }
        private double? total_debt_field;
        public double total_debt { get => total_debt_field ?? TotalDebt(); set => total_debt_field = value; }
        public double common_equity { get; set; }
        public double short_term_debt { get; set; }
        public double long_term_debt { get; set; }
        public double current_portion_long_term_debt { get; set; }
        public double net_income { get; set; }
        public double interest_expense { get; set; }
        public double tax_expense { get; set; }
        public double cash_from_operations { get; set; }
        public double CurrentRatio() => current_assets / current_liabilities;
        public double QuickRatio() => (cash + marketable_securities + ending_accounts_receivables) / current_liabilities;
        public double TotalDebt() => total_debt = short_term_debt + current_portion_long_term_debt + long_term_debt;
        public double TotalDebtToEquity() => total_debt / common_equity;
        public double LongTermDebtToEquity() => (long_term_debt + current_portion_long_term_debt) / common_equity;
        public double earnings_before_interest_and_taxes() => net_income + interest_expense + tax_expense;
        public double InterestCoverage() => earnings_before_interest_and_taxes() / interest_expense;
        public double CFOToTotalDebt() => cash_from_operations / total_debt;
        public void LiquidityWriteLine()
        {
            Console.WriteLine(name);
            LiquidityAnalysisModel liquidityAnalysisModel = LiquidityAnalysisModel();
            foreach (PropertyInfo prop in typeof(LiquidityAnalysisModel).GetProperties())
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(liquidityAnalysisModel, null));
            }
            Console.WriteLine("\n");
        }
        public void SolvencyWriteLine()
        {
            Console.WriteLine(name);
            SolvencyAnalysisModel solvencyAnalysisModel = SolvencyAnalysisModel();
            foreach (PropertyInfo prop in typeof(SolvencyAnalysisModel).GetProperties())
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(solvencyAnalysisModel, null));
            }
            Console.WriteLine("\n");
        }
        public void CoverageWriteLine()
        {
            Console.WriteLine(name);
            CoverageAnalysisModel coverageAnalysisModel = CoverageAnalysisModel();
            foreach (PropertyInfo prop in typeof(CoverageAnalysisModel).GetProperties())
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(coverageAnalysisModel, null));
            }
            Console.WriteLine("\n");
        }
        public LiquidityAnalysisModel LiquidityAnalysisModel()
        {
            return new LiquidityAnalysisModel()
            {
                current_ratio = CurrentRatio(),
                quick_ratio = QuickRatio()
            };
        }
        public SolvencyAnalysisModel SolvencyAnalysisModel()
        {
            return new SolvencyAnalysisModel()
            {
                total_debt_to_equity = TotalDebtToEquity(),
                long_term_debt_to_equity = LongTermDebtToEquity()
            };
        }
        public CoverageAnalysisModel CoverageAnalysisModel()
        {
            return new CoverageAnalysisModel()
            {
                interest_coverage = InterestCoverage(),
                cfo_to_total_debt = CFOToTotalDebt()
            };
        }
    }
}
