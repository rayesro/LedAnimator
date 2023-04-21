using LedAnimator.Domain.Exceptions;

namespace LedAnimator.Domain.Entities;

public class LedMatrix
{
  public Led[,] Leds{ get; set; }
  public int MatrixWidth { get; init; }
  public int MatrixHeight { get; init; }

  public LedMatrix(int matrixWidthParam, int matrixHeightParam)
  {
    MatrixWidth = matrixWidthParam;
    MatrixHeight = matrixHeightParam;
    Leds = new Led[MatrixWidth,MatrixHeight];
  }

  public void AssignIndexToLeds(int[,] indexArrayParam)
  {
    if (indexArrayParam == null && indexArrayParam?.Length == 0)
      throw new NullOrEmptyIndexArrayForLedMatrixException();
    if (indexArrayParam.Length != MatrixHeight * MatrixWidth)
      throw new MismatchIndexArrayLengthException();

    for (int i = 0; i < MatrixWidth; i++) 
    { 
      for (int j = 0; j < MatrixHeight; j++)
      {
        Leds[i,j].BoardIndex = indexArrayParam[i,j];
      }
    }
  }
}
