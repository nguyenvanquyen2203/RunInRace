using UnityEngine;

public class RocketItem : MonoBehaviour
{
    public AirCoinManager airCoin;
    private PlayerState playerState;
    private PlayerController controller;
    private float activeTime;
    private void Start()
    {
        playerState = PlayerState.Instance;
        controller = playerState.GetComponent<PlayerController>();
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (activeTime <= 0) DisableRocket();
        transform.position = playerState.transform.position + Vector3.up * 0.2f + Vector3.back * .3f;
        activeTime -= Time.fixedDeltaTime;
    }
    public void ActiveRocket(float uptime)
    {
        GameManager.Instance.ClearEvent.AddListener(DisableRocket);
        airCoin.ActiveAirCoin(uptime);
        transform.position = controller.transform.position + Vector3.up * 0.2f + Vector3.back * .3f;
        gameObject.SetActive(true);
        playerState.GetRocket();
        controller.ChangeState(controller.flyState);
        activeTime = uptime;
        PowerUpInformation.Instance.ActivePowerUp("Rocket");
    }
    public void DisableRocket()
    {
        GameManager.Instance.ClearEvent.RemoveListener(DisableRocket);
        airCoin.gameObject.SetActive(false);
        activeTime = 0;
        controller.OnActionEventAct(PlayerController.OnActionEvent.EndFlying);
        playerState.DisableRocket();
        gameObject.SetActive(false);
        PowerUpInformation.Instance.CancelPU("Rocket");
    }
}
