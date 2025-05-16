using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestGrooveTrigger : MonoBehaviour
{
    public int id;
[UnityEngine.Serialization.FormerlySerializedAs("ClaimBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("ClaimBtn")]public Button WeighFin;
[UnityEngine.Serialization.FormerlySerializedAs("IconImage")]
[UnityEngine.Serialization.FormerlySerializedAs("IconImage")]    public Image IconNomad;
[UnityEngine.Serialization.FormerlySerializedAs("IconRewardText")]
[UnityEngine.Serialization.FormerlySerializedAs("IconRewardText")]    public Text RailGrooveDawn;
[UnityEngine.Serialization.FormerlySerializedAs("RewardScheduleText")]
[UnityEngine.Serialization.FormerlySerializedAs("RewardScheduleText")]    public Text GroovePacifierDawn;
[UnityEngine.Serialization.FormerlySerializedAs("RewardScheduleImage")]
[UnityEngine.Serialization.FormerlySerializedAs("RewardScheduleImage")]    public Image GroovePacifierNomad;
[UnityEngine.Serialization.FormerlySerializedAs("ownRobuxData")]
[UnityEngine.Serialization.FormerlySerializedAs("ownRobuxData")]    public RobuxData RawRobuxOust;
[UnityEngine.Serialization.FormerlySerializedAs("GuideImage")]
[UnityEngine.Serialization.FormerlySerializedAs("GuideImage")]    public Image PivotNomad;
[UnityEngine.Serialization.FormerlySerializedAs("ShowWithDrawPanel")]
[UnityEngine.Serialization.FormerlySerializedAs("ShowWithDrawPanel")]    public Action<int> NoteLampRaftPanel;
[UnityEngine.Serialization.FormerlySerializedAs("ShowCoinNotEnough")]    [UnityEngine.Serialization.FormerlySerializedAs("ShowCoinNotEnough")]public Action<string, bool> NoteMeatMudMeadow;
[UnityEngine.Serialization.FormerlySerializedAs("CompleteObj")]    [UnityEngine.Serialization.FormerlySerializedAs("CompleteObj")]public GameObject EmphasisSum;
[UnityEngine.Serialization.FormerlySerializedAs("TaskText")]    [UnityEngine.Serialization.FormerlySerializedAs("TaskText")]public Text DimeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("TaskTwoText")]    [UnityEngine.Serialization.FormerlySerializedAs("TaskTwoText")]public Text DimeBatDawn;
[UnityEngine.Serialization.FormerlySerializedAs("GameImage")]
[UnityEngine.Serialization.FormerlySerializedAs("GameImage")]    public Image DireNomad;
[UnityEngine.Serialization.FormerlySerializedAs("GameText")]    [UnityEngine.Serialization.FormerlySerializedAs("GameText")]public Text DireDawn;
[UnityEngine.Serialization.FormerlySerializedAs("GameTwoText")]    [UnityEngine.Serialization.FormerlySerializedAs("GameTwoText")]public Text DireBatDawn;
[UnityEngine.Serialization.FormerlySerializedAs("GameThreeText")]    [UnityEngine.Serialization.FormerlySerializedAs("GameThreeText")]public Text DireProseDawn;
[UnityEngine.Serialization.FormerlySerializedAs("GameName")]    [UnityEngine.Serialization.FormerlySerializedAs("GameName")]public string DireLobe;
[UnityEngine.Serialization.FormerlySerializedAs("GameIconPath")]    [UnityEngine.Serialization.FormerlySerializedAs("GameIconPath")]public string DireRailKeen;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        WeighFin.onClick.AddListener(IncurFinSpeed);


        /*RewardScheduleText.text =
            ForestPoemOustMedical.instance.GetShopStringValue( ownRobuxData, 55555);
        RewardScheduleImage.fillAmount = ForestPoemOustMedical.instance.GetShopFloatValue(ownRobuxData, 55555);*/
        //RefreshSchdule();
    }
    
    public void AbsorbDebutPortrait()
    {
        SaveDataManager.SetString("RobloxRewardState" + id, "Withdraw");
        OffMaskDime();
        /*TaskText.gameObject.SetActive(true);
        TaskText.text = ForestPoemOustMedical.instance.GetRobloxTask(id).Description;*/
        IconNomad.sprite = Resources.Load<Sprite>(ForestPoemOustMedical.instance.OakForestDime(id).PicURI);
        EmphasisSum.SetActive(false);
        MeetingFateful();
    }
    public void AbsorbDebutEmphasis()
    {
        SaveDataManager.SetString("RobloxRewardState" + id, "Complete");
        TaskItemData taskItemData = ForestPoemOustMedical.instance.OakForestDime(id);
        if (taskItemData != null)
        {
            OffMaskDime();
            /*TaskText.gameObject.SetActive(true);
            TaskText.text = ForestPoemOustMedical.instance.GetRobloxTask(id).Description;*/
            IconNomad.sprite = Resources.Load<Sprite>(ForestPoemOustMedical.instance.OakForestDime(id).PicURI);
        }
        
        EmphasisSum.SetActive(true);
        MeetingFateful();
    }
    public void AbsorbDebutInsult()
    {
        DimeDawn.gameObject.SetActive(false);
        DimeBatDawn.gameObject.SetActive(false);
        EmphasisSum.SetActive(false);
        //IconImage.sprite = Resources.Load<Sprite>("RobloxShop/RobloxImage/home_icon_rubux_210");
        MeetingFateful();
    }

    private void OffMaskDime()
    {
        if (ForestPoemOustMedical.instance.EarlyOust[RawRobuxOust.ID].TaskID == 0)
        {
            DimeDawn.gameObject.SetActive(true);
            DimeBatDawn.gameObject.SetActive(false);
        }
        else
        {
            DimeDawn.gameObject.SetActive(false);
            DimeBatDawn.gameObject.SetActive(true);
        }
    }
    private void OnEnable()
    {
        //RefreshInfo();

    }

    /// <summary>
    /// 刷新状态
    /// </summary>
    public void MeetingGate()
    {
        RailGrooveDawn.text = RawRobuxOust.currencyValue.ToString();
        IconNomad.sprite = ForestPoemOustMedical.instance.OakRuggedMeID(RawRobuxOust.ID);
        DireNomad.sprite = ForestPoemOustMedical.instance.OakRuggedMeID(DireRailKeen);
        if (DireLobe != "Coins" && DireLobe != "Diamonds")
        {
            DireDawn.gameObject.SetActive(true);
            DireBatDawn.gameObject.SetActive(false);
            DireProseDawn.gameObject.SetActive(false);
            DireDawn.text = DireLobe;
            
        }
        else if(DireLobe == "Coins")
        {
            DireDawn.gameObject.SetActive(false);
            DireBatDawn.gameObject.SetActive(true);
            DireProseDawn.gameObject.SetActive(false);
        }
        else
        {
            DireDawn.gameObject.SetActive(false);
            DireBatDawn.gameObject.SetActive(false);
            DireProseDawn.gameObject.SetActive(true);
        }
        if (SaveDataManager.GetString("RobloxRewardState" + id)  == "")
        {
            AbsorbDebutInsult();
        }
        else if(SaveDataManager.GetString("RobloxRewardState" + id) == "Withdraw")
        {
            AbsorbDebutPortrait();
        }
        else
        {
            AbsorbDebutEmphasis();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void IncurFinSpeed()
    {
        //Todo 反馈 货币够了
        if (GroovePacifierNomad.fillAmount >= 1)
        {
            Debug.Log("货币够了!");

            if (SaveDataManager.GetString("RobloxRewardState" + id) == "")
            {
                NoteLampRaftPanel?.Invoke(RawRobuxOust.ID);
            }
            else if (SaveDataManager.GetString("RobloxRewardState" + id) == "Withdraw")
            {
                ForestPoemRider.instance.NoteClusterRider();
                AbsorbDebutEmphasis();
            }
            else
            {
                return;
            }
        }
        //货币不够
        else
        {
            if (SaveDataManager.GetString("RobloxRewardState" + id) == "")
            {
                if (RawRobuxOust.CostType == 1)
                    NoteMeatMudMeadow?.Invoke("1", false);
                else if (RawRobuxOust.CostType == 2)
                    NoteMeatMudMeadow?.Invoke("2", false);
                else if (RawRobuxOust.CostType == 3)
                    NoteMeatMudMeadow?.Invoke("3", false);
                else
                    NoteMeatMudMeadow?.Invoke("5", false);
                Debug.Log("货币不够!");
            }
            else if (SaveDataManager.GetString("RobloxRewardState" + id) == "Withdraw")
            {
                NoteMeatMudMeadow?.Invoke("4", false);
            }
            else
            {
                return;
            }
            
        }
    }

    public void MeetingFateful()
    {
        if (SaveDataManager.GetString("RobloxRewardState" + id) == "")
        {
            //Todo 这里的两个货币类型需要去获取
            if (RawRobuxOust != null && RawRobuxOust.CostType == 1)
            {
                GroovePacifierDawn.text =
                    ForestPoemOustMedical.instance.OakPoemCriticQuill(RawRobuxOust, ForestPoemOustMedical.instance.BehaviorFur);
                GroovePacifierNomad.fillAmount = ForestPoemOustMedical.instance.OakPoemFloatQuill(RawRobuxOust, ForestPoemOustMedical.instance.BehaviorFur);
            }
            else if (RawRobuxOust != null && RawRobuxOust.CostType == 2)
            {
                GroovePacifierDawn.text =
                    ForestPoemOustMedical.instance.OakPoemCriticQuill(RawRobuxOust, ForestPoemOustMedical.instance.BehaviorBat);
                GroovePacifierNomad.fillAmount = ForestPoemOustMedical.instance.OakPoemFloatQuill(RawRobuxOust, ForestPoemOustMedical.instance.BehaviorBat);
            }
            else if(RawRobuxOust != null)
            {
                GroovePacifierDawn.text =
                    ForestPoemOustMedical.instance.OakPoemCriticQuill(RawRobuxOust, ForestPoemOustMedical.instance.BehaviorProse);
                GroovePacifierNomad.fillAmount = ForestPoemOustMedical.instance.OakPoemFloatQuill(RawRobuxOust, ForestPoemOustMedical.instance.BehaviorProse);
            }
        }
        if (SaveDataManager.GetString("RobloxRewardState" + id) == "Withdraw")
        {
            GroovePacifierDawn.text = ForestPoemOustMedical.instance.OakDimeNoteQuill(id);
            GroovePacifierNomad.fillAmount = ForestPoemOustMedical.instance.OakDimeNoteTreeDesert(id);
        }
        if (SaveDataManager.GetString("RobloxRewardState" + id) == "Complete")
        {

            TaskItemData taskItemData = ForestPoemOustMedical.instance.OakForestDime(id);
            if (taskItemData != null)
            {
                GroovePacifierDawn.text = ForestPoemOustMedical.instance.OakDimeNoteQuill(id);
                GroovePacifierNomad.fillAmount = ForestPoemOustMedical.instance.OakDimeNoteTreeDesert(id);
            }
        }

    }
}
