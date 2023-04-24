using LedAnimator.Core.Domain.Aggregates;

namespace LedAnimator.Core.Domain.Services;

public class LedMatrixService
{
  private readonly MatrixBoard _ledMatrix;
  public bool BlackOutAfterMoving { get; set; }

  public LedMatrixService(MatrixBoard ledMatrix)
  {
    _ledMatrix=ledMatrix;
    BlackOutAfterMoving = false;
  }

  public void MoveUp()
  {
    for (int y = 0; y < _ledMatrix.MatrixHeight - 1; y++)
    {
      for (int x = 0; x < _ledMatrix.MatrixWidth; x++)
      {
        _ledMatrix.Leds[x, y] = _ledMatrix.Leds[x, y + 1];
      }
    }
    if (!BlackOutAfterMoving)
      return;

    for (int x = 0; x < _ledMatrix.MatrixWidth; x++)
    {
      _ledMatrix.Leds[x, _ledMatrix.MatrixHeight - 1].BlackOut();
    }
  }

  public void MoveDown()
  {
    for (int y = 0; y < _ledMatrix.MatrixHeight - 1; y++)
    {
      for (int x = 0; x < _ledMatrix.MatrixWidth; x++)
      {
        _ledMatrix.Leds[x, y] = _ledMatrix.Leds[x, y + 1];
      }
    }
    for (int y = _ledMatrix.MatrixHeight - 1; y > 0; y--)
    {
      for (int x = 0; x < _ledMatrix.MatrixWidth; x++)
      {
        _ledMatrix.Leds[x, y] = _ledMatrix.Leds[x, y + 1];
      }
    }

    if (!BlackOutAfterMoving)
      return;

    for (int x = 0; x < _ledMatrix.MatrixWidth; x++)
    {
      _ledMatrix.Leds[x, 0].BlackOut();
    }
  }
}
