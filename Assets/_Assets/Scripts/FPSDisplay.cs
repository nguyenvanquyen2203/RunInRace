using UnityEngine;
using TMPro; // Important: Add this line for TextMeshPro functionality

public class FPSDisplay : MonoBehaviour
{
    // How often to update the FPS display (in seconds)
    [Tooltip("How often the FPS display updates (in seconds)")]
    public float updateInterval = 0.5f;

    // Reference to the TextMeshPro UI object that will display the FPS
    [Tooltip("Assign your TextMeshPro UI object here")]
    public TextMeshProUGUI FPSText;

    private float _accum = 0f;  // FPS accumulated over the interval
    private int _frames = 0;    // Frames drawn over the interval
    private float _timeleft;    // Left time for current interval

    void Start()
    {
        // Initialize the time left for the first interval
        _timeleft = updateInterval;

        // Check if the TextMeshProUGUI component is assigned
        if (FPSText == null)
        {
            Debug.LogError("FPSText (TextMeshProUGUI) is not assigned in the Inspector for FPSDisplay!", this);
            enabled = false; // Disable the script if no text object is assigned
            return;
        }
    }

    void Update()
    {
        // Decrease the time left for the current interval
        // Time.deltaTime is the time since the last frame
        _timeleft -= Time.deltaTime;

        // Accumulate FPS. We divide by Time.deltaTime to get the instantaneous FPS for this frame.
        // Multiply by Time.timeScale to get actual real-time FPS even when game is slowed/paused.
        // If you want FPS relative to game speed (e.g., 60 FPS in slow-mo is still 60 game-FPS), remove Time.timeScale.
        _accum += Time.timeScale / Time.deltaTime;
        ++_frames;

        // If the interval has ended, update the GUI text and start a new interval
        if (_timeleft <= 0.0f)
        {
            // Calculate the average FPS over the interval
            float fps = _accum / _frames;

            // Format the FPS string for display. "F0" means no decimal places.
            string format = System.String.Format("{0:F0} FPS", fps);
            FPSText.text = format;

            // Optionally change text color based on FPS range for visual feedback
            if (fps < 30)
                FPSText.color = Color.red;
            else if (fps < 60)
                FPSText.color = Color.yellow;
            else
                FPSText.color = Color.green;

            // Reset for the next interval
            _timeleft = updateInterval;
            _accum = 0.0f;
            _frames = 0;
        }
    }
}