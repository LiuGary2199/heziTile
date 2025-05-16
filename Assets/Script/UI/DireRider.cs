using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DireRider : BaseUIForms
{
//    public Button SettingButton;
//    public Button LevelCompleteButton;
//#if SOHOShop
//    public Button SOHOShopButton;
//    public Button GoldButton;
//    public Button AmazonButton;
//    public Button PuzzleShopButton;
//#endif

//    public Image GoldImage;
//    public Text GoldNumberText;
//    public Image TokenImage;
//    public Text TokenNumberText;
//    public Image AmazonImage;
//    public Text AmazonNumberText;

//    public Button AdTestButton;
//    public Button AdjustTestButton;

//    public Button AddCashPreConditionButton;
//    public Button AddCashTaskValueButton;


//    // Start is called before the first frame update
//    void Start()
//    {
//        SettingButton.onClick.AddListener(() =>
//        {
//            UIManager.GetInstance().ShowUIForms("FlatterRider");
//        });

//        LevelCompleteButton.onClick.AddListener(() =>
//        {
//            UIManager.GetInstance().ShowUIForms("ExtolEmphasisRider");
//        });

//#if SOHOShop
//        SOHOShopButton.onClick.AddListener(() => {
//            SOHOShopManager.instance.ShowRedeemPanel();
//        });

//        GoldButton.onClick.AddListener(() => {
//            if (!CommonUtil.IsApple())
//            {
//                SOHOShopManager.instance.ShowGoldAmazonRedeemPanel();
//            }
//        });
//        AmazonButton.onClick.AddListener(() => {
//            if (!CommonUtil.IsApple())
//            {
//                SOHOShopManager.instance.ShowGoldAmazonRedeemPanel();
//            }
//        });
//        PuzzleShopButton.onClick.AddListener(() => {
//            SOHOShopManager.instance.ShowRedeemGiftPanel();
//        });
//#endif

//        AdTestButton.onClick.AddListener(() => {
//            UIManager.GetInstance().ShowUIForms("AnMedicalRealRider");
//        });

//        AdjustTestButton.onClick.AddListener(() => {
//            UIManager.GetInstance().ShowUIForms("PurifyRealRider");
//        });

//        // 处理消息
//        MessageCenterLogic.GetInstance().Register(CConfig.mg_ui_addgold, (messageData) =>
//        {
//            goldAddAnimation(messageData.valueTransform, messageData.valueDouble);
//        });
//        MessageCenterLogic.GetInstance().Register(CConfig.mg_ui_addtoken, (messageData) =>
//        {
//            tokenAddAnimation(messageData.valueTransform, messageData.valueDouble);
//        });
//        MessageCenterLogic.GetInstance().Register(CConfig.mg_ui_addamazon, (messageData) =>
//        {
//            amazonAddAnimation(messageData.valueTransform, messageData.valueDouble);
//        });

//        AddCashPreConditionButton.onClick.AddListener(() => {
//            SOHOShopManager.instance.AddCashoutPreCondition("condition1", 1);
//        });

//        AddCashTaskValueButton.onClick.AddListener(() => {
//            SOHOShopManager.instance.AddTaskValue("customTask1", 1);
//        });

//    }

//    public override void Display()
//    {
//        base.Display();

//        GoldNumberText.text = NumberUtil.DoubleToStr(DireOustMedical.GetInstance().getGold());
//        TokenNumberText.text = NumberUtil.DoubleToStr(DireOustMedical.GetInstance().getToken());
//        AmazonNumberText.text = NumberUtil.DoubleToStr(DireOustMedical.GetInstance().getAmazon());
//    }

//    public void goldAddAnimation(Transform startTransform, double num)
//    {
//        Transform endTransform = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/DireRider/TopBar/GoldBar/GoldImage");
//        addAnimation(startTransform, endTransform, GoldImage.gameObject, GoldNumberText, DireOustMedical.GetInstance().getGold(), num);
//    }
//    public void tokenAddAnimation(Transform startTransform, double num)
//    {
//        Transform endTransform = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/DireRider/TopBar/TokenBar/TokenImage");
//        addAnimation(startTransform, endTransform, TokenImage.gameObject, TokenNumberText, DireOustMedical.GetInstance().getToken(), num);
//    }
//    public void amazonAddAnimation(Transform startTransform, double num)
//    {
//        Transform endTransform = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/DireRider/TopBar/AmazonBar/AmazonImage");
//        addAnimation(startTransform, endTransform, AmazonImage.gameObject, AmazonNumberText, DireOustMedical.GetInstance().getAmazon(), num);
//    }
//    private void addAnimation(Transform startTransform, Transform endTransform, GameObject icon, Text text, double textValue, double num)
//    {
//        if (startTransform != null)
//        {
//            AnimationController.GoldMoveBest(icon, Mathf.Max((int)num, 1), startTransform, endTransform, () =>
//            {
//                AnimationController.ChangeNumber(double.Parse(text.text), textValue, 0.1f, text, () =>
//                {
//                    text.text = NumberUtil.DoubleToStr(textValue);
//                });
//            });
//        }
//        else
//        {
//            AnimationController.ChangeNumber(double.Parse(text.text), textValue, 0.1f, text, () => {
//                text.text = NumberUtil.DoubleToStr(textValue);
//            });
//        }
//    }
}
