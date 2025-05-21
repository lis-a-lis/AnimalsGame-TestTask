using System;

namespace _Project.Code.Infrastructure.Root
{
    public interface IGameResultNotifier
    {
        public event Action<string> Won;
        public event Action<string> Lost;
    }
}