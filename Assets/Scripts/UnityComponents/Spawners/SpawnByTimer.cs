using System.Collections;
using Systems.Objects;
using Systems.Spawners;
using UnityEngine;


namespace UnityComponents.Spawners
{
    public interface ISpawnTimer
    {
        public void StartSpawn(PrefabToSpawn prefab, CubeParams cubeParams, IFactoryMethod method);
        public void StopSpawn();
    }

    public class SpawnByTimer : MonoBehaviour, ISpawnTimer
    {
        WaitForSeconds _timer;
       
        public void StartSpawn(PrefabToSpawn prefab, CubeParams cubeParams, IFactoryMethod method)
        {
            _timer = new WaitForSeconds(cubeParams.Time);
            StartCoroutine(SpawnPrefab(prefab, cubeParams, method));
        }

        public void StopSpawn()
        {
            StopAllCoroutines();
        }

        internal IEnumerator SpawnPrefab(PrefabToSpawn prefab, CubeParams cubeParams, IFactoryMethod method)
        {
            method.SpawnWithParams(prefab, cubeParams);
            yield return _timer;

            StartCoroutine(SpawnPrefab(prefab, cubeParams, method));
        }
    }
}
