public class ShiledItem : ItemObj, IItem
{
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectShield();
        AudioManager.Instance.PlaySFX("CollectItem");
        gameObject.SetActive(false);
    }
}
