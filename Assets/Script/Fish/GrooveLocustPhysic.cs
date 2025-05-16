using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrooveLocustPhysic : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("getButton")]    [UnityEngine.Serialization.FormerlySerializedAs("getButton")]public Button WhoUntold;
    Dictionary<string, string> ContendRow;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<RectTransform>().sizeDelta = new Vector2(110f, 82f);
        float Flier= Screen.width / 750f;
        transform.localScale = transform.localScale * Flier;
    }
    public void Bend(Dictionary<string,string> dic)
    {
        ContendRow = dic;
        

        if (SaveDataManager.GetBool(CConfig.sv_NewUserStep + "1-2"))
        {
            GetComponent<Collider2D>().enabled = true;
            float force = Random.Range(1f, 1.5f);
            float x= Random.Range(0.5f, 1f) * (Random.Range(0, 2) == 0 ? -1 : 1);
            float y= Random.Range(0.5f, 1f) * (Random.Range(0, 2) == 0 ? -1 : 1);
            GetComponent<Rigidbody2D>().velocity = new Vector2(x, y).normalized * 0.1f;
        }
        else
        {
            Dire.instance.ChafeDireMessyArabHis();
            transform.SetParent(UIManager.GetInstance().MainCanvas.transform);
            SaveDataManager.SetBool(CConfig.sv_NewUserStep + "1-2", true);
            CapExamMedical.GetInstance().BarnArabMovePlateau(Vector2.zero, "", Vector2.zero, true, gameObject, true, () => {
                MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanelRobloxGuide);
            });
        }
        WhoUntold.onClick.AddListener(() =>
        {
            
            GetComponent<Collider2D>().enabled = false;
            
            if (ContendRow["type"] == "Gold")
            {
                //Destroy(getButton.gameObject);
                MusicMgr.GetInstance().PlayEffect(MusicType.SceneMusic.Sound_HomeGold);
                List<int> FishGoldList = new List<int>(SaveDataManager.GetIntArray(CConfig.sv_FishHaveGoldArray));
                Dire.instance.OwnLord(FishGoldList[0]);
                FishGoldList.RemoveAt(0);
                SaveDataManager.SetIntArray(CConfig.sv_FishHaveGoldArray, FishGoldList.ToArray());
                Destroy(WhoUntold.gameObject);
            }
            else if (ContendRow["type"] == "Cash")
            {
                //Destroy(getButton.gameObject);
                MusicMgr.GetInstance().PlayEffect(MusicType.SceneMusic.Sound_HomeGold);
                List<float> FishCashList = new List<float>(SaveDataManager.GetFloatArray(CConfig.sv_FishHaveCashArray));
                Dire.instance.OwnCook(FishCashList[0]);
                FishCashList.RemoveAt(0);
                SaveDataManager.SetFloatArray(CConfig.sv_FishHaveCashArray, FishCashList.ToArray());
                Destroy(WhoUntold.gameObject);
            }
            else if (ContendRow["type"] == "Puzzle")
            {
                int havePuzzle = SaveDataManager.GetInt(CConfig.sv_PuzzleHaveCount);
                havePuzzle--;
                SaveDataManager.SetInt(CConfig.sv_PuzzleHaveCount, havePuzzle);
                int rewardPuzzle = SaveDataManager.GetInt(CConfig.sv_PuzzleRewardCount);
                rewardPuzzle--;
                SaveDataManager.SetInt(CConfig.sv_PuzzleRewardCount, rewardPuzzle);
                UIManager.GetInstance().ShowUIForms(nameof(ForestFalconRider));
            }
            else
            {
                int ShellRewardCount = SaveDataManager.GetInt(CConfig.sv_ShellRewardCount);
                ShellRewardCount--;
                SaveDataManager.SetInt(CConfig.sv_ShellRewardCount, ShellRewardCount);
                int ShellHaveCount = SaveDataManager.GetInt(CConfig.sv_ShellHaveCount);
                ShellHaveCount--;
                SaveDataManager.SetInt(CConfig.sv_ShellHaveCount, ShellHaveCount);
                if (SaveDataManager.GetBool(CConfig.sv_NewUserStep + "1-3"))
                {
                    UIManager.GetInstance().ShowUIForms("FishShellPanel");
                    WhoUntold.onClick.RemoveAllListeners();
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    SaveDataManager.SetBool(CConfig.sv_NewUserStep + "1-3", true);
                }
            }
            MessageData Halt= new MessageData();
            Halt.valueString = ContendRow["type"];
            Halt.valueGameObject = gameObject;
            MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanelGetFishReward, Halt);
            WhoUntold.onClick.RemoveAllListeners();
            Destroy(gameObject);
        });
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Wall"))
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 0.1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<SpurSack>().CharacterLend.Contains(gameObject))
        {
            Vector2 v2 = transform.position - collision.transform.position;
            GetComponent<Rigidbody2D>().velocity = v2.normalized;
            GetComponent<Rigidbody2D>().drag = 0.5f;
            collision.gameObject.GetComponent<SpurSack>().CharacterLocust(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().drag > 0 && GetComponent<Rigidbody2D>().velocity.magnitude < 0.1f)
        {
            GetComponent<Rigidbody2D>().drag = 0;
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 0.1f;
        }
    }
}
