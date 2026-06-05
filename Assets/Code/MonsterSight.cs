using System.Collections;
using UnityEngine;

namespace Assets
{
    public class MonsterSight : MonoBehaviour
    {
        public Transform player;
        public float sightAngle = 60f;

        // Update is called once per frame
        void Update()
        {
            Vector3 diirToPlayer = (player.position - transform.position).normalized;

            float dot = Vector3.Dot(transform.forward, diirToPlayer);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if (angle < sightAngle)
            {
                Debug.Log("플레이어 발견");
                Vector3 cross = Vector3.Cross(transform.forward, diirToPlayer);

                if (cross.y > 0)
                {
                    Debug.Log("플레이어는 오른쪽에 있음");
                }
                else if (cross.y < 0)
                {
                    Debug.Log("플레이어는 왼쪽에 있음");
                }
            }
        }
    }
}