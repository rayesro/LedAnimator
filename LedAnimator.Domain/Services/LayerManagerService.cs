using LedAnimator.Core.Domain.Aggregates;
using System.Reflection.Emit;

namespace LedAnimator.Core.Domain.Services;

public class LayerManagerService
{
  private List<Layer> _layers;
  public int MatrixWidth { get; init; }
  public int MatrixHeight { get; init; }

  public LayerManagerService()
  {
    _layers= new List<Layer>();
  }

  public List<Layer> Layers { get { return _layers; } }
  private int _layerIds = 0; 

  public void CreateNewLayer(MatrixBoard matrixBoardParam)
  {
    Layer layer = new Layer()
    {
      Id = _layerIds,
      IsVisible = true,
      Matrix = matrixBoardParam,
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

  public void SendToBack(Layer layerParam)
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

  public void SendBackward(Layer layerParam)
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

  public void BringToFront(Layer layerParam)
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

  public void BringFrontward(Layer layerParam)
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
