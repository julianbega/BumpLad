using UnityEngine;
using GooglePlayGames;

public static class GooglePlay
{
    private static string achievement1ID = GPGSIds.achievement_startgame;

    public static void Init()
    {
        PlayGamesPlatform.Instance.Authenticate((callback) => { UnlockAchievement(achievement1ID); });
    }

    static public void AddScoreToLeaderboard(int score)
    {
        if (Social.Active.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportScore(score, "Timer Board", success => { Debug.Log("Se subio al leaderboard"); });
        }
    }

    static public void ShowLeaderboard()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
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
