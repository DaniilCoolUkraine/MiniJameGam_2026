using UnityEngine;

namespace MiniJameGam.Fish
{
    public interface IFish
    {
        Transform transform { get; }
        void MoveTowards(Vector2 finalPosition, float speed);
    }
}