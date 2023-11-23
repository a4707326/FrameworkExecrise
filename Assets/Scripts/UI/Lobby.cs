using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    private Image _avatar_Img;

    private Text _name_txt;
    private Text _money_txt;

    private Button _enterGame1_Btn;
    private Button _enterGame2_Btn;
    private Button _enterGame3_Btn;


    private void Awake()
    {
        _avatar_Img = transform.Find<Image>("Avatar_Img");

        _name_txt = transform.Find<Text>("Name/Name_Txt");
        _money_txt = transform.Find<Text>("Money/Money_Txt");

        _enterGame1_Btn = transform.Find<Button>("EnterGame1_Btn");
        _enterGame2_Btn = transform.Find<Button>("EnterGame2_Btn");
        _enterGame3_Btn = transform.Find<Button>("EnterGame3_Btn");

        _enterGame1_Btn.onClick.AddListener(OnEnterGame1Click);
        _enterGame2_Btn.onClick.AddListener(OnEnterGame2Click);
        _enterGame3_Btn.onClick.AddListener(OnEnterGame3Click);
        
    }

    private void OnEnterGame3Click()
    {
        Debug.Log("OnEnterGame3Click");
    }

    private void OnEnterGame2Click()
    {
        Debug.Log("OnEnterGame2Click");
    }

    private void OnEnterGame1Click()
    {
        Debug.Log("OnEnterGame1Click");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("已進入遊戲大廳");
        _name_txt.text = UserData.instance.name;
        _money_txt.text = UserData.instance.money.ToString();
        _avatar_Img.sprite = ResMgr.instance.GetSprite("Avatar", $"avatar_{UserData.instance.avatarID}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
