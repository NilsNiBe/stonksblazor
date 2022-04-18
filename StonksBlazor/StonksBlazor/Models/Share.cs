namespace StonksBlazor.Models
{
  public record Share(string Symbol, List<Purchase> Purchases, object ChartResult);

  public record Purchase(string Id, double Timestamp, int Amount);
}
