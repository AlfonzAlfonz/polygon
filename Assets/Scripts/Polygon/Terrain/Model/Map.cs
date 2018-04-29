using System.Collections.Generic;
using UnityEngine;

namespace Polygon.Terrain.Model {
  public class Map {
    public List<Chunk> Chunks { get; private set; }
    int Grid { get; set; }

    public Map (int grid) {
      Chunks = new List<Chunk> ();
      Grid = grid;
    }
    
  }
}