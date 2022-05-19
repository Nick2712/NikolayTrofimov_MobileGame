using System;


namespace NikolayTrofimov_MobileGame
{
    internal interface IAdsPlayer
    {
        event Action Started;
        event Action Finished;
        event Action Failed;
        event Action Skipped;
        event Action BecomeReady;

        void Play();
    }
}
