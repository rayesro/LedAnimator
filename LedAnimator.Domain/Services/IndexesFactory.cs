namespace LedAnimator.Core.Domain.Services;

public static class IndexesFactory
{
  public static int[,] GetSnakeLikeIndexFromBottomLeft(int widthParam, int heightParam)
  {
    var indexes = new int[widthParam, heightParam];
    for (int y = 0; y < heightParam; y++) 
    {
      for (int x = 0; x < widthParam; x++)
      {
        int index;
        int xCoord = widthParam*(widthParam-1-x);
        if (x % 2 > 0)
          index = xCoord + y;
        else
          index = xCoord + heightParam - 1 - y;
        indexes[x, y] = index;
      }
    }
    return indexes;
  }
}
