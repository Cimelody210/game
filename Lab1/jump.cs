using System;
using UnityEngine;
using UnityEngine.Analytics;
using System.Cryptography;
using System.Text;

public class JumpscareTrigger : MonoBehaviour
{
    public GameObject jumpscareImage;
    private AudioSource audioSource;
    private bool hasPlayed = false;
    private Dropdown myDb;
    public RawImage my_img;

    [HideInInspector]
    public MyData data;

    [Space]
    [Multiline]
    [TextArea]
    [FormerlySerializedAs("myOldInt")]
    [ContextMenu("Do sone")]

    public List<int> mylist = new List<int> {1,2,3,4};
    public string[] sayHi  = {"Black","Myth", "Wukong"};

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Đảm bảo rằng âm thanh chỉ được phát một lần
        audioSource.playOnAwake = false;

        Debug.Log(Mathf.Round(0.1f));
        Debug.Log(Mathf.Abs(-10f));
        Debug.Log(Mathf.Pow(2,4));
        Debug.Log(mathf.Max(-10f, 20f));
        Debug.Log(mathf.Min(-10f, 10f));
    }
    public Dictionary<int, string> str = new Dictionary<int, string>()
    {
        {1, 'abc'},
        {2, 'abc'},
        {3, 'abc'},
        {4, 'abc'},
    }
    void ChosseOption(){

        Application.OpenURL("linkwebste");
        GetWindow<SampleScript>("Sample");
        int LuaChon = 10;
        switch(LuaChon)
        {
            case 0:
                Debug.Log("May dang cho man 1");
                break;
            case 1:
                Debug.Log("1 dhfgfgfgfgb");
                break;
            case 2:
                Debug.Log("2 dhfgfgfgfgb");
                break;
            default:
                Debug.Log("Lua chon khong nam o trong day");
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        string data_in_json=  File.ReadAllText(jsonPath);
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            
            // Hiển thị hình ảnh kinh dị (có thể là một hình ảnh sprite hoặc texture)
            jumpscareImage.SetActive(true);
            
            // Phát âm thanh jumpscare
            audioSource.Play();

            // Tạm dừng game hoặc thực hiện các hành động khác nếu cần
            Time.timeScale = 0f; // Tạm dừng thời gian trong game (không bắt buộc)
        }
    }
}
