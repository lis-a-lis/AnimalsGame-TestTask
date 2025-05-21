using UnityEngine;

namespace _Project.Code.Infrastructure.Root.Bootstrap
{
    public class Bootstrapper : IBootstrapper
    {
        public void Run()
        {
            Game game = Object.FindFirstObjectByType<Game>();
            game.Run();
        }
    }
}