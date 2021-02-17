using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnim : MonoBehaviour
{
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();

        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        while (true)
        {
            image.fillAmount = Mathf.Abs(Mathf.Sin(Time.time));

            yield return null;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
