using System.Reflection;
using FinancialRatioAnalysis.DupontAnalysis;
using FinancialRatioAnalysis.CashConversionCycle;
using FinancialRatioAnalysis.CreditRatios;

namespace FinancialRatioAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DupontAnalyzer netflix_2017_BD = new DupontAnalyzer() { name = "netflix_2017_BD", net_income = 558929, average_common_equity = 3581956, sales = 11692713, average_total_assets = 19012742 };
            netflix_2017_BD.BasicDupontWriteLine();
            DupontAnalyzer netflix_2017_AD = new DupontAnalyzer() { name = "netflix_2017_AD", net_income = 558929, average_common_equity = 3581956, interest_expense = 238204, effective_tax_rate = 0.1239, average_total_debt = 6499432 };
            netflix_2017_AD.AdvancedDupontWriteLine();
            DupontAnalyzer netflix_2018_BD = new DupontAnalyzer() { name = "netflix_2018_BD", net_income = 1211242, average_common_equity = 5238765, sales = 15794341, average_total_assets = 25974400 };
            netflix_2018_BD.BasicDupontWriteLine();
            DupontAnalyzer netflix_2018_AD = new DupontAnalyzer() { name = "netflix_2018_AD", net_income = 1211242, average_common_equity = 5238765, interest_expense = 420493, effective_tax_rate = 0.1239, average_total_debt = 10360058 };
            netflix_2018_AD.AdvancedDupontWriteLine();
            DupontAnalyzer netflix_2019_BD = new DupontAnalyzer() { name = "netflix_2019_BD", net_income = 1866916, average_common_equity = 7582157, sales = 20156447, average_total_assets = 33975712 };
            netflix_2019_BD.BasicDupontWriteLine();
            DupontAnalyzer netflix_2019_AD = new DupontAnalyzer() { name = "netflix_2019_AD", net_income = 1866916, average_common_equity = 7582157, interest_expense = 626023 + 190622, effective_tax_rate = 0.1239, average_total_debt = 14759260 };
            netflix_2019_AD.AdvancedDupontWriteLine();
            DupontAnalyzer netflix_2020_BD = new DupontAnalyzer() { name = "netflix_2020_BD", net_income = 2761395, average_common_equity = 11065240, sales = 24996056, average_total_assets = 39280359 };
            netflix_2020_BD.BasicDupontWriteLine();
            DupontAnalyzer netflix_2020_AD = new DupontAnalyzer() { name = "netflix_2020_AD", net_income = 2761395, average_common_equity = 11065240, interest_expense = 767499 + 368060, effective_tax_rate = 0.1239, average_total_debt = 499878 + 15809095 };
            netflix_2020_AD.AdvancedDupontWriteLine();
            DupontAnalyzer netflix_2021_BD = new DupontAnalyzer() { name = "netflix_2021_BD", net_income = 5116228, average_common_equity = 15849248, sales = 29697844, average_total_assets = 44584663 };
            netflix_2021_BD.BasicDupontWriteLine();
            DupontAnalyzer netflix_2021_AD = new DupontAnalyzer() { name = "netflix_2021_AD", net_income = 5116228, average_common_equity = 15849248, interest_expense = 765620 + 417314, effective_tax_rate = 0.1239, average_total_debt = 699823 + 14693072 };
            netflix_2021_AD.AdvancedDupontWriteLine();

            TurnoverRatios netflix_2017_ratios = new TurnoverRatios() { name = "netflix_2017_ratios", sales = 11692713, cost_of_goods_sold = 8033000, ending_inventory = 0, ending_accounts_receivables = 0, ending_accounts_payables = 359555, NetPropertyPlantEquipment = 319404, current_assets = 3359040, total_assets = 19012742 };
            netflix_2017_ratios.AverageDayWriteLine();
            netflix_2017_ratios.FiscalYearWriteLine();
            TurnoverRatios netflix_2018_ratios = new TurnoverRatios() { name = "netflix_2018_ratios", sales = 15794341, cost_of_goods_sold = 9967538, ending_inventory = 0, ending_accounts_receivables = 362712, ending_accounts_payables = 562985, NetPropertyPlantEquipment = 418281, current_assets = 4542949, total_assets = 25974400 };
            netflix_2018_ratios.AverageDayWriteLine();
            netflix_2018_ratios.FiscalYearWriteLine();
            TurnoverRatios netflix_2019_ratios = new TurnoverRatios() { name = "netflix_2019_ratios", sales = 20156447, cost_of_goods_sold = 12440213, ending_inventory = 0, ending_accounts_receivables = 454399, ending_accounts_payables = 674347, NetPropertyPlantEquipment = 565221, current_assets = 6178504, total_assets = 33975712 };
            netflix_2019_ratios.AverageDayWriteLine();
            netflix_2019_ratios.FiscalYearWriteLine();
            TurnoverRatios netflix_2020_ratios = new TurnoverRatios() { name = "netflix_2020_ratios", sales = 24996056, cost_of_goods_sold = 15276319, ending_inventory = 0, ending_accounts_receivables = 610819, ending_accounts_payables = 656183, NetPropertyPlantEquipment = 960183, current_assets = 9761580, total_assets = 39280359 };
            netflix_2020_ratios.AverageDayWriteLine();
            netflix_2020_ratios.FiscalYearWriteLine();
            TurnoverRatios netflix_2021_ratios = new TurnoverRatios() { name = "netflix_2021_ratios", sales = 29697844, cost_of_goods_sold = 17332683, ending_inventory = 0, ending_accounts_receivables = 804320, ending_accounts_payables = 837483, NetPropertyPlantEquipment = 1323453, current_assets = 8069825, total_assets = 44584663 };
            netflix_2021_ratios.AverageDayWriteLine();
            netflix_2021_ratios.FiscalYearWriteLine();

            CreditRatiosAnalyzer netflix_2017_creditratios = new CreditRatiosAnalyzer() { name = "netflix_2017_creditratios", current_assets = 3359040, current_liabilities = 5466312, marketable_securities = 0, ending_accounts_receivables = 0, net_income = 558929, interest_expense = 238204, tax_expense = -73608, long_term_debt = 6499432, current_portion_long_term_debt = 0, common_equity = 3581956, total_debt = 15430786 };
            netflix_2017_creditratios.LiquidityWriteLine();
            netflix_2017_creditratios.SolvencyWriteLine();
            netflix_2017_creditratios.CoverageWriteLine();
            CreditRatiosAnalyzer netflix_2018_creditratios = new CreditRatiosAnalyzer() { name = "netflix_2018_creditratios", current_assets = 4542949, current_liabilities = 6487320, marketable_securities = 0, ending_accounts_receivables = 362712, net_income = 1211242, interest_expense = 420493, tax_expense = 15216, long_term_debt = 10360058, current_portion_long_term_debt = 0, common_equity = 5238765, total_debt = 20735635 };
            netflix_2018_creditratios.LiquidityWriteLine();
            netflix_2018_creditratios.SolvencyWriteLine();
            netflix_2018_creditratios.CoverageWriteLine();
            CreditRatiosAnalyzer netflix_2019_creditratios = new CreditRatiosAnalyzer() { name = "netflix_2019_creditratios", current_assets = 6178504, current_liabilities = 6855696, marketable_securities = 0, ending_accounts_receivables = 454399, net_income = 1866916, interest_expense = 626023, tax_expense = 195315, long_term_debt = 14759260, current_portion_long_term_debt = 0, common_equity = 7582157, total_debt = 26393555 };
            netflix_2019_creditratios.LiquidityWriteLine();
            netflix_2019_creditratios.SolvencyWriteLine();
            netflix_2019_creditratios.CoverageWriteLine();
            CreditRatiosAnalyzer netflix_2020_creditratios = new CreditRatiosAnalyzer() { name = "netflix_2020_creditratios", current_assets = 9761580, current_liabilities = 7805785, marketable_securities = 0, ending_accounts_receivables = 610819, net_income = 2761395, interest_expense = 767499, tax_expense = 437954, long_term_debt = 15809095, current_portion_long_term_debt = 0, common_equity = 11065240, total_debt = 28215119 };
            netflix_2020_creditratios.LiquidityWriteLine();
            netflix_2020_creditratios.SolvencyWriteLine();
            netflix_2020_creditratios.CoverageWriteLine();
            CreditRatiosAnalyzer netflix_2021_creditratios = new CreditRatiosAnalyzer() { name = "netflix_2021_creditratios", current_assets = 8069825, current_liabilities = 8488966, marketable_securities = 0, ending_accounts_receivables = 804320, net_income = 5116228, interest_expense = 765620, tax_expense = 723875, long_term_debt = 14693072, current_portion_long_term_debt = 0, common_equity = 15849248, total_debt = 28735415 };
            netflix_2021_creditratios.LiquidityWriteLine();
            netflix_2021_creditratios.SolvencyWriteLine();
            netflix_2021_creditratios.CoverageWriteLine();
            //DupontAnalyzer apple_2016 = new DupontAnalyzer() { name = "apple_2016", net_income = 45.7, average_common_equity = 126.2, sales = 215.6, average_total_assets = 321.7 };
            //apple_2016.BasicDupontWriteLine();
            //DupontAnalyzer apple_2017 = new DupontAnalyzer() { name = "apple_2017", net_income = 48.4, average_common_equity = 134, sales = 229.2, average_total_assets = 375.3 };
            //apple_2017.BasicDupontWriteLine();
            //DupontAnalyzer apple_2021 = new DupontAnalyzer() { name = "apple_2021", net_income = 94.7, average_common_equity = 63.1, interest_expense = 2.65, effective_tax_rate = 0.13, average_total_debt = 122.7};
            //apple_2021.AdvancedDupontWriteLine();
            //DupontAnalyzer gamestop_2021 = new DupontAnalyzer() { name = "gamestop_2021", net_income = -381, average_common_equity = 1603, interest_expense = 46, effective_tax_rate = 0.21, average_total_debt = 649 };
            //gamestop_2021.AdvancedDupontWriteLine();
            //DupontAnalyzer bestbuys_2021 = new DupontAnalyzer() { name = "bestbuys_2021", net_income = 1760, average_common_equity = 4587, interest_expense = 52, effective_tax_rate = 0.25, average_total_debt = 4082 };
            //bestbuys_2021.AdvancedDupontWriteLine();
            //TurnoverRatios apple_2021_ratios = new TurnoverRatios() { name = "apple_2021_ratios", sales = 365.8, cost_of_goods_sold = 213, ending_inventory = 6.6, ending_accounts_receivables = 26.3, ending_accounts_payables = 54.8 };
            //apple_2021_ratios.AverageDayWriteLine();
            //CreditRatiosAnalyzer procter_and_gamble = new CreditRatiosAnalyzer() { name = "procter_and_gamble", total_liabilities = 30.60, net_income = 10.51, interest_expense = 0.58, tax_expense = 3.34, cash_from_operations = 15.44 };
            //procter_and_gamble.CoverageWriteLine();
            //CreditRatiosAnalyzer clorox = new CreditRatiosAnalyzer() { name = "clorox", total_liabilities = 1.80, net_income = 0.65, interest_expense = 0.09, tax_expense = 0.34, cash_from_operations = 0.77 };
            //clorox.CoverageWriteLine();
            //DupontAnalyzer tesla_2020_dupont = new DupontAnalyzer() { name = "tesla_2020", net_income = 954, average_common_equity = 22225, sales = 31536, average_total_assets = 50643 };
            //tesla_2020_dupont.BasicDupontWriteLine();
            //CreditRatiosAnalyzer tesla_2020_ratios = new CreditRatiosAnalyzer() { name = "tesla_2020", current_assets = 34282, current_liabilities = 14248, marketable_securities = 0, ending_accounts_receivables = 1886, net_income = 954, interest_expense = 748, tax_expense = 292 };
            //tesla_2020_ratios.LiquidityWriteLine();
            //tesla_2020_ratios.CoverageWriteLine();
            //DupontAnalyzer bmw_2020_dupont = new DupontAnalyzer() { name = "bmw_2020", net_income = 3007, average_common_equity = 60891, sales = 98990, average_total_assets = 216029 };
            //bmw_2020_dupont.BasicDupontWriteLine();
            //CreditRatiosAnalyzer bmw_2020_ratios = new CreditRatiosAnalyzer() { name = "bmw_2020", current_assets = 81178, current_liabilities = 71963, marketable_securities = 0, ending_accounts_receivables = 38550, net_income = 3007, interest_expense = 458, tax_expense = 1365 };
            //bmw_2020_ratios.LiquidityWriteLine();
            //bmw_2020_ratios.CoverageWriteLine();

            //CreditRatiosAnalyzer PNG_2021_RA = new CreditRatiosAnalyzer() { name = "PNG_2021_RA", current_assets = 21653, current_liabilities = 33081, cash = 7214, marketable_securities = 0, ending_accounts_receivables = 5143, net_income = 14247, interest_expense = 439, tax_expense = 3127 };
            //PNG_2021_RA.LiquidityWriteLine();
            //PNG_2021_RA.CoverageWriteLine();
            //CreditRatiosAnalyzer clorox_2021_RA = new CreditRatiosAnalyzer() { name = "clorox_2021_RA", current_assets = 1725, current_liabilities = 1784, cash = 183, marketable_securities = 0, ending_accounts_receivables = 681, net_income = 471, interest_expense = 106, tax_expense = 136 };
            //clorox_2021_RA.LiquidityWriteLine();
            //clorox_2021_RA.CoverageWriteLine();


            //DupontAnalyzer PNG_2021_DA = new DupontAnalyzer() { name = "PNG_2021_DA", net_income = 14247, average_common_equity = 46854, sales = 80187, average_total_assets = 117208 };
            //PNG_2021_DA.BasicDupontWriteLine();
            //DupontAnalyzer clorox_2021_DA = new DupontAnalyzer() { name = "clorox_2021_DA", net_income = 471, average_common_equity = 729, sales = 7107, average_total_assets = 6158 };
            //clorox_2021_DA.BasicDupontWriteLine();

            //DupontAnalyzer PNG_2021_ADA = new DupontAnalyzer() { name = "PNG_2021_ADA", net_income = 14247, average_common_equity = 46854, interest_expense = 439, effective_tax_rate = 0.18, average_total_debt = 31493 };
            //PNG_2021_ADA.AdvancedDupontWriteLine();
        }
    }
}