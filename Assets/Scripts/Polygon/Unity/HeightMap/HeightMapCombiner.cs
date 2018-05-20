using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Polygon.Noise;
using Polygon.Unity;
using Polygon.Unity.HeightMap.Model;
using UnityEngine;
namespace Polygon.Unity.HeightMap {
  public class HeightMapCombiner : HeightMapFunction {

    public HeightMapFunction[] functions;

    private Dictionary<HeightMapFunction, HeightMapFunctionOptions> functionOptions;
    public Dictionary<HeightMapFunction, HeightMapFunctionOptions> FunctionOptions {
      get {
        functionOptions = functionOptions ?? new Dictionary<HeightMapFunction, HeightMapFunctionOptions> ();
        return functionOptions;
      }
    }

    public override float[, ] GetHeightMap (int width, int height) => GetCombinedHeightMap (width, height);

    public float[, ] GetCombinedHeightMap (int w, int h) {
      float[, ] map = new float[w, h];

      float sum = functionOptions.Sum (x => x.Value.opacity);

      foreach (HeightMapFunction func in functions) {
        var hm = func.GetHeightMap (w, h);
        for (int x = 0; x < w; x++) {
          for (int y = 0; y < h; y++) {
            map[x, y] += hm[x, y] * functionOptions[func].opacity / sum;
          }
        }
      }

      return map;
    }

    void OnValidate () {
      foreach (var f in functions) {
        if (!functionOptions.ContainsKey (f)) {
          functionOptions.Add (f, new HeightMapFunctionOptions ());
        }
      }
    }

  }
}