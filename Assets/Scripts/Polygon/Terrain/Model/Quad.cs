using Polygon.Terrain.Model;

namespace Polygon.Terrain.Model {
    public class Quad {
        public Chunk Chunk { get; set; }

        public Quad (Chunk chunk) {
            this.Chunk = chunk;
        }
    }
}