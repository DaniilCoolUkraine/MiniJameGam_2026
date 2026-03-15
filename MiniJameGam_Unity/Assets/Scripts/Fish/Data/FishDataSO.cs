using MiniJameGam.Fish.Behaviour;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MiniJameGam.Fish
{
    [CreateAssetMenu(fileName = "FishData", menuName = "Fish/FishData")]
    public class FishDataSO : SerializedScriptableObject
    {
#if UNITY_EDITOR
        public event System.Action OnValidateEvent;

        private void OnValidate()
        {
            OnValidateEvent?.Invoke();
        }
#endif
        [FoldoutGroup("Visuals")]
        [HorizontalGroup("Visuals/Split")]
        [PreviewField(100, ObjectFieldAlignment.Left, FilterMode = FilterMode.Point), HideLabel] public Sprite Image;
        [HorizontalGroup("Visuals/Split"), LabelText("Rotation")]
        public float SpriteRotation;
        public IFishBehaviour Behaviour;
    }
}