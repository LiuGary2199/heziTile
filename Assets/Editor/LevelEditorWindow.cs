using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using LitJson;
using System.IO;
using System.Text.RegularExpressions;
using System;

public class LevelEditorWindow : EditorWindow
{
    [MenuItem("Tools/编辑窗口")]//这个是将内容添加到tools里面
    public static void OpenLevelEditorWindow()
    {
        EditorWindow.GetWindow(typeof(LevelEditorWindow), false);
    }
    [MenuItem("Tools/清除数据")]//这个是将内容添加到tools里面
    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }


    [SerializeField]
    protected List<LevelEditMessage> messageList = new List<LevelEditMessage>();
   



    static string fileName = "0";
    static int new_layer_x = 0;
    static int new_layer_y = 0;
    static string fullCount = "";
    static int figureNum;
    static string checkLayer = "0";
    static string checkCount = "0";
    //static string checkImage = "0";
    [SerializeField]
    protected List<LimitItem> limitList = new List<LimitItem>();
    //序列化对象
    protected SerializedObject _serializedObject;

    //序列化属性
    protected SerializedProperty _assetLstProperty;

    protected void OnEnable()
    {
        //使用当前类初始化
        _serializedObject = new SerializedObject(this);
        //获取当前类中可序列话的属性
        _assetLstProperty = _serializedObject.FindProperty("limitList");
    }

    void OnGUI()
    {

        GUILayout.BeginHorizontal();
        fileName = EditorGUILayout.TextField("关卡编号", fileName, GUILayout.MaxWidth(500));
        if (GUILayout.Button("查找"))
        {
            string levelEditFilepath = Application.streamingAssetsPath + "/LevelEditJson/Level_Edit_" + fileName + ".json";
            levelEditFilepath = levelEditFilepath.Replace("StreamingAssets", "Resources");
            FileInfo levelEditFileInfo = new FileInfo(levelEditFilepath);
            if (levelEditFileInfo.Exists)
            {
                StreamReader reader = new StreamReader(levelEditFilepath);
                limitList = JsonMapper.ToObject<Dictionary<string, List<LimitItem>>>(reader.ReadToEnd())["target"];
                ExtolLeaveModel.OakDatebase().LintelLeave(limitList);
                ExtolLeaveModel.OakDatebase().DungExtolFast(fileName);
            }



            string levelFilepath = Application.streamingAssetsPath + "/LevelJson/Level_" + fileName + ".json";
            levelFilepath = levelFilepath.Replace("StreamingAssets", "Resources");
            FileInfo levelFileInfo = new FileInfo(levelFilepath);
            if (levelFileInfo.Exists)
            {
                StreamReader reader = new StreamReader(levelFilepath);
                string jsonString = reader.ReadToEnd();
                LevelReadJsonData jsonData = JsonMapper.ToObject<LevelReadJsonData>(jsonString);
                figureNum = int.Parse(jsonData.SovietRed);
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(10);
        figureNum = EditorGUILayout.IntField("图案数量", figureNum, GUILayout.MaxWidth(500));
        GUILayout.Space(10);
        _serializedObject.Update();
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(_assetLstProperty, true);
        if (EditorGUI.EndChangeCheck())
        {
            _serializedObject.ApplyModifiedProperties();
        }
        GUILayout.Space(30);
        if (GUILayout.Button("增加8*8"))
        {
            LimitItem item = new LimitItem();
            item.x = 8;
            item.y = 8;
            limitList.Add(item);
            ExtolLeaveModel.OakDatebase().OwnLeave(item);
        }
        if (GUILayout.Button("增加7*9"))
        {
            LimitItem item = new LimitItem();
            item.x = 7;
            item.y = 9;
            limitList.Add(item);
            ExtolLeaveModel.OakDatebase().OwnLeave(item);
        }
        if (GUILayout.Button("增加8*9"))
        {
            LimitItem item = new LimitItem();
            item.x = 8;
            item.y = 9;
            limitList.Add(item);
            ExtolLeaveModel.OakDatebase().OwnLeave(item);
        }
        if (GUILayout.Button("增加7*8"))
        {
            LimitItem item = new LimitItem();
            item.x = 7;
            item.y = 8;
            limitList.Add(item);
            ExtolLeaveModel.OakDatebase().OwnLeave(item);
        }
        GUILayout.Label("增删层级");
        new_layer_x = EditorGUILayout.IntField("X", new_layer_x);
        new_layer_y = EditorGUILayout.IntField("Y", new_layer_y);
        if (GUILayout.Button("增加一层"))
        {
            LimitItem item = new LimitItem();
            item.x = new_layer_x;
            item.y = new_layer_y;
            limitList.Add(item);
            ExtolLeaveModel.OakDatebase().OwnLeave(item);
        }
        if (GUILayout.Button("删除最后一层"))
        {
            limitList.RemoveAt(limitList.Count - 1);
            ExtolLeaveModel.OakDatebase().ClutchLeave();
        }
        GUILayout.Space(50);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("重置&生成编辑地图"))
        {
            if (ExtolLeaveModel.OakDatebase().transform.childCount == 0)
            {
                ExtolLeaveModel.OakDatebase().LintelLeave(limitList);
            }
            else
            {
                if (EditorUtility.DisplayDialog("提示", "重新生成编辑地图可能会丢失当前编辑记录", "确认", "取消"))
                {
                    for (int i = 0; i < limitList.Count; i++)
                    {
                        limitList[i].FictionFifth = false;
                    }
                    ExtolLeaveModel.OakDatebase().LintelLeave(limitList);
                }
            }
        }
        if (GUILayout.Button("保存Json"))
        {
            ExtolLeaveModel.OakDatebase().ExtractShinGrass();
            if (ExtolLeaveModel.OakDatebase().SongGrass % 3 != 0)
            {
                EditorUtility.DisplayDialog("存储失败", "方块数量不是3的倍数", "确认");
            }
            else
            {
                string levelFilepath = Application.streamingAssetsPath + "/LevelJson/Level_" + fileName + ".json";
                levelFilepath = levelFilepath.Replace("StreamingAssets", "Resources");
                FileInfo levelFileInfo = new FileInfo(levelFilepath);
                if (!levelFileInfo.Exists)
                {
                    ExtolLeaveModel.OakDatebase().SakeExtolFast(fileName, figureNum.ToString());
                }
                else
                {
                    if (EditorUtility.DisplayDialog("提示", "当前关卡文件已存在,确认要覆盖本地文件吗!?!?!?", "确认", "取消"))
                    {
                        ExtolLeaveModel.OakDatebase().SakeExtolFast(fileName, figureNum.ToString());
                    }
                }

            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);
        if (ExtolLeaveModel.OakDatebase())
        {
            fullCount = "当前激活方块数:" + ExtolLeaveModel.OakDatebase().SongGrass + "\n余数:" + ExtolLeaveModel.OakDatebase().SongGrass % 3;
            GUILayout.Label(fullCount);
        }
        ExtolLeaveModel.OakDatebase().SpringFifthBiter(limitList);


        GUILayout.Space(20);
        if (GUILayout.Button("删除高难度关卡"))
        {
            removeLevel();
        }
        checkLayer = EditorGUILayout.TextField("CheckLayer", checkLayer, GUILayout.MaxWidth(500));
        checkCount = EditorGUILayout.TextField("CheckCount", checkCount, GUILayout.MaxWidth(500));
        //checkImage = EditorGUILayout.TextField("CheckImage", checkImage, GUILayout.MaxWidth(500));
        if (GUILayout.Button("检索大于块数层数的关卡"))
        {
            checkLevelWithLayerAndCount();
        }
        if (GUILayout.Button("修改图片数量"))
        {
            ChangeLevelImageCount();
        }
    }
//    public void saveLevelJson(string fileName, string figureNum)
//    {
//        string levelFilepath = Application.streamingAssetsPath + "/LevelJson/Level_" + fileName + ".json";
//        string levelFileResourcesPath = levelFilepath.Replace("StreamingAssets", "Resources");
//        Debug.Log(levelFilepath);

//        FileInfo levelFileResourcesInfo = new FileInfo(levelFileResourcesPath);

//        if (!levelFileResourcesInfo.Exists)
//        {
//            levelFileResourcesInfo.Create().Dispose();
//            levelFileResourcesInfo.Refresh();

//        }
//        string levelJsonData = JsonUtility.ToJson(new LevelJsonData(levelDataList, figureNum));
//        string levelEditJsonData = SerializeList.ListToJson<LimitItem>(levelEditDataList);
//        //Debug.Log(levelJsonData);
//        //Debug.Log(levelEditJsonData);
//        //写入内容
//        //StreamWriter levelWrite = new StreamWriter(levelFilepath);
//        //levelWrite.WriteLine(levelJsonData);
//        //levelWrite.Dispose();
//        //levelWrite.Close();
//        StreamWriter levelEditWrite = new StreamWriter(levelEditFilepath);
//        levelEditWrite.WriteLine(levelEditJsonData);
//        levelEditWrite.Dispose();
//        levelEditWrite.Close();
//        StreamWriter levelResourceWrite = new StreamWriter(levelFileResourcesPath);
//        levelResourceWrite.WriteLine(levelJsonData);
//        levelResourceWrite.Dispose();
//        levelResourceWrite.Close();
//#if UNITY_EDITOR
//        //刷新文件列表
//        AssetDatabase.Refresh();
//#endif 
//    }
    
public void ChangeLevelImageCount()
{
    // 返回当前按下目录下的文件列表  
    string levelFilepath = Application.streamingAssetsPath + "/LevelJson";
    levelFilepath = levelFilepath.Replace("StreamingAssets", "Resources");

    string levelEditFilepath = Application.streamingAssetsPath + "/LevelEditJson";
    levelEditFilepath = levelEditFilepath.Replace("StreamingAssets", "Resources");
    DirectoryInfo levelEditInfo = new DirectoryInfo(levelEditFilepath);
    var levelEditFiles = levelEditInfo.GetFiles();
        //int i = 0;
        for (int i = 0; i < levelEditFiles.Length / 2; i++)
        {
            FileInfo levelFileResourcesInfo = new FileInfo(levelFilepath + "/Level_" + (i + 1) + ".json");

            if (!levelFileResourcesInfo.Exists)
            {
                levelFileResourcesInfo.Create().Dispose();
                levelFileResourcesInfo.Refresh();

            }
            StreamReader readerLevel = new StreamReader(levelFilepath + "/Level_" + (i + 1) + ".json");
            string levelJson = readerLevel.ReadToEnd();
            readerLevel.Dispose();
            readerLevel.Close();
            LevelReadJsonData jsonData = JsonMapper.ToObject<LevelReadJsonData>(levelJson);
            int figureNum = int.Parse(jsonData.SovietRed);
            if (figureNum > 5 && figureNum <= 9)
            {
                figureNum -= 1;
            }
            if (figureNum >= 10)
            {
                figureNum -= 2;
            }
            string levelJsonData = JsonUtility.ToJson(new LevelJsonData(jsonData.Charge, figureNum.ToString()));
            StreamWriter levelResourceWrite = new StreamWriter(levelFilepath + "/Level_" + (i + 1) + ".json");
            levelResourceWrite.WriteLine(levelJsonData);
            levelResourceWrite.Dispose();
            levelResourceWrite.Close();

        }
#if UNITY_EDITOR
        //刷新文件列表
        AssetDatabase.Refresh();
#endif 
}
    public void checkLevelWithLayerAndCount()
    {
        // 返回当前按下目录下的文件列表  
        string levelFilepath = Application.streamingAssetsPath + "/LevelJson";
        levelFilepath = levelFilepath.Replace("StreamingAssets", "Resources");
        string levelEditFilepath = Application.streamingAssetsPath + "/LevelEditJson";
        levelEditFilepath = levelEditFilepath.Replace("StreamingAssets", "Resources");
        DirectoryInfo levelEditInfo = new DirectoryInfo(levelEditFilepath);
        var levelEditFiles = levelEditInfo.GetFiles();
        string levelString = "符合条件关卡:";
        int levelCount = 0;
        for (int i = 0; i < levelEditFiles.Length/2; i ++)
        {
            StreamReader readerLevel = new StreamReader(levelFilepath+"/Level_"+(i+1)+".json");
            string levelJson = readerLevel.ReadToEnd();
            LevelReadJsonData jsonData = JsonMapper.ToObject<LevelReadJsonData>(levelJson);
            StreamReader readerLevelEdit = new StreamReader(levelEditFilepath + "/Level_Edit_" + (i+1)+".json");
            List<LimitItem> limitList = JsonMapper.ToObject<Dictionary<string, List<LimitItem>>>(readerLevelEdit.ReadToEnd())["target"];
            if (limitList.Count >= int.Parse(checkLayer) && jsonData.Charge.Count >= int.Parse(checkCount))
            {
                levelString += "\n" + (1 + i);
                levelCount++;
            }
        }
        levelString += "\n" + "符合总数:" + levelCount;
        Debug.Log(levelString);
    }
    public void removeLevel()
    {
        string levelRemoveFilepath = Application.streamingAssetsPath + "/TFLevelRemove" + ".json";
        FileInfo levelRemoveFileInfo = new FileInfo(levelRemoveFilepath);
        if (levelRemoveFileInfo.Exists)
        {
            StreamReader reader = new StreamReader(levelRemoveFilepath);
            string jsonString = reader.ReadToEnd();
            LevelRemoveData removeData = JsonMapper.ToObject<LevelRemoveData>(jsonString);
            List<LevelRemoveItem> resetItemList = new List<LevelRemoveItem>();
            List<LevelRemoveItem> allItemList = new List<LevelRemoveItem>();
            for (int i = 0; i < 1293;i++ )
            {
                LevelRemoveItem item = new LevelRemoveItem();
                item.ExtolRed = i + 1;
                item.Cuban = 1;
                allItemList.Add(item);
                resetItemList.Add(item);
            }
            foreach (LevelRemoveItem item in removeData.Clutch_Seem)
            {
                foreach(LevelRemoveItem item2 in allItemList)
                {
                    if (item2.ExtolRed == item.ExtolRed)
                    {
                        resetItemList.Remove(item2);
                    }
                }
            }
            string levelFilepath = Application.streamingAssetsPath + "/LevelJson";
            levelFilepath = levelFilepath.Replace("StreamingAssets", "Resources");
            string levelEditFilepath = Application.streamingAssetsPath + "/LevelEditJson";
            levelEditFilepath = levelEditFilepath.Replace("StreamingAssets", "Resources");
            //foreach (LevelRemoveItem item in removeData.remove_list)
            //{
            //    FileDelete(levelFilepath, "Level_" + item.LevelNum + ".json");
            //    FileDelete(levelEditFilepath, "Level_Edit_" + item.LevelNum + ".json");
            //}
            for (int i = 0; i < resetItemList.Count; i++)
            {
                LevelRemoveItem item = resetItemList[i];
                string oldLevelFilepath = levelFilepath + "/Level_" + item.ExtolRed +".json";
                string newLevelFilepath = levelFilepath + "/Level_" + (i+1) +".json";
                string oldLevelEditFilepath = levelEditFilepath + "/Level_Edit_" + item.ExtolRed + ".json";
                string newLevelEditFilepath = levelEditFilepath + "/Level_Edit_" + (i + 1) + ".json";
                SetFilesName(oldLevelFilepath, newLevelFilepath);
                SetFilesName(oldLevelEditFilepath, newLevelEditFilepath);
            }
        }
    }
    public static void SetFilesName(string path, string newPath)
    {
        Debug.Log(path);
        Debug.Log(newPath);
#if UNITY_EDITOR

        FileInfo f = new FileInfo(path);
        if (!f.Exists)
        {
            Debug.Log("目录不存在: " + path);
            return;
        }
        if (f.Extension == ".meta")
        {
            f.Delete();
        }
        else
        {
            f.MoveTo(newPath);
        }
#endif        
    }
    /// <summary>
    /// 删除指定路径下的指定文件
    /// </summary>
    /// <param name="fullPath">路径</param>
    /// <param name="fileName">文件名称</param>
    /// <returns></returns>
    public bool FileDelete(string fullPath, string fileName)
    {
        //获取指定路径下面的所有资源文件  然后进行删除
        if (Directory.Exists(fullPath))
        {
            DirectoryInfo direction = new DirectoryInfo(fullPath);
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.EndsWith(".meta"))
                {
                    continue;
                }
                string FilePath = fullPath + "/" + files[i].Name;
                // Debug.Log(files[i].Name);
                if (files[i].Name == fileName)//如果不指定文件名称将删除这个文件夹下的所有文件
                    File.Delete(FilePath);
            }
            return true;
        }
        return false;
    }

    private void OnInspectorUpdate()
    {
        Repaint();
    }
