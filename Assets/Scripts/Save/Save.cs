using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private int saveID;
    private float gameTime;
    private float money;
    private int userID;
    private string username;

    public Save(int id_save, float time, float money, int id_user, string name)
    {
        this.saveID = id_save;
        this.gameTime = time;
        this.money = money;
        this.userID = id_user;
        this.username = name;
    }

    public int GetSaveID() => saveID;
    public float GetGameTime() => gameTime;
    public float GetMoney() => money;
    public int GetUserID() => userID;
    public string GetUsername() => username;

}
