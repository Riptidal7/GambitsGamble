public static class PauseController
{
    public static bool IsPaused = false;

    public static void Pause()
    {
        IsPaused = true;
    }
    
    public static void UnPause()
    {
        IsPaused = false;
    }
}
