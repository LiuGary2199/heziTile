using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestBatGrooveBoston : MonoBehaviour
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
[UnityEngine.Serialization.FormerlySerializedAs("GuideImage")]
[UnityEngine.Serialization.FormerlySerializedAs("GuideImage")]    public Image PivotNomad;
[UnityEngine.Serialization.FormerlySerializedAs("ownRobloxItemData")]
[UnityEngine.Serialization.FormerlySerializedAs("ownRobloxItemData")]    public RobloxItemData RawForestClanOust;
[UnityEngine.Serialization.FormerlySerializedAs("ShowGetFragmentPanel")]    [UnityEngine.Serialization.FormerlySerializedAs("ShowGetFragmentPanel")]public Action<int> NoteOakDilutionRider;
[UnityEngine.Serialization.FormerlySerializedAs("CLaimBtnText")]
[UnityEngine.Serialization.FormerlySerializedAs("CLaimBtnText")]    public Text CLawnFinDawn;
[UnityEngine.Serialization.FormerlySerializedAs("isCanGetReward")]    [UnityEngine.Serialization.FormerlySerializedAs("isCanGetReward")]public bool NoJawOakGroove= false;
[UnityEngine.Serialization.FormerlySerializedAs("LevelImage")]    [UnityEngine.Serialization.FormerlySerializedAs("LevelImage")]public Image ExtolNomad;
[UnityEngine.Serialization.FormerlySerializedAs("UpImage")]    [UnityEngine.Serialization.FormerlySerializedAs("UpImage")]public Image IfNomad;
    // Start is called before the first frame update
    void Start()
    {
        WeighFin.onClick.AddListener(WeighFinCGold);
        Extract();

    }
    public void Extract()
    {
        List<int> idList = new List<int>(SaveDataManager.GetIntArray("RookieList"));
        if (idList.Contains(RawForestClanOust.ID))
        {
            IfNomad.gameObject.SetActive(true);
        }
        else
        {
            IfNomad.gameObject.SetActive(false);
        } 
        IconNomad.sprite = ForestPoemOustMedical.instance.OakRuggedMeID(RawForestClanOust.ID);
        ExtolNomad.sprite = Resources.Load<Sprite>(CConfig.RRobloxJsonrobloximgLevel + RawForestClanOust.Level);
        RailRestatementDawn.text = RawForestClanOust.Name;

        GroovePacifierDawn.text = ForestPoemOustMedical.instance.OakArbitraryCriticQuill(RawForestClanOust);

        GroovePacifierNomad.fillAmount = ForestPoemOustMedical.instance.OakArbitraryCanoeQuill(RawForestClanOust);
    }
    // Update is called once per frame
    void Update()
    {
        MeetingWeighSpout();
    }
    
    public void MeetingFateful()
    {
        /*//这里的两个货币类型需要去获取
        RewardScheduleText.text =
            ForestPoemOustMedical.instance.GetShopStringValue( ownRobuxData, 55555);
        RewardScheduleImage.fillAmount = ForestPoemOustMedical.instance.GetShopFloatValue(ownRobuxData, 55555);*/
        GroovePacifierDawn.text = ForestPoemOustMedical.instance.OakArbitraryCriticQuill(RawForestClanOust);
        GroovePacifierNomad.fillAmount = ForestPoemOustMedical.instance.OakArbitraryCanoeQuill(RawForestClanOust);
    }

    public void WeighFinCGold()
    {
        NoteOakDilutionRider?.Invoke(RawForestClanOust.ID);
    }

    private void MeetingWeighSpout()
    {
        if (SaveDataManager.GetString("String" + RawForestClanOust.ID) != "")
        {
            DateTime Halt= DateTime.ParseExact(SaveDataManager.GetString("String" + RawForestClanOust.ID),"yyyyMMddHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            TimeSpan span = DateTime.Now - Halt;
            TimeSpan timeSpan = TimeSpan.FromSeconds(int.Parse(ForestPoemOustMedical.instance.ForestPoemOust.ChipGetAds_CD)) - span;

            string timestr = string.Format("{0:D2}m {1:D2}s", timeSpan.Minutes, timeSpan.Seconds);

            CLawnFinDawn.text = timestr;
            WeighFin.enabled = false;
            if (timeSpan.TotalSeconds <= 0)
            {
                SaveDataManager.SetString("String" + RawForestClanOust.ID,"");
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
