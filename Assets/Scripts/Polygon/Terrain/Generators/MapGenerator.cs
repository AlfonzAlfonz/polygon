using UnityEngine;

namespace Polygon.Terrain.Generators {
  class MapGenerator {
    public Cube[,,] Generate(float[,] noisemap, Chunk chunk) {
      var cubes = new Cube[noisemap.GetLength(0), 100, noisemap.GetLength(1)];

      for(int x = 0; x < noisemap.GetLength(0);x++){
        for(int z = 0; z < noisemap.GetLength(1);z++){
          var h = (int)Mathf.Round(noisemap[x,z] * 100f);
          for(int y = 0; y < h+1;y++){
          cubes[x,y,z] = new Cube(chunk);
          }
        }
      }

      return cubes;
    }
  }
}