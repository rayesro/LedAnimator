using LedAnimator.Core.Domain.Aggregates;

namespace LedAnimator.Core.Domain.Services;

public class LayerManagerService
{
  private List<FrameLayer> _layers = new List<FrameLayer>();
  private int _layerIds = 0; 

  public void CreateNewLayer(MatrixBoard matrixBoardParam)
  {
    FrameLayer layer = new FrameLayer()
    {
      Id = _layerIds,
      IsVisible = true,
      Layer = matrixBoardParam,
      Order = _layerIds
    };
    _layers.Add(layer);
    _layerIds++;
  }

  public void RemoveLayerById(int frameLayerIdParam)
  {
    var layer = _layers.FirstOrDefault(x => x.Id == frameLayerIdParam);
    if (layer != null)
    {
      _layers.Remove(layer);
    }
  }

  public void SendToBack(FrameLayer layerParam)
  {
    _layers = _layers.OrderBy(x => x.Order).ToList();
    var index = _layers.IndexOf(layerParam);
    if(index == 0)
    {
      return;
    }

    var order = layerParam.Order;
    layerParam.Order = _layers[index - 1].Order;
    _layers[index - 1].Order = order;

  }

  public void SendBackward(FrameLayer layerParam)
  {
    _layers = _layers.OrderBy(x => x.Order).ToList();
    var index = _layers.IndexOf(layerParam);
    if (index == 0)
    {
      return;
    }

    var order = layerParam.Order;
    layerParam.Order = _layers[0].Order;
    _layers[0].Order = order;
  }

  public void BringToFront(FrameLayer layerParam)
  {
    _layers = _layers.OrderBy(x => x.Order).ToList();
    var index = _layers.IndexOf(layerParam);
    if (index == _layers.Count - 1)
    {
      return;
    }

    var order = layerParam.Order;
    layerParam.Order = _layers[index + 1].Order;
    _layers[index + 1].Order = order;
  }

  public void BringFrontward(FrameLayer layerParam)
  {
    _layers = _layers.OrderBy(x => x.Order).ToList();
    var index = _layers.IndexOf(layerParam);
    if (index == _layers.Count - 1)
    {
      return;
    }

    var order = layerParam.Order;
    layerParam.Order = _layers[_layers.Count - 1].Order;
    _layers[_layers.Count - 1].Order = order;
  }

}
