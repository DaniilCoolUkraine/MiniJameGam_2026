#if UNITY_EDITOR
using System.Reflection;
using MiniJameGam.Fish.Behaviour;
using UnityEditor;
using UnityEngine;

namespace MiniJameGam.Fish.Editor
{
    [CustomEditor(typeof(FishController))]
    public class FishControllerEditor : UnityEditor.Editor
    {
        private static readonly FieldInfo BehaviourField =
            typeof(FishController).GetField("_behaviour", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo FinalPositionField =
            typeof(AvoidPlayerFishBehaviour).GetField("_finalPosition", BindingFlags.NonPublic | BindingFlags.Instance);

        private void OnSceneGUI()
        {
            var fish = (FishController)target;
            var fishData = (FishDataSO)serializedObject.FindProperty("_fishData").objectReferenceValue;

            if (fishData == null)
                return;

            if (fishData.Behaviour is AvoidPlayerFishBehaviour avoidBehaviour)
            {
                Handles.color = Color.red;
                Handles.DrawWireDisc(fish.transform.position, Vector3.forward, avoidBehaviour.AvoidanceRadius);
                Handles.color = Color.green;
                Handles.DrawWireDisc(fish.transform.position, Vector3.forward, avoidBehaviour.IdleWanderRadius);
            }
            
            if (fishData.Behaviour is FollowPlayerFishBehaviour followBehaviour)
            {
                Handles.color = Color.red;
                Handles.DrawWireDisc(fish.transform.position, Vector3.forward, followBehaviour.FollowRadius);
                Handles.color = Color.green;
                Handles.DrawWireDisc(fish.transform.position, Vector3.forward, followBehaviour.IdleWanderRadius);
            }

            if (!Application.isPlaying)
                return;

            var runtimeBehaviour = BehaviourField?.GetValue(fish);
            if (runtimeBehaviour is AvoidPlayerFishBehaviour runtimeAvoid)
            {
                var finalPos = (Vector2)FinalPositionField.GetValue(runtimeAvoid);
                Handles.color = Color.yellow;
                Handles.DrawSolidDisc(finalPos, Vector3.forward, 0.15f);
                Handles.DrawLine(fish.transform.position, finalPos);
            }
        }
    }
}
#endif