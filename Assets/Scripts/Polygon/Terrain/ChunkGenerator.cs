using Polygon.Terrain.Generators;
using UnityEngine;

namespace Polygon.Terrain {
  class ChunkGenerator {

    MapGenerator Generator { get; set; }
    Noise.Noise Noise { get; set; }

    public ChunkGenerator (MapGenerator generator, Noise.Noise noise) {
      Generator = generator;
      Noise = noise;
    }

    public Chunk CreateChunk (int grid, Vector3 position) {
      Chunk chunk = new Chunk (grid);
      chunk.Position = position;

      chunk.Cubes = Generator.Generate (Noise.PerlinNoise (grid + 1, grid + 1, new Vector2 (position.x * grid, position.z * grid)), chunk);

      return chunk;
    }
  }
}