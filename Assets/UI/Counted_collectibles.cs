using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


namespace MyGameForMED3
{
    public class Counted_collectibles : MonoBehaviour
    {
        [SerializeField] TMP_Text m_TextComponent;
        

        private void Awake()
        {
            m_TextComponent = GetComponent<TMP_Text>();
        }
        [SerializeField]
        public void Update()
        {
            FindObjectOfType<item_collector>();
           
            m_TextComponent.text = NewCounter;

        }

    }
}

 