namespace Polygon.Terrain.Generators {
  public class DebugGenerator {
    public Chunk Generate (int size, Chunk chunk) {
      chunk.Cubes = Cube(chunk);
      return chunk;
    }

    Cube[, , ] Pyramid (Chunk chunk) {
      return new Cube[, , ] {
        { { new Cube (chunk), new Cube (chunk), new Cube (chunk) }, { new Cube (chunk), null, new Cube (chunk) }, { new Cube (chunk), new Cube (chunk), new Cube (chunk) }
        }, { { null, null, null },
          { null, new Cube (chunk), null },
          { null, null, null }
        }
      };
    }

    Cube[, , ] Cube (Chunk chunk) {
      return new Cube[, , ] {
        { { new Cube (chunk) }
        }
      };
    }

    Cube[, , ] Cube (int lx, int ly, int lz, Chunk chunk) {
      Cube[, , ] grid = new Cube[lx, ly, lz];

      for (int x = 0; x < lx; x++) {
        for (int z = 0; z < lz; z++) {
          for (int y = 0; y < ly; y++) {
            grid[x, y, z] =  new Cube (chunk);
          }
        }
      }

      return grid;
    }
  }
}