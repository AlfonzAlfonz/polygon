using Polygon.Terrain.Model;
using UnityEngine;

namespace Polygon.Terrain {
  public class ChunkGenerator {

    CubeMapper Mapper { get; set; }
    Noise.Noise Noise { get; set; }

    public ChunkGenerator (CubeMapper mapper, Noise.Noise noise) {
      Mapper = mapper;
      Noise = noise;
    }

    public Chunk CreateChunk (int grid, Vector3 position) {
      Chunk chunk = new Chunk (grid);
      chunk.Position = position;

      chunk.Cubes = Mapper.Generate (Noise.PerlinNoise (grid + 1, grid + 1, new Vector2 (position.x * grid, position.z * grid)), chunk);

      return chunk;
    }
  }
}