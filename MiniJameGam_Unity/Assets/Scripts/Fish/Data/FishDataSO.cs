using MiniJameGam.Fish.Behaviour;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MiniJameGam.Fish
{
    [CreateAssetMenu(fileName = "FishData", menuName = "Fish/FishData")]
    public class FishDataSO : SerializedScriptableObject
    {
        public Sprite Image;
        public IFishBehaviour Behaviour;
    }
}