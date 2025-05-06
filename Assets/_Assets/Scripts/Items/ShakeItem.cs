using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeItem : MonoBehaviour
{
    private Vector3 originalPos;
    public float shakeAmplitude;
    private Vector3 amplitude;
    private float time;
    // Start is called before the first frame update
    private void Awake()
    {
        originalPos = transform.localPosition;
    }
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        amplitude = Vector3.up * Mathf.Sin(3 * time) * shakeAmplitude;
        transform.localPosition = originalPos + amplitude;
    }
}
