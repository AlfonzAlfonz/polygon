using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Polygon;
using Polygon.Mesh;
using Polygon.Noise;
using Polygon.Terrain;
using Polygon.Terrain.Model;
using Polygon.Unity;
using Polygon.Unity.HeightMap.Model;
using UnityEngine;

public class MeshTerrain : MonoBehaviour {

  public int grid;
  public float scale;

  public Transform player;

  public Material material;

  public HeightMapFunction function;

  MeshRenderer meshR;
  DependencyContainer container;

  Map map;
  ChunkGenerator generator;

  GameObjectGenerator gameObjectGenerator;

  void Awake () {
    generator = new ChunkGenerator(new QuadMapper(), function);
    gameObjectGenerator = new GameObjectGenerator(new PlaneMeshGenerator(scale), this.transform, material);
    map = new Map(grid, 20, generator, gameObjectGenerator);
    map.player = player;
  }

  void Start () {
    GC.Collect();

  }

  void Update () {
    map.Update();
  }

  void OnApplicationQuit () {
  }
}