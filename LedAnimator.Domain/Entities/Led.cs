using LedAnimator.Shared;

namespace LedAnimator.Core.Domain.Entities;
public class Led
{
  public int BoardIndex { get; set; }
  public RGBColor Color { get; set; }
  

  public void Paint(byte redParam, byte greenParam, byte blueParam)
  {
    Color = new RGBColor(redParam, greenParam, blueParam);
  }

  public void BlackOut(RGBColor blackoutColorParam)
  {
    Color = blackoutColorParam;
  }

}


