using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

public class ForestPoemRider : BaseUIForms
{
    public static ForestPoemRider instance;
[UnityEngine.Serialization.FormerlySerializedAs("BackBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("BackBtn")]public Button CaneFin;
[UnityEngine.Serialization.FormerlySerializedAs("RuleBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("RuleBtn")]    public Button WeldFin;
[UnityEngine.Serialization.FormerlySerializedAs("CurrenctOneText")]
[UnityEngine.Serialization.FormerlySerializedAs("CurrenctOneText")]    public Text BehaviorFurDawn;
[UnityEngine.Serialization.FormerlySerializedAs("CurrenctTwoText")]
[UnityEngine.Serialization.FormerlySerializedAs("CurrenctTwoText")]    public Text BehaviorBatDawn;
[UnityEngine.Serialization.FormerlySerializedAs("TipsText")]
[UnityEngine.Serialization.FormerlySerializedAs("TipsText")]    public Text TipsDawn;
[UnityEngine.Serialization.FormerlySerializedAs("TipsTwoText")]    [UnityEngine.Serialization.FormerlySerializedAs("TipsTwoText")]public Text MoveBatDawn;
[UnityEngine.Serialization.FormerlySerializedAs("RewardBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("RewardBtn")]    public Button GrooveFin;
[UnityEngine.Serialization.FormerlySerializedAs("CharacterBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("CharacterBtn")]    public Button ArbitraryFin;
[UnityEngine.Serialization.FormerlySerializedAs("PropsBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("PropsBtn")]    public Button EpochFin;
[UnityEngine.Serialization.FormerlySerializedAs("CharacterText")]    [UnityEngine.Serialization.FormerlySerializedAs("CharacterText")]public Text ArbitraryDawn;
[UnityEngine.Serialization.FormerlySerializedAs("PropsText")]    [UnityEngine.Serialization.FormerlySerializedAs("PropsText")]public Text EpochDawn;
[UnityEngine.Serialization.FormerlySerializedAs("costumesImage")]
[UnityEngine.Serialization.FormerlySerializedAs("costumesImage")]    public GameObject IsotopicNomad;
[UnityEngine.Serialization.FormerlySerializedAs("CircleGuideBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("CircleGuideBtn")]    public Button CrayonPivotFin;
[UnityEngine.Serialization.FormerlySerializedAs("RectGuideBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("RectGuideBtn")]public Button WhigPivotFin;
[UnityEngine.Serialization.FormerlySerializedAs("GoldImage")]
[UnityEngine.Serialization.FormerlySerializedAs("GoldImage")]    public Image LordNomad;
[UnityEngine.Serialization.FormerlySerializedAs("DiamondImage")]    
[UnityEngine.Serialization.FormerlySerializedAs("DiamondImage")]    public Image SessionNomad;
[UnityEngine.Serialization.FormerlySerializedAs("BGImage")]    [UnityEngine.Serialization.FormerlySerializedAs("BGImage")]public Image BGNomad;
[UnityEngine.Serialization.FormerlySerializedAs("RewardObj")]
[UnityEngine.Serialization.FormerlySerializedAs("RewardObj")]    public GameObject GrooveSum;
[UnityEngine.Serialization.FormerlySerializedAs("CharacterObj")]
[UnityEngine.Serialization.FormerlySerializedAs("CharacterObj")]    public GameObject ArbitrarySum;
[UnityEngine.Serialization.FormerlySerializedAs("CostumesObj")]
[UnityEngine.Serialization.FormerlySerializedAs("CostumesObj")]    public GameObject PenchantSum;
[UnityEngine.Serialization.FormerlySerializedAs("RobloxRewardObj")]
[UnityEngine.Serialization.FormerlySerializedAs("RobloxRewardObj")]
    public string ForestGrooveSum;
[UnityEngine.Serialization.FormerlySerializedAs("RobloxRewardTwoObj")]
[UnityEngine.Serialization.FormerlySerializedAs("RobloxRewardTwoObj")]    public string ForestGrooveBatSum;
[UnityEngine.Serialization.FormerlySerializedAs("RobloxRewardThreeObj")]
[UnityEngine.Serialization.FormerlySerializedAs("RobloxRewardThreeObj")]    public string ForestGrooveProseSum;
[UnityEngine.Serialization.FormerlySerializedAs("IncinerateRider")]
[UnityEngine.Serialization.FormerlySerializedAs("IncinerateRider")]    public GameObject IncinerateRider;
[UnityEngine.Serialization.FormerlySerializedAs("GetFragmentPanel")]
[UnityEngine.Serialization.FormerlySerializedAs("GetFragmentPanel")]    public GameObject OakDilutionRider;
[UnityEngine.Serialization.FormerlySerializedAs("ForestWeldRider")]
[UnityEngine.Serialization.FormerlySerializedAs("ForestWeldRider")]    public GameObject ForestWeldRider;
[UnityEngine.Serialization.FormerlySerializedAs("CrayonDutchman")]
[UnityEngine.Serialization.FormerlySerializedAs("CrayonDutchman")]    public GameObject CrayonDutchman;
[UnityEngine.Serialization.FormerlySerializedAs("WhigDutchman")]    [UnityEngine.Serialization.FormerlySerializedAs("WhigDutchman")]public GameObject WhigDutchman;
[UnityEngine.Serialization.FormerlySerializedAs("GuideCharacterImage")]
[UnityEngine.Serialization.FormerlySerializedAs("GuideCharacterImage")]    public Image PivotArbitraryNomad;
[UnityEngine.Serialization.FormerlySerializedAs("GuideBackImage")]    [UnityEngine.Serialization.FormerlySerializedAs("GuideBackImage")]public Image PivotCaneNomad;

    private Image ExpertNomad;

    private Image HatchlingNomad;

    private Image EpochNomad;


    private Image ConvenientNomad;

    private Image PetroleumNomad;
[UnityEngine.Serialization.FormerlySerializedAs("rewardList")]
[UnityEngine.Serialization.FormerlySerializedAs("rewardList")]    public List<GameObject> ExpertLend= new List<GameObject>();
[UnityEngine.Serialization.FormerlySerializedAs("characterList")]
[UnityEngine.Serialization.FormerlySerializedAs("characterList")]    public List<GameObject> HatchlingLend= new List<GameObject>();
[UnityEngine.Serialization.FormerlySerializedAs("Propsist")]
[UnityEngine.Serialization.FormerlySerializedAs("Propsist")]    public List<GameObject> Unusable= new List<GameObject>();
[UnityEngine.Serialization.FormerlySerializedAs("SuccessPanel")]
[UnityEngine.Serialization.FormerlySerializedAs("SuccessPanel")]    public GameObject ClusterRider;
[UnityEngine.Serialization.FormerlySerializedAs("TaskPanel")]    [UnityEngine.Serialization.FormerlySerializedAs("TaskPanel")]public GameObject DimeRider;
    bool No_Intaglio;
[UnityEngine.Serialization.FormerlySerializedAs("SpiralMiocene")]    [UnityEngine.Serialization.FormerlySerializedAs("SpiralMiocene")]public GameObject SpiralMiocene;
[UnityEngine.Serialization.FormerlySerializedAs("RewardScrollview")]    [UnityEngine.Serialization.FormerlySerializedAs("RewardScrollview")]public GameObject GrooveCrisscross;
[UnityEngine.Serialization.FormerlySerializedAs("CharacterScrollview")]    [UnityEngine.Serialization.FormerlySerializedAs("CharacterScrollview")]public GameObject ArbitraryCrisscross;
[UnityEngine.Serialization.FormerlySerializedAs("PropsScrollview")]    [UnityEngine.Serialization.FormerlySerializedAs("PropsScrollview")]public GameObject EpochCrisscross;
    
    override protected void Awake()
    {
        base.Awake();
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CaneFin.onClick.AddListener(CaneFinSpeed);
        WeldFin.onClick.AddListener(WeldFinSpeed);
        GrooveFin.onClick.AddListener(GrooveFinSpeed);
        ArbitraryFin.onClick.AddListener(ArbitraryFinSpeed);
        EpochFin.onClick.AddListener(EpochFinSpeed);

        CrayonPivotFin.onClick.AddListener(PivotFinSpeed);
        WhigPivotFin.onClick.AddListener(PivotFinSpeed);

        //GoldImage.sprite = ForestPoemOustMedical.instance.GetSpriteByID(0, 1);
        //DiamondImage.sprite = ForestPoemOustMedical.instance.GetSpriteByID(0, 2);

        TourBehavior(ForestPoemOustMedical.instance.BehaviorFur, ForestPoemOustMedical.instance.BehaviorBat);
        ForestPoemOustMedical.instance.MeetingQuill = TourBehavior;
        ExpertNomad = GrooveFin.transform.Find("Image").GetComponent<Image>();
        ExpertNomad.gameObject.SetActive(true);
        HatchlingNomad = ArbitraryFin.transform.Find("Image").GetComponent<Image>();
        EpochNomad = EpochFin.transform.Find("Image").GetComponent<Image>();
        //CreatGame();
        FloutGroove();
        FloutArbitraryGroove();
        FloutEpochGroove();

        OnEnable();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError("horizontalNormalizedPosition == " + GameObj.transform.parent.parent.GetComponent<ScrollRect>().horizontalNormalizedPosition);
    }

    private void OnEnable()
    {
        //不是新手引导
        if (SaveDataManager.GetBool("RobloxGuide"))
        {
            if (ExpertLend != null)
            {
                for (int i = 0; i < ExpertLend.Count; i++)
                {
                    ExpertLend[i].GetComponent<ForestGrooveTrigger>().MeetingFateful();
                }
            }
            if (HatchlingLend != null)
            {
                for (int i = 0; i < HatchlingLend.Count; i++)
                {
                    HatchlingLend[i].GetComponent<ForestBatGrooveBoston>().MeetingFateful();
                }
            }
            if (Unusable != null)
            {
                for (int i = 0; i < Unusable.Count; i++)
                {
                    Unusable[i].GetComponent<ForestProseGrooveBoston>().MeetingFateful();
                }
            }

            //默认是reward分口
            GrooveFinSpeed();
        }
        //新手引导模式
        else
        {
            if (ExpertLend != null && ExpertLend.Count != 0)
            {
                ExpertLend[0].GetComponent<ForestGrooveTrigger>().PivotNomad.gameObject.SetActive(true);
                FloutCany(ExpertLend[0].gameObject, false,  0);
            }
        }
    }

    /// <summary>
    /// 初始化数据
    /// </summary>
    /// <param name="value"></param>
    /// <param name="valueTwo"></param>
    public void TourBehavior(int value, int valueTwo)
    {
        BehaviorFurDawn.text = value.ToString();
        BehaviorBatDawn.text = valueTwo.ToString();
        Oceanographic();
    }

    #region MyRegion

    private void FloutCany(GameObject self, bool isCricle,int index)
    {
        if (isCricle)
        {
            CrayonDutchman.SetActive(true);
            CrayonDutchman.GetComponent<CrayonDutchman>().Tour(self.GetComponent<Image>());
        }
        else
        {
            WhigDutchman.SetActive(true);
            WhigDutchman.GetComponent<WhigDutchman>().Tour(self.GetComponent<Image>(),index);
        }
    }

    public void Pivot(int index)
    {
        if (ForestPoemOustMedical.instance.ForestPoemOust.isStartCashShop == 0)
        {
            switch (index)
            {
                case 1 :
                    SaveDataManager.SetBool("RobloxGuide", true);
                    ExpertLend[0].GetComponent<ForestGrooveTrigger>().PivotNomad.gameObject.GetComponent<TollNomadFormation>().ParcelNomad();
                    PivotArbitraryNomad.gameObject.SetActive(true);
                    FloutCany(ArbitraryFin.gameObject, false, index);
                    break;
                case 2 :
                    PivotArbitraryNomad.gameObject.GetComponent<TollNomadFormation>().ParcelNomad();
                    ArbitraryFinSpeed();
                    HatchlingLend[2].GetComponent<ForestBatGrooveBoston>().PivotNomad.gameObject.SetActive(true);
                    FloutCany(HatchlingLend[2].gameObject, false, index);
                    break;
                case 3:
                    HatchlingLend[2].GetComponent<ForestBatGrooveBoston>().PivotNomad.gameObject.GetComponent<TollNomadFormation>().ParcelNomad();
                    SpiralMiocene.SetActive(true);
                    break;
                case 4 : 
                    PivotCaneNomad.gameObject.SetActive(true);
                    FloutCany(CaneFin.gameObject, true, index);
                    break;
            }
        }
        else
        {
            SaveDataManager.SetBool("RobloxGuide", true);
            ExpertLend[0].GetComponent<ForestGrooveTrigger>().PivotNomad.gameObject.GetComponent<TollNomadFormation>().ParcelNomad(); 
            PivotCaneNomad.gameObject.SetActive(true);
            FloutCany(CaneFin.gameObject, true, 4);
        }
    }

    #endregion

    #region Refresh

    public void Oceanographic()
    {
        if (ExpertLend != null)
        {
            for (int i = 0; i < ExpertLend.Count; i++)
            {
                ExpertLend[i].GetComponent<ForestGrooveTrigger>().MeetingFateful();
            }
        }
    }

    public void MeetingArbitrary(int id)
    {
        if (HatchlingLend != null)
        {
            for (int i = 0; i < HatchlingLend.Count; i++)
            {
                //if(id == characterList[i].GetComponent<ForestBatGrooveBoston>().ownRobloxItemData.ID)
                    HatchlingLend[i].GetComponent<ForestBatGrooveBoston>().MeetingFateful();
            }
        }
    }

    public void MeetingEpoch(int id)
    {
        if (Unusable != null)
        {
            for (int i = 0; i < Unusable.Count; i++)
            {
                if(id == Unusable[i].GetComponent<ForestProseGrooveBoston>().RawForestClanBatOust.ID)
                    Unusable[i].GetComponent<ForestProseGrooveBoston>().MeetingFateful();
            }
        }
    }
    
    

    #endregion

    #region CreatPrefab

    /// <summary>
    /// 生成商店奖励
    /// </summary>
    private void FloutGroove()
    {
        int initializationID = 2;
        if (ForestPoemOustMedical.instance.ForestPoemOust.isStartCashShop == 0)
            initializationID = 3;
        for (int i = 0; i < ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[initializationID].Shop_list.Count; i++)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>(ForestGrooveSum));
        
            obj.transform.SetParent(GrooveSum.transform, false);
            obj.GetComponent<ForestGrooveTrigger>().RawRobuxOust =
                ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[initializationID].Shop_list[i];
            ForestPoemOustMedical.instance.GermanyDire = initializationID;
            obj.GetComponent<ForestGrooveTrigger>().NoteLampRaftPanel = NoteIncinerateRider;
            obj.GetComponent<ForestGrooveTrigger>().NoteMeatMudMeadow = TugMemory;
            obj.GetComponent<ForestGrooveTrigger>().id = ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[initializationID].Shop_list[i].ID;
            obj.GetComponent<ForestGrooveTrigger>().DireLobe = ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[initializationID].unitName;
            obj.GetComponent<ForestGrooveTrigger>().DireRailKeen = ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[initializationID].iconPath;
            obj.GetComponent<ForestGrooveTrigger>().MeetingGate();
            obj.SetActive(true);
            ExpertLend.Add(obj);
        }

        ForestPoemOustMedical.instance.MeetingMigrantGate();
        MeetingDire(initializationID);
    }
    
    /// <summary>
    /// 生成角色进度奖励
    /// </summary>
    private void FloutArbitraryGroove()
    {
        for (int i = 0; i < ForestPoemOustMedical.instance.ForestPoemOust.Characters_list.Count; i++)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>(ForestGrooveBatSum));
        
            obj.transform.SetParent(ArbitrarySum.transform, false);
            obj.GetComponent<ForestBatGrooveBoston>().RawForestClanOust =
                ForestPoemOustMedical.instance.ForestPoemOust.Characters_list[i];
            obj.GetComponent<ForestBatGrooveBoston>().NoteOakDilutionRider = NoteOakDilutionRider;
            HatchlingLend.Add(obj);
        }
    }
    public void MeetingArbitraryGroove()
    {
        for (int i = 0; i < HatchlingLend.Count; i++)
        {
            HatchlingLend[i].GetComponent<ForestBatGrooveBoston>().RawForestClanOust = ForestPoemOustMedical.instance.ForestPoemOust.Characters_list[i];
            HatchlingLend[i].GetComponent<ForestBatGrooveBoston>().Extract();
        }
    }

    /// <summary>
    /// 生成装饰物进度奖励
    /// </summary>
    /// <param name="type"></param>
    private void FloutEpochGroove()
    {
        for (int i = 0; i < ForestPoemOustMedical.instance.ForestPoemOust.Props_list.Count; i++)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>(ForestGrooveProseSum));
            obj.transform.SetParent(PenchantSum.transform, false);
            obj.GetComponent<ForestProseGrooveBoston>().RawForestClanBatOust =
                ForestPoemOustMedical.instance.ForestPoemOust.Props_list[i];
            obj.GetComponent<ForestProseGrooveBoston>().NoteOakDilutionRider = NoteOakDilutionRider;
            Unusable.Add(obj);
        }
    }

    #endregion
    

    #region BtnClickEvent

    public void CaneFinSpeed()
    {
        /*GuideBackImage.gameObject.SetActive(false);
        CloseUIForm(GetType().Name);
        MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanelNextGuide);*/
        
#if EmojiMerge
        GuideBackImage.gameObject.SetActive(false);
        //CloseUIForm(GetType().Name);
        UIManager.GetInstance().RobloxCanvas.transform.Find("ForestPoemRider").gameObject.SetActive(false);
#elif ZenMerge
        GuideBackImage.gameObject.SetActive(false);
        gameObject.SetActive(false);
        CubeManager.instance.timeResume();
#else
        PivotCaneNomad.gameObject.SetActive(false);
        CloseUIForm(GetType().Name);
        MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanelNextGuide);
#endif
        
    }

    private void WeldFinSpeed()
    {
        ForestWeldRider.gameObject.SetActive(true);
    }

    private void GrooveFinSpeed()
    {
        if (ExpertNomad != null)
        {
            ExpertNomad.gameObject.SetActive(true);
            HatchlingNomad.gameObject.SetActive(false);
            EpochNomad.gameObject.SetActive(false);
            IsotopicNomad.gameObject.SetActive(false);
            GrooveCrisscross.SetActive(true);
            ArbitraryCrisscross.SetActive(false);
            EpochCrisscross.SetActive(false);
        }
    }

    private void ArbitraryFinSpeed()
    {
        ExpertNomad.gameObject.SetActive(false);
        HatchlingNomad.gameObject.SetActive(true);
        EpochNomad.gameObject.SetActive(false);
        IsotopicNomad.gameObject.SetActive(false);
        GrooveCrisscross.SetActive(false);
        ArbitraryCrisscross.SetActive(true);
        EpochCrisscross.SetActive(false);
    }
    
    //3 4 绑定
    private void EpochFinSpeed()
    {
        ExpertNomad.gameObject.SetActive(false);
        HatchlingNomad.gameObject.SetActive(false);
        EpochNomad.gameObject.SetActive(true);
            IsotopicNomad.gameObject.SetActive(true);
        GrooveCrisscross.SetActive(false);
        ArbitraryCrisscross.SetActive(false);
        EpochCrisscross.SetActive(true);
    }

   

    private void PivotFinSpeed()
    {
        
    }

    #endregion

    #region Invoke

    private int HatID;

    public void MeetingDire(int id)
    {
        ForestPoemOustMedical.instance.GermanyDire = id;
        BGNomad.sprite = ForestPoemOustMedical.instance.OakRuggedMeID(ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[id].bgPath);
        if(id == 3)
        {
            ArbitraryFin.interactable = true;
            EpochFin.interactable = true;
            ArbitraryDawn.color = Color.white;
            EpochDawn.color = Color.white;
        }
        else
        {
            ArbitraryFin.interactable = false;
            EpochFin.interactable = false;
            ArbitraryDawn.color = Color.gray;
            EpochDawn.color = Color.gray;
            GrooveFinSpeed();
        }
        for (int i = 0; i < ExpertLend.Count; i++)
        {
            ExpertLend[i].GetComponent<ForestGrooveTrigger>().RawRobuxOust = ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[id].Shop_list[i];
            ExpertLend[i].GetComponent<ForestGrooveTrigger>().id = ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[id].Shop_list[i].ID;
            ExpertLend[i].GetComponent<ForestGrooveTrigger>().DireLobe = ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[id].unitName;
            ExpertLend[i].GetComponent<ForestGrooveTrigger>().DireRailKeen = ForestPoemOustMedical.instance.ForestPoemOust.Shop_class[id].iconPath;
            ExpertLend[i].GetComponent<ForestGrooveTrigger>().MeetingGate();
        }
    }
    private void NoteIncinerateRider(int id)
    {
        ForestPoemOustMedical.instance.FirID = id;
        IncinerateRider.gameObject.SetActive(true);
    }
    public void NoteClusterRider()
    {
        ClusterRider.SetActive(true);
    }
    public void NoteDimeRider()
    {
        TaskItemData taskItemData = ForestPoemOustMedical.instance.OakForestDime(ForestPoemOustMedical.instance.FunPortrait);
        if (taskItemData != null)
        {
            DimeRider.SetActive(true);
        }
        else
        {
            NoteClusterRider();
        }
    }
    public void DogForestGroovePortrait(int id)
    {
        OakForestGrooveTrigger(id).AbsorbDebutPortrait();
    }
    public void DogForestGrooveEmphasis(int id)
    {
        OakForestGrooveTrigger(id).AbsorbDebutEmphasis();
    }
    public ForestGrooveTrigger OakForestGrooveTrigger(int id)
    {
        foreach (GameObject robloxReward in ExpertLend)
        {
            if (robloxReward.GetComponent<ForestGrooveTrigger>().id == id)
            {
                return robloxReward.GetComponent<ForestGrooveTrigger>();
            }
        }
        return null;
    }
    private void NoteOakDilutionRider(int id)
    {
        OakDilutionRider.GetComponent<OakFilmmakerRider>().ID = id;
        OakDilutionRider.gameObject.SetActive(true);
    }
    
    private bool MePrimaryTip= false;
    public void TugMemory(string des, bool isShow = false)
    {
        if (MePrimaryTip) return;
        MePrimaryTip = true;
        if (isShow)
        {
            TipsDawn.gameObject.SetActive(false);
            MoveBatDawn.gameObject.SetActive(true);
            MoveBatDawn.transform.parent.localPosition = Vector3.zero;
            MoveBatDawn.text = des;
            MoveBatDawn.transform.parent.DOLocalMoveY(200, 1.5f).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                MoveBatDawn.gameObject.SetActive(false);
                MePrimaryTip = false;
            });
        }
        else
        {
            
            MoveBatDawn.gameObject.SetActive(false);
            
            TipsDawn.transform.parent.GetChild(int.Parse(des)).gameObject.SetActive(true);
            TipsDawn.transform.parent.GetChild(int.Parse(des)).localPosition = Vector3.zero;
            //TipsText.transform.parent.GetChild(int.Parse(des)).gameObject.GetComponent<Text>().text = des;
            TipsDawn.transform.parent.GetChild(int.Parse(des)).transform.DOLocalMoveY(200, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                TipsDawn.transform.parent.GetChild(int.Parse(des)).gameObject.SetActive(false);
                MePrimaryTip = false;
            });
            /*TipsText.gameObject.SetActive(true);
            TipsText.transform.localPosition = Vector3.zero;
            TipsText.text = des;
            TipsText.transform.DOLocalMoveY(200, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                TipsText.gameObject.SetActive(false);
                IsPlayingTip = false;
            });*/
        }
        
    }
    
    /// <summary>
    /// 弹窗消失
    /// </summary>
    /// <param name="popUp">弹出的窗口组件</param>
    /// <param name="finished"></param>
    /// <param name="finished">[可选]弹窗效果类型</param>
    public void SixIfRare(GameObject popUp, Action finished)
    {
        popUp.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        popUp.transform.DOScale(popUp.transform.localScale * 0.01f, 0.5f).SetEase(Ease.InBack, 1.5f).OnComplete(() =>
        {
            finished();
        });
    }
    
    private Dictionary<GameObject, Vector3> BedIfLend= new Dictionary<GameObject, Vector3>();
    /// <summary>
    /// 弹窗出现
    /// </summary>
    /// <param name="popUp">弹出的窗口组件</param>
    /// <param name="finished"></param>
    /// <param name="finished">[可选]弹窗效果类型</param>
    public void SixIfNote(GameObject popUp, Action finished)
    {

        
        //Vector3 scale = popUp.transform.localScale;
        //popUp.transform.localScale = scale * 0.01f;
        if (!BedIfLend.ContainsKey(popUp))
        {
            Vector3 Flier= popUp.transform.localScale;
            BedIfLend.Add(popUp, Flier);
            popUp.transform.localScale = Flier * 0.01f;
        }
        popUp.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        popUp.transform.DOScale(popUp.transform.localScale * 100f, 0.5f).SetEase(Ease.OutBack, 1.5f).OnComplete(() =>
        {
            finished();
        });

    }

    #endregion

    
}
