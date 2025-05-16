using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TollNomadFormation_r1 : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("imageList")]    [UnityEngine.Serialization.FormerlySerializedAs("imageList")]public List<Sprite> ShadeLend;
    private Image Shade;
[UnityEngine.Serialization.FormerlySerializedAs("speen")]    [UnityEngine.Serialization.FormerlySerializedAs("speen")]public float Bugle;
    IEnumerator FeatSaline()
    {
        foreach(Sprite sprite in ShadeLend)
        {
            Shade.sprite = sprite;
            yield return new WaitForSeconds(Bugle);
        }
        StartCoroutine(nameof(FeatSaline));
    }
    private void OnEnable()
    {
        Shade = GetComponent<Image>();
        StartCoroutine(nameof(FeatSaline));
    }
    private void OnDisable()
    {
        StopCoroutine(nameof(FeatSaline));
    }
}
