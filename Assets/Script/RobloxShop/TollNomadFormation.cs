using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TollNomadFormation : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("imageList")]    [UnityEngine.Serialization.FormerlySerializedAs("imageList")]public List<Sprite> ShadeLend;
    private Image Shade;
[UnityEngine.Serialization.FormerlySerializedAs("speen")]    [UnityEngine.Serialization.FormerlySerializedAs("speen")]public float Bugle;
[UnityEngine.Serialization.FormerlySerializedAs("CanvasGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("CanvasGroup")]public CanvasGroup VirtueModel;
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
        StartCoroutine(nameof(NoteNomad));
    }
    private void OnDisable()
    {
        StopCoroutine(nameof(FeatSaline));
    }

    private float value = 0;
    float yInterval= 0.0f;
    IEnumerator NoteNomad()
    {
        value = Mathf.Lerp(0.0f,3.0f,0.1f);
        VirtueModel.alpha = value;
        yield return new WaitForSeconds(0.05f);
        value = Mathf.Lerp(value,3.0f,0.1f);
        VirtueModel.alpha = value;
        yield return new WaitForSeconds(0.05f);
        value = Mathf.Lerp(value,3.0f,0.1f);
        VirtueModel.alpha = value;
        yield return new WaitForSeconds(0.05f);
        value = Mathf.Lerp(value,3.0f,0.1f);
        VirtueModel.alpha = value;
        yield return new WaitForSeconds(0.05f);
    }

    public void ParcelNomad()
    {
        if(gameObject.GetComponent<Image>().gameObject.activeSelf)
            StartCoroutine(nameof(RareNomad));
    }
    IEnumerator RareNomad()
    {
        value = Mathf.Lerp(3.0f,0.0f,0.1f);
        VirtueModel.alpha = value;
        yield return new WaitForSeconds(0.05f);
        value = Mathf.Lerp(3.0f,value,0.1f);
        VirtueModel.alpha = value;
        yield return new WaitForSeconds(0.05f);
        value = Mathf.Lerp(3.0f,value,0.1f);
        VirtueModel.alpha = value;
        yield return new WaitForSeconds(0.05f);
        value = Mathf.Lerp(3.0f,value,0.1f);
        VirtueModel.alpha = value;
        yield return new WaitForSeconds(0.05f);
        gameObject.SetActive(false);
    }
}
