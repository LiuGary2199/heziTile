using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ForestFalconRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("ItemList")]    
[UnityEngine.Serialization.FormerlySerializedAs("ItemList")]    public List<GameObject> ClanLend;
[UnityEngine.Serialization.FormerlySerializedAs("CardSetDealy")]    [UnityEngine.Serialization.FormerlySerializedAs("CardSetDealy")]public float ZealSetRelic;
[UnityEngine.Serialization.FormerlySerializedAs("adButton")]    [UnityEngine.Serialization.FormerlySerializedAs("adButton")]public Button ToUntold;
    List<AddIdAndValue> valueLend;


    // Start is called before the first frame update
    void Start()
    {

        ToUntold.onClick.AddListener(() =>
        {
            ToUntoldSaline();
        });
    }
    void Bend()
    {
        valueLend = new List<AddIdAndValue>();
        foreach (GameObject obj in ClanLend)
        {
            Transform Icon = obj.transform.Find("Image");
            Transform Dawn= obj.transform.Find("Text");
            AddIdAndValue value = ForestPoemOustMedical.instance.OakForestGroove();
            valueLend.Add(value);
            Dawn.GetComponent<Text>().text = "+" + value.value;
            Icon.GetComponent<Image>().sprite = ForestPoemOustMedical.instance.OakRuggedMeID(value.id);
        }
    }
    void ToUntoldSaline()       //[TODO]动效、音效
    {
        ADManager.Instance.playRewardVideo((success) => {
            if (success)
            {
                ForestPoemOustMedical.instance.Refrigerate(valueLend);
                /*MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanelAddPuzzle);*/

                ZealVolt(()=> { Sandy(); });
                CloseUIForm(GetType().Name);
            }
        }, "109");
    }

    public void ZealModel(System.Action finish) 
    {
        
        float delaytime = 0;
        int count = 0;
        for (int i = 0; i < ClanLend.Count; i++) 
        {
            GameObject Card = ClanLend[i];
             
            
            StartCoroutine(Windmill(() => 
            {
                ZealNote(Card,1,()=> {
                    count++;
                    if (count == ClanLend.Count)
                    {
                        Dire.instance.ChafeDireMessyArabHis();
                    }
                });
            }, delaytime));
            delaytime += ZealSetRelic;
            if (i == ClanLend.Count - 1) 
            {
                finish();
                
            }
        }
    }

    public void ZealVolt(System.Action finish) 
    {

        for (int i = 0; i < ClanLend.Count; i++) 
        {
            
            ZealNote(ClanLend[i], 2);
            ClanLend[i].SetActive(false);
            if (i == ClanLend.Count - 1) 
            {
                finish();
            }
        }
    }

    IEnumerator Windmill(System.Action finish, float delaytime)
    {
        yield return new WaitForSeconds(delaytime);
        finish();
    }
    public void ZealNote(GameObject CardItem, int i, System.Action finish = null)
    {
        
        MessageData Halt= new MessageData();
        Sequence Card = DOTween.Sequence();
        Sequence Hint = DOTween.Sequence();
        Hint.SetId("cardanimtaionHint");
        Card.SetId("cardanimtaion");
        CardItem.transform.eulerAngles = new Vector3(0, 0, 0);
        Vector3 StartTransformPS = CardItem.transform.position;
        Vector3 StartTransformRT = CardItem.transform.eulerAngles;
        Vector3 StartTransformSC = CardItem.transform.localScale;
        if (i == 1)
        {

            Card.Append(CardItem.transform.DORotate(new Vector3(0, 90, 15), 0.2f));
            Card.Insert(0, CardItem.transform.DOScale(CardItem.transform.localScale * 1.1f, 0.2f));
            Card.Insert(0, CardItem.transform.DOMoveY(CardItem .transform.position.y+ 0.2f, 0.1f));
            Card.Append(CardItem.transform.DORotate(new Vector3(0, 180, 0), 0.2f).OnComplete(() =>
            {
                CardItem.GetComponent<Transform>().Find("Fx_Rotate_Light06").gameObject.SetActive(true);
            }));
            Card.Insert(0.4f, CardItem.transform.DOMoveY(StartTransformPS.y, 0.1f));
            Card.Append(CardItem.transform.DOScale(StartTransformSC, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                CardItem.GetComponent<Transform>().Find("").gameObject.SetActive(true);
                finish();
            }));
        }
        else if (i==2)
        {
            /*Debug.Log("puzzle位置" + data.valueGameObject5.transform.position.y);*/
            CardItem.transform.eulerAngles = new Vector3(0, 180, 0);
            GameObject cardcopy = Instantiate(CardItem, UIManager.GetInstance().MainCanvas.transform);
            
            /*CardItem.transform.DOScale(0, 0.01f);*/
            cardcopy.transform.position = new Vector3(CardItem.transform.position.x, CardItem.transform.position.y, -2);
            Hint.Append(cardcopy.transform.DORotate(new Vector3(0, 90, 10), 0.3f).OnComplete(() =>
            {
                CardItem.GetComponent<Transform>().Find("Fx_Rotate_Light06").gameObject.SetActive(false);
            }));
            Hint.Insert(0, cardcopy.transform.DOScale(StartTransformSC * 0.7f, 0.3f).SetEase(Ease.OutBack));
            Hint.Append(cardcopy.transform.DORotate(new Vector3(0, 0, 0), 0.5f));
            Hint.Insert(0.3f, cardcopy.transform.DOScale(StartTransformSC * 0.4f, 0.3f)).OnComplete(() =>
            {
                Destroy(cardcopy);
                Hint.Kill();
            });
        }
        
    }
    public void Sandy()
    {
        for (int i = 0; i < ClanLend.Count; i++) 
        {
            ClanLend[i].transform.eulerAngles = new Vector3(0, 0, 0);
            

            /*StartCoroutine(setdelay(() =>
            {
                ItemList[i].SetActive(true);
            }, 1f));*/
            
        }
    }
    public override void Hidding()
    {
        base.Hidding();
        DOTween.Kill("cardanimtaion");
        foreach (GameObject obj in ClanLend)
        {
            Transform LightImage = obj.transform.Find("Light");
            LightImage.DOKill();
        }
    }
    public override void Display()
    {
        base.Display();
        Dire.instance.FirnMessyArabHis();
        for (int i = 0; i < ClanLend.Count; i++)
        {

            ClanLend[i].SetActive(true);
        }
        
        StartCoroutine(Windmill(() =>
        {
            ZealModel(()=> { });
        },0.5f));
        
        //foreach (GameObject obj in ItemList)
        //{
        //    Transform LightImage = obj.transform.Find("Light");
        //    LightImage.DOLocalRotate(new Vector3(0, 0, -360), 4f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        //}
        Bend();
    }

    // Update is called once per frame

    void Update()
    {

    }
}
