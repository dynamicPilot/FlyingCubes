using Systems.Objects;
using UnityComponents.Objects;
using UnityComponents.Spawners;
using UnityEngine;

namespace Systems.Spawners
{
    public interface IFactoryMethod
    {
        public void SpawnWithParams(PrefabToSpawn prefab, CubeParams cubeParams);
    }

    public class FactoryMethod : IFactoryMethod
    {
        private ISpawn _factory;
        public FactoryMethod(ISpawn factory)
        {
            _factory = factory;
        }

        public void SpawnWithParams(PrefabToSpawn prefab, CubeParams cubeParams)
        {
            GameObject temp = _factory.Spawn(prefab);
            SetParams(temp, cubeParams);
        }

        private void SetParams(GameObject gObj, CubeParams cubeParams)
        {
            Rigidbody rb = gObj.GetComponent<Rigidbody>();
            CubeDestroyer cd = gObj.GetComponent<CubeDestroyer>();

            if (rb == null || cd == null) return;

            rb.velocity = GetVelocityVector(cubeParams.InLine) * cubeParams.Velocity;
            cd.StartCube(cubeParams.Distance);
        }

        private Vector3 GetVelocityVector(bool inLine = false)
        {
            return inLine ? Vector3.left : new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)).normalized;
        }
    }
}

