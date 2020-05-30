using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Photon.SocketServer;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using PureGame;
using PureGame.Codes;
using PureGameServer.Tools;
using PureGameServer.Handler;
using PureGameServer.Threads;

namespace PureGameServer
{
    //所有server端 主类都要继承ApplicationBase
    public class PureGameServer : ApplicationBase
    {

        public static PureGameServer _instance;
        /// <summary>
        /// 有关游戏对局的
        /// </summary>
        private RoundSetting roundSetting = new RoundSetting();
        public RoundSetting RoundSetting
        {
            get { return roundSetting; }
            set { roundSetting = value; }
        }

        




        /// <summary>
        /// 服务器数据处理
        /// </summary>
        public static readonly ILogger log = LogManager.GetCurrentClassLogger();
        public Dictionary<OperationCode, BaseHandler> handlerDictionary = new Dictionary<OperationCode, BaseHandler>();         //存储所有handler
        public List<Client> clientList = new List<Client>();        //通过集合访问所有客户端Peer，向任意客户端发送数据
        public SyncStatusThread syncStatusThread = new SyncStatusThread();
        public SyncTransformThread syncTransformThread = new SyncTransformThread();
        public StartFirstTimeThread startFirstTimeThread = new StartFirstTimeThread();
        //当一个客户端请求连接时
        //使用peerbase，表示和一个客户端连接
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {

            log.Info("一个客户端连接进来了");
            Client peer = new Client(initRequest); //需要给每个
            clientList.Add(peer);
            return peer;
        }
        //初始化
        protected override void Setup()
        {
            _instance = this;
            InitLogger();
            InitHandler();
            StartThread();
            log.Info("Set Up Complete!");
        }
        //server端关闭
        protected override void TearDown()
        {
            syncStatusThread.Stop();
            syncTransformThread.Stop();
            log.Info("服务器关闭了");
        }

        //日志初始化
        void InitLogger() {
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            FileInfo configFileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            if (configFileInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);             //让Photon知道
                XmlConfigurator.ConfigureAndWatch(configFileInfo);          //让log4net这个插件读取配置文件
            }
        }
        public void InitHandler()   //初试化Handler
        {
            CreateGameHandler createGameHandler = new CreateGameHandler();
            handlerDictionary.Add(createGameHandler.opCode, createGameHandler);
            JoinGameHandler joinGameHandler = new JoinGameHandler();
            handlerDictionary.Add(joinGameHandler.opCode, joinGameHandler);
            TeamChooseHandler teamChooseHandler = new TeamChooseHandler();
            handlerDictionary.Add(teamChooseHandler.opCode, teamChooseHandler);
            SyncTransformHandler syncTransformHandler = new SyncTransformHandler();
            handlerDictionary.Add(syncTransformHandler.opCode, syncTransformHandler);
            DamageHandler damageHandler = new DamageHandler();
            handlerDictionary.Add(damageHandler.opCode, damageHandler);
            SyncDropWeaponHandler syncDropWeaponHandler = new SyncDropWeaponHandler();
            handlerDictionary.Add(syncDropWeaponHandler.opCode, syncDropWeaponHandler);
            DeleteDropWeaponHandler deleteDropWeaponHandler = new DeleteDropWeaponHandler();
            handlerDictionary.Add(deleteDropWeaponHandler.opCode, deleteDropWeaponHandler);
            RestartHandler restartHandler = new RestartHandler();
            handlerDictionary.Add(restartHandler.opCode, restartHandler);
        }
        public void StartThread() {
            syncStatusThread.Run();
            syncTransformThread.Run();
            startFirstTimeThread.Run();
        }
     

    }
}
