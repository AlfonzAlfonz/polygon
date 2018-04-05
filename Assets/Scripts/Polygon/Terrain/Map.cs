using System.Collections.Generic;
using Polygon.Noise;
using Polygon.Terrain.Generators;
using UnityEngine;

namespace Polygon.Terrain {
  public class Map {
    public List<Chunk> Chunks { get; private set; }

    public Map () {
      Chunks = new List<Chunk> ();
      var generator = new MapGenerator ();
      var grid = 32;
      var octaves = new Octave[] {
        new Octave () {
        offset = new Vector2 (),
        frequency = 0.02f,
        amplitude = 1f,
        suboctaves = 4, 
        persistance = 1.3f,
        lacunarity = 1.6f
        },
        new Octave () {
        offset = new Vector2 (),
        frequency = .15f,
        amplitude = .3f,
        suboctaves = 4, 
        persistance = 1.3f,
        lacunarity = 1.6f
        },
      };

      for (int x = 0; x < 3; x++) {
        for (int z = 0; z < 3; z++) {
          for (int y = 0; y < 1; y++) {
            Chunk c = new Chunk(grid);
            c.Position = new Vector3(x, y, z);
            c.Cubes = generator.Generate(Noise.Noise.PerlinNoise(grid,grid, new Vector2(x * grid,z * grid), octaves), c);
            Chunks.Add (c);
            
          }
        }
      }
    }
  }
}