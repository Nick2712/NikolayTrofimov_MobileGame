namespace NikolayTrofimov_MobileGame
{
    internal interface IUpgradeItem
    {
        UpgradeType Type { get; }
        float Value { get; }
        string Id { get; }
    }
}
