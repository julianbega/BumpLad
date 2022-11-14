using System;
using UnityEngine;
using UnityEngine.UI;

public class LoggerManager : MonoBehaviour
{
    private Logger logs;
    private FileManager fileManager;
    private Alert alertManager;


    public Button AlertButton;
    public Button logButton;
    public Button logButtonUnity;
    public Button ClearDataButton;
    public TMPro.TextMeshProUGUI showeableText;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogWarning("Wrong platform");
            return;
        }
        logs = new Logger();
        fileManager = new FileManager();
        alertManager = new Alert();
        logButton.onClick.AddListener(ExampleLogCall);
        logButtonUnity.onClick.AddListener(UnityLogCall);
        ClearDataButton.onClick.AddListener(ShowAlert);
        logs.OnAndroidCall += UpdateShowingText;
        UpdateShowingText("Start Test PluginExample");
    }
    private void ExampleLogCall() => logs.AndroidLog("Ejemplo de log");

    private void UnityLogCall() => Debug.Log("example_unity_Debug.Log");

    private void UpdateShowingText(string msg)
    {
        fileManager.WriteFile(msg + '\n');
        showeableText.text = fileManager.ReadFile();
    }
    private void ShowAlert()
    {
        alertManager.showAlertDialog(new string[] { "POPAndroid", "ClearData?", "NO", "YES" }, (Int32 obj) => {
            if (obj == -2)
                ClearData();
        });
    }
    private void ClearData()
    {
        fileManager.ClearFile();
        UpdateShowingText(" ");
    }


}
