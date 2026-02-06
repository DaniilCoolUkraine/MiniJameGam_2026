using Zenject;

namespace MiniJameGam.SceneSwitcher
{
    public class SceneSwitcherInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneSwitcher>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
        }
    }
}