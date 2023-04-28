using LedAnimator.Core.Domain.Aggregates;
using LedAnimator.Core.Domain.Services;
using LedAnimator.Shared;

namespace LedAnimator.Tests.Services;

public class LedMatrixServiceTests
{
  [Test]
  public void GivenA3by3Matrix_WhenMovingItUpAndBlackingItOut_ThenLastRowMustBeBlackedOut()
  {
    var width = 3;
    var height = 3;
    var initialColoredMatrix = new[,]
    {
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.RED, Colors.GREEN, Colors.BLUE }
    };

    var expectedColoredMatrix = new[,]
    {
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.BLACK, Colors.BLACK, Colors.BLACK}
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignColorsToLeds(initialColoredMatrix);

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveUp();

    for (var i = 0; i < width; i++)
      for (var j = 0; j < height; j++)
        Assert.That(matrix[j, i].Color, Is.EqualTo(expectedColoredMatrix[i, j]));
  }
  [Test]
  public void GivenA3by3Matrix_WhenMovingItUpAndBlackingItOutWithCustomColor_ThenLastRowMustBeBlackedOut()
  {
    var width = 3;
    var height = 3;
    var initialColoredMatrix = new[,]
      {
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.RED, Colors.GREEN, Colors.BLUE }
    };

    var customColor = Colors.DARK_MAGENTA;

    var expectedColoredMatrix = new[,]
    {
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.DARK_MAGENTA, Colors.DARK_MAGENTA, Colors.DARK_MAGENTA}
    };

    var matrix = new MatrixBoard(width, height, customColor);
    matrix.AssignColorsToLeds(initialColoredMatrix);

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveUp();

    for (var i = 0; i < width; i++)
      for (var j = 0; j < height; j++)
        Assert.That(matrix[j, i].Color, Is.EqualTo(expectedColoredMatrix[i, j]));
  }

  [Test]
  public void GivenA3by3Matrix_WhenMovingItUp_ThenLastRowMustBeTheSameAsThePreLastOne()
  {
    var width = 3;
    var height = 3;
    var initialColoredMatrix = new[,]
    {
      { Colors.RED, Colors.RED, Colors.RED },
      { Colors.GREEN, Colors.GREEN, Colors.GREEN },
      { Colors.BLUE ,Colors.BLUE, Colors.BLUE }
    };

    var expectedColoredMatrix = new[,]
    {
      { Colors.GREEN, Colors.GREEN, Colors.GREEN },
      { Colors.BLUE, Colors.BLUE, Colors.BLUE },
      { Colors.BLUE, Colors.BLUE, Colors.BLUE },
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignColorsToLeds(initialColoredMatrix);

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = false;
    service.MoveUp();

    for (var i = 0; i < width; i++)
      for (var j = 0; j < height; j++)
        Assert.That(matrix[j, i].Color, Is.EqualTo(expectedColoredMatrix[i, j]));
  }

  [Test]
  public void GivenA3by3Matrix_WhenMovingItDown_ThenFirstRowMustBeBlackedOut()
  {
    var width = 3;
    var height = 3;
    var initialColoredMatrix = new[,]
    {
      { Colors.RED, Colors.RED, Colors.RED },
      { Colors.GREEN, Colors.GREEN, Colors.GREEN },
      { Colors.BLUE ,Colors.BLUE, Colors.BLUE }
    };

    var expectedColoredMatrix = new[,]
    {
      { Colors.BLACK, Colors.BLACK, Colors.BLACK },
      { Colors.RED, Colors.RED, Colors.RED },
      { Colors.GREEN, Colors.GREEN, Colors.GREEN }
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignColorsToLeds(initialColoredMatrix);

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveDown();

    for (var i = 0; i < width; i++)
      for (var j = 0; j < height; j++)
        Assert.That(matrix[j, i].Color, Is.EqualTo(expectedColoredMatrix[i, j]));
  }

  [Test]
  public void GivenA3by3Matrix_WhenMovingItToTheRight_ThenFirstColumnMustBlackedOut()
  {
    var width = 3;
    var height = 3;
    var initialColoredMatrix = new[,]
    {
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.RED, Colors.GREEN, Colors.BLUE }
    };

    var expectedColoredMatrix = new[,]
    {
      { Colors.BLACK, Colors.RED, Colors.GREEN},
      { Colors.BLACK, Colors.RED, Colors.GREEN},
      { Colors.BLACK, Colors.RED, Colors.GREEN}
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignColorsToLeds(initialColoredMatrix);

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveToTheRigth();

    for (var i = 0; i < width; i++)
      for (var j = 0; j < height; j++)
        Assert.That(matrix[j, i].Color, Is.EqualTo(expectedColoredMatrix[i, j]));
  }

  [Test]
  public void GivenA3by3Matrix_WhenMovingItToTheLeft_ThenLastColumnMustBlackedOut()
  {
    var width = 3;
    var height = 3;
    var initialColoredMatrix = new[,]
    {
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.RED, Colors.GREEN, Colors.BLUE },
      { Colors.RED, Colors.GREEN, Colors.BLUE }
    };

    var expectedColoredMatrix = new[,]
    {
      { Colors.GREEN, Colors.BLUE, Colors.BLACK },
      { Colors.GREEN, Colors.BLUE, Colors.BLACK },
      { Colors.GREEN, Colors.BLUE, Colors.BLACK }
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignColorsToLeds(initialColoredMatrix);

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveToTheLeft();

    for (var i = 0; i < width; i++)
      for (var j = 0; j < height; j++)
        Assert.That(matrix[j, i].Color, Is.EqualTo(expectedColoredMatrix[i, j]));
  }

  [Test]
  public void GivenA3by3Matrix_WhenMovingItUpAndToTheLeft_ThenBottomRowAndLastColumnMustBeBlackedOut()
  {
    var width = 3;
    var height = 3;
    var initialColoredMatrix = new[,]
    {
      { Colors.RED,   Colors.BLUE,  Colors.GREEN },
      { Colors.GREEN, Colors.RED,   Colors.BLUE },
      { Colors.BLUE,  Colors.GREEN, Colors.RED }
    };

    var expectedColoredMatrix = new[,]
    {
      { Colors.RED,   Colors.BLUE,  Colors.BLACK},
      { Colors.GREEN, Colors.RED,   Colors.BLACK},
      { Colors.BLACK, Colors.BLACK, Colors.BLACK}
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignColorsToLeds(initialColoredMatrix);

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveUpLeft();

    for (var i = 0; i < width; i++)
      for (var j = 0; j < height; j++)
        Assert.That(matrix[j, i].Color, Is.EqualTo(expectedColoredMatrix[i, j]));
  }

  [Test]
  public void GivenA3by3Matrix_WhenMovingItUpAndToTheRight_ThenBottomRowAndFirstColumnMustBeBlackedOut()
  {
    var width = 3;
    var height = 3;
    var initialColoredMatrix = new[,]
    {
      { Colors.RED,   Colors.BLUE,  Colors.GREEN },
      { Colors.GREEN, Colors.RED,   Colors.BLUE },
      { Colors.BLUE,  Colors.GREEN, Colors.RED }
    };

    var expectedColoredMatrix = new[,]
    {
      { Colors.BLACK, Colors.GREEN, Colors.RED},
      { Colors.BLACK, Colors.BLUE,  Colors.GREEN},
      { Colors.BLACK, Colors.BLACK, Colors.BLACK}
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignColorsToLeds(initialColoredMatrix);

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveUpRight();

    for (var i = 0; i < width; i++)
      for (var j = 0; j < height; j++)
        Assert.That(matrix[j, i].Color, Is.EqualTo(expectedColoredMatrix[i, j]));
  }

  [Test]
  public void GivenA3by3Matrix_WhenMovingItDownAndToTheLeft_ThenTopRowAndLastColumnMustBeBlackedOut()
  {
    var width = 3;
    var height = 3;
    var initialColoredMatrix = new[,]
    {
      { Colors.RED,   Colors.BLUE,  Colors.GREEN },
      { Colors.GREEN, Colors.RED,   Colors.BLUE },
      { Colors.BLUE,  Colors.GREEN, Colors.RED }
    };

    var expectedColoredMatrix = new[,]
    {
      { Colors.BLACK, Colors.BLACK, Colors.BLACK },
      { Colors.BLUE,  Colors.GREEN, Colors.BLACK },
      { Colors.RED,   Colors.BLUE,  Colors.BLACK }
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignColorsToLeds(initialColoredMatrix);

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveDownLeft();

    for (var i = 0; i < width; i++)
      for (var j = 0; j < height; j++)
        Assert.That(matrix[j, i].Color, Is.EqualTo(expectedColoredMatrix[i, j]));
  }

  [Test]
  public void GivenA3by3Matrix_WhenMovingItDownAndToTheRight_ThenTopmRowAndFirstColumnMustBeBlackedOut()
  {
    var width = 3;
    var height = 3;
    var initialColoredMatrix = new[,]
    {
      { Colors.RED,   Colors.BLUE,  Colors.GREEN },
      { Colors.GREEN, Colors.RED,   Colors.BLUE },
      { Colors.BLUE,  Colors.GREEN, Colors.RED }
    };

    var expectedColoredMatrix = new[,]
    {
      { Colors.BLACK, Colors.BLACK, Colors.BLACK},
      { Colors.BLACK, Colors.RED,   Colors.BLUE},
      { Colors.BLACK, Colors.GREEN, Colors.RED}
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignColorsToLeds(initialColoredMatrix);

    var service = new LedMatrixService(matrix);
    service.BlackOutAfterMoving = true;
    service.MoveDownRight();

    for (var i = 0; i < width; i++)
      for (var j = 0; j < height; j++)
        Assert.That(matrix[j, i].Color, Is.EqualTo(expectedColoredMatrix[i, j]));
  }

  [Test]
  public void GivenA3by3Matrix_WhenGeneratingIndexesWithFactory_ThenIndexesMustMatch()
  {
    var width = 3;
    var height = 3;
    var indexes = IndexesFactory.GetSnakeLikeIndexFromBottomRight(width, height);

    var expectedIndexes = new[,]
    {
      { 6, 7, 8},
      { 5, 4, 3},
      { 0, 1 ,2}
    };

    var matrix = new MatrixBoard(width, height);
    matrix.AssignIndexToLeds(indexes);

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
