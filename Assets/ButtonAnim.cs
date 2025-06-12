using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{
    public Sprite nonePressImg;
    public Sprite pressImg;
    private int indexImg = 0;
    private Image img;
    private Coroutine changeImgCoroutine;
    // Start is called before the first frame update
    private void Awake()
    {
        img = GetComponent<Image>();
        changeImgCoroutine = StartCoroutine(ChangeImg());
    }
    private void OnEnable()
    {
        if (changeImgCoroutine != null)
        {
            StopCoroutine(changeImgCoroutine);
            changeImgCoroutine = null;
        }
        indexImg = 0;
        changeImgCoroutine = StartCoroutine(ChangeImg());
    }
    private void OnDisable()
    {
        if (changeImgCoroutine != null) StopCoroutine(changeImgCoroutine);
        changeImgCoroutine = null;
    }
    private IEnumerator ChangeImg()
    {
        while (true)
        {
            if (indexImg == 0) img.sprite = nonePressImg;
            else img.sprite = pressImg;
            indexImg++;
            if (indexImg >= 2) indexImg = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
