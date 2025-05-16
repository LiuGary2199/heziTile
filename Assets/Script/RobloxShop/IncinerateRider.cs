using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncinerateRider : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ClimeBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("ClimeBtn")]public Button AlikeFin;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]public Button OvertFin;
[UnityEngine.Serialization.FormerlySerializedAs("OneInputField")]
[UnityEngine.Serialization.FormerlySerializedAs("OneInputField")]    public InputField FurStrapAgain;
[UnityEngine.Serialization.FormerlySerializedAs("TwoInputField")]
[UnityEngine.Serialization.FormerlySerializedAs("TwoInputField")]    public InputField BatStrapAgain;
    
    
    // Start is called before the first frame update
    void Start()
    {
        AlikeFin.onClick.AddListener(AlikeFinSpeed);
        OvertFin.onClick.AddListener(OvertFinSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        
    }

    private void AlikeFinSpeed()
    {
        if (FurStrapAgain.textComponent.text != "" &&
            FurStrapAgain.textComponent.text == BatStrapAgain.textComponent.text)
        {
            //能提现，减去对应的Value
            Debug.Log("能提现，减去对应的Value");
            //获取需要减去的数值
            
            ForestPoemOustMedical.instance.FirShoshone(ForestPoemOustMedical.instance.FirID);
            gameObject.SetActive(false);
        }
        else
        {
            ForestPoemRider.instance.TugMemory("0");
            //输入错误，给反馈
            Debug.Log("输入错误，给反馈");
        }
    }

    public void OvertFinSpeed()
    {
        gameObject.SetActive(false);
    }
    
}
