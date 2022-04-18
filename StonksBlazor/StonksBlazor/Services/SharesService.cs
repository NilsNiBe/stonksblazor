namespace StonksBlazor.Services
{
    public class SharesService
    {
    private static readonly Lazy<SharesService> lazy =
      new(() => new SharesService());
    public static SharesService Instance => lazy.Value;

    public async Task<ChartResult> GetChartResultFromApi(
      string symbol,
      long fromTimestampMilliseconds)
    {
      var nowTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
      var fromTimestampSeconds = (long)Math.Round((double)fromTimestampMilliseconds / 1000);
      var res = await YahooV8Service.Instance.Query2FinanceYahooV8Chart(
        symbol, "1d", fromTimestampSeconds, nowTimestamp);
      return res.Chart.Result[0];
    }
  }
}
