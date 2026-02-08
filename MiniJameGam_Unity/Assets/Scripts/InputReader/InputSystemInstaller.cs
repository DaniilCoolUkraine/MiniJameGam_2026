using Zenject;

namespace MiniJameGam.InputReader
{
    public class InputSystemInstaller : Installer<InputSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputReader>().To<InputReaderOldInputSystem>().AsSingle().NonLazy();
        }
    }
}