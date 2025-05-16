using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtolSyntax : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("BG")]    [UnityEngine.Serialization.FormerlySerializedAs("BG")]public GameObject BG;
[UnityEngine.Serialization.FormerlySerializedAs("baseWidth")]    [UnityEngine.Serialization.FormerlySerializedAs("baseWidth")]public float LilyDrama= 1080f;
    // Start is called before the first frame update
    void Awake()
    {
        float Flier= GetSystemData.GetInstance().getCameraWidth() / LilyDrama;
        BG.transform.localScale = BG.transform.localScale * Flier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
