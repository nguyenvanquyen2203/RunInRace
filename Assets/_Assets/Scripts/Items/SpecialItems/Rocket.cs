public class Rocket : ItemObj, IItem
{
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectRocket();
        MapManager.Instance.SpawnFlyMap();
        AudioManager.Instance.PlaySFX("CollectItem");
        PowerUpInformation.Instance.ActivePowerUp("Rocket");
        gameObject.SetActive(false);
    }
}
