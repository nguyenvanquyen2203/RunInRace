using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    public ParticleSystem coinCollection;
    public MagnetZone magnetZone;
    public Shield shield;
    private float shieldTime;
    private float magnetTime;
    private float scoreTime;
    private void Start()
    {
        GameManager.Instance.InitializeGameEvent.AddListener(ResetGame);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Items"))
        {
            IItem item = other.GetComponent<IItem>();
            item.CollectEvent(this);
        }
    }
    public void CollectCoin(int coin)
    {
        coinCollection.Clear();
        coinCollection.Play();
    }
    public void CollectMagnet()
    {
        magnetZone.gameObject.SetActive(true);
        CoinManager.Instance.SetTimeMagnet(magnetTime);
    }
    public void CollectShield()
    {
        shield.gameObject.SetActive(true);
        shield.ActiveShield(shieldTime);
    }
    public void CollectScoreBoost()
    {
        ScoreManager.Instance.BoostScore(scoreTime);
    }
    public void ResetGame()
    {
        shieldTime = PowerUpInformation.Instance.GetPU("Shield").timeActive;
        magnetTime = PowerUpInformation.Instance.GetPU("Magnet").timeActive;
        scoreTime = PowerUpInformation.Instance.GetPU("ScoreBoost").timeActive;
    }
}
