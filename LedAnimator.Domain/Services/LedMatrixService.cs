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
      for (int x = 0; x < _ledMatrix.MatrixWidth; x++)
        _ledMatrix.Leds[x, y].Color = _ledMatrix.Leds[x, y + 1].Color;

    if (!BlackOutAfterMoving)
      return;

    for (int x = 0; x < _ledMatrix.MatrixWidth; x++)
      _ledMatrix.Leds[x, _ledMatrix.MatrixHeight - 1].BlackOut();
  }

  public void MoveDown()
  {
    for (int y = _ledMatrix.MatrixHeight - 1; y > 0; y--)
      for (int x = 0; x < _ledMatrix.MatrixWidth; x++)
        _ledMatrix.Leds[x, y].Color = _ledMatrix.Leds[x, y - 1].Color;

    if (!BlackOutAfterMoving)
      return;

    for (int x = 0; x < _ledMatrix.MatrixWidth; x++)
      _ledMatrix.Leds[x, 0].BlackOut();
  }

  public void MoveToTheRigth()
  {
    for (int x = _ledMatrix.MatrixWidth-1; x > 0; x--)
      for (int y = 0; y < _ledMatrix.MatrixHeight; y++)
        _ledMatrix.Leds[x, y].Color = _ledMatrix.Leds[x - 1, y].Color;

    if (!BlackOutAfterMoving)
      return;

    for (int y = 0; y < _ledMatrix.MatrixHeight; y++)
      _ledMatrix.Leds[0, y].BlackOut();
  }

  public void MoveToTheLeft()
  {
    for (int x = 0; x < _ledMatrix.MatrixWidth - 1; x++)
      for (int y = 0; y < _ledMatrix.MatrixHeight; y++)
        _ledMatrix.Leds[x, y].Color = _ledMatrix.Leds[x + 1, y].Color;

    if (!BlackOutAfterMoving)
      return;

    for (int y = 0; y < _ledMatrix.MatrixHeight; y++)
      _ledMatrix.Leds[_ledMatrix.MatrixWidth-1, y].BlackOut();
  }

  public void MoveUpLeft()
  {
    MoveUp();
    MoveToTheLeft();
  }

  public void MoveUpRight()
  {
    MoveUp();
    MoveToTheRigth();
  }

  public void MoveDownLeft()
  {
    MoveDown();
    MoveToTheLeft();
  }

  public void MoveDownRight()
  {
    MoveDown();
    MoveToTheRigth();
  }
}
