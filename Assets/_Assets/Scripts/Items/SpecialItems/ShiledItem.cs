public class ShiledItem : RaceObj, IItem
{
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectShield();
        gameObject.SetActive(false);
    }
}
