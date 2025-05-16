using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件渗透
/// </summary>
public class DutchmanStonyMigration : MonoBehaviour, ICanvasRaycastFilter
{
    private Image ChargeNomad;
    public void DogMarvelNomad(Image target)
    {
        ChargeNomad = target;
    }
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (ChargeNomad == null)
        {
            return true;
        }
        return !RectTransformUtility.RectangleContainsScreenPoint(ChargeNomad.rectTransform, sp, eventCamera);
    }
}