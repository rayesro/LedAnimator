using LedAnimator.Core.Domain.Services;

namespace LedAnimator.Tests.Services;

public class IndexesFactoryTests
{
  [Test]
  public void GivenAWidthAndHeight_WhenGettingAnIndexArray_ThenIndexValuesMustMatchAccordingly()
  {
    var width = 3;
    var height = 3;

    var indexes = IndexesFactory.GetSnakeLikeIndexFromBottomRight(width, height);

    var expectedIndexes = new[,]
    {
      { 6, 7, 8 },
      { 5, 4, 3 },
      { 0, 1, 2 }
    };

    Assert.That(indexes[0, 0], Is.EqualTo(expectedIndexes[2, 0]));
    Assert.That(indexes[1, 0], Is.EqualTo(expectedIndexes[2, 1]));
    Assert.That(indexes[2, 0], Is.EqualTo(expectedIndexes[2, 2]));

    Assert.That(indexes[0, 1], Is.EqualTo(expectedIndexes[1, 0]));
    Assert.That(indexes[1, 1], Is.EqualTo(expectedIndexes[1, 1]));
    Assert.That(indexes[2, 1], Is.EqualTo(expectedIndexes[1, 2]));

    Assert.That(indexes[0, 2], Is.EqualTo(expectedIndexes[0, 0]));
    Assert.That(indexes[1, 2], Is.EqualTo(expectedIndexes[0, 1]));
    Assert.That(indexes[2, 2], Is.EqualTo(expectedIndexes[0, 2]));
  }
}
