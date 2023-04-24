namespace LedAnimator.Shared
{
  public class RGBColor 
  {
    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }

    public RGBColor(byte redParam, byte greenParam, byte blueParam)
    {
      Red=redParam;
      Green=greenParam;
      Blue=blueParam;
    }
  }
}