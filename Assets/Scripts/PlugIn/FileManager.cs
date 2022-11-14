using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    const string PACK_NAME = "com.example.logger2022";

    const string FILEMANAGER_CLASS_NAME = "FileManagerClass";

    static AndroidJavaClass FileManagerClass = null;

    static AndroidJavaObject FileManagerInstance = null;


    protected AndroidJavaClass androidClass;
    protected AndroidJavaObject unityActivity;

    public FileManager()
    {
        InitializePlugin();
    }

    protected void InitializePlugin()
    {
        androidClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = androidClass.GetStatic<AndroidJavaObject>("currentActivity");
        FileManagerClass = new AndroidJavaClass(PACK_NAME + "." + FILEMANAGER_CLASS_NAME);
        FileManagerInstance = FileManagerClass.CallStatic<AndroidJavaObject>("GetInstance");
        FileManagerInstance.CallStatic("receiveUnityActivity", unityActivity);
    }

    public void WriteFile(string msg)
    {
        FileManagerInstance.CallStatic("WriteFile", msg);
    }
    public string ReadFile()
    {
        return FileManagerInstance.CallStatic<string>("ReadFile", " ");
    }
    public void ClearFile()
    {
        FileManagerInstance.CallStatic("ClearFile", " ");
    }


}
