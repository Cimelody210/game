using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject soundManagerObject = new GameObject("SoundManager");
                instance = soundManagerObject.AddComponent<SoundManager>();
                DontDestroyOnLoad(soundManagerObject);
            }
            return instance;
        }
    }

    // Đoạn code quản lý âm thanh
    public void PlaySound(string soundName)
    {
        // Code phát âm thanh ở đây
    }
}
