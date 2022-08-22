using UnityEngine;

namespace jerry
{
    public class Enemy : MonoBehaviour
    {
        public float Speed;
        public float DeleteTime;

        public GameObject Bullet;
        [Header("子彈產生時間")]
        public float SetTime;
        [Header("參考位置")]
        public Transform TargetPoint;

        private void Start()
        {
            Destroy(gameObject, DeleteTime);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }
}

