using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrooveRiderCap : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("PanelShowList")]
[UnityEngine.Serialization.FormerlySerializedAs("PanelShowList")]    public List<GameObject> RiderNoteLend;
[UnityEngine.Serialization.FormerlySerializedAs("List_RewardItem")]    [UnityEngine.Serialization.FormerlySerializedAs("List_RewardItem")]public List<GrooveClan> Lend_GrooveClan;

    [Header("��ť")]
[UnityEngine.Serialization.FormerlySerializedAs("ADButton")]    [UnityEngine.Serialization.FormerlySerializedAs("ADButton")]public Button ADUntold;
[UnityEngine.Serialization.FormerlySerializedAs("ReceiveButton")]    [UnityEngine.Serialization.FormerlySerializedAs("ReceiveButton")]public Button AgitateUntold;
    [Header("ת����")]
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    [UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]public BoonModel SlotBG;
    [Header("���")]
[UnityEngine.Serialization.FormerlySerializedAs("ADText")]    [UnityEngine.Serialization.FormerlySerializedAs("ADText")]public Transform ADDawn;
[UnityEngine.Serialization.FormerlySerializedAs("ADImage")]    [UnityEngine.Serialization.FormerlySerializedAs("ADImage")]public Transform ADNomad;

    private RewardPanelData _ExpertOust;
    GameObject GrooveNomad;
    private double Expert;   // token����
    private bool FeatGrooveTenon= false;
[UnityEngine.Serialization.FormerlySerializedAs("flytrans")]    [UnityEngine.Serialization.FormerlySerializedAs("flytrans")]public Transform Threaten;
    protected override void Awake()
    {
        base.Awake();
       // MessageCenter.AddMsgListener(CriticBrush.FlyRewardData, OnLevelCompleteData);
    }

    public override void Display()
    {
        base.Display();
        FeatGrooveTenon = false;
        //RewardCount(2);
        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.reward_panel_open);
        GrooveRiderNoteAct();
        AgitateUntold.enabled = true;
        AgitateUntold.gameObject.SetActive(false);
        ADUntold.enabled = true;
        ADUntold.gameObject.SetActive(true);
        StartCoroutine(nameof(DumpHaleUntold));
        ADManager.Instance.PauseTimeInterstitial();
        SlotBG.BendDutch();
        OnLevelCompleteData();
