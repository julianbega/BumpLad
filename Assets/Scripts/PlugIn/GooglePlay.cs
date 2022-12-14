using UnityEngine;
using GooglePlayGames;

public static class GooglePlay
{
    private static string achievement1ID = GPGSIds.achievement_startgame;
    public static string achievement2ID = GPGSIds.achievement_new_car;
    public static string achievement3ID = GPGSIds.achievement_goingfast;



    public static void Init()
    {
        PlayGamesPlatform.Instance.Authenticate((callback) => { UnlockAchievement(achievement1ID); });
    }

    static public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
    }

    static public void UnlockAchievement(string a)
    {

        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            Debug.Log("LLamdo a desbloquear logro");
            PlayGamesPlatform.Instance.ReportProgress(a, 100f, success => { });
        }
    }
}
