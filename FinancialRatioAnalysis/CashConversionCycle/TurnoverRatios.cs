using FinancialRatioAnalysis.DupontAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinancialRatioAnalysis.CashConversionCycle
{
    internal class TurnoverRatios
    {
        public string? name { get; set; }
        public double sales { get; set; }
        public double cost_of_goods_sold { get; set; }
        public double total_assets { get; set; }
        public double current_assets { get; set; }
        public double NetPropertyPlantEquipment { get; set; }
        public double ending_accounts_receivables { get; set; }
        public double ending_accounts_payables { get; set; }
        public double ending_inventory { get; set; }
        public double AssetTurnover() => sales / total_assets;
        public double CurrentAssetsTurnover() => sales / current_assets;
        public double PPETurnover() => sales / NetPropertyPlantEquipment;
        public double AccountsReceivableTurnover() => sales / ending_accounts_receivables;
        public double AccountsPayableTurnover() => cost_of_goods_sold / ending_accounts_payables;
        public double InventoryTurnover() => cost_of_goods_sold / ending_inventory;
        public void FiscalYearWriteLine()
        {
            Console.WriteLine(name);
            FiscalYearModel fiscalYearModel = FiscalYearModel();
            foreach (PropertyInfo prop in typeof(FiscalYearModel).GetProperties())
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(fiscalYearModel, null));
            }
            Console.WriteLine("\n");
        }
        public void AverageDayWriteLine()
        {
            Console.WriteLine(name);
            AverageDaysModel averageDaysModel = AverageDaysModel();
            foreach (PropertyInfo prop in typeof(AverageDaysModel).GetProperties())
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(averageDaysModel, null));
            }
            Console.WriteLine("\n");
        }
        public AverageDaysModel AverageDaysModel()
        {
            return new AverageDaysModel()
            {
                inventory_conversion_period = 365 / InventoryTurnover(),
                receivables_conversion_period = 365 / AccountsReceivableTurnover(),
                payables_conversion_period = 365 / AccountsPayableTurnover(),
                cash_conversion_cycle = 365 / InventoryTurnover() + 365 / AccountsReceivableTurnover() - 365 / AccountsPayableTurnover(),
            };
        }
        public FiscalYearModel FiscalYearModel()
        {
            return new FiscalYearModel()
            {
                assets_turnover = AssetTurnover(),
                current_assets_turnover = CurrentAssetsTurnover(),
                ppe_turnover = PPETurnover(),
                accounts_receivables_turnover = AccountsReceivableTurnover(),
                accounts_payables_turnover = AccountsPayableTurnover(),
                inventory_turnover = InventoryTurnover(),
            };
        }

    }
}
