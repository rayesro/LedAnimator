using LedAnimator.Core.Domain.Entities;
using LedAnimator.Shared;

namespace LedAnimator.Core.Domain.Aggregates;

public class LedInMatrix : Led
{
  public int XCoord { get; set; }
  public int YCoord { get; set; }

  public LedInMatrix(RGBColor? blackoutColorParam = null)
    : base(blackoutColorParam) {  }
}
