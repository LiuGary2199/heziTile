using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestProseGrooveBoston : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ClaimBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("ClaimBtn")]public Button WeighFin;
[UnityEngine.Serialization.FormerlySerializedAs("IconImage")]
[UnityEngine.Serialization.FormerlySerializedAs("IconImage")]    public Image IconNomad;
[UnityEngine.Serialization.FormerlySerializedAs("IconDexcriptionText")]
[UnityEngine.Serialization.FormerlySerializedAs("IconDexcriptionText")]    public Text RailRestatementDawn;
[UnityEngine.Serialization.FormerlySerializedAs("RewardScheduleText")]
[UnityEngine.Serialization.FormerlySerializedAs("RewardScheduleText")]    public Text GroovePacifierDawn;
[UnityEngine.Serialization.FormerlySerializedAs("RewardScheduleImage")]
[UnityEngine.Serialization.FormerlySerializedAs("RewardScheduleImage")]    public Image GroovePacifierNomad;
[UnityEngine.Serialization.FormerlySerializedAs("ownRobloxItemTwoData")]
[UnityEngine.Serialization.FormerlySerializedAs("ownRobloxItemTwoData")]    public RobloxItemTwoData RawForestClanBatOust;
[UnityEngine.Serialization.FormerlySerializedAs("CLaimBtnText")]
[UnityEngine.Serialization.FormerlySerializedAs("CLaimBtnText")]    public Text CLawnFinDawn;
[UnityEngine.Serialization.FormerlySerializedAs("ShowGetFragmentPanel")]    
[UnityEngine.Serialization.FormerlySerializedAs("ShowGetFragmentPanel")]    public Action<int> NoteOakDilutionRider;
    // Start is called before the first frame update
    void Start()
    {
        WeighFin.onClick.AddListener(WeighFinCGold);
        
        IconNomad.sprite = ForestPoemOustMedical.instance.OakRuggedMeID(RawForestClanBatOust.ID);
        RailRestatementDawn.text = RawForestClanBatOust.Name;

        GroovePacifierDawn.text = ForestPoemOustMedical.instance.OakEpochCriticQuill(RawForestClanBatOust);

        GroovePacifierNomad.fillAmount = ForestPoemOustMedical.instance.OakEpochCanoeQuill(RawForestClanBatOust);
    }

    // Update is called once per frame
    void Update()
    {
        MeetingWeighSpout();
    }
    
    public void MeetingFateful()
    {
        //这里的两个货币类型需要去获取
        /*RewardScheduleText.text =
            ForestPoemOustMedical.instance.GetShopStringValue( ownRobloxItemTwoData, 55555);
        RewardScheduleImage.fillAmount = ForestPoemOustMedical.instance.GetShopFloatValue(ownRobloxItemTwoData, 55555);*/
        GroovePacifierDawn.text = ForestPoemOustMedical.instance.OakEpochCriticQuill(RawForestClanBatOust);

        GroovePacifierNomad.fillAmount = ForestPoemOustMedical.instance.OakEpochCanoeQuill(RawForestClanBatOust);
    }
    
    public void WeighFinCGold()
    {
        NoteOakDilutionRider?.Invoke(RawForestClanBatOust.ID);
    }
    
    
    private void MeetingWeighSpout()
    {
        if (SaveDataManager.GetString("String" + RawForestClanBatOust.ID) != "")
        {
            DateTime Halt= DateTime.ParseExact(SaveDataManager.GetString("String" + RawForestClanBatOust.ID),"yyyyMMddHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            TimeSpan span = DateTime.Now - Halt;
            TimeSpan timeSpan = TimeSpan.FromSeconds(int.Parse(ForestPoemOustMedical.instance.ForestPoemOust.ChipGetAds_CD)) - span;

            string timestr = string.Format("{0:D2}m {1:D2}s", timeSpan.Minutes, timeSpan.Seconds);

            CLawnFinDawn.text = timestr;
            WeighFin.enabled = false;
            if (timeSpan.TotalSeconds <= 0)
            {
                SaveDataManager.SetString("String" + RawForestClanBatOust.ID,"");
                CLawnFinDawn.text = "Claim";
                WeighFin.enabled = true;
            }
        }
        else
        {
            WeighFin.enabled = true;
        }
    }
}
