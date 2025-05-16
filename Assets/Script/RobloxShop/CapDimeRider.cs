using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapDimeRider : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("TaskContentText")]    [UnityEngine.Serialization.FormerlySerializedAs("TaskContentText")]public Text DimePlateauDawn;
[UnityEngine.Serialization.FormerlySerializedAs("TaskTwoContentText")]    [UnityEngine.Serialization.FormerlySerializedAs("TaskTwoContentText")]public Text DimeBatPlateauDawn;
[UnityEngine.Serialization.FormerlySerializedAs("Button")]    [UnityEngine.Serialization.FormerlySerializedAs("Button")]public Button Untold;
    // Start is called before the first frame update
    private void OnEnable()
    {

        if (ForestPoemOustMedical.instance.EarlyOust[ForestPoemOustMedical.instance.FunPortrait].TaskID == 0)
        {
            DimePlateauDawn.gameObject.SetActive(true);
            DimeBatPlateauDawn.gameObject.SetActive(false);
        }
        else
        {
            DimePlateauDawn.gameObject.SetActive(false);
            DimeBatPlateauDawn.gameObject.SetActive(true);
        }
    }
    void Start()
    {
        Untold.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            ForestPoemRider.instance.DogForestGroovePortrait(ForestPoemOustMedical.instance.FunPortrait);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
