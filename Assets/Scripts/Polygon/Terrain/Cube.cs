namespace Polygon.Terrain {
  public class Cube {

    public Chunk Chunk { get; set; }

    public Dimensions Dimensions { get; set; }

    public Cube (Chunk chunk) {
      this.Chunk = chunk;
      Dimensions = new Dimensions();
    }
  }
}