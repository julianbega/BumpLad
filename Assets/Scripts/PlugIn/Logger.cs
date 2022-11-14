
using UnityEngine;

public class Logger : MonoBehaviour
{
    const string PACK_NAME = "com.example.logger2022";

    const string LOGGER_CLASS_NAME = "Logger2022";

    static AndroidJavaClass Logger2022 = null;

    static AndroidJavaObject Logger2022Instance = null;

    public System.Action<string> OnAndroidCall;

    public Logger()
    {
        InitializePlugin();
    }
    protected void InitializePlugin()
    {
        Logger2022 = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        Logger2022Instance = Logger2022.CallStatic<AndroidJavaObject>("GetInstance");
        Application.logMessageReceived += HandleLog;
    }
    void HandleLog(string logString, string stackTrace, LogType type)
    {
        AndroidLog(logString);
    }
    public void AndroidLog(string log)
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        Logger2022Instance.Call("SendLog", log);
        OnAndroidCall.Invoke(log);
    }
}
