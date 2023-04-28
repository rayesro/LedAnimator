namespace LedAnimator.Core.Domain.Services;

public static class IndexesFactory
{
  public static int[,] GetSnakeLikeIndexFromBottomRight(int widthParam, int heightParam)
  {
    var indexes = new int[widthParam, heightParam];

    for (int i = heightParam - 1 , count = 0; i >= 0 ; i--)
    {
      for (int j = 0; j < widthParam; j++)
      {
        int x, y;
        if (i % 2 == 0)
        {
          x = j;
          y = heightParam - 1 - i;
          
        }
        else
        {
          x = widthParam - 1 - j;
          y = heightParam - 1 - i;
        }

        indexes[x, y] = count++;
      }
    }
    
    return indexes;
  }
}
