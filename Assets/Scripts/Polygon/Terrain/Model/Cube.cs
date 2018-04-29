using Polygon.Terrain.Model;
namespace Polygon.Terrain.Model {
  public class Cube {

    public Chunk Chunk { get; set; }

    public Dimensions Dimensions { get; set; }

    public Cube (Chunk chunk) {
      this.Chunk = chunk;
      Dimensions = new Dimensions();
    }
  }
}