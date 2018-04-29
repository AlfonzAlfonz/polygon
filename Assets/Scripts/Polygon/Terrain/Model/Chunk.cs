using UnityEngine;

namespace Polygon.Terrain.Model {
  public class Chunk {
    public Cube[, , ] Cubes { get; set; }

    public Vector3 Position { get; set; }

    public Chunk (int size) {
    }
  }
}