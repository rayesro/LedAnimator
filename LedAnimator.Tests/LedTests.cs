using LedAnimator.Core.Domain.Entities;

namespace LedAnimator.Tests;

public class LedTests
{
  [Test]
  public void GivenRGBValues_WhenPaintingALed_ThenLedMustHaveSameColor()
  {
    byte red = 255;
    byte green = 128;
    byte blue = 64;

    var led = new Led();
    led.Paint(red, green, blue);

    Assert.That(led.Color.Red, Is.EqualTo(red));
    Assert.That(led.Color.Green, Is.EqualTo(green));
    Assert.That(led.Color.Blue, Is.EqualTo(blue));
  }

  [Test]
  public void GivenAPaintedLed_WhenBlackingItOut_ThenRGBColorsMustBeZero()
  {
    byte red = 255;
    byte green = 128;
    byte blue = 64;
    var led = new Led();
    led.Paint(red, green, blue);

    led.BlackOut();

    Assert.That(led.Color.Red, Is.EqualTo(0));
    Assert.That(led.Color.Green, Is.EqualTo(0));
    Assert.That(led.Color.Blue, Is.EqualTo(0));
  }


}
