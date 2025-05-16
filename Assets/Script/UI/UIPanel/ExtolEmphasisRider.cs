using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ExtolEmphasisRider : BaseUIForms
{
    [Header("图片和特效")]
[UnityEngine.Serialization.FormerlySerializedAs("FX_GroundLight")]    [UnityEngine.Serialization.FormerlySerializedAs("FX_GroundLight")]public GameObject FX_GroundLight;
[UnityEngine.Serialization.FormerlySerializedAs("FX_Star")]    [UnityEngine.Serialization.FormerlySerializedAs("FX_Star")]public GameObject FX_Rake;
[UnityEngine.Serialization.FormerlySerializedAs("FX_FireworksRight")]    [UnityEngine.Serialization.FormerlySerializedAs("FX_FireworksRight")]public GameObject FX_OverwhelmBound;
[UnityEngine.Serialization.FormerlySerializedAs("FX_FireworksLift")]    [UnityEngine.Serialization.FormerlySerializedAs("FX_FireworksLift")]public GameObject FX_OverwhelmCoil;
[UnityEngine.Serialization.FormerlySerializedAs("Fx_LevelComplete")]    [UnityEngine.Serialization.FormerlySerializedAs("Fx_LevelComplete")]public GameObject So_ExtolEmphasis;
[UnityEngine.Serialization.FormerlySerializedAs("StarImage")]    [UnityEngine.Serialization.FormerlySerializedAs("StarImage")]public GameObject RakeNomad;
[UnityEngine.Serialization.FormerlySerializedAs("GoldImage")]    [UnityEngine.Serialization.FormerlySerializedAs("GoldImage")]public GameObject LordNomad;
[UnityEngine.Serialization.FormerlySerializedAs("DiamondsImage")]    [UnityEngine.Serialization.FormerlySerializedAs("DiamondsImage")]public GameObject WretchedNomad;
[UnityEngine.Serialization.FormerlySerializedAs("MoveOffset")]    [UnityEngine.Serialization.FormerlySerializedAs("MoveOffset")]public float SackLeader;
[UnityEngine.Serialization.FormerlySerializedAs("CashImage")]    [UnityEngine.Serialization.FormerlySerializedAs("CashImage")]public GameObject CookNomad;
[UnityEngine.Serialization.FormerlySerializedAs("GemImage")]    [UnityEngine.Serialization.FormerlySerializedAs("GemImage")]public GameObject SapNomad;
    [Header("list")]
[UnityEngine.Serialization.FormerlySerializedAs("LevelIcon")]    [UnityEngine.Serialization.FormerlySerializedAs("LevelIcon")]public List<GameObject> ExtolRail;
[UnityEngine.Serialization.FormerlySerializedAs("RewardValue")]    [UnityEngine.Serialization.FormerlySerializedAs("RewardValue")]public List<GameObject> GrooveQuill;
[UnityEngine.Serialization.FormerlySerializedAs("TopBarIcon")]    [UnityEngine.Serialization.FormerlySerializedAs("TopBarIcon")]public List<GameObject> BurYewRail;
[UnityEngine.Serialization.FormerlySerializedAs("Flash")]    [UnityEngine.Serialization.FormerlySerializedAs("Flash")]public Material Plumb;
    [Header("按钮")]
[UnityEngine.Serialization.FormerlySerializedAs("ADButton")]    [UnityEngine.Serialization.FormerlySerializedAs("ADButton")]public Button ADUntold;
[UnityEngine.Serialization.FormerlySerializedAs("NextLevel")]    [UnityEngine.Serialization.FormerlySerializedAs("NextLevel")]public Button HaleExtol;
[UnityEngine.Serialization.FormerlySerializedAs("ADText")]    [UnityEngine.Serialization.FormerlySerializedAs("ADText")]public GameObject ADDawn;
    [Header("文案")]
[UnityEngine.Serialization.FormerlySerializedAs("CashText")]    [UnityEngine.Serialization.FormerlySerializedAs("CashText")]public Text CookDawn;
    [Header("转盘组")]
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    [UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]public BoonModel SlotBG;

    private double Expert;   // token奖励

    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        ADUntold.onClick.AddListener(() =>
        {
            ADRadialPreyRider();
            AnimationController.Breathe(BurYewRail[1], 0);
        });
        HaleExtol.onClick.AddListener(() =>
        {
            Transform P= UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/ExtolRider/CashBar/CashIcon");
            Transform A = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>();
            AnimationController.GoldMoveBest(P.gameObject, 15, A, P, () => { });
            Dire.instance.OwnLord(Expert);
            Dire.instance.goldNotePointe = NumberUtil.DoubleToStr(Dire.instance.WhoLord());
            CloseUIForm(GetType().Name);
            ADManager.Instance.NoThanksAddCount();
            Dire.instance.BraveBlade();
            Dire.instance.WhoRake();
        });
    }
    public override void Display()
    {
        base.Display();

        Expert = NetInfoMgr.instance.InitData.passlevel_cash_price * Dire.instance.WhoCookDutch();
        CookDawn.text = "+" + NumberUtil.DoubleToStr(Expert);

        if (GameUtil.IsApple())
        {
            CookNomad.SetActive(false);
            SapNomad.SetActive(true);
        }
        else
        {
            CookNomad.SetActive(true);
            SapNomad.SetActive(false);
        }

        Dire.instance.FirnMessyArabHis();
        StartCoroutine(OralTermGourdArab());
        Rehabilitation();
        Toll();
        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_LevelComplete);
        ADUntold.gameObject.SetActive(true);

        if (NoCapExam())
        {
            ADDawn.SetActive(false);
            HaleExtol.gameObject.SetActive(false);
        }
        else
        {
            ADDawn.SetActive(true);
            HaleExtol.gameObject.SetActive(true);
        }

        SlotBG.BendDutch();
    }
    IEnumerator OralTermGourdArab()
    {
        yield return new WaitForSeconds(1f);
        Dire.instance.ChafeDireMessyArabHis();
    }
    public void Rehabilitation() 
    {
       /* DiamondsImage.GetComponent<Transform>().position = new Vector3(DiamondsImage.GetComponent<Transform>().position.x, DiamondsImage.GetComponent<Transform>().position.y - MoveOffset, DiamondsImage.GetComponent<Transform>().position.z);
        DiamondsImage.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        DiamondsImage.GetComponent<Transform>().Find("Image").GetComponent<Transform>().position = new Vector3(0, DiamondsImage.GetComponent<Transform>().Find("Image").GetComponent<Transform>().position.y, DiamondsImage.GetComponent<Transform>().Find("Image").GetComponent<Transform>().position.z);
        DiamondsImage.GetComponent<Transform>().Find("NumberText").GetComponent<Transform>().position = new Vector3(0, DiamondsImage.GetComponent<Transform>().Find("Image").GetComponent<Transform>().position.y, DiamondsImage.GetComponent<Transform>().Find("Image").GetComponent<Transform>().position.z);*/
    }

    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.P))
        //{
        //    ReturnHomePanel();
        //    print("MUYU:ReturnHomePanel");
        //}
    }

    private bool NoCapExam()
    {
        return !PlayerPrefs.HasKey(CConfig.sv_FirstSlot + "Bool") || SaveDataManager.GetBool(CConfig.sv_FirstSlot);
    }

    public void RadialPreyRider()
    {
        CloseUIForm(GetType().Name);
        Dire.instance.BraveEmphasis();
    }
    public void ADRadialPreyRider()
    {
        if (NoCapExam())
        {
            ADAgrarian();
        }
        else
        {
            ADManager.Instance.playRewardVideo((success) =>
            {
                if(success)
                {
                    ADAgrarian();
                }
            }, "101");
        }
    }
    private void ADAgrarian()
    {
        HaleExtol.gameObject.SetActive(false);
        ADUntold.gameObject.SetActive(false);
        int Boost= WhoBoonDutchThink();
        SlotBG.Flop(Boost, (multi) => {
            AnimationController.ChangeNumber(Expert, Expert * multi, 0.1f, CookDawn, "+", () => {
                Expert *= multi;
                CookDawn.text = "+" + NumberUtil.DoubleToStr(Expert);
            });
            HaleExtol.gameObject.SetActive(true);
        });

        SaveDataManager.SetBool(CConfig.sv_FirstSlot, false);
    }

    private int WhoBoonDutchThink()
    {
        // 新用户，第一次固定翻5倍
        if (NoCapExam())
        {
            int Boost= 0;
            foreach (SlotItem wg in NetInfoMgr.instance.InitData.slot_group)
            {
                if (wg.multi == 5)
                {
                    return Boost;
                }
                Boost++;
            }
        }
        else
        {
            int sumWeight = 0;
            foreach (SlotItem wg in NetInfoMgr.instance.InitData.slot_group)
            {
                sumWeight += wg.weight;
            }
            int r = Random.Range(0, sumWeight);
            int nowWeight = 0;
            int Boost= 0;
            foreach (SlotItem wg in NetInfoMgr.instance.InitData.slot_group)
            {
                nowWeight += wg.weight;
                if (nowWeight > r)
                {
                    return Boost;
                }
                Boost++;
            }
            
        }
        return 0;
    }

    /// <summary>
    /// 播放
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public void Toll()
    {
        ExtolEmphasisActSpecialization();
        RealExtolStatisticAct();
        BurYewToll();
        ExtolGroove();
        RakeNomadNote(RakeNomad, So_ExtolEmphasis);
        FX_OverwhelmBound.SetActive(true);
        FX_OverwhelmCoil.SetActive(true);
        FX_GroundLight.SetActive(true);
        FX_Rake.SetActive(true);
    }


    /// <summary>
    /// 初始化关卡胜利小金鱼icon
    /// </summary>
    public void ExtolEmphasisActSpecialization() 
    {
        for (int i = 0; i < ExtolRail.Count; i++) 
        {
            ExtolRail[i].transform.localScale = new Vector3(0, 0, 0);
        }
    }
    /// <summary>
    /// 关卡胜利小金鱼icon
    /// </summary>
    /// <param name="LevelIcon"></param>
    /// <param name="FinalOffestTransform_Y"></param>
    public void ExtolStatisticAct(GameObject LevelIcon,float FinalOffestTransform_Y) 
    {
        /*--------------------初始化--------------------*/
        LevelIcon.transform.localScale = new Vector3(0, 0, 0);
        LevelIcon.transform.position =new Vector3(LevelIcon.transform.position.x, LevelIcon.transform.position.y- FinalOffestTransform_Y, LevelIcon.transform.position.z);
        LevelIcon.GetComponent<Image>().color = new Color(LevelIcon.GetComponent<Image>().color.r, LevelIcon.GetComponent<Image>().color.g, LevelIcon.GetComponent<Image>().color.b, 0);
        /*--------------------动画--------------------*/
        LevelIcon.GetComponent<Image>().DOFade(1, 0.6f);
        LevelIcon.transform.DOMoveY(LevelIcon.transform.position.y + FinalOffestTransform_Y, 0.6f).SetEase(Ease.OutBack);
        LevelIcon.transform.DOScale(1f, 0.6f).SetEase(Ease.OutBack);
    }
    private IEnumerator CentWaxShrink(float time ,int i,float Offset) 
    { 
        yield return new WaitForSeconds(time);
        ExtolStatisticAct(ExtolRail[i], Offset);
    }
    public void RealExtolStatisticAct() 
    {
        for (int i = 0; i<ExtolRail.Count; i++) 
        {
            if (i <= 1)
            {
                StartCoroutine(CentWaxShrink(0, i, 1f));
            }
            else if (i > 1 && i < 4)
            {
                StartCoroutine(CentWaxShrink(0.2f, i,1f));
            }
            else 
            {
                StartCoroutine(CentWaxShrink(0.3f, i, 1f));
            }
        }
    }
    /// <summary>
    /// 收取金币
    /// </summary>
    public void BarnWhoFormation(int goldCount = 0,int cashCount = 0)
    {
        Dire.instance.FirnMessyArabHis();
        GameObject Fx_Power = Instantiate(Resources.Load<GameObject>(CConfig.EffectsFXPower), WretchedNomad.GetComponent<Transform>().Find("Image").gameObject.transform);
        Fx_Power.SetActive(false);

        ExtolLordSack(WretchedNomad.GetComponent<Transform>().Find("Image").gameObject, transform.parent, 5, ADUntold.transform, WretchedNomad.GetComponent<Transform>().Find("Image").gameObject.transform, () => {
            Fx_Power.SetActive(true);
            AnimationController.IconJump(WretchedNomad.GetComponent<Transform>().Find("Image").gameObject);
        }, () => {
            AnimationController.ChangeNumber(int.Parse(WretchedNomad.GetComponent<Transform>().Find("NumberText").GetComponent<Text>().text), int.Parse(WretchedNomad.GetComponent<Transform>().Find("NumberText").GetComponent<Text>().text) + cashCount, 0, WretchedNomad.GetComponent<Transform>().Find("NumberText").GetComponent<Text>(), () => {
                Fx_Power.SetActive(false);
                Dire.instance.ChafeDireMessyArabHis();
            });
        });
    }

    /// <summary>
    /// 关卡胜利幅条
    /// </summary>
    /// <param name="FinalOffestTransform_Y"></param>
    public  void BurYew(GameObject TopBarImage,float FinalOffestTransform_Y,int b,int c,float time_y) 
    {
        /*--------------------初始化--------------------*/
        FX_GroundLight.SetActive(false);
        FX_Rake.SetActive(false);
        FX_OverwhelmBound.SetActive(false);
        FX_OverwhelmCoil.SetActive(false);
        TopBarImage.transform.position = new Vector3(TopBarImage.transform.position.x, TopBarImage.transform.position.y - FinalOffestTransform_Y, TopBarImage.transform.position.z);
        if (c > 0) 
        {
        TopBarImage.GetComponent<Image>().color = new Color(TopBarImage.GetComponent<Image>().color.r, TopBarImage.GetComponent<Image>().color.g, TopBarImage.GetComponent<Image>().color.b, 0);
        }
        TopBarImage.transform.localScale = new Vector3(0, 0, 0);
        /*--------------------动画--------------------*/
        if (b>0) 
        {
            float offset = -0.5f;
            TopBarImage.GetComponent<Image>().material = Plumb;
            DOTween.To(() => offset, x => TopBarImage.GetComponent<Image>().material.SetFloat("_LightOffset", offset = x), 0.5f, 1f).SetDelay(1).OnComplete(() =>
            {
                TopBarImage.GetComponent<Image>().material.SetFloat("_LightOffset", -0.5f);
                TopBarImage.GetComponent<Image>().material = null;
            });
        }
        StartCoroutine(CentWaxShrinkQuill(() => {
            if (c > 0) 
            {
                TopBarImage.GetComponent<Image>().DOFade(1, 0.5f);
                TopBarImage.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
            }
            else if(c <-1)
            {
                TopBarImage.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
            }
            else
            {
                TopBarImage.transform.DOScale(45f, 0.5f).SetEase(Ease.OutBack);
            }

            TopBarImage.transform.DOMoveY(TopBarImage.transform.position.y + FinalOffestTransform_Y, 0.5f).SetEase(Ease.OutBack);
        }, time_y));
    }

    public void FinNote(GameObject BtnImage,float time_Y, float FinalOffestTransform_Y) 
    {
        Sequence s = DOTween.Sequence();
        BtnImage.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        BtnImage.transform.localScale = new Vector3(0, 0, 0);
        BtnImage.transform.position = new Vector3(BtnImage.transform.position.x, BtnImage.transform.position.y - FinalOffestTransform_Y, BtnImage.transform.position.z);
        s.Append(BtnImage.GetComponent<Image>().DOFade(1, 0.5f));
        s.Append(BtnImage.transform.DOMoveY(BtnImage.transform.position.y + FinalOffestTransform_Y, 0.5f).SetEase(Ease.OutBack));
        s.Append(BtnImage.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack));
        s.SetDelay(time_Y);
        s.Play();
    }
    public void BurYewToll() 
    {
        for (int i = 0; i < BurYewRail.Count; i++) 
        {
            if (i==1)
            {
                BurYew(BurYewRail[i], 0.5f, 1, 1,0);
                AnimationController.Breathe(BurYewRail[1], 1);
            }
            else if (i == 0 )
            {
                BurYew(BurYewRail[0], 0.5f, 0,1, 0);
            }
            else if (i == 2)
            {
                FinNote(BurYewRail[i], 2, 0.5f);
            }
            else if (i == 3) 
            {
                BurYew(BurYewRail[i], 0.5f, 0,0, 0.75f);
                /*TopBarIcon[i].GetComponent<Transform>().Find("FX_ground").gameObject.SetActive(true);*/
            }
            else if (i == 4)
            {
                BurYew(BurYewRail[i], 0.5f, 0, -2, 0.75f);
            }
        }
    }

    /// <summary>
    /// 星星奖励
    /// </summary>
    /// <param name="StarIamge"></param>
    /// <param name="Fx_LevelComplete"></param>
    public void RakeNomadNote(GameObject StarIamge, GameObject Fx_LevelComplete) 
    {
        /*--------------------初始化--------------------*/
        Fx_LevelComplete.SetActive(false);
        RakeNomad.transform.eulerAngles = new Vector3(0, 0, -180);
        RakeNomad.transform.localScale = new Vector3(15, 15, 15);
        RakeNomad.SetActive(false);
        /*--------------------动画--------------------*/
        RakeNomad.SetActive(true);
        RakeNomad.transform.DORotate(new Vector3(0, 0, 0), 0.6f, RotateMode.FastBeyond360).OnComplete(() =>
        {
            Fx_LevelComplete.SetActive(true);
        });
        RakeNomad.transform.DOScale(new Vector3(1, 1, 1), 0.6f).OnComplete(() =>
        {
            RakeNomad.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.2f).OnComplete(() =>
            {
                RakeNomad.transform.DOScale(new Vector3(1, 1, 1), 0.2f);
            });
        });
    }

    /// <summary>
    /// 金币/现金值出现
    /// </summary>
    /// <param name="value"></param>
    /// <param name="FinalOffestTransform_Y"></param>
    public void LordQuill(GameObject value, float FinalOffestTransform_Y)
    {
        /*--------------------初始化--------------------*/
        value.transform.position = new Vector3(value.transform.position.x, value.transform.position.y - FinalOffestTransform_Y, value.transform.position.z);
        value.GetComponent<CanvasGroup>().alpha = 0;
        value.transform.localScale = new Vector3(1, 1, 1);
        /*value.GetComponent<Transform>().Find("FX_Star").gameObject.SetActive(false);*/
        /*--------------------动画--------------------*/
        value.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        value.transform.DOMoveY(value.transform.position.y + FinalOffestTransform_Y, 0.5f).SetEase(Ease.OutBack).OnComplete(() => 
        {
            /*value.GetComponent<Transform>().Find("FX_Star").gameObject.SetActive(true);*/
        });
    }
    private IEnumerator CentWaxShrinkQuill(System.Action finish, float time)
    {
        yield return new WaitForSeconds(time);
        finish();
    }
    public void ExtolGroove() 
    {
        for (int i = 0; i < GrooveQuill.Count; i++) 
        {
            if (i <= 0)
            {
                LordQuill(GrooveQuill[i],0.5f);
                StartCoroutine(CentWaxShrinkQuill(()=> { },0));
            }
            else 
            {
                LordQuill(GrooveQuill[i], 0.5f);
                StartCoroutine(CentWaxShrinkQuill(() => { },0.15f));
            }
        }
    }



    public static void ExtolLordSack(GameObject GoldImage, Transform parent, int a, Transform GoldStart, Transform GoldFinal, System.Action NextShow, System.Action finish)
    {
        if (a == 0)
        {
            finish();
        }
        a = Mathf.Min(20, a); //避免生成太多金币，最多20个
        //float endtime = 0;
        //float starttime = Time.time;
        //Debug.Log("starttime = " + starttime);
        int finishCount = 0;
        float Delaytime = 0;
        int goldGroups = Mathf.Min(5, a);
        int GroupNum = a / 5 + 1;
        for (int i = 0; i < goldGroups; i++)
        {
            for (int j = 0; j < GroupNum; j++)
            {
                var s = DOTween.Sequence();
                GameObject GoldIcon = Instantiate(GoldImage, parent);
                GoldIcon.SetActive(true);
                GoldIcon.GetComponent<Transform>().position = GoldStart.position;
                GoldIcon.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                GoldIcon.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
                float OffsetX = Random.Range(-0.75f, 0.75f);
                float OffsetY = Random.Range(-0.75f, 0.75f);
                /*-------------------------------------动画效果------------------------------------*/
                //Debug.Log(OffsetX);
                GoldIcon.GetComponent<Transform>().position = new Vector3(OffsetX, OffsetY, 0) + GoldIcon.GetComponent<Transform>().position;
                s.Append(GoldIcon.GetComponent<Image>().DOFade(1, 0.4f));
                s.Insert(0, GoldIcon.GetComponent<Transform>().DOScale(new Vector3(0.75f, 0.75f, 1), 0.4f).SetEase(Ease.OutBack));
                s.Append(GoldIcon.GetComponent<Transform>().DOMove(GoldFinal.position, 0.8f).SetEase(Ease.InBack)).SetDelay(0.15f + Delaytime).OnComplete(() =>
                {
                    NextShow();
                });
                s.Insert(0.55f + Delaytime, GoldIcon.GetComponent<Transform>().DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.8f));
                /*s.Append(GoldIcon.GetComponent<Transform>().DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.3f));*/

                finishCount++;
                if (finishCount == a)
                {
                    //    endtime = Time.time;
                    //    Debug.Log("endtime = " + endtime);
                    s.AppendCallback(() =>
                    {
                        s.Kill();
                        Destroy(GoldIcon);
                        finish();
                    });
                    s.Play();
                    return;
                }
                s.AppendCallback(() =>
                {
                    s.Kill();
                    Destroy(GoldIcon);
                });
                s.Play();

            }
            Delaytime += Random.Range(0.05f, 0.2f);
        }

    }
}