using UnityEditor;
using UnityEngine;

public class EditorWindowTest : EditorWindow
{

    private static int start_image_num = 1;    //图片编号 - 起始
    private static int end_image_num = 1;     //图片编号 - 结束

    [MenuItem("Tools/批量粗处理关卡预制体")]
    private static void Open_Window()
    {
        EditorWindowTest myWindow = (EditorWindowTest)EditorWindow.GetWindow(typeof(EditorWindowTest), true, "批量粗处理关卡预制体", true);
        myWindow.position = new Rect(700f, 300f, 300f, 300f);
        myWindow.Show();
        


    }
    private void OnGUI()
    {
        start_image_num = EditorGUILayout.IntField("图片起始编号：", start_image_num);
        end_image_num = EditorGUILayout.IntField("图片结束编号：", end_image_num);
        if (GUILayout.Button("只更换材质"))
        {
            Debug.Log("编号从 " + start_image_num + " 到 " + end_image_num);
            Level_Material_Change();
        }
        if (GUILayout.Button("只更换图片"))
        {
            Debug.Log("编号从 " + start_image_num + " 到 " + end_image_num);
            Level_Sprite_Change();
        }
        if (GUILayout.Button("只刷新碰撞区域"))
        {
            Debug.Log("编号从 " + start_image_num + " 到 " + end_image_num);
            Level_Clldr_Refresh();
        }

        if (GUILayout.Button("粗处理开始"))
        {
            Debug.Log("编号从 "+ start_image_num + " 到 " + end_image_num);
            Level_Bulk_Processing();
        }

    }


    private static void Level_Material_Change()
    {
        Debug.Log("粗处理开始");
        for (int i = start_image_num; i < end_image_num + 1; i++)
        {
            //更换图片
            string pfb_dir = "Assets/Resources/Level";
            string pfb_path = pfb_dir + "/Level_" + (i + 1000).ToString() + ".prefab";
            var pfb = AssetDatabase.LoadAssetAtPath<GameObject>(pfb_path);
            string mat_path = "Assets/Art/Materials/Mat_Flash.mat";
            pfb.GetComponent<SpriteRenderer>().material = AssetDatabase.LoadAssetAtPath<Material>(mat_path);
        }
        AssetDatabase.SaveAssets();
        Debug.Log("粗处理结束");
    }

    private static void Level_Clldr_Refresh()
    {
        Debug.Log("粗处理开始");
        for (int i = start_image_num; i < end_image_num + 1; i++)
        {
            string pfb_dir = "Assets/Resources/Level";
            string pfb_path = pfb_dir + "/Level_" + (i + 1000).ToString() + ".prefab";
            var pfb = AssetDatabase.LoadAssetAtPath<GameObject>(pfb_path);

            //刷新碰撞区域
            var clldr = pfb.GetComponent<PolygonCollider2D>();
            GameObject.DestroyImmediate(clldr, true);
            pfb.AddComponent<PolygonCollider2D>();
        }
        AssetDatabase.SaveAssets();
        Debug.Log("粗处理结束");
    }

    private static void Level_Sprite_Change()
    {
        Debug.Log("粗处理开始");
        for (int i = start_image_num; i < end_image_num + 1; i++)
        {
            //更换图片
            string pfb_dir = "Assets/Resources/Level";
            string pfb_path = pfb_dir + "/Level_" + (i + 1000).ToString() + ".prefab";
            var pfb = AssetDatabase.LoadAssetAtPath<GameObject>(pfb_path);
            string img_path = "ART/GameImage/LevelImage-" + i.ToString();
            pfb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img_path);
        }
        AssetDatabase.SaveAssets();
        Debug.Log("粗处理结束");
    }

    private static void Level_Bulk_Processing()
    {
        Debug.Log("粗处理开始");
        for (int i = start_image_num; i < end_image_num + 1; i++)
        {
            //更换图片
            string pfb_dir = "Assets/Resources/Level";
            string pfb_path = pfb_dir + "/Level_"+ (i + 1000).ToString() +".prefab";
            var pfb = AssetDatabase.LoadAssetAtPath<GameObject>(pfb_path);
            string img_path = "ART/GameImage/LevelImage-" + i.ToString();
            pfb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(img_path);

            //刷新碰撞区域
            var clldr = pfb.GetComponent<PolygonCollider2D>();
            GameObject.DestroyImmediate(clldr, true);
            pfb.AddComponent<PolygonCollider2D>();
        }
        AssetDatabase.SaveAssets();
        Debug.Log("粗处理结束");
    }
}

