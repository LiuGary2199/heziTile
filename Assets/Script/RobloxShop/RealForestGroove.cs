using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealForestGroove : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("deleteBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("deleteBtn")]public Button BelongFin;
[UnityEngine.Serialization.FormerlySerializedAs("GetChildBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("GetChildBtn")]public Button OakPlankFin;
[UnityEngine.Serialization.FormerlySerializedAs("AddChildBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("AddChildBtn")]    public Button WhoPlankFin;
[UnityEngine.Serialization.FormerlySerializedAs("GetPropsBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("GetPropsBtn")]    public Button OakEpochFin;
[UnityEngine.Serialization.FormerlySerializedAs("AddPropsBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("AddPropsBtn")]    public Button WhoEpochFin;
[UnityEngine.Serialization.FormerlySerializedAs("Textl")]
[UnityEngine.Serialization.FormerlySerializedAs("Textl")]    public Text Taste;
    // Start is called before the first frame update
    void Start()
    {
        BelongFin.onClick.AddListener(BelongFinSpeed);
        OakPlankFin.onClick.AddListener(OakPlankFinSpeed);
        WhoPlankFin.onClick.AddListener(WhoPlankFinCGold);
        OakEpochFin.onClick.AddListener(OakEpochFinSpeed);
        WhoEpochFin.onClick.AddListener(WhoEpochFinSpeed);
        Taste.text = ForestPoemOustMedical.instance.PairOakQuill();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BelongFinSpeed()
    {
        PlayerPrefs.DeleteAll();
        Taste.text = ForestPoemOustMedical.instance.PairOakQuill();
    }

    private void OakPlankFinSpeed()
    {
        ForestPoemOustMedical.instance.OakArbitraryGroove();
        Taste.text = ForestPoemOustMedical.instance.PairOakQuill();
    }

    private void WhoPlankFinCGold()
    {
        //ForestPoemOustMedical.instance.Addschedule(ForestPoemOustMedical.instance.CurrentId, ForestPoemOustMedical.instance.AddValue);
        Taste.text = ForestPoemOustMedical.instance.PairOakQuill();
    }

    private void OakEpochFinSpeed()
    {
        ForestPoemOustMedical.instance.OakEpochGroove();
        Taste.text = ForestPoemOustMedical.instance.PairOakQuill();
        
    }

    private void WhoEpochFinSpeed()
    {
        //ForestPoemOustMedical.instance.Addschedule(ForestPoemOustMedical.instance.CurrentId, ForestPoemOustMedical.instance.AddValue);
        Taste.text = ForestPoemOustMedical.instance.PairOakQuill();
    }


}
