using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using Spine.Unity;
[System.Serializable]
public struct LimitStruct
{
    public float Hat;
    public float Can;
}

[System.Serializable]
public class FishLayerData
{
    /// <summary>
    /// 所在层的显示颜色
    /// </summary>
    /// 
    [Header("所在层的显示颜色")]
    public Color color;
    /// <summary>
    /// 所在层速度区间
    /// </summary>
    /// 
    [Header("所在层速度区间")]
    public LimitStruct UntieEarly;
    /// <summary>
    /// 所在层尺寸
    /// </summary>
    /// 
    [Header("所在层尺寸")]
    public float Flier;
    /// <summary>
    /// 所在层父节点(处理显示层级)
    /// </summary>
    /// 
    [Header("所在层父节点(处理显示层级)")]
    public Transform Proper;
}
[System.Serializable]
public class FishData
{
    /// <summary>
    /// 鱼的出现间隔区间
    /// </summary>
    /// 
    [Header("鱼的出现间隔区间")]
    public LimitStruct NoteEarly;
    /// <summary>
    /// 最大旋转角度
    /// </summary>
    /// 
    [Header("最大旋转角度")]
    public float WokPathogen;
    /// <summary>
    /// 一次旋转动作所用时间区间
    /// </summary>
    /// 
    [Header("一次旋转动作所用时间区间")]
    public LimitStruct ThreshTerm;

    /// <summary>
    /// 旋转角速度
    /// </summary>
    [Header("旋转角速度")]
    public float SizableInterval;

