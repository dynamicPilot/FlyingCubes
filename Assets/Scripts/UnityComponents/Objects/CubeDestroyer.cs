using System.Collections;
using UnityComponents.Common;
using UnityEngine;


namespace UnityComponents.Objects
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubeDestroyer : MonoBehaviour
    {
        [SerializeField] private float _updateTime = 1f;
        Rigidbody _rigidBody;
        private float _distance;        

        WaitForSeconds _timer;
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _timer = new WaitForSeconds(_updateTime);
        }

        public void StartCube(float distance)
        {
            _distance = distance;
            StartCoroutine(Updater());
        }

        private IEnumerator Updater()
        {
            yield return _timer;
            _distance -= _updateTime * _rigidBody.velocity.magnitude;

            if (_distance > 0) StartCoroutine(Updater());
            else HideCube();
        }

        private void HideCube()
        {
            _rigidBody.velocity = Vector3.zero;
            gameObject.SetActive(false);

            FreeEventManager.TriggerEvent(gameObject);
        }
    }
}
