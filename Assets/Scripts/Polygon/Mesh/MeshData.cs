using System;
using System.Collections.Generic;
using UnityEngine;

namespace Polygon.Mesh {
  public class MeshData {
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int Depth { get; private set; }

    public List<Vector3> Vertices { get; private set; }

    public List<int> Triangles { get; private set; }

    public List<Vector2> UV { get; private set; }

    public MeshData (int width, int height, int depth) {
      Width = width;
      Height = height;
      Depth = depth;

      Vertices = new List<Vector3> (6 * 6 * width * height * depth);
      UV = new List<Vector2> (6 * 6 * width * height * depth);
      Triangles = new List<int> (6 * 6 * width * height * depth);
    }
  }
}