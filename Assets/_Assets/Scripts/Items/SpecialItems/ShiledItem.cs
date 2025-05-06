public class ShiledItem : RaceObj, IItem
{
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectShield();
        AudioManager.Instance.PlaySFX("CollectItem");
        gameObject.SetActive(false);
    }
}
