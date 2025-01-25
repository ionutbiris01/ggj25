using UnityEngine;

namespace _Project._Scripts.CoffeCupSystem
{
    [CreateAssetMenu(fileName = "CoffeCupVFXPropertyConfig", menuName = "VFX/CoffeCupPropertyConfig")]
    public class CoffeeCupVFXPropertyConfig : ScriptableObject
    {
        [System.Serializable]
        public class VFXProperty
        {
            public string propertyName; // Name in the VFX Graph Blackboard
            public Vector2 range; // Min and Max values
        }

        public VFXProperty[] properties; // List of properties to modify
    }
}