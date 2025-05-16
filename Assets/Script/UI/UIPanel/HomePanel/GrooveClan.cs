using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrooveClan : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("RewardImage")]    [UnityEngine.Serialization.FormerlySerializedAs("RewardImage")]public Image GrooveNomad;
[UnityEngine.Serialization.FormerlySerializedAs("RewardText")]    [UnityEngine.Serialization.FormerlySerializedAs("RewardText")]public Text GrooveDawn;

    public void DogGrooveOust(RewardType type,double value)
    {
        string path = "";
        switch (type)
        {
            case RewardType.gold:
                path = CriticBrush.LordRuggedKeen;
                break;
            case RewardType.cash:
                path = CriticBrush.CrackRuggedKeen;
                break;
            case RewardType.amazon:
                path = CriticBrush.StraitZRuggedKeen;
                break;
        }
        GrooveNomad.sprite = Resources.Load<Sprite>(path);
        GrooveNomad.transform.GetComponent<RectTransform>().sizeDelta = (path == CriticBrush.StraitZRuggedKeen) ? new Vector2(120, 120) : new Vector2(180,180);
        GrooveDawn.text = value.ToString();
    }
}
