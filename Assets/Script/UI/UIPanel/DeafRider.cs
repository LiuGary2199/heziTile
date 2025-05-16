using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DeafRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("lightSprite")]
#if UNITY_IOS
    string appid = "1637039085";
#endif
#if UNITY_ANDROID
    string appid = "com.tilefungame.tileaquarium";
#endif
    [UnityEngine.Serialization.FormerlySerializedAs("lightSprite")]public Sprite PatchRugged;
[UnityEngine.Serialization.FormerlySerializedAs("blackSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("blackSprite")]public Sprite FloraRugged;
[UnityEngine.Serialization.FormerlySerializedAs("buttonList")]    [UnityEngine.Serialization.FormerlySerializedAs("buttonList")]public List<Button> IndeedLend;
[UnityEngine.Serialization.FormerlySerializedAs("content")]    [UnityEngine.Serialization.FormerlySerializedAs("content")]public GameObject Cottage;
    // Start is called before the first frame update
    private void OnEnable()
    {
    }
    void Start()
    {
        IndeedLend[0].onClick.AddListener(() => {
            SledSaline(0 + 1);
        });
        IndeedLend[1].onClick.AddListener(() => {
            SledSaline(1 + 1);
        });
        IndeedLend[2].onClick.AddListener(() => {
            SledSaline(2 + 1);
        });
        IndeedLend[3].onClick.AddListener(() => {
            SledSaline(3 + 1);
        });
        IndeedLend[4].onClick.AddListener(() => {
            SledSaline(4 + 1);

        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SledSaline(int index)
    {
        for (int i = 0; i < IndeedLend.Count; i++)
        {
            if (i < index)
            {
                IndeedLend[i].GetComponent<Image>().sprite = PatchRugged;
            }
            else
            {
                IndeedLend[i].GetComponent<Image>().sprite = FloraRugged;
            }
        }
        if ((index <= 3 && CommonUtil.IsApple()) || index > 3)
        {
            BusRake();
        }
        SaveDataManager.SetBool(CConfig.sv_ready_rate, true);
        CloseUIForm(GetType().Name);
    }

    /// <summary>
    /// 发邮件
    /// </summary>
    public void PourEmail()
    {
        //Debug.Log("发邮件");
        Uri uri = new Uri(string.Format("mailto:{0}?subject={1}", @"luckygoapp@gmail.com", Application.productName));//第二个参数是邮件的标题
        Application.OpenURL(uri.AbsoluteUri);
    }
    /// <summary>
    /// 去gp
    /// </summary>
    public void BusRake()
    {
        PourAPRoePocket();
    }
    private void PourAPRoePocket()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + appid);
#endif
#if UNITY_IOS
        var url = string.Format(
            "itms-apps://itunes.apple.com/cn/app/id{0}?mt=8&action=write-review",
            appid);
        Application.OpenURL(url);
#endif
    }
}
