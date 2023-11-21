using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameForMED3
{
    public class rotation : MonoBehaviour
    {
        [SerializeField] float speedx;
        [SerializeField] float speedy;
        [SerializeField] float speedz;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(360 * speedx * Time.deltaTime, 360 * speedy * Time.deltaTime, 360 * speedz * Time.deltaTime);
        }
    }
}
