using System;
using System.Collection.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using System.Cryptography;
using System.Text;
using UnityEngine.UI;

public class JumpscareTrigger : MonoBehaviour
{
    public GameObject jumpscareImage;
    private AudioSource audioSource;
    private bool hasPlayed = false;
    private Dropdown myDb;
    public RawImage my_img;
    private Rigidbody2D rb;

    [HideInInspector]
    public MyData data;

    [Space]
    [Multiline]
    [TextArea]
    [FormerlySerializedAs("myOldInt")]
    [ContextMenu("Do sone")]

    public List<int> mylist = new List<int> {1,2,3,4};
    public string[] sayHi  = {"Black","Myth", "Wukong"};
    private InventoryItem InventItem {get; set;}
    float distance => Vector2.Distance(transform.postion, nodes[nextExp]);

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Transform thisParent = transform.parent; 
        for(int i= 0, i< thisParent.children; i++){
            nodes.Add(thisParent.GetChild(i).transform.postion);
        }
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
        {1, 'Trương Hùng'},
        {2, 'Aumshoko Shikihara'},
        {3, ''},
        {4, 'abc'},
    }
    void OnDrag(PointerEventData eventData){
        transform.postion = Input.mousePostion;
        Debug.Log(transform.postion);
    }
    public void OnDrop(PointerEventData eventData){
        RectTransform inv = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(inv, Input.mousePostion)){

            Debug.Log(RectTransformUtility.RectangleContainsScreenPoint(inv, Input.mousePostion));
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().Item;
        }
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
                if (distanceToNext <= distanceOrcharge){
                    if(nextExp + 1 == nodes.Count){
                        nextExp  = 9;
                    } else {
                        nextExp ++;
                    }
                }
                break;
            case 3:
                break;
            default:
                Debug.Log("Lua chon khong nam o trong day");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
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
