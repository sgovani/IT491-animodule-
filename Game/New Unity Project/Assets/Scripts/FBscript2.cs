using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.IO;

public class FBscript2 : MonoBehaviour
{//This is Facebook's code, there is tutorials on how to use the Facebook SDK and their own documentation 
    public Image test;
    public GameObject buttons;

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void LogIn()
    {
        FB.LogInWithPublishPermissions(
             new List<string>() { "publish_actions" },
             OnLogIn
            );
    }

    private void OnLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("Login Success");
        }
        else
        {
            Debug.Log("Canceled Login");
            Debug.Log(result.ToString());
        }
    }

    public void Share()
    {
        if (FB.IsLoggedIn)
        {
            StartCoroutine(TakeScreenshot());
        }
        else
        {
            LogIn();
            StartCoroutine(TakeScreenshot());
        }
    }

    private System.Collections.IEnumerator TakeScreenshot()
    {
        buttons.SetActive(false);
        yield return new WaitForEndOfFrame();

        var width = Screen.width;
        var height = Screen.height;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        byte[] screenshot = tex.EncodeToPNG();

        var wwwForm = new WWWForm();
        wwwForm.AddBinaryData("image", screenshot, "Screenshot.png");

        FB.API("me/photos", HttpMethod.POST, OnShareGraph, wwwForm);
        buttons.SetActive(true);
    }

    private void OnShareGraph(IGraphResult result)
    {
        if (result.Error == "400 Bad Request")
        {
            Debug.Log("Must Login");
        }
        else if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Share Image error: " + result.Error);
            Debug.Log(result.ToString());
        }
        else
        {
            Debug.Log("Share Succeed");
        }
    }

    public void LogOut()
    {
        FB.LogOut();
    }
}