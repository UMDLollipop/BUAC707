using FinancialRatioAnalysis.DupontAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResearchAndDevelopmentAndRedFlags.RNDCapitalization
{
    internal class RNDCapitalizer
    {
        public string? name { get; set; }
        public double sales { get; set; }
        public double net_income { get; set; }
        public double total_assets { get; set; }
        public double effective_tax_rate { get; set; }
        public List<double> rnd_spendings { get; set; }
        public double year_1_rnd { get; set; }
        public double year_2_rnd { get; set; }
        public double year_3_rnd { get; set; }
        public double year_4_rnd { get; set; }
        public double year_5_rnd { get; set; }
        public double adjusted_total_assets { get; set; }
        public double adjusted_net_income { get; set; }
        public void adjustedTotalAssetsWriteLine()
        {
            Console.WriteLine(name);
            AdjustedTotalAssetsModel adjustedTotalAssetsModel = AdjustedTotalAssetsModel();
            var sb = new System.Text.StringBuilder();
            sb.Append(String.Format("{0,9} {1,9} {2,9} {3,9} {4,9} {5,9} {6,9}\n\n", "Year", "RND", "Year 1", "Year 2", "Year 3", "Year 4", "Year 5"));
            for (int index = 0; index < adjustedTotalAssetsModel.adjusted_year_5_rnd_assets.Count; index++)
                sb.Append(String.Format("{0,9} {1,9} {2,9} {3,9} {4,9} {5,9} {6,9}\n",
                    index + 1,
                    (adjustedTotalAssetsModel.GetType().GetProperty($"adjusted_year_{index + 1}_rnd_assets").GetValue(adjustedTotalAssetsModel, null) as List<double>)[index],
                    index < adjustedTotalAssetsModel.adjusted_year_1_rnd_assets.Count ? adjustedTotalAssetsModel.adjusted_year_1_rnd_assets[index] : 0,
                    index < adjustedTotalAssetsModel.adjusted_year_2_rnd_assets.Count ? adjustedTotalAssetsModel.adjusted_year_2_rnd_assets[index] : 0,
                    index < adjustedTotalAssetsModel.adjusted_year_3_rnd_assets.Count ? adjustedTotalAssetsModel.adjusted_year_3_rnd_assets[index] : 0,
                    index < adjustedTotalAssetsModel.adjusted_year_4_rnd_assets.Count ? adjustedTotalAssetsModel.adjusted_year_4_rnd_assets[index] : 0,
                    index < adjustedTotalAssetsModel.adjusted_year_5_rnd_assets.Count ? adjustedTotalAssetsModel.adjusted_year_5_rnd_assets[index] : 0));

            Console.WriteLine(sb);
            adjusted_total_assets = total_assets + adjustedTotalAssetsModel.adjusted_year_5_rnd_assets.Sum();
            Console.WriteLine($"Adjusted Total Assets = {total_assets} + {adjustedTotalAssetsModel.adjusted_year_5_rnd_assets.Sum()} = {adjusted_total_assets}");
        }
        public void adjustedNetIncomesWriteLine()
        {
            Console.WriteLine(name);
            AdjustedNetIncomeModel adjustedNetIncomeModel = AdjustedNetIncomeModel();
            var sb = new System.Text.StringBuilder();
            sb.Append(String.Format("{0,9} {1,9} {2,9} {3,9} {4,9} {5,9} {6,9}\n\n", "Year", "RND", "Year 1", "Year 2", "Year 3", "Year 4", "Year 5"));
            for (int index = 0; index < adjustedNetIncomeModel.adjusted_year_5_net_income.Count; index++)
                sb.Append(String.Format("{0,9} {1,9} {2,9} {3,9} {4,9} {5,9} {6,9}\n",
                    index + 1,
                    index < (adjustedNetIncomeModel.GetType().GetProperty($"adjusted_year_{index + 1}_net_income").GetValue(adjustedNetIncomeModel, null) as List<double>).Count ? (adjustedNetIncomeModel.GetType().GetProperty($"adjusted_year_{index + 1}_net_income").GetValue(adjustedNetIncomeModel, null) as List<double>)[index] : 0,
                    index < adjustedNetIncomeModel.adjusted_year_1_net_income.Count ? adjustedNetIncomeModel.adjusted_year_1_net_income[index] : 0,
                    index < adjustedNetIncomeModel.adjusted_year_2_net_income.Count ? adjustedNetIncomeModel.adjusted_year_2_net_income[index] : 0,
                    index < adjustedNetIncomeModel.adjusted_year_3_net_income.Count ? adjustedNetIncomeModel.adjusted_year_3_net_income[index] : 0,
                    index < adjustedNetIncomeModel.adjusted_year_4_net_income.Count ? adjustedNetIncomeModel.adjusted_year_4_net_income[index] : 0,
                    index < adjustedNetIncomeModel.adjusted_year_5_net_income.Count ? adjustedNetIncomeModel.adjusted_year_5_net_income[index] : 0));

            Console.WriteLine(sb);
            adjusted_net_income = net_income + (year_5_rnd - adjustedNetIncomeModel.adjusted_year_5_net_income.Sum()) * (1 - effective_tax_rate);
            Console.WriteLine($"Adjusted Net Income = {net_income} + ({year_5_rnd} - {adjustedNetIncomeModel.adjusted_year_5_net_income.Sum()}) * (1 - {effective_tax_rate}) = {adjusted_net_income}");
        }
        public void ReturnOnAssets()
        {
            DupontAnalyzer unadjusted_roa = new DupontAnalyzer() { name = "undajusted_roa", net_income = net_income, sales = sales, average_total_assets = total_assets };
            Console.WriteLine($"Unadjusted ROA = {unadjusted_roa.ProfitMargin()} * {unadjusted_roa.AssetTurnover()} = {unadjusted_roa.ReturnOnAssets()}");
            DupontAnalyzer adjusted_roa = new DupontAnalyzer() { name = "adjusted_roa", net_income = adjusted_net_income, sales = sales, average_total_assets = adjusted_total_assets };
            Console.WriteLine($"Adjusted ROA = {adjusted_roa.ProfitMargin()} * {adjusted_roa.AssetTurnover()} = {adjusted_roa.ReturnOnAssets()}");
        }
        public AdjustedTotalAssetsModel AdjustedTotalAssetsModel()
        {
            rnd_spendings = new List<double>()
            {
                year_1_rnd, year_2_rnd, year_3_rnd, year_4_rnd, year_5_rnd
            };
            AdjustedTotalAssetsModel adjustedTotalAssetsModel = new AdjustedTotalAssetsModel();
            int i = 0;
            foreach (PropertyInfo prop in typeof(AdjustedTotalAssetsModel).GetProperties())
            {
                List<double> rnd_spending = new List<double>();
                for (int j = 0; j <= i; j++)
                {
                    rnd_spending.Add(rnd_spendings[j] * (rnd_spendings.Count - (i - j)) / rnd_spendings.Count);
                }
                i++;
                prop.SetValue(adjustedTotalAssetsModel, rnd_spending);
            }
            return adjustedTotalAssetsModel;
        }
        public AdjustedNetIncomeModel AdjustedNetIncomeModel()
        {
            rnd_spendings = new List<double>()
            {
                year_1_rnd, year_2_rnd, year_3_rnd, year_4_rnd, year_5_rnd
            };
            AdjustedNetIncomeModel adjustedNetIncomeModel = new AdjustedNetIncomeModel();
            int i = 0;
            foreach (PropertyInfo prop in typeof(AdjustedNetIncomeModel).GetProperties())
            {
                List<double> rnd_spending = new List<double>();
                for (int j = 0; j < i; j++)
                {
                    rnd_spending.Add(rnd_spendings[j] / rnd_spendings.Count);
                }
                i++;
                prop.SetValue(adjustedNetIncomeModel, rnd_spending);
            }
            return adjustedNetIncomeModel;
        }
    }
}
