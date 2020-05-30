using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using PureGame.Tools;

public class SettingPanel : MonoBehaviour
{
    public string lastKey = "";             //存储修改前的按键
    public Text curEditKeyText;     //当前正在修改的键
    public bool isEditing = false;          //是否处于修改状态
    public Dictionary<string, Text> keyText = new Dictionary<string, Text>();
    public Dictionary<string, Button> setButton = new Dictionary<string, Button>();

    void Awake() {
        Transform settingContent = transform.Find("Scroll View/Viewport/Content");
        foreach (Transform t in settingContent) {
            if (t.GetComponent<Button>() != null) {
                setButton.Add(t.name, t.GetComponent<Button>());
                keyText.Add(t.name, settingContent.Find(t.name + "Key").GetComponent<Text>());
                t.GetComponent<Button>().onClick.AddListener(OnSetClick);
            }
        }
        transform.Find("DefaultButton").GetComponent<Button>().onClick.AddListener(RecoveryDefaultKey);
        transform.Find("ReplyButton").GetComponent<Button>().onClick.AddListener(ReplyEditedKey);
        transform.Find("CancelButton").GetComponent<Button>().onClick.AddListener(CancelEditedKey);
    }

    void LateUpdate() {
        if (isEditing) {
            ReadKeyDown();
        }
    }

