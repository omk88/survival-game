using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemyCount;
    public GameObject player;
    public GameObject Enemy;
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 5)
        {
            for (int i = GameObject.FindGameObjectsWithTag("Enemy").Length; i < 10; i++)
            {
                var y = 200f;
                var x = player.transform.position.x + Random.Range(50, -50);
                var z = player.transform.position.z + +Random.Range(50, -50);
                Ray ray = new Ray(new Vector3(x, y, z), Vector3.down);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 300))
                {
                    y = hit.point.y;
                    Instantiate(Enemy, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
    }
}