    /// <summary>
    /// 两次旋转动作的间隔区间
    /// </summary>
    /// 
    [Header("两次旋转动作的间隔区间")]
    public LimitStruct ThreshEarly;
    /// <summary>
    /// 加速倍数区间
    /// </summary>
    /// 
    [Header("加速倍数区间")]
    public LimitStruct CoalUntie;
    /// <summary>
    /// 加速动作间隔区间
    /// </summary>
    /// 
    [Header("加速动作间隔区间")]
    public LimitStruct CoalEarly;
    /// <summary>
    /// 最下层
    /// </summary>
    /// 
    [Header("最下层")]
    public FishLayerData Always;
    /// <summary>
    /// 中间
    /// </summary>
    /// 
    [Header("中间层")]
    public FishLayerData Wee;
    /// <summary>
    /// 最上层
    /// </summary>
    /// 
    [Header("最上层")]
    public FishLayerData Bur;
    
}
public class SpurMedical : MonoBehaviour
{
    public static SpurMedical instance;
[UnityEngine.Serialization.FormerlySerializedAs("BG")]    [UnityEngine.Serialization.FormerlySerializedAs("BG")]public GameObject BG; 
[UnityEngine.Serialization.FormerlySerializedAs("OldBG")]    [UnityEngine.Serialization.FormerlySerializedAs("OldBG")]public GameObject EndBG; 
[UnityEngine.Serialization.FormerlySerializedAs("point_left")]    [UnityEngine.Serialization.FormerlySerializedAs("point_left")]public Transform Extra_Mast;
[UnityEngine.Serialization.FormerlySerializedAs("point_right")]    [UnityEngine.Serialization.FormerlySerializedAs("point_right")]public Transform Extra_Buggy;
[UnityEngine.Serialization.FormerlySerializedAs("point_top_up")]    [UnityEngine.Serialization.FormerlySerializedAs("point_top_up")]public Transform Extra_Egg_It;
[UnityEngine.Serialization.FormerlySerializedAs("point_top_down")]    [UnityEngine.Serialization.FormerlySerializedAs("point_top_down")]public Transform Extra_Egg_Silt;
[UnityEngine.Serialization.FormerlySerializedAs("point_mid_up")]    [UnityEngine.Serialization.FormerlySerializedAs("point_mid_up")]public Transform Extra_Its_It;
[UnityEngine.Serialization.FormerlySerializedAs("point_mid_down")]    [UnityEngine.Serialization.FormerlySerializedAs("point_mid_down")]public Transform Extra_Its_Silt;
[UnityEngine.Serialization.FormerlySerializedAs("point_bottom_up")]    [UnityEngine.Serialization.FormerlySerializedAs("point_bottom_up")]public Transform Extra_Influx_It;
[UnityEngine.Serialization.FormerlySerializedAs("point_bottom_down")]    [UnityEngine.Serialization.FormerlySerializedAs("point_bottom_down")]public Transform Extra_Influx_Silt;
[UnityEngine.Serialization.FormerlySerializedAs("BackImage")]    [UnityEngine.Serialization.FormerlySerializedAs("BackImage")]public Image CaneNomad;
[UnityEngine.Serialization.FormerlySerializedAs("FrontImage")]    [UnityEngine.Serialization.FormerlySerializedAs("FrontImage")]public Image CiderNomad;
[UnityEngine.Serialization.FormerlySerializedAs("MidImage")]    [UnityEngine.Serialization.FormerlySerializedAs("MidImage")]public Image WeeNomad;
[UnityEngine.Serialization.FormerlySerializedAs("FishPrefab")]    [UnityEngine.Serialization.FormerlySerializedAs("FishPrefab")]public GameObject SpurYellow;
[UnityEngine.Serialization.FormerlySerializedAs("Data")]    [UnityEngine.Serialization.FormerlySerializedAs("Data")]public FishData Oust;
[UnityEngine.Serialization.FormerlySerializedAs("RewardGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("RewardGroup")]public Transform GrooveModel;
[UnityEngine.Serialization.FormerlySerializedAs("RewardBubblePrefab")]    [UnityEngine.Serialization.FormerlySerializedAs("RewardBubblePrefab")]public GameObject GrooveLocustYellow;
[UnityEngine.Serialization.FormerlySerializedAs("GoldRewardBubble")]    [UnityEngine.Serialization.FormerlySerializedAs("GoldRewardBubble")]public Sprite LordGrooveLocust;
[UnityEngine.Serialization.FormerlySerializedAs("CashRewardBubble")]    [UnityEngine.Serialization.FormerlySerializedAs("CashRewardBubble")]public Sprite CookGrooveLocust;
[UnityEngine.Serialization.FormerlySerializedAs("ShellRewardBubble")]    [UnityEngine.Serialization.FormerlySerializedAs("ShellRewardBubble")]public Sprite RumorGrooveLocust;
[UnityEngine.Serialization.FormerlySerializedAs("PuzzleRewardBubble")]    [UnityEngine.Serialization.FormerlySerializedAs("PuzzleRewardBubble")]public Sprite FalconGrooveLocust;
[UnityEngine.Serialization.FormerlySerializedAs("mask")]    [UnityEngine.Serialization.FormerlySerializedAs("mask")]public GameObject Sago;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("FishList")]    [UnityEngine.Serialization.FormerlySerializedAs("FishList")]public List<GameObject> SpurLend;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("stopFishList")]    [UnityEngine.Serialization.FormerlySerializedAs("stopFishList")]public List<GameObject> RailSpurLend;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("stopFishIndexList")]    [UnityEngine.Serialization.FormerlySerializedAs("stopFishIndexList")]public List<int> RailSpurThinkLend; 
    bool SewOakCookAnxious= true;
    bool SewOakLordAnxious= true;
    bool SewOakRumorAnxious= true;
    bool SewOakFalconAnxious= true;
    int CheerAnxiousOakGrass= 0;
    int WeakenAnxiousOakGrass= 0;
