using UnityEngine;

public class Shield : MonoBehaviour
{
    private PlayerState playerState;
    private float activeTime;
    private void Start()
    {
        playerState = PlayerState.Instance;
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (activeTime <= 0) playerState.DisableShiled();
        transform.position = playerState.transform.position + Vector3.up * 0.75f;
        activeTime -= Time.fixedDeltaTime;
    }
    public void ActiveShield(float uptime)
    {
        GameManager.Instance.ClearEvent.AddListener(() => { playerState.DisableShiled(); });
        transform.position = playerState.transform.position + Vector3.up * 0.75f;
        gameObject.SetActive(true);
        activeTime = uptime;
        playerState.GetShield();
        PowerUpInformation.Instance.ActivePowerUp("Shield");
    }
    public void DisableShield()
    {
        GameManager.Instance.ClearEvent.RemoveListener(DisableShield);
        activeTime = 0;
        gameObject.SetActive(false);
        PowerUpInformation.Instance.CancelPU("Shield");
    }
}