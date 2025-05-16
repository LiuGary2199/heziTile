using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
public class LogSpurRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("BuyButton")]    [UnityEngine.Serialization.FormerlySerializedAs("BuyButton")]public Button LogUntold;
[UnityEngine.Serialization.FormerlySerializedAs("CanelButton")]    [UnityEngine.Serialization.FormerlySerializedAs("CanelButton")]public Button GourdUntold;
[UnityEngine.Serialization.FormerlySerializedAs("fishSkeleton")]    [UnityEngine.Serialization.FormerlySerializedAs("fishSkeleton")]public SkeletonGraphic SaleCetacean;
[UnityEngine.Serialization.FormerlySerializedAs("PriceText")]    [UnityEngine.Serialization.FormerlySerializedAs("PriceText")]public Text SporeDawn;
[UnityEngine.Serialization.FormerlySerializedAs("FishNameText")]    [UnityEngine.Serialization.FormerlySerializedAs("FishNameText")]public Text SpurLobeDawn;
    int SaleThink;
    protected override void Awake()
    {
        base.Awake();
        LogUntold.onClick.AddListener(() =>
        {
            int state = Dire.instance.FewSpur(SaleThink);
            if (state == 1)
            {
                MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanelSwitchPage,new MessageData(1));
                CloseUIForm(GetType().Name);
                SaleCetacean.gameObject.SetActive(false);
            }
            else
            {
                OpenUIForm("MoveRider");
                if (state == 2)
                {
                    MessageCenterLogic.GetInstance().Send("tips", new MessageData("gold"));
                }
                if (state == 3)
                {
                    MessageCenterLogic.GetInstance().Send("tips", new MessageData("tank"));
                }
            }
        });
        GourdUntold.onClick.AddListener(() =>
        {
            CloseUIForm(GetType().Name);
            SaleCetacean.gameObject.SetActive(false);
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_BuyFishPanel_FishIndex, (messageData) =>
        {
            SaleThink = messageData.valueInt;
            FishShopItemData itemData = NetInfoMgr.instance.gameData.FishShop[SaleThink];
            SaleCetacean.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)itemData.Pos_X, (float)itemData.Pos_Y);
            SaleCetacean.skeletonDataAsset = Resources.Load<SkeletonDataAsset>(CConfig.AnimationFishAni + itemData.ArtPath);
            SaleCetacean.initialSkinName = itemData.SkinName;
            SaleCetacean.Initialize(true);
            SaleCetacean.AnimationState.SetAnimation(0, "fish_await", true);
            SporeDawn.text = Dire.instance.WhoPoemSpurSpore(SaleThink).ToString();
            SpurLobeDawn.text = I2.Loc.LocalizationManager.GetTranslation(CConfig.Fish + itemData.Name);
        });
    }
    public override void Display()
    {
        base.Display();
        SaleCetacean.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
