using UnityEngine;

public static class SceneParametersStatic
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static bool DisplayCredits { get; set; } = false;
    public static string SceneName { get; set; } = nameof(AvailableScenes.PlayerScene);

    public static bool AutoSkipDialogsBegin { get; set; } = false;
}

public enum AvailableScenes
{
    PlayerScene,
    PlayerSceneExpert,
    FinalScreenLayered,
    TitleScreen
}
