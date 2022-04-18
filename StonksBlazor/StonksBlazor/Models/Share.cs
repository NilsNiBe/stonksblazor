namespace StonksBlazor.Models
{
  public record Share(string Symbol, List<Purchase> Purchases, object ChartResult);

  public record Purchase(string Id, long Timestamp, int Amount);
}
