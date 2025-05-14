using UnityEngine;

public class WaitForSecondsWhileUnpaused : CustomYieldInstruction
{
    private float targetTime;

    public override bool keepWaiting
    {
        get
        {
            if (PauseController.IsPaused) return true;
            return Time.time < targetTime;
        }
    }

    public WaitForSecondsWhileUnpaused(float seconds)
    {
        targetTime = Time.time + seconds;
    }
}
