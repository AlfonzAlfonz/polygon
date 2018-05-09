using System.Collections.Generic;
using Polygon.Terrain.Model;
using UnityEngine;

namespace Polygon.Terrain {
  public interface IChunkGenerator {

    void CreateChunk(Chunk chunk);
  }
}