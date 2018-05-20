using System.Collections.Generic;
using System.Threading.Tasks;
using Polygon.Terrain.Model;
using UnityEngine;

namespace Polygon.Terrain {
  public class ChunkGenerator : IChunkGenerator {
    public QuadMapper Mapper { get; set; }
    public Noise.Noise Noise { get; set; }

    public ChunkGenerator (QuadMapper mapper, Noise.Noise noise) {
      Mapper = mapper;
      Noise = noise;
    }

    public void CreateChunk (Chunk chunk) {
      var task = new Task (() => {
        Mapper.Map (
          Noise.PerlinNoise (chunk.Grid + 1, chunk.Grid + 1, chunk.AbsolutePosition),
          chunk
        );
      });
      chunk.MakeTask = task;
      task.Start();
    }
  }
}