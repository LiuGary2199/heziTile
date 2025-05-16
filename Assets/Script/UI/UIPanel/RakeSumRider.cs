using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;

public class RakeSumRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("StarBox")]    [UnityEngine.Serialization.FormerlySerializedAs("StarBox")]public GameObject RakeSum;
[UnityEngine.Serialization.FormerlySerializedAs("Fx_StarBoxOpen")]    [UnityEngine.Serialization.FormerlySerializedAs("Fx_StarBoxOpen")]public GameObject So_RakeSumDump;
[UnityEngine.Serialization.FormerlySerializedAs("EndTF")]    [UnityEngine.Serialization.FormerlySerializedAs("EndTF")]public List<GameObject> OftTF;
[UnityEngine.Serialization.FormerlySerializedAs("startX")]    [UnityEngine.Serialization.FormerlySerializedAs("startX")]public float SandyX;
[UnityEngine.Serialization.FormerlySerializedAs("startY")]    [UnityEngine.Serialization.FormerlySerializedAs("startY")]public float SandyY;
[UnityEngine.Serialization.FormerlySerializedAs("GetRewardBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("GetRewardBtn")]public GameObject OakGrooveFin;
    List<GameObject> ZealLend;
[UnityEngine.Serialization.FormerlySerializedAs("GoldSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("GoldSprite")]public Sprite LordRugged;
[UnityEngine.Serialization.FormerlySerializedAs("UndoSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("UndoSprite")]public Sprite JoltRugged;
[UnityEngine.Serialization.FormerlySerializedAs("HintSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("HintSprite")]public Sprite VoltRugged;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshSprite")]    [UnityEngine.Serialization.FormerlySerializedAs("RefreshSprite")]public Sprite MeetingRugged;
    Sequence FinModemLeader;
[UnityEngine.Serialization.FormerlySerializedAs("fishSkeletonPrefab")]    [UnityEngine.Serialization.FormerlySerializedAs("fishSkeletonPrefab")]public GameObject SaleCetaceanYellow;


    private double ExpertCook;
    private double ExpertLord;
    private double ExpertStrait;
    private string ExpertFlairLobe;
   // private Puzzle rewardPuzzle;
    private int ExpertSpurThink;


    public override void Display()
    {
        base.Display();

        // 计算奖励
        Init initData = NetInfoMgr.instance.InitData;
        ExpertCook = initData.starbox_cash_price * Dire.instance.WhoCookDutch();
        ExpertLord = initData.starbox_gold_price * Dire.instance.WhoLordDutch();
        ExpertStrait = initData.starbox_amazon_price * Dire.instance.WhoStraitDutch();
        if (RandomUtil.InChance(initData.starbox_skill_chance))
        {
            string[] skills = new string[] { "Undo", "Hint", "Shuffle" };
            ExpertFlairLobe = skills[Random.Range(0, 3)];
        }
        else
        {
            ExpertFlairLobe = "";
        }
        //rewardPuzzle = SOHOShopManager.instance.GetRewardPuzzle();
        ExpertSpurThink = Dire.instance.WhoGemFoldMessSpurGrass() % NetInfoMgr.instance.gameData.FishShop.Count;

        So_RakeSumDump.SetActive(false);
        OakGrooveFin.transform.localScale = new Vector3(0, 0, 0);
        RakeSum.transform.localScale = new Vector3(0, 0, 0);
        RakeSum.transform.position = new Vector3(SandyX, SandyY, RakeSum.transform.position.z);
        RakeSum.GetComponent<CanvasGroup>().alpha = 0;
        RakeSum.GetComponent<Transform>().Find("BoxTop").GetComponent<Image>().sprite = Resources.Load<Sprite>(CConfig.EffectsRewardBoxTopClose);
        So_RakeSumDump.SetActive(false);
        for (int j = 0; j < OftTF.Count; j++) 
        {
            GameObject startPos = OftTF[j];
            startPos.GetComponent<CanvasGroup>().alpha = 0;
            startPos.transform.position = new Vector3(0, 0, 0);
        }
        DumpSum();
    }
    /// <summary>
    /// 按钮出现     !!点击之后记得销毁动画 我没写 交给你了遇哥!!
    /// </summary>
    public void BusSumGroove()
    {
        OakGrooveFin.transform.DOScale(new Vector3(1, 1, 1), 0.3f).SetEase(Ease.OutBack).OnComplete(() => 
        {
            FinModemLeader = DOTween.Sequence();
            FinModemLeader.Append(OakGrooveFin.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1f));
            FinModemLeader.Append(OakGrooveFin.transform.DOScale(new Vector3(1f,1f, 1f), 1f));
            FinModemLeader.SetLoops(-1);
            FinModemLeader.Play();
        });
    }
    /// <summary>
    /// 宝箱打开
    /// </summary>
    /// <param name="CardCount">奖励个数</param>
    public void DumpSum() 
    {
        foreach(GameObject obj in OftTF)
        {
            obj.transform.Find("RewardIcon").gameObject.SetActive(true);
            if (obj.transform.Find("FishImage") != null)
            {
                Destroy(obj.transform.Find("FishImage").gameObject);
            }
        }

        ZealLend = new List<GameObject>();
        // EndTF[0] : cash
      //  EndTF[0].transform.Find("Text").GetComponent<Text>().text = "+" + NumberUtil.DoubleToStr(rewardCash);
        //CardList.Add(EndTF[0]);
        
        // EndTF[1] : gold
        OftTF[1].transform.Find("Text").GetComponent<Text>().text = "+" + NumberUtil.DoubleToStr(ExpertLord);
        ZealLend.Add(OftTF[1]);
        
        // EndTF[2] : amazon
      //  EndTF[2].transform.Find("Text").GetComponent<Text>().text = "+" + NumberUtil.DoubleToStr(rewardAmazon);
      //  CardList.Add(EndTF[2]);
        
        // 技能奖励
        int Boost= 3;
        if (ExpertFlairLobe != "")
        {
            if (ExpertFlairLobe == "Undo")
            {
                OftTF[Boost].transform.Find("RewardIcon").GetComponent<Image>().sprite = JoltRugged;
            } else if (ExpertFlairLobe == "Hint")
            {
                OftTF[Boost].transform.Find("RewardIcon").GetComponent<Image>().sprite = VoltRugged;
            } else if (ExpertFlairLobe == "Shuffle")
            {
                OftTF[Boost].transform.Find("RewardIcon").GetComponent<Image>().sprite = MeetingRugged;
            }
            OftTF[Boost].transform.Find("Text").GetComponent<Text>().text = "+5";
            ZealLend.Add(OftTF[Boost]);
            Boost++;
        }

        // 碎片奖励
        //if (rewardPuzzle != null)
        //{
        //    EndTF[index].transform.Find("RewardIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>(rewardPuzzle.puzzle_img);
        //    EndTF[index].transform.Find("Text").GetComponent<Text>().text = "+" + rewardPuzzle.reward_count;
        //    CardList.Add(EndTF[index]);
        //    index++;
        //}

        // 鱼奖励
        //EndTF[index].transform.Find("RewardIcon").gameObject.SetActive(false);
        //FishShopItemData fishData = NetInfoMgr.instance.gameData.FishShop[rewardFishIndex];
        //GameObject fish = Instantiate(fishSkeletonPrefab, EndTF[index].transform);
        //fish.name = "FishImage";
        //SkeletonGraphic fishSkeleton = fish.GetComponent<SkeletonGraphic>();
        //fishSkeleton.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)fishData.Pos_X, (float)fishData.Pos_Y);
        //fishSkeleton.skeletonDataAsset = Resources.Load<SkeletonDataAsset>(CConfig.AnimationFishAni + fishData.ArtPath);
        //fishSkeleton.initialSkinName = fishData.SkinName;
        //fishSkeleton.Initialize(true);
        //fishSkeleton.AnimationState.SetAnimation(0, "fish_await", true);
        //EndTF[index].transform.Find("Text").GetComponent<Text>().text = fishData.Name;
        //CardList.Add(EndTF[index]);

        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_OpenStarBox);
        AnimationController.StarBoxMove(RakeSum, 1, So_RakeSumDump, () =>
        {
            AnimationController.StarBoxRewardShow(ZealLend, ZealLend.Count, () =>
            {
                //宝箱打开动画结束
                BusSumGroove();
            });
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        OakGrooveFin.GetComponent<Button>().onClick.AddListener(() =>
        {

            FinModemLeader.Kill();
            //领取奖励
            Transform P= UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/ExtolRider");
            Transform A = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>();
            AnimationController.GoldMoveBest(P.GetComponent<RectTransform>().Find("CashBar/CashIcon").gameObject, 15, A, P.GetComponent<RectTransform>().Find("CashBar/CashIcon"), () => 
            { 
                Dire.instance.OwnCook(ExpertCook); 
            });

            AnimationController.GoldMoveBest(P.GetComponent<RectTransform>().Find("GoldBar/GoldIcon").gameObject, 15, A, P.GetComponent<RectTransform>().Find("GoldBar/GoldIcon"), () =>
            {
                Dire.instance.OwnLord(ExpertLord);
            });

            AnimationController.GoldMoveBest(P.GetComponent<RectTransform>().Find("AmazonBar/AmazonIcon").gameObject, 15, A, P.GetComponent<RectTransform>().Find("AmazonBar/AmazonIcon"), () =>
            {
                Dire.instance.OwnStrait(ExpertStrait);
            });
            
            if (ExpertFlairLobe != "")
            {
                Dire.instance.WhoFlairGrass(ExpertFlairLobe, 5);
            }
            //if (rewardPuzzle != null)
            //{
            //    SOHOShopManager.instance.AddRewardPuzzle(rewardPuzzle);
            //}
            //StartCoroutine(DropFish());
            Dire.instance.RakeSumIdeaSpur(ExpertSpurThink);
            CloseUIForm(GetType().Name);
            
        });
    }
    //IEnumerator DropFish()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    Dire.instance.levelFinish();
    //    Dire.instance.buyFish(rewardFishIndex);
    //}

    // Update is called once per frame
    void Update()
    {

    }

    public override void Hidding()
    {
        base.Hidding();

        
    }
}