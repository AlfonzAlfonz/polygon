using UnityEngine;

namespace Polygon.Mesh {
  class RenderFaces {
    public Vector2[, ] North { get; set; }
    public Vector2[, ] South { get; set; }

    public Vector2[, ] West { get; set; }
    public Vector2[, ] East { get; set; }

    public Vector2[, ] Up { get; set; }
    public Vector2[, ] Down { get; set; }

    public RenderFaces (int size) {
      North = new Vector2[size, size];
      South = new Vector2[size, size];
      West = new Vector2[size, size];
      East = new Vector2[size, size];
      Up = new Vector2[size, size];
      Down = new Vector2[size, size];
    }
  }
}