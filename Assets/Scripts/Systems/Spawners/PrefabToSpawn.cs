using Systems.Objects;
using UnityEngine;

namespace Systems.Spawners
{
    public struct PrefabToSpawn
    {
        public GameObject Prefab;
        public Transform Parent;
        public Vector3 Position;
        public CubeParams Params;
    }
}

