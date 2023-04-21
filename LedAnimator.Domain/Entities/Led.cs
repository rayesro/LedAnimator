using LedAnimator.Domain.ValueObjects;

namespace LedAnimator.Domain.Entities;
public class Led
{
  public int BoardIndex { get; set; }
  public RGBColor Color { get; set; }


  public void Paint(byte redParam, byte greenParam, byte blueParam)
  {
    Color.Red = redParam;
    Color.Green = greenParam;
    Color.Blue = blueParam;
  }

  public void BlackOut()
  {
    Color.Red = 0;
    Color.Green = 0;
    Color.Blue = 0;
  }

}

