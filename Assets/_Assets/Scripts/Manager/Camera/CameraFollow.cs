using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerState.Instance.transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 tempPos = player.transform.position + Vector3.up * 3f + Vector3.forward * -4f;
        if (tempPos.y < 3f) tempPos.y = 3f;
        tempPos.x = 0;
        transform.position = tempPos;
    }
}
