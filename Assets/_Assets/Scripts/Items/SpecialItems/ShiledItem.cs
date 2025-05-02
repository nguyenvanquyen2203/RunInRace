public class ShiledItem : RaceObj, IItem
{
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectShield(5f);
        gameObject.SetActive(false);
    }
}
