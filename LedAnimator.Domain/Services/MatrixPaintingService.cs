using LedAnimator.Core.Domain.Aggregates;
using LedAnimator.Shared;

namespace LedAnimator.Core.Domain.Services;

public class MatrixPaintingService
{
  private readonly int _matrixWidth, _matrixHeight;
  public bool BlackOutAfterMoving { get; set; }

  public MatrixPaintingService(int matrixWidth, int matrixHeight)
  {
    BlackOutAfterMoving = false;

    _matrixWidth=matrixWidth;
    _matrixHeight=matrixHeight;
  }

  public void MoveUp(MatrixBoard ledMatrixParam)
  {
    for (int y = 0; y < ledMatrixParam.MatrixHeight - 1; y++)
      for (int x = 0; x < ledMatrixParam.MatrixWidth; x++)
        ledMatrixParam.Leds[x, y].Color = ledMatrixParam.Leds[x, y + 1].Color;

    if (!BlackOutAfterMoving)
      return;

    for (int x = 0; x < ledMatrixParam.MatrixWidth; x++)
      ledMatrixParam.BlackOutLed(x, ledMatrixParam.MatrixHeight - 1);
  }

  public void MoveDown(MatrixBoard ledMatrixParam)
  {
    for (int y = ledMatrixParam.MatrixHeight - 1; y > 0; y--)
      for (int x = 0; x < ledMatrixParam.MatrixWidth; x++)
        ledMatrixParam.Leds[x, y].Color = ledMatrixParam.Leds[x, y - 1].Color;

    if (!BlackOutAfterMoving)
      return;

    for (int x = 0; x < ledMatrixParam.MatrixWidth; x++)
      ledMatrixParam.BlackOutLed(x, 0);
  }

  public void MoveToTheRigth(MatrixBoard ledMatrixParam)
  {
    for (int x = ledMatrixParam.MatrixWidth-1; x > 0; x--)
      for (int y = 0; y < ledMatrixParam.MatrixHeight; y++)
        ledMatrixParam.Leds[x, y].Color = ledMatrixParam.Leds[x - 1, y].Color;

    if (!BlackOutAfterMoving)
      return;

    for (int y = 0; y < ledMatrixParam.MatrixHeight; y++)
      ledMatrixParam.BlackOutLed(0, y);
  }

  public void MoveToTheLeft(MatrixBoard ledMatrixParam)
  {
    for (int x = 0; x < ledMatrixParam.MatrixWidth - 1; x++)
      for (int y = 0; y < ledMatrixParam.MatrixHeight; y++)
        ledMatrixParam.Leds[x, y].Color = ledMatrixParam.Leds[x + 1, y].Color;

    if (!BlackOutAfterMoving)
      return;

    for (int y = 0; y < ledMatrixParam.MatrixHeight; y++)
      ledMatrixParam.BlackOutLed(ledMatrixParam.MatrixWidth - 1, y);
  }

  public void MoveUpLeft(MatrixBoard ledMatrixParam)
  {
    MoveUp(ledMatrixParam);
    MoveToTheLeft(ledMatrixParam);
  }

  public void MoveUpRight(MatrixBoard ledMatrixParam)
  {
    MoveUp(ledMatrixParam);
    MoveToTheRigth(ledMatrixParam);
  }

  public void MoveDownLeft(MatrixBoard ledMatrixParam)
  {
    MoveDown(ledMatrixParam);
    MoveToTheLeft(ledMatrixParam);
  }

  public void MoveDownRight(MatrixBoard ledMatrixParam)
  {
    MoveDown(ledMatrixParam);
    MoveToTheRigth(ledMatrixParam);
  }


  public MatrixBoard GetFramesMerged(List<Layer> layersParam)
  {
    MatrixBoard frame = new MatrixBoard(_matrixWidth, _matrixHeight);
    var layers = layersParam.OrderBy(x => x.Order).ToList();

    /*
     * We start checking colors from the frontest layer on led at time.
     * If the led on the frontest layer is not a blackout one, then that color
     * goes to the frame, and we skip to the next led.
     * But if the led is blacked out, then we check the led in the next frontest layer.
     */
    for (var y = 0; y < _matrixHeight; y++)
    {
      for (var x = 0; x < _matrixWidth; x++)
      {
        for (int l = layers.Count - 1; l >= 0; l--)
        {
          if (layers[l].Matrix.Leds[x, y].Color == layers[l].Matrix.BlackoutColor)
            continue;
          frame[x, y].Color = layers[l].Matrix.Leds[x, y].Color;
          break;
        }
      }
    }
    return frame;
  }

  public void PaintColumn(MatrixBoard ledMatrixParam, int columnParam, RGBColor colorParam)
  {
    for (var y = 0; y < _matrixHeight; y++)
      ledMatrixParam.Leds[columnParam, y].Color = colorParam;
  }

  public void PaintRow(MatrixBoard ledMatrixParam, int rowParam, RGBColor colorParam)
  {
    for (var x = 0; x < _matrixWidth; x++)
      ledMatrixParam.Leds[x, rowParam].Color = colorParam;
  }
}
