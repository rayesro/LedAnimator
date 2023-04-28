namespace LedAnimator.Core.Domain.Aggregates;

public class FrameLayer
{
  public int Id { get; set; }
  //Lowest order number represent the layer at the bottom of the frame
  public int Order { get; set; }
  public MatrixBoard Layer { get; set; }
  public bool IsVisible { get; set; }
}
