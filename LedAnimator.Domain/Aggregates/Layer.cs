namespace LedAnimator.Core.Domain.Aggregates;

public class Layer
{
  public int Id { get; set; }
  //Lowest order number represent the layer at the bottom of the frame
  public int Order { get; set; }
  public MatrixBoard Matrix { get; set; }
  public bool IsVisible { get; set; }
}
