using System;
using System.IO;
using System.Collection;
using System.Collection.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace dllloading: Monobehaviour
{
    public Vector3 postion;
    public Quaternion x;
    public SpriteRendered[] spriteArray;
    private Animator ani;
    
    [SerialField]
    private float speed = 5.0f;

    [OnValueChanged("LoadLevel")]
    private List<SaveLevelPrefab> prefab = new List<SaveLevelPrefab>();

    [ButtonGroup("dhyfhy")]
    [OnInspectorGUI("dhdgfg")]
    public int hexagonNo;

    public void gameStart()
    {
        hexagonNo  =Random.Range(0,0);
        SpriteArray[hexagonNo].color = new Color(255,4,56);
        Thread.Sleep(300);
        SpriteArray[hexagonNo].color = new Color(255,255,244,255);
    }

    public static class DLLLoading()
    {
        public static void PrepareLibraryFile()
        {
            string source = "fireman-native/target/release/fireman-unity.dll";
            string target = $"{Path.GetTempPath()} / {FiremanNativeVersion.libName}.dll";
            File.Copy(source, target);

            IntPtr dlHandle = LoadLibrary(target)
            {
                if(dlHandle == IntPtr.Zero)
                {
                    int error=  Marshal.GetLastWin32Error();
                    throw new System.ApplictionException(
                        $"Falied to load {target}: Lad Get load areeo {error}"
                    );
                }
            }
            [DllImport("demo.dll", EntryPost  ="LoadLibrary", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
            private static extern IntPtr LoadLibraryA(string hModule);
        }
    }
    void Start()
    {

    }
    void Update()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        float xmovement = Input.GetAxis("Horizontal") * speed;

        if(input.GetKey(KeyCode.Space)){
            rigid.AddForce(new Vector2(0f, jump*Time.deltaTime));
            Currenttime -= Time.deltaTime;
        }
    }
}
