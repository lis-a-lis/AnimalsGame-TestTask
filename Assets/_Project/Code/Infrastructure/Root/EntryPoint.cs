using _Project.Code.Infrastructure.Root.Bootstrap;
using UnityEngine;

namespace _Project.Code.Infrastructure.Root
{
    public static class EntryPoint
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Start()
        {
            IBootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}