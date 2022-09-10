using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void startBtn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        print("clicked on start button");
    }

    public void settingsBtn()
    {
        print("clicked on settings button");
    }

    public void aboutBtn()
    {
        print("clicked on about button");
    }

    public void quitBtn()
    {
        Application.Quit();
        print("clicked on quit button");
    }

    public void pageClick() 
    {
        Application.OpenURL("https://baka.omg.lol");
        print("clicked on profile page button");
    }

    public void discordClick() 
    {
        Application.OpenURL("https://discord.gg/KsKsgMBp5n");
        print("clicked on discord button");
    }

    public void emailClick()
    {
        Application.OpenURL("mailto:contact@baka.omg.lol");
        print("clicked on email button");
    }
}
