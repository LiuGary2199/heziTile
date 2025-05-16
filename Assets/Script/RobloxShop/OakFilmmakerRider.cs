using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OakFilmmakerRider : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ClaimBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("ClaimBtn")]public Button WeighFin;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button OvertFin;
[UnityEngine.Serialization.FormerlySerializedAs("FragmentImage")]
[UnityEngine.Serialization.FormerlySerializedAs("FragmentImage")]    public Image DilutionNomad;
[UnityEngine.Serialization.FormerlySerializedAs("FragmentText")]    [UnityEngine.Serialization.FormerlySerializedAs("FragmentText")]public Text DilutionDawn;
[UnityEngine.Serialization.FormerlySerializedAs("ID")]
[UnityEngine.Serialization.FormerlySerializedAs("ID")]    public int ID;
[UnityEngine.Serialization.FormerlySerializedAs("levelImage")]    [UnityEngine.Serialization.FormerlySerializedAs("levelImage")]public Image BraveNomad;

    private AddIdAndValue _OwnOnGarQuill= new AddIdAndValue();
    
    
    // Start is called before the first frame update
    void Start()
    {
        WeighFin.onClick.AddListener(WeighADFinSpeed);
        OvertFin.onClick.AddListener(OvertFinSpeed);
        
        
        
    }

    private void OnEnable()
    {
        if(ID.ToString().StartsWith("2"))
        {
            BraveNomad.gameObject.SetActive(true);
            BraveNomad.sprite = Resources.Load<Sprite>(CConfig.RobloxShopRobloxImagerobloximgLevel + ForestPoemOustMedical.instance.ForestClanReply[ID].Level);
        }
        else
        {
            BraveNomad.gameObject.SetActive(false);
        }
        DilutionNomad.sprite = ForestPoemOustMedical.instance.OakRuggedMeID(ID);
        _OwnOnGarQuill = ForestPoemOustMedical.instance.OakQuill(ID);
        DilutionDawn.text = _OwnOnGarQuill.value.ToString();
        ForestPoemRider.instance.SixIfNote(transform.Find("Window").gameObject, () =>
        {
            //gameObject.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WeighADFinSpeed()
    {
        
            ADManager.Instance.playRewardVideo((success) =>
            {
                ForestPoemRider.instance.SixIfRare(transform.Find("Window").gameObject, () =>
                {
                    gameObject.SetActive(false);
                    ForestPoemRider.instance.TugMemory("+ " + _OwnOnGarQuill.value, true);
                    List<AddIdAndValue> list = new List<AddIdAndValue>();
                    list.Add(_OwnOnGarQuill);
                    ForestPoemOustMedical.instance.Refrigerate(list);
                    SaveDataManager.SetString("String" + _OwnOnGarQuill.id,DateTime.Now.ToString("yyyyMMddHH:mm:ss"));
                    if(_OwnOnGarQuill.id.ToString().StartsWith("2"))
                    {
                        ForestPoemRider.instance.MeetingArbitrary(_OwnOnGarQuill.id);
                    }
                    else
                    {
                        ForestPoemRider.instance.MeetingEpoch(_OwnOnGarQuill.id);
                    }
                });
            },"27");
        /*{
            //看广告回调
            //增加数值，刷新数据，隐藏页面
            
            
        }*/
    }

    private void OvertFinSpeed()
    {
        ForestPoemRider.instance.SixIfRare(transform.Find("Window").gameObject, () =>
        {
            gameObject.SetActive(false);
        });
        //
    }
}
