public class CoinItem : RaceObj, IItem
{
    public int coinValue;
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectCoin(coinValue);
        GameManager.Instance.GetCoin();
        gameObject?.SetActive(false);
    }
    private void OnEnable()
    {
        CoinManager.Instance?.Register(this);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        CoinManager.Instance?.Unregister(this);
    }
}
