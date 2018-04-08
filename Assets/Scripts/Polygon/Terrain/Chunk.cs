using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Polygon.Mesh;
using Polygon.Terrain.Generators;
using UnityEngine;

namespace Polygon.Terrain {
  public class Chunk {
    public Cube[, , ] Cubes { get; set; }

    public Vector3 Position { get; set; }

    public Chunk (int size) {
    }
  }
}