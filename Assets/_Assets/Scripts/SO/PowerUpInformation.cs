using UnityEngine;

public class PowerUpInformation : MonoBehaviour
{
    private static PowerUpInformation instance;
    public static PowerUpInformation Instance { get { return instance; } }
    public PowerUpInforSO powerUpInfor;
    private void Awake()
    {
        instance = this;
    }
}
