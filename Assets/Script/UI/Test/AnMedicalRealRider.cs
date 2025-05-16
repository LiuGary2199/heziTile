using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnMedicalRealRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("LastPlayTimeCounterText")]    [UnityEngine.Serialization.FormerlySerializedAs("LastPlayTimeCounterText")]public Text BoonTollTermAccreteDawn;
[UnityEngine.Serialization.FormerlySerializedAs("Counter101Text")]    [UnityEngine.Serialization.FormerlySerializedAs("Counter101Text")]public Text Accrete101Dawn;
[UnityEngine.Serialization.FormerlySerializedAs("Counter102Text")]    [UnityEngine.Serialization.FormerlySerializedAs("Counter102Text")]public Text Accrete102Dawn;
[UnityEngine.Serialization.FormerlySerializedAs("Counter103Text")]    [UnityEngine.Serialization.FormerlySerializedAs("Counter103Text")]public Text Accrete103Dawn;
[UnityEngine.Serialization.FormerlySerializedAs("TrialNumText")]    [UnityEngine.Serialization.FormerlySerializedAs("TrialNumText")]public Text TenetRedDawn;
[UnityEngine.Serialization.FormerlySerializedAs("PlayRewardedAdButton")]    [UnityEngine.Serialization.FormerlySerializedAs("PlayRewardedAdButton")]public Button TollCredibleAnUntold;
[UnityEngine.Serialization.FormerlySerializedAs("PlayInterstitialAdButton")]    [UnityEngine.Serialization.FormerlySerializedAs("PlayInterstitialAdButton")]public Button TollCircumscribeAnUntold;
[UnityEngine.Serialization.FormerlySerializedAs("NoThanksButton")]    [UnityEngine.Serialization.FormerlySerializedAs("NoThanksButton")]public Button NoGlassyUntold;
[UnityEngine.Serialization.FormerlySerializedAs("TrialNumButton")]    [UnityEngine.Serialization.FormerlySerializedAs("TrialNumButton")]public Button TenetRedUntold;
[UnityEngine.Serialization.FormerlySerializedAs("CloseButton")]    [UnityEngine.Serialization.FormerlySerializedAs("CloseButton")]public Button OvertUntold;
[UnityEngine.Serialization.FormerlySerializedAs("TimeInterstitialText")]    [UnityEngine.Serialization.FormerlySerializedAs("TimeInterstitialText")]public Text TermCircumscribeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("PauseTimeInterstitialButton")]    [UnityEngine.Serialization.FormerlySerializedAs("PauseTimeInterstitialButton")]public Button MessyTermCircumscribeUntold;
[UnityEngine.Serialization.FormerlySerializedAs("ResumeTimeInterstitialButton")]    [UnityEngine.Serialization.FormerlySerializedAs("ResumeTimeInterstitialButton")]public Button RegainTermCircumscribeUntold;

    private void Start()
    {
        InvokeRepeating(nameof(NoteAccreteDawn), 0, 0.5f);

        OvertUntold.onClick.AddListener(() =>
        {
            CloseUIForm(GetType().Name);
        });

        TollCredibleAnUntold.onClick.AddListener(() =>
        {
            ADManager.Instance.playRewardVideo((success) => { }, "10");
        });

        TollCircumscribeAnUntold.onClick.AddListener(() =>
        {
            ADManager.Instance.playInterstitialAd(1);
        });

        NoGlassyUntold.onClick.AddListener(() =>
        {
            ADManager.Instance.NoThanksAddCount();
        });

        TenetRedUntold.onClick.AddListener(() =>
        {
            ADManager.Instance.UpdateTrialNum(SaveDataManager.GetInt(CConfig.sv_ad_trial_num) + 1);
            TenetRedDawn.text = SaveDataManager.GetInt(CConfig.sv_ad_trial_num).ToString();
        });

        MessyTermCircumscribeUntold.onClick.AddListener(() =>
        {
            ADManager.Instance.PauseTimeInterstitial();
            NoteMessyTermCircumscribe();
        });

        RegainTermCircumscribeUntold.onClick.AddListener(() =>
        {
            ADManager.Instance.ResumeTimeInterstitial();
            NoteMessyTermCircumscribe();
        });

    }

    public override void Display()
    {
        base.Display();
        TenetRedDawn.text = SaveDataManager.GetInt(CConfig.sv_ad_trial_num).ToString();
        NoteMessyTermCircumscribe();
    }

    private void NoteAccreteDawn()
    {
        BoonTollTermAccreteDawn.text = ADManager.Instance.lastPlayTimeCounter.ToString();
        Accrete101Dawn.text = ADManager.Instance.counter101.ToString();
        Accrete102Dawn.text = ADManager.Instance.counter102.ToString();
        Accrete103Dawn.text = ADManager.Instance.counter103.ToString();
    }

    private void NoteMessyTermCircumscribe()
    {
        TermCircumscribeDawn.text = ADManager.Instance.pauseTimeInterstitial ? "已暂停" : "未暂停";
    }
}
