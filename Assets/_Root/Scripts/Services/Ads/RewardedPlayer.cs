using UnityEngine.Advertisements;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class RewardedPlayer : UnityAdsPlayerBase
    {
        public RewardedPlayer(string id) : base(id)
        {

        }
        protected override void Load()
        {
            Advertisement.Load(_id);
        }

        protected override void OnPlaying()
        {
            Advertisement.Show(_id);
        }
    }
}
