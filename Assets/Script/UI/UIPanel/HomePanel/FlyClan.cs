using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FlyClan : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("FlyButton")]    [UnityEngine.Serialization.FormerlySerializedAs("FlyButton")]public Button WhoUntold;
[UnityEngine.Serialization.FormerlySerializedAs("CashValue")]    [UnityEngine.Serialization.FormerlySerializedAs("CashValue")]public Text CookQuill;

    private Sequence _Lay1;
    private Sequence _Lay2;

    private double _SlamRed;

    private void Awake()
    {
        WhoUntold.onClick.AddListener(() => {

            //if (NewbieManager.GetInstance().IsOpenNewbie) { return; }
            //if (BubbleManager.GetInstance().IsWinGame()) { return; }
            WhoMedical.Instance.NoDumpWho = true;
            WhoMedical.Instance.DumpIEWho();
            PostEventScript.GetInstance().SendEvent("1011");
            OakGroove();
            CartoonWhoClan();
        });
        SpyTactAfraid();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("-----------------------------------------");
    }

    public void WhoToll()
    {
        transform.DOPlay();
        _Lay1.Play();
        _Lay2.Play();
    }

    public void WhoMessy()
    {
        transform.DOPause();
        _Lay1.Pause();
        _Lay2.Pause();
    }

    public void WhoBeak()
    {
        _Lay1.Kill();
        _Lay2.Kill();
        transform.DOKill();
    }

    private void OakGroove()
    {
        RewardPanelData Halt= new RewardPanelData();
        Halt.RustLace = "Fly";
        Halt.Row_Groove.Add(RewardType.cash, _SlamRed);
        GrooveMedical.GetInstance().DumpExtolEmphasisRider(Halt);
    }

    private void SpyTactAfraid()
    {
        _SlamRed = NetInfoMgr.instance.gameFlyData.multi * Dire.instance.WhoCookDutch();
        _SlamRed = Mathf.Ceil((float)_SlamRed);
        CookQuill.text = "$" + _SlamRed;
        _Lay1 = DOTween.Sequence();
        _Lay2 = DOTween.Sequence();
        /*int leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
        {*/
            HearWho();
        /*}
        else
        {
            RigthFly();
        }*/
    }

    private void HearWho()
    {
        transform.localPosition = new Vector3(-450f, 0, 0);
        _Lay1 = DOTween.Sequence();
        _Lay2 = DOTween.Sequence();
        _Lay1.Append(transform.DOLocalMoveY(-150f - Random.Range(-50f, 50f), 2.5f).SetEase(Ease.InSine));
        _Lay1.Append(transform.DOLocalMoveY(0, 2.5f).SetEase(Ease.InSine));
        _Lay1.SetLoops(-1);
        _Lay1.Play();

       // _Via2.Append(transform.DOScale(0.75f, 0.5f).SetEase(Ease.Linear));
       // _Via2.Append(transform.DOScale(0.7f, 0.5f).SetEase(Ease.Linear));
        _Lay2.SetLoops(-1);
        _Lay2.Play();
        transform.DOLocalMoveX(450, 10f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (WhoMedical.Instance.NoDumpWho)
            {
                CartoonWhoClan();
            }
            else
            {
                WhoBeak();
                StartCoroutine(DutyWho(() => { ThankWho(); }));
            }

        });
    }

    private void ThankWho()
    {
        transform.localPosition = new Vector3(450, 0, 0);
        _Lay1 = DOTween.Sequence();
        _Lay2 = DOTween.Sequence();
        _Lay1.Append(transform.DOLocalMoveY(-150f - Random.Range(-50f, 50f), 2.5f).SetEase(Ease.InSine));
        _Lay1.Append(transform.DOLocalMoveY(0, 2.5f).SetEase(Ease.InSine));
        _Lay1.SetLoops(-1);
        _Lay1.Play();

       // _Via2.Append(transform.DOScale(0.75f, 0.5f).SetEase(Ease.Linear));
       // _Via2.Append(transform.DOScale(0.7f, 0.5f).SetEase(Ease.Linear));
        _Lay2.SetLoops(-1);
        _Lay2.Play();
        transform.DOLocalMoveX(-450, 10f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (WhoMedical.Instance.NoDumpWho)
            {
                CartoonWhoClan();
            }
            else
            {
                WhoBeak();
                StartCoroutine(DutyWho(() => { HearWho(); }));
            }

        });
    }

    IEnumerator DutyWho(Action action)
    {
        yield return new WaitForSeconds(5f);
        action?.Invoke();
    }

    public void CartoonWhoClan()
    {
        WhoBeak();
        GetComponent<RectTransform>().DOKill();
        Destroy(gameObject);
    }

}
