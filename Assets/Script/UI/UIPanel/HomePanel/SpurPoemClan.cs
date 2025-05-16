using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using DG.Tweening;
public class SpurPoemClan : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Price")]    [UnityEngine.Serialization.FormerlySerializedAs("Price")]public GameObject Spore;
[UnityEngine.Serialization.FormerlySerializedAs("NextUnlock")]    [UnityEngine.Serialization.FormerlySerializedAs("NextUnlock")]public GameObject HaleCement;
[UnityEngine.Serialization.FormerlySerializedAs("Lock")]    [UnityEngine.Serialization.FormerlySerializedAs("Lock")]public GameObject Lash;
[UnityEngine.Serialization.FormerlySerializedAs("PriceText")]    [UnityEngine.Serialization.FormerlySerializedAs("PriceText")]public Text SporeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("LockText")]    [UnityEngine.Serialization.FormerlySerializedAs("LockText")]public Text LashDawn;
[UnityEngine.Serialization.FormerlySerializedAs("fishSkeleton")]    [UnityEngine.Serialization.FormerlySerializedAs("fishSkeleton")]public SkeletonGraphic SaleCetacean;
[UnityEngine.Serialization.FormerlySerializedAs("Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Button")]public Button Untold;
    [HideInInspector]
    int Boost;
    
    // Start is called before the first frame update
    void Start()
    {
        Untold.onClick.AddListener(() =>
        {
            if (Dire.instance.WhoSpurLace(Boost) == 0)
            {
                UIManager.GetInstance().ShowUIForms(nameof(LogSpurRider));
                MessageCenterLogic.GetInstance().Send(CConfig.mg_BuyFishPanel_FishIndex, new MessageData(Boost));
            }
        });
    }
    public void Bend(int i)
    {
        Boost = i;
        Meeting();
    }
    public void Meeting()
    {
        int type = Dire.instance.WhoSpurLace(Boost);
        FishShopItemData itemData = NetInfoMgr.instance.gameData.FishShop[Boost];
        SaleCetacean.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)itemData.Pos_X, (float)itemData.Pos_Y);
        SaleCetacean.skeletonDataAsset = Resources.Load<SkeletonDataAsset>(CConfig.AnimationFishAni + itemData.ArtPath);
        SaleCetacean.initialSkinName = itemData.SkinName;
        SaleCetacean.Initialize(true);
        SaleCetacean.AnimationState.SetAnimation(0, "fish_await", true);
        if (type == 0)
        {
            Spore.SetActive(true);
            Lash.SetActive(false);
            HaleCement.SetActive(false);
            SporeDawn.text = Dire.instance.WhoPoemSpurSpore(Boost).ToString();
        }
        else if(type == 1)
        {
            Spore.SetActive(false);
            Lash.SetActive(true);
            HaleCement.SetActive(true);
            if (itemData.UnlockType == "level")
            {
                LashDawn.text = itemData.UnlockValue.ToString();
            }
        }
        else
        {
            Spore.SetActive(false);
            Lash.SetActive(true);
            HaleCement.SetActive(false);
            if (itemData.UnlockType == "level")
            {
                LashDawn.text = itemData.UnlockValue.ToString();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
