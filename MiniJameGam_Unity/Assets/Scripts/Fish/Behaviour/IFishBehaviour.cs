using MiniJameGam.Player;

namespace MiniJameGam.Fish.Behaviour
{
    public interface IFishBehaviour
    {
        IFishBehaviour Clone(IFish fish, IPlayer player);
        void Update();
        void FixedUpdate();
    }
}