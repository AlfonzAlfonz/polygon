using Polygon.Terrain.Model;
using UnityEngine;

namespace Polygon.Terrain
{
  public class QuadMapper
  {
    public void Map(float[, ] heightMap, Chunk chunk)
    {
      chunk.HeightMap = heightMap;

      for (int x = 0; x < heightMap.GetLength(0) - 1; x++)
      {
        for (int y = 0; y < heightMap.GetLength(1) - 1; y++)
        {
          chunk.Quads[x, y] = new Quad(chunk);
        }
      }
    }
  }
}