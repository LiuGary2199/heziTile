using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SillyRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("AdButton")]    [UnityEngine.Serialization.FormerlySerializedAs("AdButton")]public Button AnUntold;
[UnityEngine.Serialization.FormerlySerializedAs("GetButton")]    [UnityEngine.Serialization.FormerlySerializedAs("GetButton")]public Button OakUntold;
[UnityEngine.Serialization.FormerlySerializedAs("RewardImage")]    [UnityEngine.Serialization.FormerlySerializedAs("RewardImage")]public Image GrooveNomad;
[UnityEngine.Serialization.FormerlySerializedAs("RewardPuzzleImage")]    [UnityEngine.Serialization.FormerlySerializedAs("RewardPuzzleImage")]public Image GrooveFalconNomad;
[UnityEngine.Serialization.FormerlySerializedAs("RewardValue")]    [UnityEngine.Serialization.FormerlySerializedAs("RewardValue")]public Text GrooveQuill;

    private TileReward Expert;

    // Start is called before the first frame update
    void Start()
    {
        OakUntold.onClick.AddListener(() =>
        {
            ADManager.Instance.NoThanksAddCount();
            OwnGroove();
            Dire.instance.LargeGapGrooveTerm();
            CloseUIForm(GetType().Name);
        });

        AnUntold.onClick.AddListener(() =>
        {
            ADManager.Instance.playRewardVideo((success) =>
            {
                if (success)
                {
                    OakUntold.gameObject.SetActive(false);
                    AnUntold.gameObject.SetActive(false);
                    AnUntold.enabled = false;
                    AnimationController.ChangeNumber(Expert.rewardValue, Expert.rewardValue * 2, 0.1f, GrooveQuill, "+", () => {
                        Expert.rewardValue *= 2;
                        GrooveQuill.text = "+" + NumberUtil.DoubleToStr(Expert.rewardValue);
                        OwnGroove();
                        Dire.instance.LargeGapGrooveTerm();
                        CloseUIForm(GetType().Name);
                        //GetButton.enabled = true;
                        //GetButton.gameObject.SetActive(true);
                    });
                }
            }, "109");
            
        });
    }

    public override void Display()
    {
        base.Display();

        OakUntold.gameObject.SetActive(true);
        AnUntold.gameObject.SetActive(true);
        OakUntold.enabled = true;
        AnUntold.enabled = true;

        Expert = Dire.instance.GapGroove;
        if (Expert == null)
        {
            CloseUIForm(GetType().Name);
        }

        if (Expert.rewardType == RewardType.gold)
        {
            GrooveNomad.gameObject.SetActive(true);
            GrooveFalconNomad.gameObject.SetActive(false);
            GrooveNomad.sprite = Resources.Load<Sprite>(CConfig.AUi_Bonus_Gold);
        } 
        else if(Expert.rewardType == RewardType.cash)
        {
            GrooveNomad.gameObject.SetActive(true);
            GrooveFalconNomad.gameObject.SetActive(false);
            GrooveNomad.sprite = Resources.Load<Sprite>(CConfig.AUi_Bonus_Cash);
        } 
        else if(Expert.rewardType == RewardType.amazon)
        {
            GrooveNomad.gameObject.SetActive(true);
            GrooveFalconNomad.gameObject.SetActive(false);
            GrooveNomad.sprite = Resources.Load<Sprite>(CConfig.AUi_Bonus_Amazon);
        } 
        //else if(reward.rewardType == RewardType.puzzle)
        //{
        //    RewardImage.gameObject.SetActive(false);
        //    RewardPuzzleImage.gameObject.SetActive(true);
        //    Puzzle puzzle = reward.puzzle;
        //    RewardPuzzleImage.sprite = Resources.Load<Sprite>(puzzle.puzzle_img);
        //}

        GrooveQuill.text = "+" + NumberUtil.DoubleToStr(Expert.rewardValue);
    }

    private void OwnGroove()
    {
        if (Expert.rewardType == RewardType.gold)
        {
            Transform P= UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/ExtolRider/GoldBar/GoldIcon");
            if (CommonUtil.IsBgswitch())
            {
                P = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/ExtolRider/NewTopGroup/GoldBar/GoldIcon");
            }
            Transform A = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>();
            A.position = new Vector3(0, 0, 0);
            AnimationController.GoldMoveBest(P.gameObject,15, A, P,()=> 
            {
                Dire.instance.OwnLord(Expert.rewardValue); 
            });
            
        }
        else if (Expert.rewardType == RewardType.cash)
        {
            Transform P = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/ExtolRider/CashBar/CashIcon");
            Transform A = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>();
            A.position = new Vector3(0, 0, 0);
            AnimationController.GoldMoveBest(P.gameObject, 15, A,P, () =>
            {
                Dire.instance.OwnCook(Expert.rewardValue);
            });
        }
        else if (Expert.rewardType == RewardType.amazon)
        {
            Transform P = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().Find("Normal/ExtolRider/AmazonBar/AmazonIcon");
            Transform A = UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>();
            A.position = new Vector3(0, 0, 0);
            AnimationController.GoldMoveBest(P.gameObject, 15, A, P, () =>
            {
                Dire.instance.OwnStrait(Expert.rewardValue);
            });
            
        }
        else if (Expert.rewardType == RewardType.puzzle)
        {
        //    SOHOShopManager.instance.AddRewardPuzzle(reward.puzzle);
        }
    }
}
