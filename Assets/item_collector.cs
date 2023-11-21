using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameForMED3
{
    public class item_collector : MonoBehaviour
    {
       
        int collectibleCount = 0;
        public GameObject Flower;
        


        public void OnTriggerEnter(Collider other)
        {


            if (other.gameObject.CompareTag("Collectible"))
            {
                Destroy(other.gameObject);
                collectibleCount++;
                Debug.Log(collectibleCount + " Flowers Collected");
                


                //Instantiate(Flower, randomSpawnPosition, Quaternion.identity);
            }


            string NewCounter = collectibleCount.ToString();


        }



    }
}
