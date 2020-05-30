using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class PhotonEngine : MonoBehaviour,IPhotonPeerListener
{
    public static PhotonEngine _instance;
    private static PhotonPeer peer;             //代表当前客户端
    public Dictionary<OperationCode, BaseRequest> requestDictionary = new Dictionary<OperationCode, BaseRequest>();               //请求字典 发往服务器
    public Dictionary<EventCode, BaseEvent> eventDictionary = new Dictionary<EventCode, BaseEvent>();                       //事件字典  处理服务器发送来的事件

    public void DebugReturn(DebugLevel level, string message)
    {
        
    }

    //处理服务器主动发来的消息  服务器通过SendEvent发送到这里
    public void OnEvent(EventData eventData)
    {
        EventCode evCode = (EventCode)eventData.Code;           //区分事件类型
        BaseEvent baseEvent = PureDictTool.GetValue<EventCode, BaseEvent>(eventDictionary, evCode);        //绑定事件
        baseEvent.OnEvent(eventData);           //执行事件
    }

    //处理客户端请求后服务器返回的反馈,
    public void OnOperationResponse(OperationResponse operationResponse)
    {
        OperationCode opCode = (OperationCode)operationResponse.OperationCode;          //区分请求类型
        BaseRequest baseRequest = PureDictTool.GetValue<OperationCode, BaseRequest>(requestDictionary, opCode);       //查询并绑定请求
        baseRequest.OnOperationResponse(operationResponse);             ///执行请求
    }   

    public void OnStatusChanged(StatusCode statusCode)
    {
        Debug.Log(statusCode);
    }

    //请求添加，删除
    public void AddRequest(BaseRequest baseRequest) {
        requestDictionary.Add(baseRequest.opCode, baseRequest);
    }
    public void RemoveRequest(BaseRequest baseRequest) {
        requestDictionary.Remove(baseRequest.opCode);
    }
    //事件添加，删除
    public void AddEvent(BaseEvent baseEvent)
    {
        eventDictionary.Add(baseEvent.evCode, baseEvent);
    }
    public void RemoveEvent(BaseEvent baseEvent) {
        eventDictionary.Remove(baseEvent.evCode);
    }


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        peer = new PhotonPeer(this, ConnectionProtocol.Udp);
        peer.Connect("192.168.0.103:5055", "PureGame");//www.zimo.wiki:5055
    }
    void Update() {
        peer.Service();     //维持连接
    }
    void OnDestroy() {
        if (peer != null && peer.PeerState == PeerStateValue.Connected) {
            peer.Disconnect();
        }
    }



    //get-set Method
    public static PhotonPeer Peer
    {
        get { return PhotonEngine.peer; }
        set { PhotonEngine.peer = value; }
    }
}
