using System.Collections.Generic;
using System.Threading.Tasks;
using Polygon.Terrain.Model;
using Polygon.Unity.HeightMap.Model;
using UnityEngine;

namespace Polygon.Terrain {
  public class ChunkGenerator : IChunkGenerator {
    public QuadMapper Mapper { get; set; }
    public HeightMapFunction HeightMapFunction { get; set; }

    public ChunkGenerator (QuadMapper mapper, HeightMapFunction heightMapFunction) {
      Mapper = mapper;
      HeightMapFunction = heightMapFunction;
    }

    public void CreateChunk (Chunk chunk) {
      var task = new Task (() => {
        Mapper.Map (
          HeightMapFunction.GetHeightMap (chunk.Grid + 1, chunk.Grid + 1, chunk.AbsolutePosition),
          chunk
        );
      });
      chunk.MakeTask = task;
      task.Start ();
    }
  }
}