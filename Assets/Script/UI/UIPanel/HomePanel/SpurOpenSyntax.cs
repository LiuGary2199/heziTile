using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpurOpenSyntax : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("scrollView")]    [UnityEngine.Serialization.FormerlySerializedAs("scrollView")]public RectTransform SalaryPlan;
[UnityEngine.Serialization.FormerlySerializedAs("topBar")]    [UnityEngine.Serialization.FormerlySerializedAs("topBar")]public RectTransform EggYew;
[UnityEngine.Serialization.FormerlySerializedAs("bottomBar")]    [UnityEngine.Serialization.FormerlySerializedAs("bottomBar")]public RectTransform InfluxYew;
    private void Awake()
    {
        SalaryPlan.anchoredPosition = new Vector2(0, -EggYew.sizeDelta.y);
        SalaryPlan.sizeDelta = new Vector2(UIManager.GetInstance().MainCanvas.GetComponent<CanvasScaler>().referenceResolution.x, UIManager.GetInstance().MainCanvas.GetComponent<RectTransform>().sizeDelta.y - EggYew.sizeDelta.y - InfluxYew.sizeDelta.y);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
