namespace Polygon.Terrain {
  public class Cube {

    public Chunk Chunk { get; set; }

    public Cube (Chunk chunk) {
      this.Chunk = chunk;
    }
  }
}