//    public void ChangeLevelJson()
//    {
//        messageList = new List<LevelEditMessage>();
//        for (int i = 0; i <= 1750; i++)
//        {
//            string levelFilepath = Application.streamingAssetsPath + "/TMLevel/" + i + ".json";
//            FileInfo levelFileInfo = new FileInfo(levelFilepath);
//            if (levelFileInfo.Exists)
//            {
//                StreamReader reader = new StreamReader(levelFilepath);
//                string jsonString = reader.ReadToEnd();
//                TmJsonData jsonData = JsonMapper.ToObject<TmJsonData>(jsonString);



//                string WritelevelFilepath = Application.streamingAssetsPath + "/LevelJson/Level_" + i + ".json";
//                string levelEditFilepath = Application.streamingAssetsPath + "/LevelEditJson/Level_Edit_" + i + ".json";
//                string levelFileResourcesPath = WritelevelFilepath.Replace("StreamingAssets", "Resources");
//                //Debug.Log(levelFilepath);
//                FileInfo WritelevelFileInfo = new FileInfo(WritelevelFilepath);

//                if (!levelFileInfo.Exists)
//                {
//                    levelFileInfo.Create().Close();
//                    levelFileInfo.Refresh();
//                }
//                FileInfo levelEditFileInfo = new FileInfo(levelEditFilepath);

