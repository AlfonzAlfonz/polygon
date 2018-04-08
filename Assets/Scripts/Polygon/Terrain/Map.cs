using System.Collections.Generic;
using System.Threading.Tasks;
using Polygon.Noise;
using Polygon.Terrain.Generators;
using UnityEngine;

namespace Polygon.Terrain {
  public class Map {
    public List<Chunk> Chunks { get; private set; }

    MapGenerator Generator { get; set; }
    Noise.Noise Noise { get; set; }
    int Grid { get; set; }

    public Map (int grid, MapGenerator generator, Noise.Noise noise) {
      Chunks = new List<Chunk> ();
      Generator = generator;
      Noise = noise;
      Grid = grid;
    }

    public Chunk AddChunk (Vector3 position) {
      Chunk chunk = new Chunk (Grid);
      chunk.Position = position;

      chunk.Cubes = Generator.Generate (Noise.PerlinNoise (Grid + 1, Grid + 1, new Vector2 (position.x * Grid, position.z * Grid)), chunk);
      Chunks.Add (chunk);

      return chunk;
    }
  }
}