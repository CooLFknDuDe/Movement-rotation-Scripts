using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameForMED3
{
    public class Instatiation : MonoBehaviour
    {
        Vector3 randomSpawnPosition;
        int randomSpawnAmount;
        public GameObject Flower;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int randomSpawnAmount = Random.Range(0, 10);
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-60,-10), Random.Range(-1, -1), Random.Range(-10,10));

                Instantiate(Flower, randomSpawnPosition, Quaternion.identity);
            }
        }


    }
}
