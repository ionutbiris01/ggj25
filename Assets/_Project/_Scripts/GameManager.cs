using UnityEngine;

namespace _Project._Scripts
{
    public class GameManager : MonoBehaviour
    {
        [Range(0,1)] public float coffeCupIntensity = 0;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            EventManager.ChangeCoffeCupIntensity(coffeCupIntensity);
        }
    }
}
