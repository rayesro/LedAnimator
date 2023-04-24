using LedAnimator.Core.Domain.Aggregates;
using LedAnimator.Core.Domain.Services;
using LedAnimator.Shared;

namespace LedAnimator.Tests;

public class LedMatrixServiceTests
{
  [Test]
  public void GivenA3by3Matrix_WhenMovingItUp_ThenLastTwoRowsMustBeTheSameAndFirstIndexMustNotBePresent()
  {
    var width = 3;
    var height = 3;
    var indices = new int[,]
    {
      { 1, 2, 3 },
      { 4, 5, 6 },
      { 7, 8, 9 },
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignIndexToLeds(indices);

    var service = new LedMatrixService(matrix);
    service.MoveUp();

    Assert.That(matrix.GetIndexByCoords(0, 1), Is.EqualTo(matrix.GetIndexByCoords(0, 2)));
    Assert.That(matrix.GetIndexByCoords(1, 1), Is.EqualTo(matrix.GetIndexByCoords(1, 2)));
    Assert.That(matrix.GetIndexByCoords(2, 1), Is.EqualTo(matrix.GetIndexByCoords(2, 2)));

    Assert.That(matrix.GetIndexByCoords(0, 0), Is.Not.EqualTo(1));
    Assert.That(matrix.GetIndexByCoords(0, 1), Is.Not.EqualTo(2));
    Assert.That(matrix.GetIndexByCoords(0, 2), Is.Not.EqualTo(3));

    Assert.That(matrix.GetIndexByCoords(0, 0), Is.EqualTo(4));
    Assert.That(matrix.GetIndexByCoords(1, 0), Is.EqualTo(5));
    Assert.That(matrix.GetIndexByCoords(2, 0), Is.EqualTo(6));
  }

  [Test]
  public void GivenA3by3Matrix_WhenMovingItUpAndBlackingOutLastRow_ThenLastRowMustBeBlack()
  {
    var width = 3;
    var height = 3;
    var matrix = new MatrixBoard(width, height);

    matrix[0, 0].Color = Colors.RED;
    matrix[1, 0].Color = Colors.RED;
    matrix[2, 0].Color = Colors.RED;

    matrix[0, 1].Color = Colors.GREEN;
    matrix[1, 1].Color = Colors.GREEN;
    matrix[2, 1].Color = Colors.GREEN;

    matrix[0, 2].Color = Colors.BLUE;
    matrix[1, 2].Color = Colors.BLUE;
    matrix[2, 2].Color = Colors.BLUE;

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveUp();

    Assert.That(matrix.Leds[0, 2].Color, Is.EqualTo(Colors.BLACK));
    Assert.That(matrix.Leds[1, 2].Color, Is.EqualTo(Colors.BLACK));
    Assert.That(matrix.Leds[2, 2].Color, Is.EqualTo(Colors.BLACK));
  }

  [Test]
  public void GivenA3by3Matrix_WhenMovingItUpAndBlackingOutLastRowAndUsingACustomBlackoutColor_ThenLastRowMustTheCustomBlackoutColor()
  {
    var width = 3;
    var height = 3;
    var customColor = new RGBColor(126, 56, 78);
    var matrix = new MatrixBoard(width, height,customColor);

    matrix[0, 0].Color = Colors.RED;
    matrix[1, 0].Color = Colors.RED;
    matrix[2, 0].Color = Colors.RED;

    matrix[0, 1].Color = Colors.GREEN;
    matrix[1, 1].Color = Colors.GREEN;
    matrix[2, 1].Color = Colors.GREEN;

    matrix[0, 2].Color = Colors.BLUE;
    matrix[1, 2].Color = Colors.BLUE;
    matrix[2, 2].Color = Colors.BLUE;

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveUp();

    Assert.That(matrix.Leds[0, 2].Color, Is.EqualTo(customColor));
    Assert.That(matrix.Leds[1, 2].Color, Is.EqualTo(customColor));
    Assert.That(matrix.Leds[2, 2].Color, Is.EqualTo(customColor));
  }
}
