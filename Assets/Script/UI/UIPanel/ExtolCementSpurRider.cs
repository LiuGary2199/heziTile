using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using DG.Tweening;

public class ExtolCementSpurRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("LevelIconList")]    [UnityEngine.Serialization.FormerlySerializedAs("LevelIconList")]public List<GameObject> ExtolRailLend;
[UnityEngine.Serialization.FormerlySerializedAs("UnlockProgress")]    [UnityEngine.Serialization.FormerlySerializedAs("UnlockProgress")]public Image CementRelation;
[UnityEngine.Serialization.FormerlySerializedAs("PlayButton")]    [UnityEngine.Serialization.FormerlySerializedAs("PlayButton")]public Button TollUntold;
[UnityEngine.Serialization.FormerlySerializedAs("PlayButtonText")]    [UnityEngine.Serialization.FormerlySerializedAs("PlayButtonText")]public Text TollUntoldDawn;
[UnityEngine.Serialization.FormerlySerializedAs("UnlockButtonText")]    [UnityEngine.Serialization.FormerlySerializedAs("UnlockButtonText")]public Text CementUntoldDawn;
[UnityEngine.Serialization.FormerlySerializedAs("UnlockText")]    [UnityEngine.Serialization.FormerlySerializedAs("UnlockText")]public Text CementDawn;
[UnityEngine.Serialization.FormerlySerializedAs("LevelText")]    [UnityEngine.Serialization.FormerlySerializedAs("LevelText")]public Text ExtolDawn;
[UnityEngine.Serialization.FormerlySerializedAs("FishBubbleImage")]    [UnityEngine.Serialization.FormerlySerializedAs("FishBubbleImage")]public GameObject SpurLocustNomad;
[UnityEngine.Serialization.FormerlySerializedAs("FishImage")]    [UnityEngine.Serialization.FormerlySerializedAs("FishImage")]public GameObject SpurNomad;
[UnityEngine.Serialization.FormerlySerializedAs("Fx_UnlockFish")]    [UnityEngine.Serialization.FormerlySerializedAs("Fx_UnlockFish")]public GameObject So_CementSpur;
[UnityEngine.Serialization.FormerlySerializedAs("lockImage")]    [UnityEngine.Serialization.FormerlySerializedAs("lockImage")]public GameObject HolyNomad;
[UnityEngine.Serialization.FormerlySerializedAs("EndPos")]    [UnityEngine.Serialization.FormerlySerializedAs("EndPos")]public GameObject OftIcy;
[UnityEngine.Serialization.FormerlySerializedAs("levelIconLock")]    [UnityEngine.Serialization.FormerlySerializedAs("levelIconLock")]public Sprite BraveRailLash;
[UnityEngine.Serialization.FormerlySerializedAs("levelIconUnlock")]    [UnityEngine.Serialization.FormerlySerializedAs("levelIconUnlock")]public Sprite BraveRailCement;
[UnityEngine.Serialization.FormerlySerializedAs("closeButton")]    [UnityEngine.Serialization.FormerlySerializedAs("closeButton")]public Button GlandUntold;
    int OatRed1;
    int OatRed2;
    int BraveRed1;
    int BraveRed2;
    int  FailCementSpurThink;
    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake();
        TollUntold.onClick.AddListener(() =>
        {
            if (TollUntoldDawn.gameObject.activeSelf)
            {
                CloseUIForm(GetType().Name);
                MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanelLevelStart);
            }
            else
            {
                ExtolCement();
            }
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_LevelUnlockEndPos, (messageData) =>
        {
            OftIcy = messageData.valueGameObject;
            Bend();
        });
    }
    
    public override void Display()
    {
        base.Display();
        SpurNomad.SetActive(true);
        OatRed1 = Dire.instance.OatNotePointe;
        OatRed2 = Dire.instance.WhoDay();
        BraveRed1 = Dire.instance.SuitExtolNotePointe;
        BraveRed2 = Dire.instance.WhoExamExtol();
        FailCementSpurThink = Dire.instance.WhoHaleCementSpurOust();
        HolyNomad.SetActive(true);
        HolyNomad.GetComponent<Transform>().Find("LockimageTop").GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        SpurLocustNomad.GetComponent<CanvasGroup>().alpha = 1;
        SpurLocustNomad.GetComponent<Transform>().Find("FishImage").GetComponent<SkeletonGraphic>().color = new Color(SpurLocustNomad.GetComponent<Transform>().Find("FishImage").GetComponent<SkeletonGraphic>().color.r, SpurLocustNomad.GetComponent<Transform>().Find("FishImage").GetComponent<SkeletonGraphic>().color.g, SpurLocustNomad.GetComponent<Transform>().Find("FishImage").GetComponent<SkeletonGraphic>().color.b, 1);
    }
    public void Bend()
    {
        
        int startLevelNum = 1;
        if (FailCementSpurThink != 0)
        {
            startLevelNum = NetInfoMgr.instance.gameData.FishShop[FailCementSpurThink - 1].UnlockValue;
        }
        int endLevelNum = NetInfoMgr.instance.gameData.FishShop[FailCementSpurThink].UnlockValue;
        int limit = endLevelNum - startLevelNum;
        float space = (CementRelation.GetComponent<RectTransform>().sizeDelta.x * CementRelation.transform.localScale.x - 60) / limit;
        for (int i = 0; i <= limit; i++)
        {
            GameObject levelIcon = ExtolRailLend[i];
            if (startLevelNum + i <= BraveRed1)
            {
                levelIcon.GetComponent<Image>().sprite = BraveRailCement;
                levelIcon.transform.Find("Text").GetComponent<Text>().color = Color.white;
            }
            else
            {
                levelIcon.GetComponent<Image>().sprite = BraveRailLash;
                levelIcon.transform.Find("Text").GetComponent<Text>().color = Color.gray;
            }
            levelIcon.transform.Find("Text").GetComponent<Text>().text = (startLevelNum + i).ToString();
            levelIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * space + 30, 0);
            levelIcon.SetActive(true);
        }
        ExtolDawn.text = "" + Dire.instance.WhoExamExtol();
        int needLevelCount = 0;
        for (int i = BraveRed2; i < endLevelNum; i++)
        {
            int needExp = Dire.instance.WhoExtolHerbDay(i);
            if (i == BraveRed2)
            {
                needExp -= OatRed2;
            }
            needLevelCount += needExp;
        }

        //UnlockText.text = "play " + needLevelCount + " more game to unlock this fish";
        GetComponent<I2.Loc.LocalizationParamsManager>().SetParameterValue("unlock_fish", needLevelCount.ToString());
        //UnlockText.GetComponent<I2.Loc.Localize>().SetTerm(UnlockText.GetComponent<I2.Loc.Localize>().Term);
        FishShopItemData itemData = NetInfoMgr.instance.gameData.FishShop[FailCementSpurThink];
        SpurNomad.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)itemData.Pos_X, (float)itemData.Pos_Y);
        SpurNomad.GetComponent<SkeletonGraphic>().skeletonDataAsset = Resources.Load<SkeletonDataAsset>(CConfig.AnimationFishAni + NetInfoMgr.instance.gameData.FishShop[FailCementSpurThink].ArtPath);
        SpurNomad.GetComponent<SkeletonGraphic>().initialSkinName = NetInfoMgr.instance.gameData.FishShop[FailCementSpurThink].SkinName;
        SpurNomad.GetComponent<SkeletonGraphic>().Initialize(true);
        SpurNomad.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "fish_await", true);
        int level1NeedExp = Dire.instance.WhoExtolHerbDay(BraveRed1 + 1);
        int level2NeedExp = Dire.instance.WhoExtolHerbDay(BraveRed2);
        float progress1 = (BraveRed1 - startLevelNum) * (1f / (float)limit) + ((float)OatRed1 / (float)level1NeedExp) * (1f / (float)limit);
        float progress2 = (BraveRed2 - startLevelNum) * (1f / (float)limit) + ((float)OatRed2 / (float)level2NeedExp) * (1f / (float)limit);
        CementRelation.fillAmount = progress1;
        
            
        if (Dire.instance.OatNotePointe != Dire.instance.WhoDay() || Dire.instance.SuitExtolNotePointe != Dire.instance.WhoExamExtol())
        {
            GlandUntold.gameObject.SetActive(false);
            TollUntold.gameObject.SetActive(false);
            Dire.instance.FirnMessyArabHis();
            Sequence Pen= DOTween.Sequence();
            Pen.AppendInterval(1f);
            int count = BraveRed1;
            for (int i = BraveRed1; i < BraveRed2; i++)
            {
                float lastProgress;
                float nowProgress = (i + 1 - startLevelNum) * (1f / (float)limit);
                if (BraveRed1 == i)
                {
                    lastProgress = progress1;
                }
                else
                {
                    lastProgress = (i - startLevelNum) * (1f / (float)limit);
                }
                Pen.Append(DOTween.To(() => lastProgress, x => CementRelation.fillAmount = x, nowProgress, 2f * (nowProgress - lastProgress))).SetEase(Ease.Linear);
                Pen.AppendCallback(() =>
                {
                    int Boost= count - startLevelNum + 1;
                    MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_LevelUp);
                    AnimationController.LevelUnlockIConScale(ExtolRailLend[Boost], BraveRailCement, ExtolRailLend[Boost].transform.Find("Text").GetComponent<Text>(), () =>
                    {

                    });
                    count++;
                    if (count == BraveRed2)
                    {
                        if (BraveRed2 == endLevelNum)
                        {

                            ExtolCementNote(() => {
                                Dire.instance.ChafeDireMessyArabHis();
                                CementUntoldDawn.gameObject.SetActive(true);
                                TollUntoldDawn.gameObject.SetActive(false);
                                TollUntold.gameObject.SetActive(true);
                            });
                        }
                        else
                        {
                            CementUntoldDawn.gameObject.SetActive(false);
                            TollUntoldDawn.gameObject.SetActive(true);
                            if (OatRed2 != 0)
                            {
                                float last= (BraveRed2 - startLevelNum) * (1f / (float)limit);
                                Pen.Append(DOTween.To(() => last, x => CementRelation.fillAmount = x, progress2, 2f * (progress2 - last))).SetEase(Ease.Linear);
                                Pen.AppendCallback(() =>
                                {
                                    Dire.instance.ChafeDireMessyArabHis();
                                    TollUntold.gameObject.SetActive(true);
                                    GlandUntold.gameObject.SetActive(true);
                                });
                            }
                            else
                            {
                                Dire.instance.ChafeDireMessyArabHis();
                                TollUntold.gameObject.SetActive(true);
                                GlandUntold.gameObject.SetActive(true);
                            }
                        }
                    }
                });
            }
        }
        else
        {
            
            if (Dire.instance.SuitExtolNotePointe == endLevelNum)
            {
                SpurNomad.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "fish_swimming", true);
                CementUntoldDawn.gameObject.SetActive(true);
                TollUntoldDawn.gameObject.SetActive(false);
                TollUntold.gameObject.SetActive(true);
            }
            else
            {
                SpurNomad.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "fish_await", true);
                CementUntoldDawn.gameObject.SetActive(false);
                TollUntoldDawn.gameObject.SetActive(true);
                TollUntold.gameObject.SetActive(true);
                GlandUntold.gameObject.SetActive(true);
            }
        }

    }

    
    /// <summary>
    /// 满足解锁条件动画
    /// </summary>
    public void ExtolCementNote(System.Action finish)
    {
        So_CementSpur.SetActive(true);
        //鱼开始swimming
        SpurLocustNomad.GetComponent<Transform>().Find("FishImage").GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "fish_swimming",true);
        SpurLocustNomad.transform.DOScaleY(1.15f, 0.2f);
        SpurLocustNomad.transform.DOScaleX(0.85f, 0.2f).OnComplete(() =>
        {
            SpurLocustNomad.transform.DOScaleY(1f, 0.2f);
            SpurLocustNomad.transform.DOScaleX(1.15f, 0.2f).OnComplete(() =>
            {
                SpurLocustNomad.transform.DOScaleY(1.15f, 0.2f);
                SpurLocustNomad.transform.DOScaleX(0.85f, 0.2f).OnComplete(() =>
                {
                    SpurLocustNomad.transform.DOScaleY(1f, 0.2f).SetEase(Ease.OutBack);
                    SpurLocustNomad.transform.DOScaleX(1f, 0.2f).SetEase(Ease.OutBack).OnComplete(() => 
                    {
                        So_CementSpur.SetActive(false);
                        finish();
                    });
                });
            });
        });
    }

    /// <summary>
    /// 点击解锁Btn
    /// </summary>
    public void ExtolCement() 
    {
        Dire.instance.FirnMessyArabHis();
        HolyNomad.GetComponent<Transform>().Find("LockimageTop").GetComponent<Transform>().DORotate(new Vector3(0, 0, -20), 0.2f).SetDelay(0.2f);
        HolyNomad.transform.DOScale(1.3f, 0.25f).OnComplete(() => 
        {
            HolyNomad.transform.DOScale(1f, 0.25f).OnComplete(() => 
            {
                So_CementSpur.SetActive(true);
                SpurLocustNomad.transform.DOScaleY(1.15f, 0.2f);
                SpurLocustNomad.transform.DOScaleX(0.85f, 0.2f).OnComplete(() => 
                {
                    SpurLocustNomad.transform.DOScaleY(0.85f, 0.2f);
                    SpurLocustNomad.transform.DOScaleX(1.15f, 0.2f).OnComplete(() => 
                    {
                        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_UnlockFish);
                        //关闭弹窗
                        So_CementSpur.SetActive(false);
                        CloseUIForm(GetType().Name);
                        SpurLocustNomad.transform.localScale = new Vector3(1f, 1f, 1f);
                        SpurMeExcelYew(SpurLocustNomad, OftIcy, HolyNomad, ()=> 
                        {
                            Dire.instance.ChafeDireMessyArabHis();
                        });   
                    });
                });
            });
        });
    }

    /// <summary>
    /// 解锁鱼之后的动画
    /// </summary>
    /// <param name="ScreenFishImage"></param>
    /// <param name="FishMoveOffset"></param>
    /// <param name="EndPos"></param>
    public static void SpurMeExcelYew(GameObject UnlockFishImage, GameObject EndPos,GameObject lockImage,System.Action finish) 
    {
        /*-----------------------------------物体准备----------------------------------*/
        lockImage.SetActive(false);
        lockImage.transform.localScale = new Vector3(1, 1, 1);
        GameObject ScreenFishImage = Instantiate(UnlockFishImage, UIManager.GetInstance().MainCanvas.transform);
        ScreenFishImage.GetComponent<Transform>().Find("FishImage").gameObject.SetActive(true);
        ScreenFishImage.SetActive(true);
        ScreenFishImage.transform.position = new Vector3(0, 0, 0);
        ScreenFishImage.transform.localScale = new Vector3(0, 0, 0);
        float Untie= 2.2f / 0.7f;
        float t2 = (2.2f - EndPos.transform.position.y) / Untie;
        Debug.Log("t2 =" + t2);
        /*-----------------------------------动画开始----------------------------------*/
        var s = DOTween.Sequence();
        s.Append(ScreenFishImage.transform.DOScale(0.6f, 0.3f).SetDelay(0.1f).OnComplete(() =>
        {
            ScreenFishImage.transform.DOScaleY(0.45f, 0.2f);
            ScreenFishImage.transform.DOScaleX(0.75f, 0.2f).OnComplete(() =>
            {
                ScreenFishImage.transform.DOScaleY(0.75f, 0.2f);
                ScreenFishImage.transform.DOScaleX(0.45f, 0.2f).OnComplete(() =>
                {
                    ScreenFishImage.transform.DOScaleX(0.6f, 0.2f).SetEase(Ease.OutBack);
                    ScreenFishImage.transform.DOScaleY(0.6f, 0.2f);
                });
            });
        }));//用时1.1f
        s.Insert(1.2f, ScreenFishImage.transform.DOScale(0.35f, 0.5f));
        s.Insert(0,ScreenFishImage.transform.DOMoveX(EndPos.transform.position.x,2f));//用时1.8f
        s.Insert(0, ScreenFishImage.transform.DOMoveY((ScreenFishImage.transform.position.y + 1.7f),0.5f));
        s.Insert(0.6f, ScreenFishImage.transform.DORotate(new Vector3(0, 0, 60), 1f).SetDelay(0.3f));
        s.Insert(1.5f, ScreenFishImage.GetComponent<Transform>().Find("FishImage").GetComponent<SkeletonGraphic>().DOFade(0, 0.5f));
        s.Insert(1.5f, ScreenFishImage.GetComponent<CanvasGroup>().DOFade(0, 0.7f));
        s.Insert(0.6f, ScreenFishImage.transform.DOMoveY(EndPos.transform.position.y, 1.2f).SetEase(Ease.InQuart).OnComplete(() =>
        {
            ScreenFishImage.transform.DOScale(0, 0.01f);
            CapExamMedical.GetInstance().AmnesiaStony(TriggerType.Sale_Balsam);
        }));
        /*s.AppendCallback(()=> { Destroy(ScreenFishImage); });*/
        s.InsertCallback(2.4f, () => 
        {
            Destroy(ScreenFishImage);
            finish();
        });
    }

    
    public override void Hidding()
    {
        base.Hidding();
        SpurNomad.SetActive(false);
        if (!SaveDataManager.GetBool(CConfig.sv_ready_rate) && Dire.instance.WhoExamExtol() >= 3)
        {
            OpenUIForm("DeafRider");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
