using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeafUsRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Stars")]    [UnityEngine.Serialization.FormerlySerializedAs("Stars")]public Button[] Major;
[UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]    [UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]public Sprite Crew1Rugged;
[UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]    [UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]public Sprite Crew2Rugged;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button star in Major)
        {
            star.onClick.AddListener(() =>
            {
                string indexStr = System.Text.RegularExpressions.Regex.Replace(star.gameObject.name, @"[^0-9]+", "");
                int Boost= indexStr == "" ? 0 : int.Parse(indexStr);
                PatchBlade(Boost);
            });
        }
    }

    public override void Display()
    {
        base.Display();
        for (int i = 0; i < 5; i++)
        {
            Major[i].gameObject.GetComponent<Image>().sprite = Crew2Rugged;
        }
    }


    private void PatchBlade(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            Major[i].gameObject.GetComponent<Image>().sprite = i <= index ? Crew1Rugged : Crew2Rugged;
        }
        PostEventScript.GetInstance().SendEvent("1301", (index + 1).ToString());
        if (index < 3)
        {
            StartCoroutine(GlandRider());
        } else
        {
            // 跳转到应用商店
            RateUsManager.instance.OpenAPPinMarket();
            StartCoroutine(GlandRider());
        }
        
        // 打点
        //PostEventScript.GetInstance().SendEvent("1210", (index + 1).ToString());
    }

    IEnumerator GlandRider(float waitTime = 0.5f)
    {
        yield return new WaitForSeconds(waitTime);
        CloseUIForm(GetType().Name);
    }
}
