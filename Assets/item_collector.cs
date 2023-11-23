using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameForMED3
{
    public class item_collector : MonoBehaviour
    {
        public GameObject Flower;
        


        public void OnTriggerEnter(Collider other)
        {


            if (other.gameObject.CompareTag("Collectible"))
            {
                Destroy(other.gameObject);
            
                Counted_collectibles.instance.ItemCollected();
                Debug.Log(" Flowers Collected");
                


                //Instantiate(Flower, randomSpawnPosition, Quaternion.identity);
            }


            //string NewCounter = collectibleCount.ToString();


        }



    }
}
