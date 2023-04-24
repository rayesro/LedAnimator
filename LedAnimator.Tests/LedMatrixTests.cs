using LedAnimator.Core.Domain.Aggregates;
using LedAnimator.Core.Domain.Exceptions;

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

}
