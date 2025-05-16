using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpurSack : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("fishIndex")]    [UnityEngine.Serialization.FormerlySerializedAs("fishIndex")]public int SaleThink;
[UnityEngine.Serialization.FormerlySerializedAs("direction")]    [UnityEngine.Serialization.FormerlySerializedAs("direction")]public int Estuarine= 1;
[UnityEngine.Serialization.FormerlySerializedAs("speed")]    [UnityEngine.Serialization.FormerlySerializedAs("speed")]public float Rider;
[UnityEngine.Serialization.FormerlySerializedAs("maxY")]    [UnityEngine.Serialization.FormerlySerializedAs("maxY")]public float CanY;
[UnityEngine.Serialization.FormerlySerializedAs("minY")]    [UnityEngine.Serialization.FormerlySerializedAs("minY")]public float HatY;
    float Feathery;
    Sequence Pen;
    Dictionary<string, string> ContendRow;
    float ExpertMarvelX;
[UnityEngine.Serialization.FormerlySerializedAs("collisionList")]    [UnityEngine.Serialization.FormerlySerializedAs("collisionList")]public List<GameObject> CharacterLend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    private void OnEnable()
    {
        CharacterLend = new List<GameObject>();
        Feathery = 0;
        BorrowSaline();
    }
    private void OnDisable()
    {
        Pen.Kill();
    }
    public void CharacterLocust(GameObject gameObject)
    {
        CharacterLend.Add(gameObject);
    }
    void BorrowSaline()
    {
        Pen.Kill();
        Pen = DOTween.Sequence();
        if (Feathery == 0)
        {
            Feathery = Random.Range(-SpurMedical.instance.Oust.WokPathogen, SpurMedical.instance.Oust.WokPathogen);
        } else if (Feathery > 0)
        {
            Feathery = Random.Range(-SpurMedical.instance.Oust.WokPathogen, 0);
        }
        else
        {
            Feathery = Random.Range(0, SpurMedical.instance.Oust.WokPathogen);
        }

        float rotateTime = Random.Range(SpurMedical.instance.Oust.ThreshTerm.Hat, SpurMedical.instance.Oust.ThreshTerm.Hat);
        float limitTime = Random.Range(SpurMedical.instance.Oust.ThreshEarly.Hat, SpurMedical.instance.Oust.ThreshEarly.Can);
        Pen.AppendInterval(limitTime);
        Pen.Append(transform.DORotate(new Vector3(0,0,Feathery), rotateTime));
        Pen.AppendCallback(() => {
            BorrowSaline();
        });
        Pen.Play();
    }
    void RepelRadialCane()
    {
        if (transform.localScale.x < 0)
        {
            if (transform.position.y >= CanY - 0.1f && Feathery > 0)
            {
                BorrowSaline();
            }
            if (transform.position.y <= HatY + 0.1f && Feathery < 0)
            {
                BorrowSaline();
            }
        } 
        else
        {
            if (transform.position.y >= CanY - 0.1f && Feathery < 0)
            {
                BorrowSaline();
            }
            if (transform.position.y <= HatY + 0.1f && Feathery > 0)
            {
                BorrowSaline();
            }
        }
        
    }
    public void BusAnxious(Dictionary<string,string> dic)
    {
        ContendRow = dic;
        ExpertMarvelX = Random.Range(-1f, 1f);
    }
    public void LintelGroove()
    {
        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_FishRewardShow);
        SpurMedical.instance.SpurFameGroove(gameObject,ContendRow);
        ContendRow = null;
        ExpertMarvelX = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M)) 
        {
            SaveDataManager.SetInt(CConfig.sv_PuzzleRewardCount, SaveDataManager.GetInt(CConfig.sv_PuzzleRewardCount) + 3);
        }
        transform.position += Estuarine * transform.right * Time.deltaTime * Rider;
        //if (missionDic != null)
        //{
        //    if (missionDic["type"] == "Shell" && missionDic["num"] == "1")
        //    {
        //        if (transform.position.y <= 0.8f)
        //        {
        //            createReward();
        //        }
        //    }
        //    else
        //    {
        //        if (transform.position.x - rewardTargetX <= 0.1f && transform.position.x - rewardTargetX >= -0.1f && missionDic != null)
        //        {
        //            createReward();
        //        }

        //    }
        //}

        RepelRadialCane();
        if (transform.position.x < SpurMedical.instance.Extra_Mast.position.x || transform.position.x > SpurMedical.instance.Extra_Buggy.position.x)
        {
            gameObject.SetActive(false);
            SpurMedical.instance.RailSpurLend.Add(gameObject);
            SpurMedical.instance.RailSpurThinkLend.Add(SaleThink);
        }
    }
}
