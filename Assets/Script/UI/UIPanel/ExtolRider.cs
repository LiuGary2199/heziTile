using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ExtolRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("CashNumberText")]    [UnityEngine.Serialization.FormerlySerializedAs("CashNumberText")]public Text CookPointeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("CashImage")]    [UnityEngine.Serialization.FormerlySerializedAs("CashImage")]public Transform CookNomad;
[UnityEngine.Serialization.FormerlySerializedAs("GoldNumberText")]    [UnityEngine.Serialization.FormerlySerializedAs("GoldNumberText")]public Text LordPointeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("GoldImage")]    [UnityEngine.Serialization.FormerlySerializedAs("GoldImage")]public Transform LordNomad;
[UnityEngine.Serialization.FormerlySerializedAs("AmazonNumberText")]    [UnityEngine.Serialization.FormerlySerializedAs("AmazonNumberText")]public Text StraitPointeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("AmazonImage")]    [UnityEngine.Serialization.FormerlySerializedAs("AmazonImage")]public Transform StraitNomad;
[UnityEngine.Serialization.FormerlySerializedAs("StarBoxText")]    [UnityEngine.Serialization.FormerlySerializedAs("StarBoxText")]public Text RakeSumDawn;
[UnityEngine.Serialization.FormerlySerializedAs("LevelNumberText")]
[UnityEngine.Serialization.FormerlySerializedAs("LevelNumberText")]    public Text ExtolPointeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("UndoButton")]    [UnityEngine.Serialization.FormerlySerializedAs("UndoButton")]public Button JoltUntold;
[UnityEngine.Serialization.FormerlySerializedAs("HintButton")]    [UnityEngine.Serialization.FormerlySerializedAs("HintButton")]public Button VoltUntold;
[UnityEngine.Serialization.FormerlySerializedAs("ShuffleButton")]    [UnityEngine.Serialization.FormerlySerializedAs("ShuffleButton")]public Button RoadbedUntold;
[UnityEngine.Serialization.FormerlySerializedAs("PauseButton")]    [UnityEngine.Serialization.FormerlySerializedAs("PauseButton")]public Button MessyUntold;
[UnityEngine.Serialization.FormerlySerializedAs("BankSliderImage")]   // public Button RedeemButton;
[UnityEngine.Serialization.FormerlySerializedAs("BankSliderImage")]    public Image BossAthensNomad;
[UnityEngine.Serialization.FormerlySerializedAs("BankButton")]    [UnityEngine.Serialization.FormerlySerializedAs("BankButton")]public Button BossUntold;
[UnityEngine.Serialization.FormerlySerializedAs("FullImage")]    [UnityEngine.Serialization.FormerlySerializedAs("FullImage")]public GameObject ShinNomad;
[UnityEngine.Serialization.FormerlySerializedAs("FX_Star")]    [UnityEngine.Serialization.FormerlySerializedAs("FX_Star")]public GameObject FX_Rake;
[UnityEngine.Serialization.FormerlySerializedAs("FX_Ground")]    [UnityEngine.Serialization.FormerlySerializedAs("FX_Ground")]public GameObject FX_Locust;
[UnityEngine.Serialization.FormerlySerializedAs("BaseCash")]    [UnityEngine.Serialization.FormerlySerializedAs("BaseCash")]public GameObject KickCook;
[UnityEngine.Serialization.FormerlySerializedAs("TopBar")]    [UnityEngine.Serialization.FormerlySerializedAs("TopBar")]public GameObject BurYew;
[UnityEngine.Serialization.FormerlySerializedAs("BottonBar")]    [UnityEngine.Serialization.FormerlySerializedAs("BottonBar")]public GameObject EncodeYew;
[UnityEngine.Serialization.FormerlySerializedAs("AutoButton")]    [UnityEngine.Serialization.FormerlySerializedAs("AutoButton")]public Button LimbUntold;
[UnityEngine.Serialization.FormerlySerializedAs("StarBoxButton")]    [UnityEngine.Serialization.FormerlySerializedAs("StarBoxButton")]public Button RakeSumUntold;
[UnityEngine.Serialization.FormerlySerializedAs("GoldButton")]    [UnityEngine.Serialization.FormerlySerializedAs("GoldButton")]public Button LordUntold;
[UnityEngine.Serialization.FormerlySerializedAs("AmazonButton")]    [UnityEngine.Serialization.FormerlySerializedAs("AmazonButton")]public Button StraitUntold;
[UnityEngine.Serialization.FormerlySerializedAs("PuzzleButton")]    [UnityEngine.Serialization.FormerlySerializedAs("PuzzleButton")]public Button FalconUntold;
[UnityEngine.Serialization.FormerlySerializedAs("PuzzleIcon")]    [UnityEngine.Serialization.FormerlySerializedAs("PuzzleIcon")]public Image FalconRail;
[UnityEngine.Serialization.FormerlySerializedAs("flyManager")]    [UnityEngine.Serialization.FormerlySerializedAs("flyManager")]public WhoMedical BisMedical;
[UnityEngine.Serialization.FormerlySerializedAs("oldtop")]
[UnityEngine.Serialization.FormerlySerializedAs("oldtop")]
    public GameObject Embryo;
