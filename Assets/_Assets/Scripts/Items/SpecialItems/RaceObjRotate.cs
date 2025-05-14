using UnityEngine;

public class RaceObjRotate : MonoBehaviour
{
    private void OnEnable()
    {
        if (transform.localPosition.x > 0) transform.localScale = new Vector3(1f, 1f, -1f);
        else transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
