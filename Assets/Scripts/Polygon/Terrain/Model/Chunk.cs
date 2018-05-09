using UnityEngine;
using System;

namespace Polygon.Terrain.Model
{
  public class Chunk
  {
    public Quad[,] Quads { get; set; }

    public GameObject GameObject { get; set; }

    float[,] heightMap;
    public float[,] HeightMap
    {
      get { return heightMap; }
      set
      {
        if (value.GetLength(0) != Grid + 1 || value.GetLength(1) != Grid + 1)
        {
          throw new ArgumentException();
        }
        heightMap = value;
      }
    }

    public Vector2 Position { get; set; }

    public Vector2 AbsolutePosition => Position * Grid;

    public int Grid { get; set; }

    public bool Active { get; set; }

    public Chunk(Vector2 position, int grid)
    {
      Grid = grid;
      Active = false;
      Position = position;
      Quads = new Quad[grid, grid];
    }
  }
}