[UnityEngine.Serialization.FormerlySerializedAs("oldbottom")]    [UnityEngine.Serialization.FormerlySerializedAs("oldbottom")]public GameObject Scientist;
[UnityEngine.Serialization.FormerlySerializedAs("newtop")]    [UnityEngine.Serialization.FormerlySerializedAs("newtop")]public GameObject Victim;
[UnityEngine.Serialization.FormerlySerializedAs("newbottom")]    [UnityEngine.Serialization.FormerlySerializedAs("newbottom")]public GameObject Infertile;
[UnityEngine.Serialization.FormerlySerializedAs("newUndoButton")]    [UnityEngine.Serialization.FormerlySerializedAs("newUndoButton")]public Button PpmJoltUntold;
[UnityEngine.Serialization.FormerlySerializedAs("newHintButton")]    [UnityEngine.Serialization.FormerlySerializedAs("newHintButton")]public Button PpmVoltUntold;
[UnityEngine.Serialization.FormerlySerializedAs("newShuffleButton")]    [UnityEngine.Serialization.FormerlySerializedAs("newShuffleButton")]public Button PpmRoadbedUntold;
[UnityEngine.Serialization.FormerlySerializedAs("newPauseButton")]    [UnityEngine.Serialization.FormerlySerializedAs("newPauseButton")]public Button PpmMessyUntold;
[UnityEngine.Serialization.FormerlySerializedAs("newLevelNumberText")]    [UnityEngine.Serialization.FormerlySerializedAs("newLevelNumberText")]public Text PpmExtolPointeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("newGoldNumberText")]    [UnityEngine.Serialization.FormerlySerializedAs("newGoldNumberText")]public Text PpmLordPointeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("newGoldImage")]    [UnityEngine.Serialization.FormerlySerializedAs("newGoldImage")]public Transform PpmLordNomad;

    Sequence DireLordAct;
    int FootLace= 1;
    bool SewSkyFlair;

    private Sprite[] FalconDepth;
    private int FalconRailThink;    // 当前显示的碎片
