using MiniJameGam.InputReader;
using Zenject;

namespace MiniJameGam
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputSystemInstaller.Install(Container);
        }
    }
}