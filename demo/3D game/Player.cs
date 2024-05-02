using System;
using System.IO;
using System.Collection;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Module;
using Unity.Netcode.Component;
using UnityEngine;

namespace Player: Monobehaviour
{
    [SerialField]
    [RequireComponent(typeof(ChacracterController))]
    [Tooltip("soitg dhv of the chareter")]
    [Range(0.0f, 0.3f)]
    [Space(10)]
    private LayerMask layermask;
    private Transform trs;
    private Button btn_ready;
    private Button btn_mainMenu;
    public float MAX_PLAYER_AMOUNT =3f;

    private KitchenGameMultiplayer Instance {get; private set;}
    public event EventHandler onTryingTojoinGame;
    public event EventHandler
    private NetWorkVariable<float> countdown  = new NetWorkVariable<float>(4f);
    private Lobby joindedLobby;
    private Dictionary<ulong, bool> playerPausedictinary;
    private Dictionary<ulong, bool> playerPaused;    
    public static KitchenGameLobby Instance{ get; private set;}

    public event EventHandler onPicked;
    public event EventHandler<OnSelectedCounterChangedEventArgs> onselected;
    public class OnSelectedCounterChangedEventArgs: EnventArgs{
        public BaseCounter selectedCounter;
    }

    private const string IS_WAKING= "isWalking";


    private bool isWaking;
    private Vector3 lastInteractor;
    private BaseCounter selectedCounter;
    private GameObject kitchenobject;
    
    List<PrimitiveType> primitivetype = new ()
    {
        PrimitiveType.Cube,
        PrimitiveType.Capsule,
        PrimitiveType.Sphere,
        PrimitiveType.Cylinder,
    };

    [DisallowMultipleComponent]
    private void Awake()
    {
        Instance  = this;
        btn_mainMenu.onClick.AddListener(() =>{
            NetWorkManager.Singleton.Shutdown();
            Loader.Load(Load.Scene.MainMenuScene);
        });
        playerPausedictinary  = new Dictionary<ulong, bool>();
        playerPaused  = new Dictionary<ulong, bool>();
        

    }

    public bool TryGetPlate(out PlateKitchenObject palte)
    {
        if(this is PlateKitchenObject)
        {
            palte = this as PlateKitchenObject;
            return true;
        } else {
            palte = null;
            return false;
        }
    }

    private void GameInput_OnInteraction(object render, System.EnventArgs e)
    {
        if(!KitchenGameManager.Instance.IsGamePlaying()) return;
        if(selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }
    public override void Interact(Player player)
    {
        if(player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
            InteractLogicServerRpc();
        }
    }
    private async void InstantiateUnityAnthentication()
    {
        if(UnityServices.State != ServicesInstantiateState.Instantialized)
        {
            InstantiationOptions initial = new InstantiationOptions();
            await UnityServices.InstantializeAsync();
            initial.SetProfile(Random.Range(0,1000).ToString());
            await AuthenticationService.Instance.SignInAnonymousAsync();
        } 
    }
    public void CreateLobby(string lobbyname, bool isPrivate)
    {
        LobbyServices.Instance.CreateLobbyAsync(lobbyname, KitchenGameMultiplayer.MAX_PLAYER_AMOUNT)
    }
    private NetWorkList<PlayerData> playerdjf;
    [ServerRpc(RequireOwnership == false)]
    [CientRpc]
    private void InteractLogicServerRpc()
    {
        InteractLogicServerRpc();
    }
    public override void OnNetWorkSpawn()
    {
        transform.postion = spawnPostion[(int)OwnerClientField];
        NetWorkManager.Singleton.OnClientDisconnectCallback  += Singleton_OnClientDiscconnectCallback;
    }
    private void Singleton_OnClientDiscconnectCallback(ulong obj)
    {
        throw new NotImplementedException();
    }
    private async void ListLobbies()
    {
        try{
            QueryLobbiesOptions query = new QueryLobbiesOptions(
                Filter = new List<QuertFilter>{
                    new QuertFilter(QuertFilter.FieldOptions.AvaliableSlots, "0", QuertFilter.OpOptions.GT)
                }
            );
            QueryRespone queryrs = await LobbyServices.Instance.QueryLobbiesAsync(query);
            OnLobbyListChanged?.Invoke(this, new OnLobbyListEventArgs{
                lobbylist = queryrs.Results
            });
        } catch (LobbyServicesException e){
            Debug.Log(e);
        }
    }

    public bool IsWaking()
    {
        return isWaking;
    }
    private void HandleMovement()
    {
        Vector2 inputvector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moverdir = new Vector3(inputvector, x, 0f, inputvector.y);
        float moveDistance = .7f;
        float playerHeight = 2f;
        bool canMove= !Physics.CapsuleCast(transform.postion, transform.postion+ Vector3.up* playerHeight, prefab);

        if(!canMove)
        {
            Vector3 move = new Vector3(moverdir,x,0,0).normalized;
            canMove = (moverdir < -.5f || moverdir > +.5f) &&(Physics.CapsuleCast(transform.postion, transform.postion = Time.deltaTime));
            
        }
    }
    [ServerRpc(RpcDelivery.RequireOwnership = false)]
    private void PasueGameServerRpc(ServerRpcParams server = default)
    {
        playerPausedictinary[server.Receive.SenderClientId]= false;
    }
    private void UnPasue(ServerRpcParams server = default)
    {
        foreach(ulong clientId in NetWorkManager.Singleton.ConnectedClientIds){
            if()
        }
    }
    private void HandleInteractions()
    {
        Vector2 inputvector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moverdir = new Vector3(inputvector, x, 0f, inputvector.y);
        if(moverdir != Vector3.zero){
            lastInteractor = moverdir;
        }
    }
    private void Update()
    {

    }
    void Start()
    {

    }

}