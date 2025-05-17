public class Magnet : ItemObj, IItem
{
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectMagnet();
        AudioManager.Instance.PlaySFX("CollectItem");
        PowerUpInformation.Instance.ActivePowerUp("Magnet");
        gameObject.SetActive(false);
    }
}
