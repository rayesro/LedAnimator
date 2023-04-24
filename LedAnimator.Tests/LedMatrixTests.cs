using LedAnimator.Core.Domain.Aggregates;
using LedAnimator.Core.Domain.Exceptions;
using LedAnimator.Core.Domain.Services;
using LedAnimator.Shared;

namespace LedAnimator.Tests;

public class LedMatrixTests
{
  [Test]
  public void GivenAWidthAndHeight_WhenCreatingALedMatrix_ThenMatrixMustHaveACapacityOfWitdthTimesHeightLeds()
  {
    var width = 16;
    var height = 16;

    var matrix = new MatrixBoard(width, height);

    Assert.That(matrix.Leds.Length, Is.EqualTo(width * height));
  }

  [Test]
  public void GivenAnNullIndexArray_WhenAssignigIndexToLeds_ThenThrowAnException()
  {
    var width = 16;
    var height = 16;

    var matrix = new MatrixBoard(width, height);

    Assert.Throws<NullOrEmptyIndexArrayForLedMatrixException>(() => matrix.AssignIndexToLeds(null));
  }

  [Test]
  public void GivenAn3By3IndexArrayAndA16By16Matrix_WhenAssignigIndexToLeds_ThenThrowAnException()
  {
    var width = 16;
    var height = 16;

    var matrix = new MatrixBoard(width, height);
    var indices = new int[,]
    {
      { 1, 2, 3 },
      { 4, 5, 6 },
      { 7, 8, 9 },
    };

    Assert.Throws<MismatchIndexArrayLengthException>(() => matrix.AssignIndexToLeds(indices));
  }

  [TestCase(0, 0 ,1)]
  [TestCase(1, 0, 2)]
  [TestCase(2, 0, 3)]
  [TestCase(0, 1, 4)]
  [TestCase(1, 1, 5)]
  [TestCase(2, 1, 6)]
  [TestCase(0, 2, 7)]
  [TestCase(1, 2, 8)]
  [TestCase(2, 2, 9)]
  public void GivenXandYCoordsOfAn3by3LedMatrix_WhenAssignigIndexFromTopLeftToBottomRight_ThenIndexesShouldFollowTheOrder
    (int xCoordParam, int yCoordParam, int expectedIndexParam)
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