//                if (!levelEditFileInfo.Exists)
//                {

//                    levelEditFileInfo.Create().Close();
//                    levelEditFileInfo.Refresh();
//                }
//                FileInfo levelFileResourcesInfo = new FileInfo(levelFileResourcesPath);

//                if (!levelFileResourcesInfo.Exists)
//                {
//                    levelFileResourcesInfo.Create().Close();
//                    levelFileResourcesInfo.Refresh();
//                }
//                List<LimitItem> levelEditDataList = new List<LimitItem>();
//                List<LevelData> levelDataList = new List<LevelData>();
//                List<int> layerList = new List<int>();
//                foreach (TmLevelJsonData levelLayerData in jsonData.l)
//                {
//                    int layer = levelLayerData.p[2];
//                    if (layerList.Count == 0)
//                    {
//                        layerList.Add(layer);
//                    }
//                    else
//                    {
//                        bool isInsert = false;
//                        for (int j = 0; j < layerList.Count; j++)
//                        {
//                            if (layerList[j] < layer)
//                            {
//                                isInsert = true;
//                                layerList.Insert(j, layer);
//                                break;
//                            }
//                        }
//                        if (!isInsert)
//                        {
//                            layerList.Add(layer);
//                        }
//                    }
//                }
//                //foreach (int layer in layerList)
//                //{
//                //    Debug.Log("layer:" + layer);
//                //}
//                foreach (TmLevelJsonData levelLayerData in jsonData.l)
//                {
//                    if (levelLayerData.t.Count > 0)
//                    {
//                        LimitItem limitItem = new LimitItem();
//                        int layer = layerList.IndexOf(levelLayerData.p[2]);
//                        int offset_x = levelLayerData.p[0];
//                        int offset_y = levelLayerData.p[1];
//                        int tm_x = offset_x + levelLayerData.t[0][0];
//                        int tm_y = offset_y + levelLayerData.t[0][1];
//                        limitItem.x = tm_x % 100 == 0 ? 11 : 10;
//                        limitItem.y = tm_y % 100 == 0 ? 11 : 10;
//                        limitItem.disableEmpty = true;
//                        levelEditDataList.Add(limitItem);
//                        foreach (List<int> list in levelLayerData.t)
//                        {
//                            LevelData data = new LevelData();
//                            tm_x = offset_x + list[0];
//                            tm_y = offset_y + list[1];
//                            int x = (tm_x + (tm_x % 100 == 0 ? 500 : 450)) / 100;
//                            int y = (tm_y + (tm_y % 100 == 0 ? 500 : 450)) / 100;
//                            int px = (tm_x + 500) / 50;
//                            int py = (tm_y + 500) / 50;
//                            data.layer = layer.ToString();
//                            data.x = x.ToString();
//                            data.y = y.ToString();
//                            data.px = px.ToString();
//                            data.py = py.ToString();
//                            levelDataList.Add(data);
//                        }
//                    }
//                }
//                //Debug.Log("关卡号:" + i + "\n" + "层数:" + levelEditDataList.Count + "   " + "块数:" + levelDataList.Count);
//                LevelEditMessage message = new LevelEditMessage(i, levelEditDataList.Count, levelDataList.Count);
//                messageList.Add(message);

