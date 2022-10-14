using Systems.Spawners;
using UnityEngine;

namespace UnityComponents.Spawners
{
    public interface ISpawn
    {
        public GameObject Spawn(PrefabToSpawn prefab);
    }

    public class Factory : MonoBehaviour, ISpawn
    {        
        public GameObject Spawn(PrefabToSpawn prefab)
        {
            return Instantiate(prefab.Prefab, prefab.Position, Quaternion.identity, prefab.Parent);
        }
    }
}

