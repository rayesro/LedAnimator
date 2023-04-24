using LedAnimator.Shared;

namespace LedAnimator.Core.Domain.Entities;
public class Led
{
  public int BoardIndex { get; set; }
  public RGBColor Color { get; set; }
  public RGBColor BlackoutColor { get; set; }

  public Led(RGBColor? blackoutColorParam = null)
  {
    if(blackoutColorParam == null)
      BlackoutColor = Colors.BLACK;
    else
      BlackoutColor = blackoutColorParam;
  }

  public void Paint(byte redParam, byte greenParam, byte blueParam)
  {
    Color = new RGBColor(redParam, greenParam, blueParam);
  }

  public void BlackOut()
  {
    Color = BlackoutColor;
  }

}


