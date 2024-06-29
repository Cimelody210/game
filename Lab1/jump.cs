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
    private Dictionary<int, string> levelBackgrounds;
    public Dictionary<int, string> level = new Dictionary<int, string>()
    {
        {1, 'Six Ear Maccaque'},
        {2, 'Lu Bo Dynatis'},
        {3, 'Ma Vien'},
        {4, 'Ngot Luong Hop Thai'},
        {5, 'Zhu Nan'},
        {6, 'Zhu ZhongShi'},
        {7, 'Ton Si Nghi'},
       
    }
    void OnDrag(PointerEventData eventData){
        transform.postion = Input.mousePostion;
        Debug.Log(transform.postion);
    }
    void LoadBackground(int level)
    {
        // Kiểm tra xem level có tồn tại trong dictionary levelBackgrounds không
        if (levelBackgrounds.ContainsKey(level))
        {
            // Tên của hình nền tương ứng với level
            string backgroundName = levelBackgrounds[level];
            
            // Load hình nền từ Resources/Backgrounds
            Sprite backgroundSprite = Resources.Load<Sprite>($"Backgrounds/{backgroundName}");

            // Kiểm tra xem đã load thành công hình nền hay chưa
            if (backgroundSprite != null)
            {
                // Set hình nền cho SpriteRenderer
                backgroundSpriteRenderer.sprite = backgroundSprite;
            }
            else
            {
                Debug.LogError($"Failed to load background sprite: {backgroundName}");
            }
        } else{
            Debug.LogError($"No background defined for level: {level}");

        }
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

        // Gán enemy cụ thể và bắt đầu chiến đấu với nó
        GameObject specificEnemy = null;
        // Lấy danh sách enemy của level từ dictionary
        List<string> enemies = levels[level];

        public SpriteRenderer backgroundSpriteRenderer; // SpriteRenderer của hình nền

        
        int LuaChon = 10;
        switch(LuaChon)
        {
            case 0:
                Debug.Log("May dang cho man 1");
                break;
            // Solo với khỉ 6 tai Lục Nhĩ và quan quân nhà Đương thời Lý Thế Dân
            case 1:
                specificEnemy = Instantiate(Resources.Load<GameObject>("Prefabs/LinhCatBT"));
                playerCharacter.transform.position = new Vector3(0, 0, 0);
                specificEnemy.transform.position = new Vector3(10, 0, 0);    // Vị trí của enemy
                // specificEnemy.GetComponent<EnemyController>().StartBattle(); 

                // Gọi phương thức StartGame trong script của nhân vật + Gán nhân vật vào vị trí chiến đấu, bắt đầu animation, v.v.
                playerCharacter.GetComponent<PlayerController>().StartGame();


                Debug.Log("1 dhfgfgfgfgb");
                break;
            // Solo với Lữ Bố và các tướng Tam quốc
            case 2:
                Debug.Log("2 dhfgfgfgfgb");
                specificEnemy = Instantiate(Resources.Load<GameObject>("Prefabs/TaoKham"));
                if (distanceToNext <= distanceOrcharge){
                    if(nextExp + 1 == nodes.Count){
                        nextExp  = 9;
                    } else {
                        nextExp ++;
                    }
                }
                break;
            // Solo với Lữ Bố và các tướng thời thập quốc TQ
            case 3:
                specificEnemy = Instantiate(Resources.Load<GameObject>("Prefabs/AnLocSon"));
                break;
            // Solo với Lữ Bố và quân  Mông Cổ
            case 4:
                specificEnemy = Instantiate(Resources.Load<GameObject>("Prefabs/LuBo"));
                break;
            // Solo với đám Minh thời Chu Đệ -> Chu Chiêm Cơ
            case 5:
                Debug.Log("Đang bắt đầu cuộc chiến với " + string(enemy) + "của Cẩm y vệ");
                foreach (Transform child in enemyListContainer)
                {
                    Destroy(child.gameObject);
                }

                // Hiển thị từng enemy dưới dạng button
                foreach (string enemy in enemies)
                {
                    GameObject buttonGO = Instantiate(enemyButtonPrefab, enemyListContainer);
                    Button button = buttonGO.GetComponent<Button>();
                    button.GetComponentInChildren<Text>().text = enemy;
                    button.onClick.AddListener(() => StartBattle(enemy)); // Thêm listener cho button
                }
                
                modalPanel.SetActive(false);
                break;
            // Cũng là Minh triều nhưng là đánh nhau với đám Đông-Tây xưởng, Cẩm Y vệ
            case 6:
                break;
            // Đánh nhau với quân Mãn Thanh
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            default:
                Debug.LogError($"Unknown enemy type: {enemy}");
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