//                string levelJsonData = JsonUtility.ToJson(new LevelJsonData(levelDataList, (levelDataList.Count / 3 < 12 ? levelDataList.Count / 3 : 12).ToString()));
//                string levelEditJsonData = SerializeList.ListToJson<LimitItem>(levelEditDataList);
//                //Debug.Log(levelJsonData);
//                //Debug.Log(levelEditJsonData);
//                //写入内容
//                StreamWriter levelWrite = new StreamWriter(WritelevelFilepath);
//                levelWrite.WriteLine(levelJsonData);
//                levelWrite.Dispose();
//                levelWrite.Close();
//                StreamWriter levelEditWrite = new StreamWriter(levelEditFilepath);
//                levelEditWrite.WriteLine(levelEditJsonData);
//                levelEditWrite.Dispose();
//                levelEditWrite.Close();
//                StreamWriter levelResourceWrite = new StreamWriter(levelFileResourcesPath);
//                levelResourceWrite.WriteLine(levelJsonData);
//                levelResourceWrite.Dispose();
//                levelResourceWrite.Close();

//            }
//        }
//        string editMessage = SerializeList.ListToJson<LevelEditMessage>(messageList);
//        Debug.Log(editMessage);

//        string messageFilepath = Application.streamingAssetsPath + "/message.json";
//        //Debug.Log(levelFilepath);        
//        FileInfo MessagelevelFileInfo = new FileInfo(messageFilepath);

//        if (!MessagelevelFileInfo.Exists)
//        {

//            MessagelevelFileInfo.Create().Dispose();
//            MessagelevelFileInfo.Refresh();
//        }
//        StreamWriter MessageWrite = new StreamWriter(messageFilepath);
//        MessageWrite.WriteLine(editMessage);
//        MessageWrite.Dispose();
//        MessageWrite.Close();
//#if UNITY_EDITOR
//        //刷新文件列表
//        AssetDatabase.Refresh();
//#endif
//    }
}
public class TmJsonData
{
    public List<int> p;
    public List<TmLevelJsonData> l;
}
public class TmLevelJsonData
{
    public List<int> p;
    public List<List<int>> t;
}