using UnityEngine;

public class Coin : CollectibleBase
{
    public int coinValue = 1;

    public override void Collect(ManageCollectibles manager)
    {
        manager.Coin(coinValue);
    }
}