[UnityEngine.Serialization.FormerlySerializedAs("StartPanel")]    
[UnityEngine.Serialization.FormerlySerializedAs("StartPanel")]    public GameObject BladeRider;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]public Button OvertFin;
[UnityEngine.Serialization.FormerlySerializedAs("newbg")]
[UnityEngine.Serialization.FormerlySerializedAs("newbg")]    public GameObject Error;

    // Start is called before the first frame update
    override protected void Awake()
    {
        if (CommonUtil.IsBgswitch())
        {
            Error.gameObject.SetActive(true);
            Embryo.gameObject.SetActive(false);
            Scientist.gameObject.SetActive(false);
            Victim.gameObject.SetActive(true);
            Infertile.gameObject.SetActive(true);
        }
        else
        {
            Error.gameObject.SetActive(false);
            Embryo.gameObject.SetActive(true);
            Scientist.gameObject.SetActive(true);
            Victim.gameObject.SetActive(false);
            Infertile.gameObject.SetActive(false);

        }
        base.Awake();
        BladeRider.gameObject.SetActive(true);
        ADManager.Instance.initAutoPlayTime();
        OvertFin.onClick.AddListener(() =>
        {
            BladeRider.gameObject.SetActive(false);
        });
        JoltUntold.onClick.AddListener(() =>
        {
            if (SewSkyFlair)
            {
                if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) > 2)
                {
                    if (Dire.instance.BraveScheme.GetComponent<ExtolToll>().CooperWordLend.Count - Dire.instance.BraveScheme.GetComponent<ExtolToll>().OralEasilyLend.Count > 0)
                    {
                        if (Dire.instance.WhoFlairGrass("Undo") > 0)
                        {
                            Dire.instance.EkeFlairGrass("Undo", 1);
                            MessageCenterLogic.GetInstance().Send("mg_undo");
                            StartCoroutine(nameof(ScowlJawSkyCentTerm));
                            ExtractFlairGrass();
                        }
                        else
                        {
                            UIManager.GetInstance().ShowUIForms(nameof(FlairRider));
                            MessageCenterLogic.GetInstance().Send(CConfig.mg_SkillType, new MessageData(CConfig.mg_undo));
                        }
                    }
                }
                else
                {
                    SaveDataManager.SetInt(CConfig.sv_NewUserStep, 3);
                    CapExamMedical.GetInstance().RareArab(JoltUntold.gameObject, true);
                    Dire.instance.WhoFlairGrass("Undo", 2);
                    MessageCenterLogic.GetInstance().Send("RefreshSkill");
                    MessageCenterLogic.GetInstance().Send("mg_undo");
                    StartCoroutine(nameof(ScowlJawSkyCentTerm));
                }
            }
            
            
        });
        RakeSumUntold.onClick.AddListener(() => 
        {
            //UIManager.GetInstance().ShowUIForms(nameof(RakeSumRider));
            //return;
            if (Dire.instance.OakRakeRed() < GameUtil.StarBoxNum())
            {
                ToastManager.GetInstance().ShowToast("Pass " + GameUtil.StarBoxNum() + " level to open the CHEST ");
                //AlertManager.GetInstance().ShowAlert("Pass " + GameUtil.StarBoxNum() + " level to open the CHEST ");
            }
            else
            {
                UIManager.GetInstance().ShowUIForms(nameof(RakeSumRider));
            }
        });
        VoltUntold.onClick.AddListener(() =>
        {
            if (SewSkyFlair)
            {
                if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) > 3)
                {
                    if (Dire.instance.WhoFlairGrass("Hint") > 0)
                    {
                        Dire.instance.EkeFlairGrass("Hint", 1);
                        MessageCenterLogic.GetInstance().Send("mg_hint");
                        ExtractFlairGrass();
                        StartCoroutine(nameof(ScowlJawSkyCentTerm));
                    }
                    else
                    {
                        UIManager.GetInstance().ShowUIForms(nameof(FlairRider));
                        MessageCenterLogic.GetInstance().Send(CConfig.mg_SkillType, new MessageData(CConfig.mg_hint));
                    }
                }
                else
                {
                    SaveDataManager.SetInt(CConfig.sv_NewUserStep, 4);
                    CapExamMedical.GetInstance().RareArab(VoltUntold.gameObject, true);
                    Dire.instance.WhoFlairGrass("Hint", 2);
                    MessageCenterLogic.GetInstance().Send("RefreshSkill");
                    MessageCenterLogic.GetInstance().Send("mg_hint");
                    StartCoroutine(nameof(ScowlJawSkyCentTerm));
                }
            }
            
        });
        RoadbedUntold.onClick.AddListener(() =>
        {
            if (SewSkyFlair)
            {
                if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) > 4)
                {
                    if (Dire.instance.WhoFlairGrass("Shuffle") > 0)
                    {
                        Dire.instance.EkeFlairGrass("Shuffle", 1);
                        MessageCenterLogic.GetInstance().Send("mg_shuffle");
                        ExtractFlairGrass();
                        StartCoroutine(nameof(ScowlJawSkyCentTerm));
                    }
                    else
                    {
                        UIManager.GetInstance().ShowUIForms(nameof(FlairRider));
                        MessageCenterLogic.GetInstance().Send(CConfig.mg_SkillType, new MessageData(CConfig.mg_shuffle));
                    }
                }
                else
                {
                    SaveDataManager.SetInt(CConfig.sv_NewUserStep, 5);
                    CapExamMedical.GetInstance().RareArab(RoadbedUntold.gameObject, true);
                    Dire.instance.WhoFlairGrass("Shuffle", 2);
                    MessageCenterLogic.GetInstance().Send("RefreshSkill");
                    MessageCenterLogic.GetInstance().Send("mg_shuffle");
                    StartCoroutine(nameof(ScowlJawSkyCentTerm));
                }
            }
        });
        LimbUntold.onClick.AddListener(() => {
            Dire.instance.BraveScheme.GetComponent<ExtolToll>().LimbLodge();
            LimbUntold.gameObject.SetActive(false);
        });
        MessyUntold.onClick.AddListener(() =>
        {
            UIManager.GetInstance().ShowUIForms(nameof(MessyRider));
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_LevelPanel_LevelNumber, (messageData) =>
        {
            ExtolPointeDawn.text = ""+ messageData.valueInt;
            PpmExtolPointeDawn.text = "" + messageData.valueInt;
        });
        BossUntold.onClick.AddListener(() =>
        {
            PostEventScript.GetInstance().SendEvent("1210");
            OpenUIForm("BankPanel");
            MessageCenterLogic.GetInstance().Send(CConfig.mg_BankPanel_From, new MessageData(GetType().Name));
        });

        PpmMessyUntold.onClick.AddListener(() =>
        {
            UIManager.GetInstance().ShowUIForms(nameof(MessyRider));
        });
        PpmJoltUntold.onClick.AddListener(() =>
        {
            if (SewSkyFlair)
            {
                if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) > 2)
                {
                    if (Dire.instance.BraveScheme.GetComponent<ExtolToll>().CooperWordLend.Count - Dire.instance.BraveScheme.GetComponent<ExtolToll>().OralEasilyLend.Count > 0)
                    {
                        if (Dire.instance.WhoFlairGrass("Undo") > 0)
                        {
                            Dire.instance.EkeFlairGrass("Undo", 1);
                            MessageCenterLogic.GetInstance().Send("mg_undo");
                            StartCoroutine(nameof(ScowlJawSkyCentTerm));
                            ExtractFlairGrass();
                        }
                        else
                        {
                            UIManager.GetInstance().ShowUIForms(nameof(FlairRider));
                            MessageCenterLogic.GetInstance().Send(CConfig.mg_SkillType, new MessageData(CConfig.mg_undo));
                        }
                    }
                }
                else
                {
                    SaveDataManager.SetInt(CConfig.sv_NewUserStep, 3);
                    CapExamMedical.GetInstance().RareArab(PpmJoltUntold.gameObject, true);
                    Dire.instance.WhoFlairGrass("Undo", 2);
                    MessageCenterLogic.GetInstance().Send("RefreshSkill");
                    MessageCenterLogic.GetInstance().Send("mg_undo");
                    StartCoroutine(nameof(ScowlJawSkyCentTerm));
                }
            }
        });
        PpmRoadbedUntold.onClick.AddListener(() =>
        {
            if (SewSkyFlair)
            {
                if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) > 4)
                {
                    if (Dire.instance.WhoFlairGrass("Shuffle") > 0)
                    {
                        Dire.instance.EkeFlairGrass("Shuffle", 1);
                        MessageCenterLogic.GetInstance().Send("mg_shuffle");
                        ExtractFlairGrass();
                        StartCoroutine(nameof(ScowlJawSkyCentTerm));
                    }
                    else
                    {
                        UIManager.GetInstance().ShowUIForms(nameof(FlairRider));
                        MessageCenterLogic.GetInstance().Send(CConfig.mg_SkillType, new MessageData(CConfig.mg_shuffle));
                    }
                }
                else
                {
                    SaveDataManager.SetInt(CConfig.sv_NewUserStep, 5);
                    CapExamMedical.GetInstance().RareArab(PpmRoadbedUntold.gameObject, true);
                    Dire.instance.WhoFlairGrass("Shuffle", 2);
                    MessageCenterLogic.GetInstance().Send("RefreshSkill");
                    MessageCenterLogic.GetInstance().Send("mg_shuffle");
                    StartCoroutine(nameof(ScowlJawSkyCentTerm));
                }
            }
        });
        PpmVoltUntold.onClick.AddListener(() =>
        {
            if (SewSkyFlair)
            {
                if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) > 3)
                {
                    if (Dire.instance.WhoFlairGrass("Hint") > 0)
                    {
                        Dire.instance.EkeFlairGrass("Hint", 1);
                        MessageCenterLogic.GetInstance().Send("mg_hint");
                        ExtractFlairGrass();
                        StartCoroutine(nameof(ScowlJawSkyCentTerm));
                    }
                    else
                    {
                        UIManager.GetInstance().ShowUIForms(nameof(FlairRider));
                        MessageCenterLogic.GetInstance().Send(CConfig.mg_SkillType, new MessageData(CConfig.mg_hint));
                    }
                }
                else
                {
                    SaveDataManager.SetInt(CConfig.sv_NewUserStep, 4);
                    CapExamMedical.GetInstance().RareArab(PpmVoltUntold.gameObject, true);
                    Dire.instance.WhoFlairGrass("Hint", 2);
                    MessageCenterLogic.GetInstance().Send("RefreshSkill");
                    MessageCenterLogic.GetInstance().Send("mg_hint");
                    StartCoroutine(nameof(ScowlJawSkyCentTerm));
                }
            }

        });
        //RedeemButton.onClick.AddListener(() => {
        //   //OpenUIForm("RedeemPanel");
        //    if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) == 1)
        //    {
        //        SaveDataManager.SetInt(CConfig.sv_NewUserStep, 2);
        //        CapExamMedical.GetInstance().HideMask(RedeemButton.gameObject, true);
        //    }
        //});

        //GoldButton.onClick.AddListener(() => {
        //    SOHOShopManager.instance.ShowGoldAmazonRedeemPanel();
        //});
        //AmazonButton.onClick.AddListener(() => {
        //    SOHOShopManager.instance.ShowGoldAmazonRedeemPanel();
        //});
        //PuzzleButton.onClick.AddListener(() => {
        //    SOHOShopManager.instance.ShowRedeemGiftPanel();
        //});


        MessageCenterLogic.GetInstance().Register(CConfig.mg_LevelPanel_BankAdd, (messageData) =>
        {
            Transform startTrans = messageData.valueGameObject.transform;
            SlamWordFormation(startTrans, messageData.valueInt);
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_LevelPanel_BankClear, (messageData) =>
        {
            
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_LevelPanel_AddCash, (messageData) =>
        {
            SlamWhoFormation(messageData.valueTransform, messageData.valueDouble);
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_LevelPanel_AddGold, (messageData) =>
        {
            BarnWhoFormation(messageData.valueTransform, messageData.valueDouble);
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_LevelPanel_AddAmazon, (messageData) =>
        {
            RevereWhoFormation(messageData.valueTransform, messageData.valueDouble);
        });
       
        MessageCenterLogic.GetInstance().Register(CConfig.mg_LevelPanel_Hide, (messageData) => {
            OnHide();
        });
        MessageCenterLogic.GetInstance().Register("RefreshSkill", (messageData) =>
        {
            ExtractFlairGrass();
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_ShowAutoButton, (messageData) =>
        {
            if (LimbUntold.gameObject.activeInHierarchy == false) 
            {
                LimbUntold.gameObject.SetActive(true);
                AnimationController.HomeBankShow(LimbUntold.gameObject, 2f, () => { });
            }
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_DissmissAutoButton, (messageData) =>
        {
            LimbUntold.gameObject.SetActive(false);
        });

        MessageCenterLogic.GetInstance().Register(CConfig.mg_ChangeStar, (messagegData) => {
            SpringRakeSumRed();
        });


        // 现金提现引导
        MessageCenterLogic.GetInstance().Register(CConfig.mg_ShowCashShopGuide, (messageData) => { 
            //if (!GameUtil.IsApple())
            //{
            //    if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) == 1)
            //    {
            //        // 新用户引导
            //        CapExamMedical.GetInstance().ShowMask(true, true, RedeemButton.GetComponent<RectTransform>().localPosition, RedeemButton.gameObject);
            //    }
            //}
        });

        // 技能引导
        MessageCenterLogic.GetInstance().Register(CConfig.mg_ShowSkillGuide, (messageData) => {
            ExtractFlairGrass();
            int BravePointe= messageData.valueInt;
            int userGuideStep = SaveDataManager.GetInt(CConfig.sv_NewUserStep);
            if (userGuideStep == 2 && BravePointe == 2)
            {
                if (CommonUtil.IsBgswitch())
                {
                    Vector3 position = PpmJoltUntold.GetComponent<RectTransform>().localPosition;
                    CapExamMedical.GetInstance().NoteArab(true, true, new Vector3(position.x, position.y + 50, position.z), PpmJoltUntold.gameObject);
                }
                else
                {
                    Vector3 position = JoltUntold.GetComponent<RectTransform>().localPosition;
                    CapExamMedical.GetInstance().NoteArab(true, true, new Vector3(position.x, position.y + 50, position.z), JoltUntold.gameObject);
                }
            }
            else if (userGuideStep == 3 && BravePointe == 3)
            {
                if (CommonUtil.IsBgswitch())
                {
                    Vector3 position = PpmVoltUntold.GetComponent<RectTransform>().localPosition;
                    CapExamMedical.GetInstance().NoteArab(true, true, new Vector3(position.x, position.y + 50, position.z), PpmVoltUntold.gameObject);
                }
                else
                {
                    Vector3 position = VoltUntold.GetComponent<RectTransform>().localPosition;
                    CapExamMedical.GetInstance().NoteArab(true, true, new Vector3(position.x, position.y + 50, position.z), VoltUntold.gameObject);
                }

            }
            else if (userGuideStep == 4 && BravePointe == 4)
            {
                if (CommonUtil.IsBgswitch())
                {
                    Vector3 position = PpmRoadbedUntold.GetComponent<RectTransform>().localPosition;
                    CapExamMedical.GetInstance().NoteArab(true, true, new Vector3(position.x, position.y + 50, position.z), PpmRoadbedUntold.gameObject);
                }
                else
                {
                    Vector3 position = RoadbedUntold.GetComponent<RectTransform>().localPosition;
                    CapExamMedical.GetInstance().NoteArab(true, true, new Vector3(position.x, position.y + 50, position.z), RoadbedUntold.gameObject);
                }
            }
        });
    }
    IEnumerator ScowlJawSkyCentTerm()
    {
        SewSkyFlair = false;
        yield return new WaitForSeconds(0.8f);
        SewSkyFlair = true;
    }
    public override void Display()
    {
        base.Display();

        if (CommonUtil.IsApple()) {
            // 审核模式
            CookNomad.transform.parent.gameObject.SetActive(false);
            StraitNomad.transform.parent.gameObject.SetActive(false);
            FalconUntold.gameObject.SetActive(false);
           // RedeemButton.gameObject.SetActive(false);
            LordUntold.enabled = false;
        }
        else
        {
            CookNomad.transform.parent.gameObject.SetActive(true);
            StraitNomad.transform.parent.gameObject.SetActive(true);
            FalconUntold.gameObject.SetActive(true);
           // RedeemButton.gameObject.SetActive(true);
            LordUntold.enabled = true;
        }

        ADManager.Instance.resumeAutoPlayTime();
        SewSkyFlair = true;
        SpurMedical.instance.BusLocustRare();
        OnShow();
        CookPointeDawn.text = NumberUtil.DoubleToStr(Dire.instance.WhoCook());
        LordPointeDawn.text = NumberUtil.DoubleToStr(Dire.instance.WhoLord());
        PpmLordPointeDawn.text = NumberUtil.DoubleToStr(Dire.instance.WhoLord());
        StraitPointeDawn.text = NumberUtil.DoubleToStr(Dire.instance.WhoStrait());
        SpringRakeSumRed();

        ExtractFlairGrass();

        //showPuzzleShopIcon();
    }
    public override void Hidding()
    {
        base.Hidding();
        ADManager.Instance.pauseAutoPlayTime();
    }
    public void ExtractFlairGrass()
    {
        int BravePointe= Dire.instance.BraveScheme.BravePointe;
        if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) >= 2 && BravePointe >= 2)
        {
            if (CommonUtil.IsBgswitch())
            {
                PpmJoltUntold.transform.Find("LockImage").gameObject.SetActive(false);
            }
            else
            {
                JoltUntold.transform.Find("LockImage").gameObject.SetActive(false);
            }
        }
    
        if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) >= 3 && BravePointe >= 3)
        {
            if (CommonUtil.IsBgswitch())
            {
                PpmVoltUntold.transform.Find("LockImage").gameObject.SetActive(false);
            }
            else
            {
                VoltUntold.transform.Find("LockImage").gameObject.SetActive(false);
            }
        }
        if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) >= 4 && BravePointe >= 4)
        {
            if (CommonUtil.IsBgswitch())
            {
                PpmRoadbedUntold.transform.Find("LockImage").gameObject.SetActive(false);
            }
            else
            {
                RoadbedUntold.transform.Find("LockImage").gameObject.SetActive(false);
            }
        }
        if (Dire.instance.WhoFlairGrass("Undo") > 0)
        {
            if (CommonUtil.IsBgswitch())
            {
                PpmJoltUntold.transform.Find("SkillTime").gameObject.SetActive(true);
                PpmJoltUntold.transform.Find("SkillTime/Text").GetComponent<Text>().text = Dire.instance.WhoFlairGrass("Undo").ToString();
            }
            else
            {
                JoltUntold.transform.Find("SkillTime").gameObject.SetActive(true);
                JoltUntold.transform.Find("SkillTime/Text").GetComponent<Text>().text = Dire.instance.WhoFlairGrass("Undo").ToString();
            }
        }
        else
        {
            if (CommonUtil.IsBgswitch())
            {
                PpmJoltUntold.transform.Find("SkillTime").gameObject.SetActive(false);
            }
            else
            {
                JoltUntold.transform.Find("SkillTime").gameObject.SetActive(false);
            }
        }
        if (Dire.instance.WhoFlairGrass("Hint") > 0)
        {
            if (CommonUtil.IsBgswitch())
            {
                PpmVoltUntold.transform.Find("SkillTime").gameObject.SetActive(true);
                PpmVoltUntold.transform.Find("SkillTime/Text").GetComponent<Text>().text = Dire.instance.WhoFlairGrass("Hint").ToString();
            }
            else
            {
                VoltUntold.transform.Find("SkillTime").gameObject.SetActive(true);
                VoltUntold.transform.Find("SkillTime/Text").GetComponent<Text>().text = Dire.instance.WhoFlairGrass("Hint").ToString();
            }
        }
        else
        {
            if (CommonUtil.IsBgswitch())
            {
                PpmVoltUntold.transform.Find("SkillTime").gameObject.SetActive(false);
            }
            else
            {
                VoltUntold.transform.Find("SkillTime").gameObject.SetActive(false);
            }
        }
        if (Dire.instance.WhoFlairGrass("Shuffle") > 0)
        {
            if (CommonUtil.IsBgswitch())
            {
                PpmRoadbedUntold.transform.Find("SkillTime").gameObject.SetActive(true);
                PpmRoadbedUntold.transform.Find("SkillTime/Text").GetComponent<Text>().text = Dire.instance.WhoFlairGrass("Shuffle").ToString();
            }
            else
            {
                RoadbedUntold.transform.Find("SkillTime").gameObject.SetActive(true);
                RoadbedUntold.transform.Find("SkillTime/Text").GetComponent<Text>().text = Dire.instance.WhoFlairGrass("Shuffle").ToString();
            }
        }
        else
        {
            if (CommonUtil.IsBgswitch())
            {
                PpmRoadbedUntold.transform.Find("SkillTime").gameObject.SetActive(false);
            }
            else
            {
                RoadbedUntold.transform.Find("SkillTime").gameObject.SetActive(false);
            }
        }
    }
    
    public void SlamWhoFormation(Transform startTransform, double num)
    {
        Transform P= UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/ExtolRider/CashBar/CashIcon");
        if (startTransform != null)
        {
            GameObject goldobj = LordNomad.gameObject;
            if (CommonUtil.IsBgswitch())
            {
                goldobj = PpmLordNomad.gameObject;
            }
            AnimationController.GoldMoveBest(goldobj, 15, startTransform, P, () =>
            {
                AnimationController.ChangeNumber(double.Parse(CookPointeDawn.text), (int)Dire.instance.WhoCook(), 0.1f, CookPointeDawn, () => {
                    Dire.instance.SlamNotePointe = NumberUtil.DoubleToStr(Dire.instance.WhoCook());
                    CookPointeDawn.text = Dire.instance.SlamNotePointe;
                });
            });
        }
        else
        {
            AnimationController.ChangeNumber(double.Parse(CookPointeDawn.text), (int)Dire.instance.WhoCook(), 0.1f, CookPointeDawn, () => {
                Dire.instance.SlamNotePointe = NumberUtil.DoubleToStr(Dire.instance.WhoCook());
                CookPointeDawn.text = Dire.instance.SlamNotePointe;
            });
        }
    }
    public void BarnWhoFormation(Transform startTransform, double num)
    {
        Transform P = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/ExtolRider/GoldBar/GoldIcon");
        if (startTransform != null)
        {
            GameObject goldobj = LordNomad.gameObject;
            if (CommonUtil.IsBgswitch())
            {
                goldobj = PpmLordNomad.gameObject;
                P = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/ExtolRider/NewTopGroup/GoldBar/GoldIcon");
            }
            AnimationController.GoldMoveBest(goldobj, Mathf.Max((int)num, 1), startTransform, P, () =>
            {
                if (CommonUtil.IsBgswitch())
                {
                    AnimationController.ChangeNumber(double.Parse(PpmLordPointeDawn.text), Dire.instance.WhoLord(), 0.1f, PpmLordPointeDawn, () =>
                    {
                        Dire.instance.goldNotePointe = NumberUtil.DoubleToStr(Dire.instance.WhoLord());
                        PpmLordPointeDawn.text = Dire.instance.goldNotePointe;
                    });
                }
                else
                {
                    AnimationController.ChangeNumber(double.Parse(LordPointeDawn.text), Dire.instance.WhoLord(), 0.1f, LordPointeDawn, () =>
                    {
                        Dire.instance.goldNotePointe = NumberUtil.DoubleToStr(Dire.instance.WhoLord());
                        LordPointeDawn.text = Dire.instance.goldNotePointe;
                    });
                }
            });
        }
        else
        {
            if (CommonUtil.IsBgswitch())
            {
                AnimationController.ChangeNumber(double.Parse(PpmLordPointeDawn.text), Dire.instance.WhoLord(), 0.1f, PpmLordPointeDawn, () => {
                    Dire.instance.goldNotePointe = NumberUtil.DoubleToStr(Dire.instance.WhoLord());
                    PpmLordPointeDawn.text = Dire.instance.goldNotePointe;
                });
            }
            else
            {
                AnimationController.ChangeNumber(double.Parse(LordPointeDawn.text), Dire.instance.WhoLord(), 0.1f, LordPointeDawn, () => {
                    Dire.instance.goldNotePointe = NumberUtil.DoubleToStr(Dire.instance.WhoLord());
                    LordPointeDawn.text = Dire.instance.goldNotePointe;
                });
            }
        }

    }
    public void RevereWhoFormation(Transform startTransform, double num)
    {
        Transform P = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/ExtolRider/AmazonBar/AmazonIcon");
        if (startTransform != null)
        {
            GameObject goldobj = LordNomad.gameObject;
            if (CommonUtil.IsBgswitch())
            {
                goldobj = PpmLordNomad.gameObject;
            }
            AnimationController.GoldMoveBest(goldobj, Mathf.Max((int)num, 1), startTransform, P, () =>
            {
                AnimationController.ChangeNumber(double.Parse(StraitPointeDawn.text), Dire.instance.WhoStrait(), 0.1f, StraitPointeDawn, () => {
                    Dire.instance.RevereNotePointe = NumberUtil.DoubleToStr(Dire.instance.WhoStrait());
                    StraitPointeDawn.text = Dire.instance.RevereNotePointe;
                });
            });
        }
        else
        {
            AnimationController.ChangeNumber(double.Parse(StraitPointeDawn.text), Dire.instance.WhoStrait(), 0.1f, StraitPointeDawn, () => {
                Dire.instance.RevereNotePointe = NumberUtil.DoubleToStr(Dire.instance.WhoStrait());
                StraitPointeDawn.text = Dire.instance.RevereNotePointe;
            });
        }
    }
    public void SlamWordFormation(Transform startTrans,int bankType)
    {
        
        
    }

    // 修改星星宝箱星星数量
    private void SpringRakeSumRed()
    {
        int starNum = Dire.instance.OakRakeRed();
        int maxNum = GameUtil.StarBoxNum();
        RakeSumDawn.text = starNum + "/" + maxNum;
        if (starNum >= maxNum)
        {
            // 自动打开星星宝箱
            UIManager.GetInstance().ShowUIForms(nameof(RakeSumRider));
            Dire.instance.AsianRakeRed();
        }
    }

    // 修改提现商店和碎片商店的icon
    //private void showPuzzleShopIcon()
    //{
    //    if (PuzzleIcons == null || PuzzleIcons.Length == 0)
    //    {
    //        PuzzleIcons = Resources.LoadAll<Sprite>("SOHOShop/UI_Redeem/UI_Puzzle/Puzzle");
    //    }
    //    PuzzleIconIndex = 0;

    //    StartCoroutine(changePuzzleShopIcon());
    //}
    //private IEnumerator changePuzzleShopIcon()
    //{
    //    while(true)
    //    {
    //        PuzzleIcon.sprite = PuzzleIcons[PuzzleIconIndex];
    //        PuzzleIconIndex = (PuzzleIconIndex + 1) % PuzzleIcons.Length;

    //        yield return new WaitForSeconds(3);
    //    }
    //}

    

    void OnShow()
    {
        AnimationController.HomeShow(BurYew, 2, () => { });
        AnimationController.HomeShow(EncodeYew, -2, () => {
        });
        
    }
    void OnHide()
    {
        AnimationController.HomeHide(BurYew, 2, () => { });
        AnimationController.HomeHide(EncodeYew, -2, () => {
            UIManager.GetInstance().CloseOrReturnUIForms(nameof(ExtolRider));
            UIManager.GetInstance().ShowUIForms("HomePanel");
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
