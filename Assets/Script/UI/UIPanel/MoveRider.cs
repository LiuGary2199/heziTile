using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MoveRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("TipsBG")]    [UnityEngine.Serialization.FormerlySerializedAs("TipsBG")]public GameObject MoveBG;
[UnityEngine.Serialization.FormerlySerializedAs("Text")]    [UnityEngine.Serialization.FormerlySerializedAs("Text")]public GameObject Dawn;
    // Start is called before the first frame update
    public override void Display()
    {

        base.Display();
        BarnMove();
    }

    void BarnMove()
    {
        MoveBG.transform.position = new Vector3(0, -1f, 0);
        var q = DOTween.Sequence();
        q.Append(MoveBG.GetComponent<CanvasGroup>().DOFade(0.9f, 0.2f));
        q.Insert(0,MoveBG.transform.DOMoveY(0, 1f).SetEase(Ease.OutQuart));
        q.Insert(2f,MoveBG.GetComponent<CanvasGroup>().DOFade(0, 0.2f).OnComplete(() =>
        {
            CloseUIForm(GetType().Name);
            q.Kill();
        }));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
