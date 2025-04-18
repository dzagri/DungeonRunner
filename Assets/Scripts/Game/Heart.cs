public class Heart : CollectibleBase
{
    readonly int heartAmount = 1;
    public override void Collect(ManageCollectibles manager)
    {
        manager.Heart(heartAmount);
    }

}
