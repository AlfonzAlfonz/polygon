using System;
using UnityEngine;

namespace Polygon.Noise {
  [Serializable]
  public class Octave {
    public Vector2 offset;

    public float frequency;

    public float amplitude;

    [Range(0, 10)]
    public int suboctaves = 1;

    public float persistance = 2;

    public float lacunarity = 2;
  }
}