;    }

    // Start is called before the first frame update
    void Start()
    {   
        ADUntold.onClick.AddListener(() => {
            ADManager.Instance.playRewardVideo((success) =>
            {
                if (success)
                {
                    StopCoroutine(nameof(DumpHaleUntold));
                    ADUntold.enabled = false;
                    FeatGrooveTenon = true;
                    FeatBoon();
                }
            }, "1212");
        });
        AgitateUntold.onClick.AddListener(() => 
        {
            AgitateUntold.enabled = false;
            ADManager.Instance.ResumeTimeInterstitial();
            if (!FeatGrooveTenon)
            {
                ADManager.Instance.playInterstitialAd(0);
            }
            CloseUIForm(GetType().Name);
            //   RewardPanelMove(2, () => { });
            //�ֽ�
            foreach (var item in _ExpertOust.Row_Groove)
            {
                Dire.instance.OwnCook(item.Value, Threaten);
            }
           // GrooveMedical.GetInstance().AddMoneyToCache(_rewardData.Dic_Reward);
        });
    }

   // private void OnLevelCompleteData(KeyValuesUpdate kv)
     private void OnLevelCompleteData()
    {
        KeyValuesUpdate kv = NetInfoMgr.instance.flyreward;
        RewardPanelData Halt= (RewardPanelData)kv.Values;
        _ExpertOust = Halt;
        OvertGrooveResult();
        OnSetRewardPosition(Halt.Row_Groove.Count);
        int Boost= 0;
        foreach (var item in Halt.Row_Groove)
        {
            Lend_GrooveClan[Boost].gameObject.SetActive(true);
            Lend_GrooveClan[Boost].DogGrooveOust(item.Key, item.Value);
            Boost++;
        }
    }

    IEnumerator DumpHaleUntold()
    {
        yield return new WaitForSeconds(2);
        if (!NoCapExam())
        {
            AgitateUntold.gameObject.SetActive(true);
        }
    }

    private void OnSetRewardPosition(int count)
    {
        if (count == 1)
        {
            Lend_GrooveClan[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(0,95, 0);
            Lend_GrooveClan[0].transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (count == 2)
        {
            Lend_GrooveClan[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(-150, 270, 0);
            Lend_GrooveClan[0].transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            Lend_GrooveClan[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(150, 270, 0);
            Lend_GrooveClan[1].transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
        else
        {
            Lend_GrooveClan[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 370, 0);
            Lend_GrooveClan[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(-150, 170, 0);
            Lend_GrooveClan[2].GetComponent<RectTransform>().anchoredPosition = new Vector3(150, 170, 0);
        }
    }

    private void OvertGrooveResult()
    {
        for (int i = 0; i < Lend_GrooveClan.Count; i++)
        {
            Lend_GrooveClan[i].transform.localScale = new Vector3(1f, 1f, 1f);
            Lend_GrooveClan[i].gameObject.SetActive(false);
        }
    }

    public void GrooveRiderNoteAct() 
    {
        float DelayTime = 0;
        for (int i = 0; i < RiderNoteLend.Count; i++)
        {
            GameObject Item = RiderNoteLend[i];
            Item.transform.localScale = new Vector3(0, 0, 0);
            Item.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(DelayTime);
            DelayTime += 0.1f;
        }
    }

    /*public void RewardCount(int index) 
    {
        for (int i = 0; i < RewardIndex.Count; i++)
        {
            if (i == index-1)
            {
                RewardIndex[i].SetActive(true);
            }
            else
            {
                RewardIndex[i].SetActive(false);
            }
        }
    }*/

    private bool NoCapExam()
    {
        return !PlayerPrefs.HasKey(CConfig.sv_FirstSlot + "Bool") || SaveDataManager.GetBool(CConfig.sv_FirstSlot);
    }

    private void FeatBoon()
    {
        AgitateUntold.gameObject.SetActive(false);
        ADUntold.gameObject.SetActive(false);
        int Boost= WhoBoonDutchThink();
        SlotBG.Flop(Boost, (multi) => {
            // slot������Ļص�
            // ��ֵ�仯TODO
            int Boost= 0;
            foreach (var item in _ExpertOust.Row_Groove)
            {
                Text rewardText = Lend_GrooveClan[Boost].GrooveDawn;
                double rewardValue = item.Value;
                RewardType type = item.Key;
                AnimationController.ChangeNumber(rewardValue, rewardValue * multi, 0, rewardText, "+", () =>
                {
                    rewardValue = rewardValue * multi;
                    rewardText.text = "+" + NumberUtil.DoubleToStr(rewardValue);
                    _ExpertOust.Row_Groove[type] = rewardValue;
                    AgitateUntold.gameObject.SetActive(true);
                });
                Boost++;
            }
            
            //ADButton.gameObject.SetActive(true);
        });
    }

    private int WhoBoonDutchThink()
    {
        // ���û�����һ�ι̶���5��
        if (NoCapExam())
        {
            int Boost= 0;
            foreach (SlotItem wg in NetInfoMgr.instance.InitData.slot_group)
            {
                if (wg.multi == 2)
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
            int r =UnityEngine.Random.Range(0, sumWeight);
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
    /// ��ȡ����
    /// </summary>
    /// <param name="index">1=��ң�2=����ѷ����3=�ֽ�</param>
    /// <param name="finish">��ɻص�</param>
    public void GrooveRiderSack(int index,System.Action finish )
    {
        float delayTime = 0;
        //��ʼ��
        for (int i = 0; i < 5; i++)
        {
            int a = i;
            GameObject GoldIcon = Instantiate(GrooveNomad, GrooveNomad.transform.parent);
            GoldIcon.transform.position = new Vector3(0, 0, 0);
            GoldIcon.SetActive(true);
            GoldIcon.transform.DOMove(GrooveNomad.transform.position, 0.6f).SetDelay(delayTime).OnComplete(() =>
            {
                if (a == 4)
                {

                    finish();
                }
                Destroy(GoldIcon);
            });
            delayTime += 0.1f;
        }

    }
}
