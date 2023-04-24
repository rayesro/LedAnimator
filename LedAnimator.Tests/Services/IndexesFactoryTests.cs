using LedAnimator.Core.Domain.Services;

namespace LedAnimator.Tests.Services;

public class IndexesFactoryTests
{
  [Test]
  public void GivenAWidthAndHeight_WhenGettingAnIndexArray_ThenIndexValuesMustMatchAccordingly()
  {
    var width = 3;
    var height = 3;

    var indexes = IndexesFactory.GetSnakeLikeIndexFromBottomLeft(width, height);

    Assert.That(indexes[0, 0], Is.EqualTo(8));
    Assert.That(indexes[0, 1], Is.EqualTo(7));
    Assert.That(indexes[0, 2], Is.EqualTo(6));

    Assert.That(indexes[1, 0], Is.EqualTo(3));
    Assert.That(indexes[1, 1], Is.EqualTo(4));
    Assert.That(indexes[1, 2], Is.EqualTo(5));

    Assert.That(indexes[2, 0], Is.EqualTo(2));
    Assert.That(indexes[2, 1], Is.EqualTo(1));
    Assert.That(indexes[2, 2], Is.EqualTo(0));
  }
}
