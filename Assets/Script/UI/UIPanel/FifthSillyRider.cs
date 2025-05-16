using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FifthSillyRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("GetButton")]    [UnityEngine.Serialization.FormerlySerializedAs("GetButton")]public Button OakUntold;
[UnityEngine.Serialization.FormerlySerializedAs("ADGetButton")]    [UnityEngine.Serialization.FormerlySerializedAs("ADGetButton")]public Button ADOakUntold;
[UnityEngine.Serialization.FormerlySerializedAs("DailyBounsItemList")]    [UnityEngine.Serialization.FormerlySerializedAs("DailyBounsItemList")]public List<GameObject> DailyFluteClanLend;
    void Start()
    {
        OakUntold.onClick.AddListener(() =>
        {
            OakGroove(DailyFluteClanLend[SaveDataManager.GetInt(CConfig.sv_DailyBounsGetCount)]);
        });
        ADOakUntold.onClick.AddListener(() =>
        { 
            ADManager.Instance.playRewardVideo((success) => { 
                if (success)
                {
                    OakGroove(DailyFluteClanLend[SaveDataManager.GetInt(CConfig.sv_DailyBounsGetCount)], true);
                }
            }, "108");
        });
    }
    public override void Display()
    {
        base.Display();

        for (int i = 0; i < SaveDataManager.GetInt(CConfig.sv_DailyBounsGetCount); i++)
        {
            GameObject item = DailyFluteClanLend[i];
            PlusFifthGroove(3, i == 6 ? 1 : 0, item);
        }
        for (int i = SaveDataManager.GetInt(CConfig.sv_DailyBounsGetCount) + 1; i < NetInfoMgr.instance.gameData.DailyBonus.Count; i++)
        {
            GameObject item = DailyFluteClanLend[i];
            PlusFifthGroove(1, i == 6 ? 1 : 0, item);
        }
        if (Dire.instance.FifthFluteOakThink() != 8)
        {
            GameObject item = DailyFluteClanLend[SaveDataManager.GetInt(CConfig.sv_DailyBounsGetCount)];
            PlusFifthGroove(2, SaveDataManager.GetInt(CConfig.sv_DailyBounsGetCount) == 6 ? 1 : 0, item);
        }
        else
        {
            GameObject item = DailyFluteClanLend[SaveDataManager.GetInt(CConfig.sv_DailyBounsGetCount)];
            PlusFifthGroove(3, SaveDataManager.GetInt(CConfig.sv_DailyBounsGetCount) == 6 ? 1 : 0, item);
        }
        if (Dire.instance.FifthFluteOakThink() != 8)
        {
            OakUntold.gameObject.SetActive(true);
        }
        else
        {
            OakUntold.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 判断领取  如果i=1 奖励未领取； 如果i=2  奖励可领取；如果i=3 奖励已领取；
    /// </summary>
    /// <param name="i"> i是判断 未领取/可领取/已领取 </param>
    /// <param name="j"> j是判断 j=0 是第一天到第六天 j>0 是第七天 * 因为第七天的背景图不一样 * </param>
    /// <param name="Day">day1-7的gameobject</param>
    public void PlusFifthGroove(int i,int j,GameObject Day) 
    {
        if (i == 1)
        {
            if (j > 0)
            {
                Day.GetComponent<Transform>().Find("DayBG").GetComponent<Image>().sprite = Resources.Load<Sprite>(CConfig.EffectsDailyReward7);

            }
            else 
            {
                Day.GetComponent<Transform>().Find("DayBG").GetComponent<Image>().sprite = Resources.Load<Sprite>(CConfig.EffectsDailyReward);
                Day.GetComponent<Transform>().Find("DuiHao").gameObject.SetActive(false);
                Day.GetComponent<Transform>().Find("Fx_RewardBG").gameObject.SetActive(false);
            }
        }
        else if (i == 2)
        {
            if (j > 0)
            {
                Day.GetComponent<Transform>().Find("DayBG").GetComponent<Image>().sprite = Resources.Load<Sprite>(CConfig.EffectsDailyReward7Open);
            }
            else
            {
                Day.GetComponent<Transform>().Find("DayBG").GetComponent<Image>().sprite = Resources.Load<Sprite>(CConfig.EffectsDailyOpen);
            }
        }
        else if (i == 3) 
        {
            if (j > 0)
            {
                Day.GetComponent<Transform>().Find("Mask").gameObject.SetActive(true);
                Day.GetComponent<Transform>().Find("DuiHao").gameObject.SetActive(true);
                Day.GetComponent<Transform>().Find("Fx_RewardBG").gameObject.SetActive(false);
            }
            else 
            {
                Day.GetComponent<Transform>().Find("Mask").gameObject.SetActive(true);
                Day.GetComponent<Transform>().Find("Fx_RewardBG").gameObject.SetActive(false);
                Day.GetComponent<Transform>().Find("DuiHao").gameObject.SetActive(true);
            }
        }
    }




    /// <summary>
    /// 点击get按钮 获取奖励
    /// </summary>
    /// <param name="RewardImage">奖励图片</param>
    public void OakGroove(GameObject day, bool isAD = false) 
    {
        AnimationController.DailyBonusAni(day.GetComponent<Transform>().Find("Gift").gameObject, day.GetComponent<Transform>().Find("Fx_RewardBG").gameObject, ()=> 
        {
            Dire.instance.FifthSillyOakGroove(isAD);
            //关闭弹窗 回到主页给奖励
            CloseUIForm(GetType().Name);
            MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanel_AddCash);
        });
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
