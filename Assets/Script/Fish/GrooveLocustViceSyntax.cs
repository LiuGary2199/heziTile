using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrooveLocustViceSyntax : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("bottomWall1")]    [UnityEngine.Serialization.FormerlySerializedAs("bottomWall1")]public RectTransform InfluxVice1;
[UnityEngine.Serialization.FormerlySerializedAs("bottomWall2")]    [UnityEngine.Serialization.FormerlySerializedAs("bottomWall2")]public RectTransform InfluxVice2;
    // Start is called before the first frame update
    void Start()
    {
        InfluxVice1.anchoredPosition = new Vector2(0, InfluxVice1.anchoredPosition.y * (Screen.width / 750f));
        InfluxVice2.anchoredPosition = new Vector2(0, InfluxVice2.anchoredPosition.y * (Screen.width / 750f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
