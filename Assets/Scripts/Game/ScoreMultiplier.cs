using UnityEngine;

public class ScoreMultiplier : CollectibleBase
{
    readonly float duration = 15f;
    readonly bool activeState = true;
    public override void Collect(ManageCollectibles manager)
    {
        manager.ScoreMultiplier(duration, activeState);
    }
}
