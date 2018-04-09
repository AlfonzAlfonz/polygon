using System.Collections.Generic;
using Polygon.Noise;
using Polygon.Terrain.Generators;
using UnityEngine;

namespace Polygon.Terrain {
  public class Map {
    public List<Chunk> Chunks { get; private set; }
    int Grid { get; set; }

    public Map (int grid) {
      Chunks = new List<Chunk> ();
      Grid = grid;
    }
    
  }
}