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

    [SerializeField]
    [HideInInspector]
    private HeightMapFunctionOptions master;
    public HeightMapFunctionOptions Master {
      get {
        master = master ?? new HeightMapFunctionOptions () {
          opacity = 1
        };
        return master;
      }
    }

    [SerializeField]
    [HideInInspector]
    private HeightMapFunctionOptionsPair[] functionOptions;
    public HeightMapFunctionOptionsPair[] FunctionOptions {
      get {
        UpdateOptions ();
        return functionOptions;
      }
    }

    public override float[, ] GetHeightMap (int width, int height, Vector2 offset) => GetCombinedHeightMap (width, height, offset);

    public float[, ] GetCombinedHeightMap (int w, int h, Vector2 offset) {
      float[, ] map = new float[w, h];

      UpdateOptions ();

      float sum = functionOptions.Sum (x => x.options.opacity);

      if (sum > 0) {
        foreach (var pair in functionOptions) {
          var hm = pair.function.GetHeightMap (w, h, offset);
          for (int x = 0; x < w; x++) {
            for (int y = 0; y < h; y++) {
              map[x, y] += hm[x, y] * pair.options.opacity / sum * Master.opacity;
            }
          }
        }
      }

      return map;
    }

    void OnValidate () {
      UpdateOptions ();
    }

    public void UpdateOptions () {
      if (functionOptions == null || functions.Length != functionOptions.Length) {
        functionOptions = new HeightMapFunctionOptionsPair[functions.Length];
      }

      for (int i = 0; i < functions.Length; i++) {
        var f = functions[i];
        if (functionOptions[i] == null || functionOptions[i].function != f) {
          functionOptions[i] = new HeightMapFunctionOptionsPair () {
          function = f,
          options = new HeightMapFunctionOptions ()
          };
        }
      }
    }

  }
}