    void OnSetClick() {
        curEditKeyText = PureDictTool.GetValue<string, Text>(keyText, EventSystem.current.currentSelectedGameObject.name);
        lastKey = curEditKeyText.text;
        curEditKeyText.text = "";
        Cursor.visible = false;
        isEditing = true;
    }
    //恢复默认按键
    void RecoveryDefaultKey()
    {
        TextAsset keyFile = (TextAsset)Resources.Load("Text/DefaultKey");
        string keyInfo = keyFile.text;
        File.WriteAllText(Application.streamingAssetsPath + "/CustomerKeys.txt", keyInfo, Encoding.UTF8);
        string[] eachKey = File.ReadAllText(Application.streamingAssetsPath + "/CustomerKeys.txt", Encoding.UTF8).Split('\n');
        foreach (string a in eachKey)
        {
            string[] temp = a.Split(',');
            Text t = PureDictTool.GetValue<string, Text>(keyText, temp[0]);
            t.text = temp[1];
        }
        CustomerKeys.UpdateKeys();
    }
    //应用键位函数
    void ReplyEditedKey()
    {
        string keyInfo = "";
        foreach (string a in keyText.Keys)
        {
            keyInfo += (a + ",");
            Text t = PureDictTool.GetValue<string, Text>(keyText, a);
            if (t.text == "")
            {
                keyInfo += "U/N\n";
            }
            else {
                keyInfo += t.text + '\n';
            }
        }
        File.WriteAllText(Application.streamingAssetsPath + "/CustomerKeys.txt", keyInfo, Encoding.UTF8);
        CustomerKeys.UpdateKeys();
    }
    //取消修改键位函数
    void CancelEditedKey()
    {
        string keyInfo = File.ReadAllText(Application.streamingAssetsPath + "/CustomerKeys.txt", Encoding.UTF8);
        string[] eachKey = keyInfo.Split('\n');
        foreach (string a in eachKey)
        {
            string[] temp = a.Split(',');
            Text t = PureDictTool.GetValue<string, Text>(keyText, temp[0]);
            if (temp[1] == "U/N")
            {
                t.text = "";
            }
            else
            {
                t.text = temp[1];
            }
        }
        PanelManager.Instance.settingPanel.gameObject.SetActive(false);        //关闭面板
        PanelManager.Instance.startPanel.gameObject.SetActive(true);
    }
    //设置该键位，并清空与该键位冲突的键位
    void SetKey(string keyVal)
    {
        //清除冲突按键
        foreach (Text a in keyText.Values)
        {
            if (a.text.Trim() == keyVal)
            {
                a.text = "";
            }
        }
        curEditKeyText.text = keyVal;       //赋值新按键
        isEditing = false;
        Cursor.visible = true;      //显示鼠标
        lastKey = "";
        curEditKeyText = null;
    }
    //读取按键
    void ReadKeyDown()
    {
        //字母键
        if (Input.GetKeyUp(KeyCode.Q)) { SetKey("Q"); return; }
        if (Input.GetKeyUp(KeyCode.W)) { SetKey("W"); return; }
        if (Input.GetKeyUp(KeyCode.E)) { SetKey("E"); return; }
        if (Input.GetKeyUp(KeyCode.R)) { SetKey("R"); return; }
        if (Input.GetKeyUp(KeyCode.T)) { SetKey("T"); return; }
        if (Input.GetKeyUp(KeyCode.Y)) { SetKey("Y"); return; }
        if (Input.GetKeyUp(KeyCode.U)) { SetKey("U"); return; }
        if (Input.GetKeyUp(KeyCode.I)) { SetKey("I"); return; }
        if (Input.GetKeyUp(KeyCode.O)) { SetKey("O"); return; }
        if (Input.GetKeyUp(KeyCode.P)) { SetKey("P"); return; }
        if (Input.GetKeyUp(KeyCode.A)) { SetKey("A"); return; }
        if (Input.GetKeyUp(KeyCode.S)) { SetKey("S"); return; }
        if (Input.GetKeyUp(KeyCode.D)) { SetKey("D"); return; }
        if (Input.GetKeyUp(KeyCode.F)) { SetKey("F"); return; }
        if (Input.GetKeyUp(KeyCode.G)) { SetKey("G"); return; }
        if (Input.GetKeyUp(KeyCode.H)) { SetKey("H"); return; }
        if (Input.GetKeyUp(KeyCode.J)) { SetKey("J"); return; }
        if (Input.GetKeyUp(KeyCode.K)) { SetKey("K"); return; }
        if (Input.GetKeyUp(KeyCode.L)) { SetKey("L"); return; }
        if (Input.GetKeyUp(KeyCode.Z)) { SetKey("Z"); return; }
        if (Input.GetKeyUp(KeyCode.X)) { SetKey("X"); return; }
        if (Input.GetKeyUp(KeyCode.C)) { SetKey("C"); return; }
        if (Input.GetKeyUp(KeyCode.V)) { SetKey("V"); return; }
        if (Input.GetKeyUp(KeyCode.B)) { SetKey("B"); return; }
        if (Input.GetKeyUp(KeyCode.N)) { SetKey("N"); return; }
        if (Input.GetKeyUp(KeyCode.M)) { SetKey("M"); return; }
        //函数键
        if (Input.GetKeyUp(KeyCode.F1)) { SetKey("F1"); return; }
        if (Input.GetKeyUp(KeyCode.F2)) { SetKey("F2"); return; }
        if (Input.GetKeyUp(KeyCode.F3)) { SetKey("F3"); return; }
        if (Input.GetKeyUp(KeyCode.F4)) { SetKey("F4"); return; }
        if (Input.GetKeyUp(KeyCode.F5)) { SetKey("F5"); return; }
        if (Input.GetKeyUp(KeyCode.F6)) { SetKey("F6"); return; }
        if (Input.GetKeyUp(KeyCode.F7)) { SetKey("F7"); return; }
        if (Input.GetKeyUp(KeyCode.F8)) { SetKey("F8"); return; }
        if (Input.GetKeyUp(KeyCode.F9)) { SetKey("F9"); return; }
        if (Input.GetKeyUp(KeyCode.F10)) { SetKey("F10"); return; }
        if (Input.GetKeyUp(KeyCode.F11)) { SetKey("F11"); return; }
        if (Input.GetKeyUp(KeyCode.F12)) { SetKey("F12"); return; }
        //数字键
        if (Input.GetKeyUp(KeyCode.Alpha0)) { SetKey("0"); return; }
        if (Input.GetKeyUp(KeyCode.Alpha1)) { SetKey("1"); return; }
        if (Input.GetKeyUp(KeyCode.Alpha2)) { SetKey("2"); return; }
        if (Input.GetKeyUp(KeyCode.Alpha3)) { SetKey("3"); return; }
        if (Input.GetKeyUp(KeyCode.Alpha4)) { SetKey("4"); return; }
        if (Input.GetKeyUp(KeyCode.Alpha5)) { SetKey("5"); return; }
        if (Input.GetKeyUp(KeyCode.Alpha6)) { SetKey("6"); return; }
        if (Input.GetKeyUp(KeyCode.Alpha7)) { SetKey("7"); return; }
        if (Input.GetKeyUp(KeyCode.Alpha8)) { SetKey("8"); return; }
        if (Input.GetKeyUp(KeyCode.Alpha9)) { SetKey("9"); return; }
        //各种功能键
        if (Input.GetKeyUp(KeyCode.Tab)) { SetKey("TAB"); return; }
        if (Input.GetKeyUp(KeyCode.CapsLock)) { SetKey("CAPSLOCK"); return; }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { SetKey("LSHIFT"); return; }
        if (Input.GetKeyUp(KeyCode.RightShift)) { SetKey("RSHIFT"); return; }
        if (Input.GetKeyUp(KeyCode.RightControl)) { SetKey("RCTRL"); return; }
        if (Input.GetKeyUp(KeyCode.RightAlt)) { SetKey("RALT"); return; }
        if (Input.GetKeyUp(KeyCode.LeftAlt)) { SetKey("LALT"); return; }
        if (Input.GetKeyUp(KeyCode.LeftControl)) { SetKey("LCTRL"); return; }
        //标点符号
        if (Input.GetKeyUp(KeyCode.LeftBracket)) { SetKey("["); return; }        //[
        if (Input.GetKeyUp(KeyCode.RightBracket)) { SetKey("]"); return; }       //]
        if (Input.GetKeyUp(KeyCode.Slash)) { SetKey("/"); return; }              ///
        if (Input.GetKeyUp(KeyCode.Semicolon)) { SetKey(";"); return; }      //;
        if (Input.GetKeyUp(KeyCode.Period)) { SetKey("."); return; }         //.
        if (Input.GetKeyUp(KeyCode.Minus)) { SetKey("-"); return; }      //-
        if (Input.GetKeyUp(KeyCode.Equals)) { SetKey("="); return; }     //=
        //键位设置取消
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isEditing = false;
            Cursor.visible = true;
            curEditKeyText.text = lastKey;
            lastKey = "";
            curEditKeyText = null;
            CustomerKeys.UpdateKeys();
        }
    }
}
