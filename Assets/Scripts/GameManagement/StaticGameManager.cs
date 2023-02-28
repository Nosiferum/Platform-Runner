using System;

namespace DogukanKarabiyik.PlatformRunner.Managers
{
    public static class StaticGameManager
    {
        public static Action OnLevelStart;
        public static Action OnLevelOver;

        public static Action OnLevelSuccess;
        public static Action OnLevelFail;

        public static Action OnEndLineReached;

        public static void GameStart()
        {
            OnLevelStart?.Invoke();
        }

        public static void GameFail()
        {
            OnLevelOver?.Invoke();
            OnLevelFail?.Invoke();
        }

        public static void GameSuccess()
        {
            OnLevelOver?.Invoke();
            OnLevelSuccess?.Invoke();
        }

        public static void EndLineReached()
        {
            OnEndLineReached?.Invoke();
        }
    }
}


