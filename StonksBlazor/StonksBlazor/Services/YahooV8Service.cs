using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace StonksBlazor.Services
{
  public class YahooV8Service
  {
    private static readonly Lazy<YahooV8Service> lazy =
      new(() => new YahooV8Service());
    public static YahooV8Service Instance => lazy.Value;
    private readonly HttpClient Http = new();

    private const string CorsProxy = "https://corsproxy.cloudno.de";
    private const string Chart = $"{CorsProxy}/https://query2.finance.yahoo.com/v8/finance/chart";
    private const string Search = $"{CorsProxy}/https://query2.finance.yahoo.com/v1/finance/search";
    private const string QuoteSummary = $"{CorsProxy}/https://query2.finance.yahoo.com/v10/finance/quoteSummary";

    /// <summary>
    /// Stock quote data
    /// </summary>
    /// <param name="symbol">stock symbol</param>
    /// <param name="interval">granularity (1m (for 7 days period max), 2m, 5m, 15m, 30m, 60m, 90m, 1h (for 730 day period max), 1d, 5d, 1wk, 1mo, 3mo)</param>
    /// <param name="period1">start of period in seconds</param>
    /// <param name="period2">end of period in seconds</param>
    public Task<Query2YahooFinanceV8ChartResponse> Query2FinanceYahooV8Chart(
      string symbol,
      string interval,
      long period1,
      long period2)
    {
      var request = new HttpRequestMessage(HttpMethod.Get,
        $"{Chart}/{symbol}?region=US&lang=en-US&interval={interval}&period1={period1}&period2={period2}");
      request.Headers.Add("x-requested-with", "XMLHttpRequest");
      return SendRequest<Query2YahooFinanceV8ChartResponse>(request);
    }

    /// <summary>
    /// Stock search
    /// </summary>
    /// <param name="symbol">Search input</param>
    public Task<Query2YahooFinanceV8SearchResponse> Query2FinanceYahooV8Search(
      string symbol)
    {
      var request = new HttpRequestMessage(HttpMethod.Get,
        $"{Search}?q={symbol}&quotesCount=6&newsCount=0");
      request.Headers.Add("x-requested-with", "XMLHttpRequest");
      return SendRequest<Query2YahooFinanceV8SearchResponse>(request);
    }

    /// <summary>
    /// Stock quote summary (current price, ...)
    /// </summary>
    /// <param name="symbol">stock symbol</param>
    public Task<Query2YahooFinanceV8SearchQuoteSummary> Query2FinanceYahooV8QuoteSummary(
      string symbol)
    {
      var request = new HttpRequestMessage(HttpMethod.Get,
        $"{QuoteSummary}/{symbol}?modules=financialData");
      request.Headers.Add("x-requested-with", "XMLHttpRequest");
      return SendRequest<Query2YahooFinanceV8SearchQuoteSummary>(request);
    }


    private async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
      var response = await Http.SendAsync(request);
      response.EnsureSuccessStatusCode();

      if (response.Content?.Headers?.ContentType?.MediaType == "application/json")
      {
        var res = await response.Content.ReadFromJsonAsync<T>();        
        if (res == null)
        {
          throw new Exception("Empty Response");
        }
        return res;
      }
      else
      {
        Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
      }
      throw new Exception("Invalid Media Type");
    }
  }
}
