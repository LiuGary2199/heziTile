using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrooveRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("CashBase")]    [UnityEngine.Serialization.FormerlySerializedAs("CashBase")]public GameObject CookKick;
[UnityEngine.Serialization.FormerlySerializedAs("GoldBase")]    [UnityEngine.Serialization.FormerlySerializedAs("GoldBase")]public GameObject LordKick;
[UnityEngine.Serialization.FormerlySerializedAs("ExpBase")]    [UnityEngine.Serialization.FormerlySerializedAs("ExpBase")]public GameObject DayKick;
[UnityEngine.Serialization.FormerlySerializedAs("StarExpBase")]    [UnityEngine.Serialization.FormerlySerializedAs("StarExpBase")]public GameObject RakeDayKick;
[UnityEngine.Serialization.FormerlySerializedAs("PuzzleBase")]    [UnityEngine.Serialization.FormerlySerializedAs("PuzzleBase")]public GameObject FalconKick;
[UnityEngine.Serialization.FormerlySerializedAs("ShellBase")]    [UnityEngine.Serialization.FormerlySerializedAs("ShellBase")]public GameObject RumorKick;
[UnityEngine.Serialization.FormerlySerializedAs("FullMask")]    [UnityEngine.Serialization.FormerlySerializedAs("FullMask")]public GameObject ShinArab;
[UnityEngine.Serialization.FormerlySerializedAs("BottomMask")]    [UnityEngine.Serialization.FormerlySerializedAs("BottomMask")]public GameObject AlwaysArab;
[UnityEngine.Serialization.FormerlySerializedAs("TopMask")]    [UnityEngine.Serialization.FormerlySerializedAs("TopMask")]public GameObject BurArab;
    protected override void Awake()
    {
        base.Awake();
        MessageCenterLogic.GetInstance().Register(CConfig.mg_RewardPanel_Play,(messageData)=>
        {
            //if (messageData.valueString2 == null || messageData.valueString2 == "" || messageData.valueString2 == "Full")
            //{
            //    FullMask.SetActive(true);
            //}
            if (messageData.valueString2 == "TopBottom")
            {
                ShinArab.SetActive(false);
                AlwaysArab.SetActive(true);
                BurArab.SetActive(true);
            }
            int count = messageData.valueInt;
            if (count == 0)
            {
                count = 5;
            }
            if (messageData.valueString == "Gold")
            {
                GameObject Fx_Power = Instantiate(Resources.Load<GameObject>(CConfig.EffectsFXPower), messageData.valueGameObject.transform);
                Fx_Power.SetActive(false);
                AnimationController.GoldMoveBest(LordKick, count, LordKick.transform, messageData.valueGameObject.transform,() =>
                {
                    CloseUIForm(GetType().Name);
                    messageData.messageCallBack?.Invoke();
                    Destroy(Fx_Power);
                });
            }
            if (messageData.valueString == "Cash")
            {
                GameObject Fx_Power = Instantiate(Resources.Load<GameObject>(CConfig.EffectsFXPower), messageData.valueGameObject2.transform);
                Fx_Power.SetActive(false);
                AnimationController.GoldMoveBest(CookKick, count, CookKick.transform, messageData.valueGameObject2.transform, () =>
                {
                    CloseUIForm(GetType().Name);
                    messageData.messageCallBack?.Invoke();
                    Destroy(Fx_Power);
                });
            }
            if (messageData.valueString == "Exp")
            {
                GameObject Fx_Power = Instantiate(Resources.Load<GameObject>(CConfig.EffectsFXPower), messageData.valueGameObject3.transform);
                Fx_Power.SetActive(false);
                AnimationController.GoldMoveBest(DayKick, 5, DayKick.transform, messageData.valueGameObject3.transform, () =>
                {
                    CloseUIForm(GetType().Name);
                    messageData.messageCallBack?.Invoke();
                    Destroy(Fx_Power);
                });
            }
            if (messageData.valueString == "StarExp")
            {
                GameObject Fx_Power = Instantiate(Resources.Load<GameObject>(CConfig.EffectsFXPower), messageData.valueGameObject4.transform);
                Fx_Power.SetActive(false);
                AnimationController.GoldMoveBest(RakeDayKick,  1, RakeDayKick.transform, messageData.valueGameObject4.transform, () =>
                {
                    CloseUIForm(GetType().Name);
                    messageData.messageCallBack?.Invoke();
                    Destroy(Fx_Power);
                });
            }
            if (messageData.valueString == "Puzzle")
            {
                GameObject Fx_Power = Instantiate(Resources.Load<GameObject>(CConfig.EffectsFXPower), messageData.valueGameObject5.transform);
                Fx_Power.SetActive(false);
                AnimationController.GoldMoveBest(FalconKick, 3, FalconKick.transform, messageData.valueGameObject5.transform,  () =>
                {
                    CloseUIForm(GetType().Name);
                    messageData.messageCallBack?.Invoke();
                    Destroy(Fx_Power);
                });
            }
            if (messageData.valueString == "Shell")
            {
                GameObject Fx_Power = Instantiate(Resources.Load<GameObject>(CConfig.EffectsFXPower), messageData.valueGameObject6.transform);
                Fx_Power.SetActive(false);
                AnimationController.GoldMoveBest(RumorKick,  1, RumorKick.transform, messageData.valueGameObject6.transform, () =>
                {
                    CloseUIForm(GetType().Name);
                    messageData.messageCallBack?.Invoke();
                    Destroy(Fx_Power);
                });
            }
            MusicMgr.GetInstance().PlayEffect(MusicType.SceneMusic.Sound_HomeGold);
        
        });

    }
    public override void Display()
    {
        
        base.Display();
        ShinArab.SetActive(true);
        AlwaysArab.SetActive(false);
        BurArab.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
