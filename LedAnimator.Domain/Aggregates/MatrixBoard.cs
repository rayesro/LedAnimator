﻿using LedAnimator.Core.Domain.Exceptions;
using LedAnimator.Shared;

namespace LedAnimator.Core.Domain.Aggregates;

public class MatrixBoard
{
	public LedInMatrix[,] Leds { get; set; }
	public int MatrixWidth { get; init; }
	public int MatrixHeight { get; init; }

  public MatrixBoard(int matrixWidthParam, int matrixHeightParam, RGBColor? blackoutColorParam = null )
  {
    MatrixWidth = matrixWidthParam;
    MatrixHeight = matrixHeightParam;
    Leds = new LedInMatrix[MatrixWidth, MatrixHeight];
    for (int i = 0; i < MatrixWidth; i++)
      for (int j = 0; j < MatrixHeight; j++)
        Leds[i, j] = new LedInMatrix(blackoutColorParam);
  }

	public LedInMatrix this[int x, int y]
	{
		get { return GetLedByCoords(x, y); }
		set { Leds[x, y] = value; }
	}

  public int GetIndexByCoords(int xCoordParam, int yCoordParam)
  {
    if (xCoordParam > MatrixWidth || yCoordParam > MatrixHeight)
      throw new CoordsOutOfBoundsException();
    return Leds[xCoordParam, yCoordParam].BoardIndex;
  }

  private LedInMatrix GetLedByCoords(int xCoordParam, int yCoordParam)
  {
    if (xCoordParam > MatrixWidth || yCoordParam > MatrixHeight)
      throw new CoordsOutOfBoundsException();
    return Leds[xCoordParam, yCoordParam];
  }
  public void AssignIndexToLeds(int[,] indexArrayParam)
  {
    if (indexArrayParam == null)
      throw new NullOrEmptyIndexArrayForLedMatrixException();
    if (indexArrayParam.Length != MatrixHeight * MatrixWidth)
      throw new MismatchIndexArrayLengthException();

    for (int i = 0; i < MatrixWidth; i++)
      for (int j = 0; j < MatrixHeight; j++)
        Leds[j, i].BoardIndex = indexArrayParam[i, j];
  }

  public void AssignColorsToLeds(RGBColor[,] colorsArrayParam)
  {
    if (colorsArrayParam == null)
      throw new NullOrEmptyColorArrayForLedMatrixException();
    if (colorsArrayParam.Length != MatrixHeight * MatrixWidth)
      throw new MismatchColorArrayLengthException();

    for (int i = 0; i < MatrixWidth; i++)
      for (int j = 0; j < MatrixHeight; j++)
        Leds[j, i].Color = colorsArrayParam[i, j];
  }

  public LedInMatrix? GetLedByIndex(int indexParam)
  {
    LedInMatrix? led = null;
    for (int i = 0;i < MatrixWidth;i++)
      for (int j = 0;j < MatrixHeight;j++)
      {
        if (Leds[i, j].BoardIndex != indexParam)
          continue;
        led = Leds[i, j];
        break;
      }
    return led;
  }

}
