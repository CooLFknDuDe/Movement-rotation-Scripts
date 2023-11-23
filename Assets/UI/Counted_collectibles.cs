using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


namespace MyGameForMED3
{
    public class Counted_collectibles : MonoBehaviour
    {
        public static Counted_collectibles instance;
        public int collectibleCount = 0;
        [SerializeField] TMP_Text m_TextComponent;
        

        private void Awake()
        {
            instance = this;
        }
        [SerializeField]
        public void Update()
        {
           //FindObjectOfType<item_collector>();
           
           //m_TextComponent.text = NewCounter;

        }

        public void ItemCollected(){
            collectibleCount++;
            m_TextComponent.text = $"{collectibleCount}";
        }

    }
}

 