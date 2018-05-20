using Polygon.Unity.HeightMap.Model;
using UnityEngine;

namespace Polygon.Unity.HeightMap {
  public class HeightMapDisplay : MonoBehaviour {
    public int width;
    public int height;
    Texture2D texture;
    public Texture2D Texture {
      get {
        if (texture == null || texture.width != width || texture.height != height) {
          texture = new Texture2D (width, height);
          texture.filterMode = FilterMode.Point;
          texture.wrapMode = TextureWrapMode.Clamp;
        }
        return texture;
      }
    }

    public HeightMapFunction function;

    public bool ChildUpdate { get; set; }

    public void ApplyTexture () {
      UpdateTexture (Texture);
      var renderer = GetComponent<MeshRenderer> ();
      renderer.sharedMaterial.mainTexture = Texture;
    }

    public void UpdateTexture (Texture2D texture, int? width = null, int? height = null) {
      var w = width ?? this.width;
      var h = height ?? this.height;

      texture.SetPixels (function.GetHeightMap (w, h).ToHeightMapTexture ());
      texture.Apply ();
    }
  }
}