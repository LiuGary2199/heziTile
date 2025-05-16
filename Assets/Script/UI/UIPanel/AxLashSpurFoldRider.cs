using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AxLashSpurFoldRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Fx_FireWorkLift")]    [UnityEngine.Serialization.FormerlySerializedAs("Fx_FireWorkLift")]public GameObject So_FiveDiscCoil;
[UnityEngine.Serialization.FormerlySerializedAs("Fx_FireWorkRight")]    [UnityEngine.Serialization.FormerlySerializedAs("Fx_FireWorkRight")]public GameObject So_FiveDiscBound;
[UnityEngine.Serialization.FormerlySerializedAs("Fx_Star")]    [UnityEngine.Serialization.FormerlySerializedAs("Fx_Star")]public GameObject So_Rake;
[UnityEngine.Serialization.FormerlySerializedAs("Fx_BubbleTransitions")]    [UnityEngine.Serialization.FormerlySerializedAs("Fx_BubbleTransitions")]public GameObject So_LocustConcentrate;
[UnityEngine.Serialization.FormerlySerializedAs("FishTank")]    [UnityEngine.Serialization.FormerlySerializedAs("FishTank")]public GameObject SpurFold;
[UnityEngine.Serialization.FormerlySerializedAs("Content")]    [UnityEngine.Serialization.FormerlySerializedAs("Content")]public GameObject Plateau;
[UnityEngine.Serialization.FormerlySerializedAs("GetBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("GetBtn")]public GameObject OakFin;
[UnityEngine.Serialization.FormerlySerializedAs("TileText")]    [UnityEngine.Serialization.FormerlySerializedAs("TileText")]public GameObject WordDawn;
[UnityEngine.Serialization.FormerlySerializedAs("BGImage")]    [UnityEngine.Serialization.FormerlySerializedAs("BGImage")]public GameObject BGNomad;
[UnityEngine.Serialization.FormerlySerializedAs("TankIcon")]    [UnityEngine.Serialization.FormerlySerializedAs("TankIcon")]public Image FoldRail;
[UnityEngine.Serialization.FormerlySerializedAs("fishNameText")]    [UnityEngine.Serialization.FormerlySerializedAs("fishNameText")]public Text SaleLobeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("MoveOffset")]    [UnityEngine.Serialization.FormerlySerializedAs("MoveOffset")]public float SackLeader;
    int Boost;

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Display()
    {
        base.Display();
        So_LocustConcentrate.transform.position = new Vector3(So_LocustConcentrate.transform.position.x, So_LocustConcentrate.transform.position.y - 10, So_LocustConcentrate.transform.position.z);
        So_LocustConcentrate.SetActive(false);
        So_FiveDiscCoil.SetActive(false);
        So_FiveDiscBound.SetActive(false);
        So_Rake.SetActive(false);
        WordDawn.SetActive(true);
        OakFin.SetActive(true);
        SpurFold.SetActive(true);
        SpurFold.transform.position = new Vector3(SpurFold.transform.position.x, SpurFold.transform.position.y - SackLeader, SpurFold.transform.position.z);
        OakFin.transform.position = new Vector3(OakFin.transform.position.x, OakFin.transform.position.y - SackLeader, OakFin.transform.position.z);
        WordDawn.transform.position = new Vector3(WordDawn.transform.position.x, WordDawn.transform.position.y - SackLeader, WordDawn.transform.position.z);
        Plateau.GetComponent<CanvasGroup>().alpha = 0;
        BGNomad.GetComponent<Image>().material = null;
        CementSpurFold();
    }
    /// <summary>
    /// 解锁鱼缸
    /// </summary>
    /// <param name="finish"></param>
    public void CementSpurFold() 
    {
        Dire.instance.FirnMessyArabHis();
        So_FiveDiscCoil.SetActive(true);
        So_FiveDiscBound.SetActive(true);
        So_Rake.SetActive(true);
        Plateau.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
        var s = DOTween.Sequence();
        s.Append(WordDawn.transform.DOMoveY((WordDawn.transform.position.y + SackLeader), 0.3f).SetEase(Ease.OutBack));
        s.Insert(0.1f, SpurFold.transform.DOMoveY((SpurFold.transform.position.y + SackLeader), 0.3f).SetEase(Ease.OutBack));
        s.Insert(0.2f, OakFin.transform.DOMoveY((OakFin.transform.position.y + SackLeader), 0.3f).SetEase(Ease.OutBack)).OnComplete(() => 
        {
            Dire.instance.ChafeDireMessyArabHis();
            /* finish();*/
        });
    }
    /// <summary>
    /// 鱼缸切换
    /// </summary>
    /// <param name="finish"></param>
    public void SpurFoldConcentrate() 
    {
        Dire.instance.FirnMessyArabHis();
        So_LocustConcentrate.SetActive(true);
        float Star = 1;
        BGNomad.GetComponent<Image>().material = Resources.Load<Material>(CConfig.EffectsMoveOffset);
        WordDawn.SetActive(false);
        OakFin.SetActive(false);
        SpurFold.SetActive(false);
        So_LocustConcentrate.transform.position = new Vector3(So_LocustConcentrate.transform.position.x, -GetSystemData.GetInstance().getCameraHeight() / 2, So_LocustConcentrate.transform.position.z);
        So_LocustConcentrate.transform.DOMoveY(GetSystemData.GetInstance().getCameraHeight() / 2, 1.6f);
        DOTween.To(() => Star, x => BGNomad.GetComponent<Image>().material.SetFloat("_MoveOffset", Star = x), -10, 1.5f).OnComplete(() => 
        {
            CloseUIForm(GetType().Name);
            Dire.instance.ChafeDireMessyArabHis();
        });
    }
    void Start()
    {
        
    }
    protected override void Awake()
    {
        base.Awake();
        OakFin.GetComponent<Button>().onClick.AddListener(() =>
        {
            Dire.instance.BalsamFoldSpur(Boost);
            SpurFoldConcentrate();
            MessageCenterLogic.GetInstance().Send(CConfig.mg_SelectFishTank, new MessageData(Boost));
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_UnlockFishTankPanelIndex, (messageData) =>
        {
            Boost = messageData.valueInt;
            AquariumShopItemData Halt= NetInfoMgr.instance.gameData.AquariumShop[messageData.valueInt];
            SaleLobeDawn.text = Halt.Name;
            FoldRail.sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (Boost + 1) + CConfig.ScTex_TileFishBG + (Boost + 1) + CConfig.ScTank);

        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
