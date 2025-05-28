public class Rocket : ItemObj, IItem
{
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectRocket();
        AudioManager.Instance.PlaySFX("CollectItem");
        PowerUpInformation.Instance.ActivePowerUp("Rocket");
        gameObject.SetActive(false);
    }
}
