using UnityEngine;

namespace Polygon.Unity.HeightMap.Model {
  public abstract class HeightMapFunction : MonoBehaviour {
    public abstract float[, ] GetHeightMap (int width, int height);

    void OnValidate() {
    }
  }
}