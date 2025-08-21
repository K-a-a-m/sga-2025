using UnityEngine;

public static class DisplayCreditsStatic
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static bool DisplayCredits { get; set; } = false;
    public static string SceneName { get; set; } = nameof(AvailableScenes.PlayerScene);
}

public enum AvailableScenes
{
    PlayerScene,
    FinalScreenLayered,
    TitleScreen
}
