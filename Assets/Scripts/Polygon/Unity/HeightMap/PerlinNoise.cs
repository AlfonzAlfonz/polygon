using System.Collections.Generic;
using Polygon.Noise;
using Polygon.Unity.HeightMap.Model;
using UnityEngine;

namespace Polygon.Unity.HeightMap {
  public class PerlinNoise : HeightMapFunction {
    public Vector2 offset;

    public List<Octave> octaves;

    public PerlinNoise () {
      octaves = new List<Octave> () {
        new Octave () {
        offset = new Vector2 (),
        frequency = 1f / 1000f,
        amplitude = 3f,
        suboctaves = 4,
        persistance = 1.3f,
        lacunarity = 1.6f
        },
        new Octave () {
        offset = new Vector2 (),
        frequency = 2f / 100f,
        amplitude = 5f,
        suboctaves = 4,
        persistance = 1.3f,
        lacunarity = 1.6f
        }
      };
    }

    public override float[, ] GetHeightMap (int width, int height) {

      Noise.Noise noise = new Noise.Noise (octaves.ToArray ());
      return noise.PerlinNoise (width, height, offset);
    }
  }
}