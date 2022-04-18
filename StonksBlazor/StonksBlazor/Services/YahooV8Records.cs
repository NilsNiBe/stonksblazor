namespace StonksBlazor.Services
{
  public record Pre(
    string Timezone,
    double Start,
    double End,
    double Gmtoffset
  );

  public record Regular(
    string Timezone,
    double Start,
    double End,
    double Gmtoffset
  );

  public record Post  (
    string Timezone,
    double Start,
    double End,
    double Gmtoffset
  );
  public record CurrentTradingPeriod
  (
    Pre Pre,
    Regular Regular,
    Post Post
  );

  public record Meta
  (
    string Currency,
    string Symbol,
    string ExchangeName,
    string InstrumentType,
    double FirstTradeDate,
    double RegularMarketTime,
    double Gmtoffset,
    string Timezone,
    string ExchangeTimezoneName,
    double RchartPreviousClose,
    double PriceHint,
    CurrentTradingPeriod CurrentTradingPeriod,
    string DataGranularity,
    string Range,
    string[] ValidRanges
);
  public record IndicatorsQuote
  (
    double[] Close,
    double[] High,
    double[] Open,
    double[] Volume,
    double[] Low
  );
  public record Adjclose
  (
    double[] adjclose
  );
  public record Indicators
  (
    IndicatorsQuote[] Quote,
    Adjclose[] Adjclose
  );
  public record ChartResult
  (
    Meta Meta,
    double[] Timestamp,
    Indicators Indicators
  );
  public record Chart
  (
    ChartResult[] Result,
    Object? Error
  );
  public record Query2YahooFinanceV8ChartResponse
  (
    Chart Chart
  );

  public record SearchQuote
  (
    string Exchange,
    string Shortname,
    string QuoteType,
    string Symbol,
    string Index,
    double Score,
    string TypeDisp,
    string Longname,
    bool IsYahooFinance
  );

  public record Query2YahooFinanceV8SearchResponse
  (
    Object[] Explains,
    double Count,
    SearchQuote[] Quotes,
    Object[] News,
    Object[] Nav,
    Object[] Lists,
    Object[] ResearchReports,
    Object[] ScreenerFieldResults,
    double TotalTime,
    double TimeTakenForQuotes,
    double TimeTakenForNews,
    double TimeTakenForAlgowatchlist,
    double TimeTakenForPredefinedScreener,
    double TimeTakenForCrunchbase,
    double TimeTakenForNav,
    double TimeTakenForResearchReports,
    double TimeTakenForScreenerField
  );

  public record CurrentPrice
  (
    double Raw,
    string Fmt
  );

  public record TargetHighPrice
  (
    double Raw,
    string Fmt
  );

  public record TargetLowPrice
  (
    double Raw,
    string Fmt
  );

  public record TargetMeanPrice
  (
    double Raw,
    string Fmt
  );

  public record TargetMedianPrice
  (
    double Raw,
    string Fmt
  );

  public record RecommendationMean
  (
    double Raw,
    string Fmt
  );

  public record doubleOfAnalystOpinions
  (
    double Raw,
    string Fmt,
    string LongFmt
  );

  public record TotalCash
  (
    double Raw,
    string Fmt,
    string LongFmt
  );

  public record TotalCashPerShare
  (
    double Raw,
    string Fmt
  );

  public record Ebitda
  (
    double Raw,
    string Fmt,
    string LongFmt
  );

  public record TotalDebt
  (
    double Raw,
    string Fmt,
    string LongFmt
  );

  public record QuickRatio
  (
    double Raw,
    string Fmt
  );

  public record CurrentRatio
  (
    double Raw,
    string Fmt
  );

  public record TotalRevenue
  (
    double Raw,
    string Fmt,
    string LongFmt
  );

  public record DebtToEquity
  (
    double Raw,
    string Fmt
  );

  public record RevenuePerShare
  (
    double Raw,
    string Fmt
  );

  public record ReturnOnAssets
  (
    double Raw,
    string Fmt
  );

  public record ReturnOnEquity
  (
    double Raw,
    string Fmt
  );

  public record GrossProfits
  (
    double Raw,
    string Fmt,
    string LongFmt
  );

  public record FreeCashflow
  (
    double Raw,
    string Fmt,
    string LongFmt
  );

  public record OperatingCashflow
  (
    double Raw,
    string Fmt,
    string LongFmt
  );

  public record EarningsGrowth
  (
    double Raw,
    string Fmt
  );

  public record RevenueGrowth
  (
    double Raw,
    string Fmt
  );

  public record GrossMargins
  (
    double Raw,
    string Fmt
  );

  public record EbitdaMargins
  (
    double Raw,
    string Fmt
  );

  public record OperatingMargins
  (
    double Raw,
    string Fmt
  );

  public record ProfitMargins
  (
    double Raw,
    string Fmt
  );

  public record FinancialData
  (
    double MaxAge,
    CurrentPrice CurrentPrice,
    TargetHighPrice TargetHighPrice,
    TargetLowPrice TargetLowPrice,
    TargetMeanPrice TargetMeanPrice,
    TargetMedianPrice TargetMedianPrice,
    RecommendationMean RecommendationMean,
    string RecommendationKey,
    doubleOfAnalystOpinions DoubleOfAnalystOpinions,
    TotalCash TotalCash,
    TotalCashPerShare TotalCashPerShare,
    Ebitda Ebitda,
    TotalDebt TotalDebt,
    QuickRatio QuickRatio,
    CurrentRatio CurrentRatio,
    TotalRevenue TotalRevenue,
    DebtToEquity DebtToEquity,
    RevenuePerShare RevenuePerShare,
    ReturnOnAssets ReturnOnAssets,
    ReturnOnEquity ReturnOnEquity,
    GrossProfits GrossProfits,
    FreeCashflow FreeCashflow,
    OperatingCashflow OperatingCashflow,
    EarningsGrowth EarningsGrowth,
    RevenueGrowth RevenueGrowth,
    GrossMargins GrossMargins,
    EbitdaMargins EbitdaMargins,
    OperatingMargins OperatingMargins,
    ProfitMargins ProfitMargins,
    string FinancialCurrency
  );

  public record QuoteSummaryResult
  (
    FinancialData FinancialData
  );

  public record QuoteSummary
  (
    QuoteSummaryResult[] Result,
    object? Rrror
  );

  public record Query2YahooFinanceV8SearchQuoteSummary
  (
    QuoteSummary QuoteSummary
  );

}
