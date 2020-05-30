using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CustomerKeys : MonoBehaviour
{
    public static KeyCode keyForward;
    public static KeyCode keyBack;
    public static KeyCode keyLeft;
    public static KeyCode keyRight;
    public static KeyCode keyJump;
    public static KeyCode keyCrouch;
    public static KeyCode keyShoot;
    public static KeyCode keySpecial;
    public static KeyCode keyReload;
    public static KeyCode keyDrop;
    public static KeyCode keyLastWeapon;
    public static KeyCode keyMain;
    public static KeyCode keyVice;
    public static KeyCode keyKnife; 
    public static KeyCode keyThrow;
    public static KeyCode keyBomb;
    public static KeyCode keyShop;
    public static KeyCode keyScoreBar;

    void Awake()
    {
        UpdateKeys();
    }
    //更新键位
    public static void UpdateKeys() {
        string keyInfo = File.ReadAllText(Application.streamingAssetsPath + "/CustomerKeys.txt", Encoding.UTF8);
        string[] eachKey = keyInfo.Split('\n');
        foreach (string a in eachKey) {
            string[] thisKey = a.Split(',');
            switch (thisKey[0]) {
                case "Forward": keyForward = CorrectKey(thisKey[1]); break;
                case "Back": keyBack = CorrectKey(thisKey[1]); break;
                case "Left": keyLeft = CorrectKey(thisKey[1]); break;
                case "Right": keyRight = CorrectKey(thisKey[1]); break;
                case "Jump": keyJump = CorrectKey(thisKey[1]); break;
                case "Crouch": keyCrouch = CorrectKey(thisKey[1]); break;
                case "Shoot": keyShoot = CorrectKey(thisKey[1]); break;
                case "Special": keySpecial = CorrectKey(thisKey[1]); break;
                case "Reload": keyReload = CorrectKey(thisKey[1]); break;
                case "Drop": keyDrop = CorrectKey(thisKey[1]); break;
                case "LastWeapon": keyLastWeapon = CorrectKey(thisKey[1]); break;
                case "Main": keyMain = CorrectKey(thisKey[1]); break;
                case "Vice": keyVice = CorrectKey(thisKey[1]); break;
                case "Knife": keyKnife = CorrectKey(thisKey[1]); break;
                case "Throw": keyThrow = CorrectKey(thisKey[1]); break;
                case "Bomb": keyBomb = CorrectKey(thisKey[1]); break;
                case "Shop": keyShop = CorrectKey(thisKey[1]); break;
                case "ScoreBar": keyScoreBar = CorrectKey(thisKey[1]); break;
            }
        }
    }
   static KeyCode CorrectKey(string keyVal) {
        switch (keyVal) {
            case "Q": return KeyCode.Q;
            case "W": return KeyCode.W;
            case "E": return KeyCode.E;
            case "R": return KeyCode.R;
            case "T": return KeyCode.T;
            case "Y": return KeyCode.Y;
            case "U": return KeyCode.U;
            case "I": return KeyCode.I;
            case "O": return KeyCode.O;
            case "P": return KeyCode.P;
            case "A": return KeyCode.A;
            case "S": return KeyCode.S;
            case "D": return KeyCode.D;
            case "F": return KeyCode.F;
            case "G": return KeyCode.G;
            case "H": return KeyCode.H;
            case "J": return KeyCode.J;
            case "K": return KeyCode.K;
            case "L": return KeyCode.L;
            case "Z": return KeyCode.Z;
            case "X": return KeyCode.X;
            case "C": return KeyCode.C;
            case "V": return KeyCode.V;
            case "B": return KeyCode.B;
            case "N": return KeyCode.N;
            case "M": return KeyCode.M;
            case "F1": return KeyCode.F1;
            case "F2": return KeyCode.F2;
            case "F3": return KeyCode.F3;
            case "F4": return KeyCode.F4;
            case "F5": return KeyCode.F5;
            case "F6": return KeyCode.F6;
            case "F7": return KeyCode.F7;
            case "F8": return KeyCode.F8;
            case "F9": return KeyCode.F9;
            case "F10": return KeyCode.F10;
            case "F11": return KeyCode.F11;
            case "F12": return KeyCode.F12;
            case "0": return KeyCode.Alpha0;
            case "1": return KeyCode.Alpha1;
            case "2": return KeyCode.Alpha2;
            case "3": return KeyCode.Alpha3;
            case "4": return KeyCode.Alpha4;
            case "5": return KeyCode.Alpha5;
            case "6": return KeyCode.Alpha6;
            case "7": return KeyCode.Alpha7;
            case "8": return KeyCode.Alpha8;
            case "9": return KeyCode.Alpha9;
            case "TAB": return KeyCode.Tab;
            case "CAPSLOCK": return KeyCode.CapsLock;
            case "LSHIFT": return KeyCode.LeftShift;
            case "RSHIFT": return KeyCode.RightShift;
            case "RCTRL": return KeyCode.RightControl;
            case "LCTRL": return KeyCode.LeftControl;
            case "RALT": return KeyCode.RightAlt;
            case "LALT": return KeyCode.LeftAlt;
            case "[": return KeyCode.LeftBracket;
            case "]": return KeyCode.RightBracket;
            case "/": return KeyCode.Slash;
            case ";": return KeyCode.Semicolon;
            case ".": return KeyCode.Period;
            case "-": return KeyCode.Minus;
            case "=": return KeyCode.Equals;
            case "Mouse1": return KeyCode.Mouse0;
            case "Mouse2": return KeyCode.Mouse1;
            case "U/N": return KeyCode.None;
        }
        return KeyCode.None;
    }
    public static KeyCode KeyForward
    {
        get { return CustomerKeys.keyForward; }
    }
    public static KeyCode KeyBack
    {
        get { return CustomerKeys.keyBack; }
    }
    public static KeyCode KeyLeft
    {
        get { return CustomerKeys.keyLeft; }
    }
    public static KeyCode KeyRight
    {
        get { return CustomerKeys.keyRight; }
    }
    public static KeyCode KeyJump
    {
        get { return CustomerKeys.keyJump; }
    }
    public static KeyCode KeyCrouch
    {
        get { return CustomerKeys.keyCrouch; }
    }
    public static KeyCode KeyShoot
    {
        get { return CustomerKeys.keyShoot; }
    }
    public static KeyCode KeySpecial
    {
        get { return CustomerKeys.keySpecial; }
    }
    public static KeyCode KeyReload
    {
        get { return CustomerKeys.keyReload; }
    }
    public static KeyCode KeyDrop
    {
        get { return CustomerKeys.keyDrop; }
    }
    public static KeyCode KeyLastWeapon
    {
        get { return CustomerKeys.keyLastWeapon; }
    }
    public static KeyCode KeyMain
    {
        get { return CustomerKeys.keyMain; }
    }
    public static KeyCode KeyVice
    {
        get { return CustomerKeys.keyVice; }
    }
    public static KeyCode KeyKnife
    {
        get { return CustomerKeys.keyKnife; }
    }
    public static KeyCode KeyThrow
    {
        get { return CustomerKeys.keyThrow; }
    }
    public static KeyCode KeyBomb
    {
        get { return CustomerKeys.keyBomb; }
    }
    public static KeyCode KeyShop
    {
        get { return CustomerKeys.keyShop; }
    }
    public static KeyCode KeyScoreBar
    {
        get { return CustomerKeys.keyScoreBar; }
    }


}