    Assert.That(matrix.GetIndexByCoords(xCoordParam, yCoordParam), Is.EqualTo(expectedIndexParam));
  }

  [TestCase(0, 4)]
  [TestCase(4, 0)]
  [TestCase(4, 4)]
  public void GivenAnXandYCoordsOutOfBoundsOfAn3by3LedMatrix_WhenGettingIndexByCoords_ThenThrowAnException(int xCoordParam, int yCoordParam)
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

    Assert.Throws<CoordsOutOfBoundsException>(() => matrix.GetIndexByCoords(xCoordParam, yCoordParam));
  }

  [TestCase(0, 0, 1)]
  [TestCase(1, 0, 2)]
  [TestCase(2, 0, 3)]
  [TestCase(0, 1, 4)]
  [TestCase(1, 1, 5)]
  [TestCase(2, 1, 6)]
  [TestCase(0, 2, 7)]
  [TestCase(1, 2, 8)]
  [TestCase(2, 2, 9)]
  public void GivenXandYCoordsOfAn3by3LedMatrix_WhenUsingArrayNotation_ThenIndexesShouldFollowTheOrder
    (int xCoordParam, int yCoordParam, int expectedIndexParam)
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

    Assert.That(matrix[xCoordParam, yCoordParam].BoardIndex, Is.EqualTo(expectedIndexParam));
  }

  [TestCase(0, 4)]
  [TestCase(4, 0)]
  [TestCase(4, 4)]
  public void GivenAnXandYCoordsOutOfBoundsOfAn3by3LedMatrix_WhenUsingArrayNotation_ThenThrowAnException(int xCoordParam, int yCoordParam)
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

    Assert.Throws<CoordsOutOfBoundsException>(() => { var sm = matrix[xCoordParam, yCoordParam]; }) ;
  }

  [Test]
  public void GivenA3by3Matrix_WhenGettingALedByIndex_ThenLedInMatrixMustHaveTheAssignedColor()
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
    for (int i = 0; i < height; i++)
      for (int j = 0; j < width; j++)
        matrix[j, i].Color = i switch
        {
          0 => Colors.RED,
          1 => Colors.GREEN,
          2 => Colors.BLUE,
          _ => throw new NotImplementedException()
        };

    matrix.AssignIndexToLeds(indices);

    Assert.That(matrix[0, 0].Color, Is.EqualTo(Colors.RED));
    Assert.That(matrix.GetLedByIndex(1).Color, Is.EqualTo(Colors.RED));

    Assert.That(matrix[1, 0].Color, Is.EqualTo(Colors.RED));
    Assert.That(matrix.GetLedByIndex(2).Color, Is.EqualTo(Colors.RED));

    Assert.That(matrix[2, 0].Color, Is.EqualTo(Colors.RED));
    Assert.That(matrix.GetLedByIndex(3).Color, Is.EqualTo(Colors.RED));


    Assert.That(matrix[0, 1].Color, Is.EqualTo(Colors.GREEN));
    Assert.That(matrix.GetLedByIndex(4).Color, Is.EqualTo(Colors.GREEN));

    Assert.That(matrix[1, 1].Color, Is.EqualTo(Colors.GREEN));
    Assert.That(matrix.GetLedByIndex(5).Color, Is.EqualTo(Colors.GREEN));

    Assert.That(matrix[2, 1].Color, Is.EqualTo(Colors.GREEN));
    Assert.That(matrix.GetLedByIndex(6).Color, Is.EqualTo(Colors.GREEN));


    Assert.That(matrix[0, 2].Color, Is.EqualTo(Colors.BLUE));
    Assert.That(matrix.GetLedByIndex(7).Color, Is.EqualTo(Colors.BLUE));

    Assert.That(matrix[1, 2].Color, Is.EqualTo(Colors.BLUE));
    Assert.That(matrix.GetLedByIndex(8).Color, Is.EqualTo(Colors.BLUE));

    Assert.That(matrix[2, 2].Color, Is.EqualTo(Colors.BLUE));
    Assert.That(matrix.GetLedByIndex(9).Color, Is.EqualTo(Colors.BLUE));
  }

  [Test]
  public void GivenA3by3Matrix_WhenAssigningA2b2ColorMatrix_ThenColorsMustMatchByXandYCoords()
  {
    var width = 3;
    var height = 3;

    var expectedColors = new[,]
    {
      { Colors.BLACK, Colors.RED, Colors.GREEN },
      { Colors.BLACK, Colors.RED, Colors.GREEN },
      { Colors.BLACK, Colors.RED, Colors.GREEN }
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignColorsToLeds(expectedColors);

   Assert.That(matrix[0, 0].Color, Is.EqualTo(expectedColors[0, 0]));
   Assert.That(matrix[1, 0].Color, Is.EqualTo(expectedColors[0, 1]));
   Assert.That(matrix[2, 0].Color, Is.EqualTo(expectedColors[0, 2]));

  Assert.That(matrix[0, 1].Color, Is.EqualTo(expectedColors[1, 0]));
  Assert.That(matrix[1, 1].Color, Is.EqualTo(expectedColors[1, 1]));
  Assert.That(matrix[2, 1].Color, Is.EqualTo(expectedColors[1, 2]));

  Assert.That(matrix[0, 2].Color, Is.EqualTo(expectedColors[2, 0]));
  Assert.That(matrix[1, 2].Color, Is.EqualTo(expectedColors[2, 1]));
  Assert.That(matrix[2, 2].Color, Is.EqualTo(expectedColors[2, 2]));


  }

}