[UnityEngine.Serialization.FormerlySerializedAs("newbgobj")]
[UnityEngine.Serialization.FormerlySerializedAs("newbgobj")]    public GameObject Spectrum;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        int fishTankIndex = SaveDataManager.GetInt(CConfig.sv_SelectFishTank);
        //BG.GetComponent<Image>().sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScTex_TileFishBG + (fishTankIndex + 1));
        //BackImage.sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScBack);
        //FrontImage.sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScFront);
        //MidImage.sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScMid);
        Debug.Log("FishList:" + SpurLend.Count);
        MessageCenterLogic.GetInstance().Register(CConfig.mg_SelectFishTank, (messageData) =>
        {
            AbsorbSpurFold(messageData.valueInt);
        });
        SewOakRumorAnxious = false;
        TourSpur();
        //新手引导1-1
        if (!SaveDataManager.GetBool(CConfig.sv_NewUserStep + "1-1"))
        {
            WhoSpur(0);
            SaveDataManager.SetBool(CConfig.sv_NewUserStep + "1-1", true);
            Dire.instance.FirnMessyArabHis();
        }
    }
    /// <summary>
    /// 初始化鱼
    /// </summary>
    void TourSpur()
    {
        GameData Halt= NetInfoMgr.instance.gameData;
        Spectrum.gameObject.SetActive(false);
        int fishPoolCount = 25;
        SpurLend = new List<GameObject>();
        for (int i = 0; i < fishPoolCount; i++)
        {
            GameObject fishItem = Instantiate(SpurYellow, Oust.Always.Proper);
            SpurLend.Add(fishItem);
        }
        RailSpurLend = new List<GameObject>(SpurLend);
        int nowTankIndex = SaveDataManager.GetInt(CConfig.sv_SelectFishTank);
        RailSpurThinkLend = new List<int>(SaveDataManager.GetIntArray(CConfig.sv_TankHaveFishList));
        StartCoroutine(nameof(NoteSpur));
        //initFishReward();
    }
    void BendSpurGroove()
    {
        List<int> FishGoldList = new List<int>(SaveDataManager.GetIntArray(CConfig.sv_FishHaveGoldArray));
        List<float> FishCashList = new List<float>(SaveDataManager.GetFloatArray(CConfig.sv_FishHaveCashArray));
        float sw = GetSystemData.GetInstance().getCameraWidth();
        float sh = GetSystemData.GetInstance().getCameraHeight();
        float xmax = sw / 2 - 1;
        float xmin = -sw / 2 + 1;
        float ymax = sh / 2 - 2;
        float ymin = -sh / 2 + 2;
        foreach (int goldNum in FishGoldList)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("type", "Gold");
            dic.Add("num", goldNum.ToString());
            GameObject FishReward = Instantiate(GrooveLocustYellow, GrooveModel);
            FishReward.transform.position = new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax), 0);
            FishReward.GetComponent<Image>().sprite = LordGrooveLocust;
            FishReward.GetComponent<GrooveLocustPhysic>().Bend(dic);
        }
        foreach (float cashNum in FishCashList)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("type", "Cash");
            dic.Add("num", cashNum.ToString());
            GameObject FishReward = Instantiate(GrooveLocustYellow, GrooveModel);
            FishReward.transform.position = new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax), 0);
            FishReward.GetComponent<Image>().sprite = CookGrooveLocust;
            FishReward.GetComponent<GrooveLocustPhysic>().Bend(dic);
        }
        int shellHaveCount = SaveDataManager.GetInt(CConfig.sv_ShellHaveCount);
        for(int i = 0; i < shellHaveCount; i++)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("type", "Shell");
            GameObject FishReward = Instantiate(GrooveLocustYellow, GrooveModel);
            FishReward.transform.position = new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax), 0);
            FishReward.GetComponent<Image>().material = Resources.Load<Material>(CConfig.EffectsMatShellFlash); 
            GameObject So_Rake= Instantiate(Resources.Load<GameObject>(CConfig.EffectsFxStar), FishReward.transform);
            FishReward.GetComponent<Image>().sprite = RumorGrooveLocust;
            FishReward.GetComponent<GrooveLocustPhysic>().Bend(dic);
        }
    }
    /// <summary>
    /// 切换鱼缸
    /// </summary>
    /// <param name="fishTankIndex"></param>
    public void AbsorbSpurFold(int fishTankIndex)
    {
        int oldTankIndex = SaveDataManager.GetInt(CConfig.sv_SelectFishTank);
        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_Transitions);
        //换图
     //   OldBG.GetComponent<Image>().sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (oldTankIndex + 1) + CConfig.ScTex_TileFishBG + (oldTankIndex + 1));
        //OldBG.GetComponent<Image>().material = null;
     //   OldBG.SetActive(true);
        //BG.GetComponent<Image>().sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScTex_TileFishBG + (fishTankIndex + 1));
        //BackImage.sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScTex_TileFishBG + (fishTankIndex + 1)+ CConfig.ScBack);
        //FrontImage.sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScTex_TileFishBG + (fishTankIndex + 1)+ CConfig.ScFront);
        //MidImage.sprite = Resources.Load<Sprite>(CConfig.SScTex_TileFishBG + (fishTankIndex + 1) + CConfig.ScTex_TileFishBG + (fishTankIndex + 1)+ CConfig.ScMid);
        //AnimationController.ScreenTransitions(OldBG, () => { OldBG.SetActive(false); });
        //StopCoroutine("ShowFish");
        //foreach (GameObject fish in FishList)
        //{
        //    fish.SetActive(false);
        //}
        int nowTankIndex = fishTankIndex;
        SaveDataManager.SetInt(CConfig.sv_SelectFishTank,fishTankIndex);
        //stopFishIndexList = new List<int>(SaveDataManager.GetIntArray(CConfig.sv_TankHaveFishList + nowTankIndex));
        //stopFishList = new List<GameObject>(FishList);
        //StartCoroutine(nameof(ShowFish));
    }
    /// <summary>
    /// 添加新鱼
    /// </summary>
    /// <param name="fishIndex"></param>
    public void WhoSpur(int fishIndex)
    {
        if (RailSpurLend.Count > 0)
        {
            int nowTankIndex = SaveDataManager.GetInt(CConfig.sv_SelectFishTank);
            List<int> nowTankHaveFishList = new List<int>(SaveDataManager.GetIntArray(CConfig.sv_TankHaveFishList));
            nowTankHaveFishList.Add(fishIndex);
            //ForestPoemOustMedical.instance.SetTaskValue(1001, 1);
            SaveDataManager.SetIntArray(CConfig.sv_TankHaveFishList,nowTankHaveFishList.ToArray());
            SaveDataManager.SetInt(CConfig.sv_FishCount + fishIndex, SaveDataManager.GetInt(CConfig.sv_FishCount + fishIndex) + 1);
            GameObject fish = RailSpurLend[0];
            FishLayerData layerData = Oust.Always;
            fish.GetComponent<SpurSack>().CanY = Extra_Influx_It.position.y;
            fish.GetComponent<SpurSack>().HatY = Extra_Influx_Silt.position.y;
            fish.transform.SetParent(layerData.Proper);
            fish.transform.localScale = new Vector3(layerData.Flier * 1, layerData.Flier, layerData.Flier) * ((float)Screen.width / 750f);
            FishShopItemData itemData = NetInfoMgr.instance.gameData.FishShop[fishIndex];
            fish.GetComponent<SkeletonGraphic>().skeletonDataAsset = Resources.Load<SkeletonDataAsset>(CConfig.AnimationFishAni + itemData.ArtPath);
            fish.GetComponent<SkeletonGraphic>().initialSkinName = itemData.SkinName;
            fish.GetComponent<SkeletonGraphic>().Initialize(true);
            fish.GetComponent<SkeletonGraphic>().color = layerData.color;
            fish.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "fish_await", true);
            fish.SetActive(true);
            RailSpurLend.Remove(fish);
            fish.GetComponent<SpurSack>().SaleThink = fishIndex;
            fish.GetComponent<SpurSack>().Estuarine = 0;
            fish.GetComponent<SpurSack>().Rider = 0;
            fish.GetComponent<Collider2D>().enabled = true;
            SewOakRumorAnxious = false;
            Dire.instance.WhoSpurRumorOust();
            Dictionary<string, string> ContendRow= new Dictionary<string, string>();
            ContendRow.Add("type", "Shell");
            //新购买的鱼
            ContendRow.Add("num", "1");
            fish.GetComponent<SpurSack>().BusAnxious(ContendRow);
            MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_BuyFishInTank);
            WoldSpur(fish,() =>
            {
                fish.GetComponent<SpurSack>().Estuarine = -1;
                fish.GetComponent<SpurSack>().Rider = Random.Range(layerData.UntieEarly.Hat, layerData.UntieEarly.Can);
            });

        }
    }
    /// <summary>
    /// 放鱼动画
    /// </summary>
    /// <param name="Newfish"></param>
    /// <param name="finish"></param>
    void WoldSpur(GameObject Newfish, System.Action finish)
    {

        GameObject Fx_FishAdd = Instantiate(Resources.Load<GameObject>(CConfig.AAniFxBubbleMid), Newfish.transform);
        Fx_FishAdd.SetActive(true);
        Newfish.transform.position = new Vector3(GetSystemData.GetInstance().getCameraWidth() / 2, GetSystemData.GetInstance().getCameraHeight() / 2, 0);
        var NewfishAni = DOTween.Sequence();
        NewfishAni.Append(Newfish.transform.DOMoveX(0, 2f).SetEase(Ease.OutExpo));
        NewfishAni.Insert(0.12f, Newfish.transform.DORotate(new Vector3(0, 0, 45), 0.2f));
        NewfishAni.Insert(0, Newfish.transform.DOMoveY(-0.1f, 3f));
        NewfishAni.Insert(0.62f, Newfish.transform.DORotate(new Vector3(0, 0, 15), 2f));
        NewfishAni.Insert(2.62f, Newfish.transform.DORotate(new Vector3(0, 0, 12), 0.3f).OnComplete(() =>
        {
            Fx_FishAdd.SetActive(false);
            Destroy(Fx_FishAdd);
            finish();
        }));
        NewfishAni.Play();
    }
    /// <summary>
    /// 生成鱼
    /// </summary>
    /// <returns></returns>
    IEnumerator NoteSpur()
    {
        while (true)
        {
            int nowTankIndex = SaveDataManager.GetInt(CConfig.sv_SelectFishTank);
            int canMoveCount = SaveDataManager.GetIntArray(CConfig.sv_TankHaveFishList).Length;
            if (RailSpurThinkLend.Count > 0)
            {
                int MastToBound= Random.Range(0, 2);
                int Fluke= Random.Range(0, 3);

                Vector3 initPos = OakTourProperly(MastToBound, Fluke);
                GameObject fish = RailSpurLend[Random.Range(0, RailSpurLend.Count)];
                FishLayerData layerData = null;
                switch (Fluke)
                {
                    case 0:
                        layerData = Oust.Always;
                        fish.GetComponent<SpurSack>().CanY = Extra_Influx_It.position.y;
                        fish.GetComponent<SpurSack>().HatY = Extra_Influx_Silt.position.y;
                        fish.GetComponent<Collider2D>().enabled = true;
                        Dictionary<string, string> ContendRow= OakAnxious();
                        if (ContendRow != null)
                        {
                            fish.GetComponent<SpurSack>().BusAnxious(ContendRow);
                        }
                        break;
                    case 1:
                        layerData = Oust.Wee;
                        fish.GetComponent<SpurSack>().CanY = Extra_Its_It.position.y;
                        fish.GetComponent<SpurSack>().HatY = Extra_Its_Silt.position.y;
                        fish.GetComponent<Collider2D>().enabled = false;
                        break;
                    case 2:
                        layerData = Oust.Bur;
                        fish.GetComponent<SpurSack>().CanY = Extra_Egg_It.position.y;
                        fish.GetComponent<SpurSack>().HatY = Extra_Egg_Silt.position.y;
                        fish.GetComponent<Collider2D>().enabled = false;
                        break;
                }
                fish.transform.SetParent(layerData.Proper);
                fish.transform.position = initPos;
                fish.transform.localScale = new Vector3(layerData.Flier * (initPos.x > 0 ? 1 : -1), layerData.Flier, layerData.Flier) * ((float)Screen.width /  750f);
                fish.GetComponent<SpurSack>().Estuarine = initPos.x > 0 ? -1 : 1;
                fish.GetComponent<SpurSack>().Rider = Random.Range(layerData.UntieEarly.Hat, layerData.UntieEarly.Can);
                
                int SaleThink= RailSpurThinkLend[Random.Range(0,RailSpurThinkLend.Count)];
                fish.GetComponent<SpurSack>().SaleThink = SaleThink;
                FishShopItemData itemData = NetInfoMgr.instance.gameData.FishShop[SaleThink];
                fish.GetComponent<SkeletonGraphic>().skeletonDataAsset = Resources.Load<SkeletonDataAsset>(CConfig.AnimationFishAni + itemData.ArtPath);
                fish.GetComponent<SkeletonGraphic>().initialSkinName = itemData.SkinName;
                fish.GetComponent<SkeletonGraphic>().Initialize(true);
                fish.GetComponent<SkeletonGraphic>().color = layerData.color;
                fish.GetComponent<SkeletonGraphic>().AnimationState.SetAnimation(0, "fish_await", true);
                fish.SetActive(true);
                
                RailSpurThinkLend.Remove(SaleThink);
                RailSpurLend.Remove(fish);
            }
            float showFishLimit = Random.Range(Oust.NoteEarly.Hat, Oust.NoteEarly.Can);
            yield return new WaitForSeconds(showFishLimit);
        }
    }
    /// <summary>
    /// 获取出生点
    /// </summary>
    /// <param name="leftOrRight"></param>
    /// <param name="layerType"></param>
    /// <returns></returns>
    Vector3 OakTourProperly(int leftOrRight, int layerType)
    {
        float x;
        float y;

        if (leftOrRight == 0)
        {
            x = Extra_Mast.transform.position.x ;
        }
        else
        {
            x = Extra_Buggy.transform.position.x ;
        }
        if (layerType == 0)
        {
            y = UnityEngine.Random.Range(Extra_Influx_Silt.position.y, Extra_Influx_It.position.y);
        }
        else if (layerType == 1)
        {
            y = UnityEngine.Random.Range(Extra_Its_Silt.position.y, Extra_Its_It.position.y) ;
        }
        else
        {
            y = UnityEngine.Random.Range(Extra_Egg_Silt.position.y, Extra_Egg_It.position.y);
        }
        return new Vector3(x, y, 0);
    }

    /// <summary>
    /// 鱼生产资源
    /// </summary>
    /// <param name="Reward">生产的资源</param>
    /// <param name="FishImage">鱼的图片</param>
    public void SpurFameGroove(GameObject FishImage,Dictionary<string,string> dic) 
    {
        //DOTweenPath RewardPath;
        float x = 1;
        float y = 1f;
        float xOffset = Random.Range(-GetSystemData.GetInstance().getCameraWidth()/2+x, GetSystemData.GetInstance().getCameraWidth() / 2 - x);
        float yOffset = Random.Range(-GetSystemData.GetInstance().getCameraHeight()/2 +y,FishImage.transform.position.y);
        float Rider= GetSystemData.GetInstance().getCameraHeight() / 2;
        float ytime1 = -yOffset / Rider;
        GameObject FishReward   = Instantiate(GrooveLocustYellow, GrooveModel);
        FishReward.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 82);
        FishReward.transform.position = FishImage.transform.position;
        if (dic["type"] == "Gold")
        {
            FishReward.GetComponent<Image>().material = null;
            FishReward.GetComponent<Image>().sprite = LordGrooveLocust;
        }
        else if (dic["type"] == "Cash")
        {
            FishReward.GetComponent<Image>().material = null;
            FishReward.GetComponent<Image>().sprite = CookGrooveLocust;
        }
        else if (dic["type"] == "Puzzle")
        {
            FishReward.GetComponent<Image>().material = null;
            FishReward.GetComponent<Image>().sprite = FalconGrooveLocust;
        }
        else
        {
            FishReward.GetComponent<Image>().material = Resources.Load<Material>(CConfig.EffectsMatShellFlash);
            GameObject So_Rake= Instantiate(Resources.Load<GameObject>(CConfig.EffectsFxStar), FishReward.transform);
            FishReward.GetComponent<Image>().sprite = RumorGrooveLocust;
        }
        GameObject Fx_Reward = Instantiate(Resources.Load<GameObject>(CConfig.AAniFxSoulExplosionOrange), FishReward.transform);
        Fx_Reward.transform.localScale = new Vector3(150, 150, 150);
        Fx_Reward.SetActive(true);
        Rider /= 3;
        if (ytime1 < 1) 
        {
            ytime1+= 1;
        }
        if (-yOffset > 3)
        {
            ytime1 += 0.7f;
        }
        var s = DOTween.Sequence();
        s.Append(FishReward.transform.DOMoveX(xOffset, 0.53f+ytime1));
        s.Insert(0,FishReward.transform.DOMoveY((FishReward.transform.position.y + 0.5f), 0.33f)).OnComplete(() =>
        {
            Destroy(Fx_Reward);
        });
        s.Insert(0.53f, FishReward.transform.DOMoveY(yOffset, ytime1));
        s.Insert(0.53f + ytime1, FishReward.transform.DOMoveY((yOffset + 0.1f), 0.5f));
        s.AppendCallback(() =>
        {

            FishReward.GetComponent<GrooveLocustPhysic>().Bend(dic);
            
            
        });
    }



    /// <summary>
    /// 领取任务
    /// </summary>
    /// <returns></returns>
    public Dictionary<string,string> OakAnxious()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        if (SewOakRumorAnxious)
        {
            if (SaveDataManager.GetInt(CConfig.sv_ShellHaveCount) + CheerAnxiousOakGrass < SaveDataManager.GetInt(CConfig.sv_ShellRewardCount))
            {
                CheerAnxiousOakGrass++;
                dic.Add("type", "Shell");
                //关卡贝壳
                dic.Add("num", "2");
                SewOakRumorAnxious = false;
                return dic;
            }
        }
        if (SewOakFalconAnxious)
        {
            if (SaveDataManager.GetInt(CConfig.sv_PuzzleRewardCount) > WeakenAnxiousOakGrass + SaveDataManager.GetInt(CConfig.sv_PuzzleHaveCount))
            {
                WeakenAnxiousOakGrass++;
                dic.Add("type", "Puzzle");
                dic.Add("num", "1");
                SewOakFalconAnxious = false;
                return dic;
            }
        }
        if (SewOakCookAnxious)
        {
            int allCashCount = SaveDataManager.GetInt(CConfig.sv_FishRewardCashCount);
            float allCashNum = SaveDataManager.GetFloat(CConfig.sv_FishRewardCashNum);
            if (allCashCount > 0)
            {
                float onceTimeNum = allCashNum / allCashCount;
                dic.Add("type", "Cash");
                dic.Add("num", onceTimeNum.ToString());
                SewOakCookAnxious = false;
                return dic;
            }
        }
        if (SewOakLordAnxious)
        {
            int allGoldCount = SaveDataManager.GetInt(CConfig.sv_FishRewardGoldCount);
            int allGoldNum = SaveDataManager.GetInt(CConfig.sv_FishRewardGoldNum);
            if (allGoldCount > 0)
            {
                int onceTimeNum = allGoldNum / allGoldCount;
                dic.Add("type", "Gold");
                dic.Add("num", onceTimeNum.ToString());
                SewOakLordAnxious = false;
                return dic;
            }
        }
        
        return null;
    }
    
    public void BusLocustRare()
    {
        //for (int i = 0; i < RewardGroup.childCount; i++)
        //{
        //    GameObject bubble = RewardGroup.GetChild(i).gameObject;
        //    bubble.GetComponent<Image>().DOFade(0.5f, 0.3f);
        //}
        GrooveModel.GetComponent<CanvasGroup>().DOFade(0.5f, 0.3f);
        
    }
    public void BusLocustNote()
    {
        //for (int i = 0; i < RewardGroup.childCount; i++)
        //{
        //    GameObject bubble = RewardGroup.GetChild(i).gameObject;
        //    bubble.GetComponent<Image>().DOFade(1f, 0.3f);
        //}
        GrooveModel.GetComponent<CanvasGroup>().DOFade(1f, 0.3f);
    }
    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    /// 奖励的流光
    /// </summary>
    /// <param name="Reward"></param>
    public void SpurGroovePlumb(GameObject Reward)
    {
        float offset = -0.6f;
        var RewardAni = DOTween.Sequence();
        RewardAni.Insert(2f, DOTween.To(() => offset, x => Reward.GetComponent<Image>().material.SetFloat("_LightOffset", offset = x), 0.6f, 1f).SetLoops(-1));
    }
}
