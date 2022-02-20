using Merge.Board;
using Merge.Storage;
using Merge.Views.Board;
using UnityEngine;

namespace Merge.Session
{
    public class SessionDirector : MonoBehaviour
    {
        [SerializeField]
        private BoardView boardView;
        
        private IDataStorage dataStorage;
        private IPieceFactory pieceFactory;
        private IRandomProvider random;

        private GameBoard gameBoard;

        private string currentSessionSettingsId;

        public void Awake()
        {
            random = new Random();
            var storage = new DataStorage();
            storage.LoadData();
            dataStorage = storage;
            pieceFactory = new PieceFactory(dataStorage);
            
            gameBoard = new GameBoard(dataStorage, pieceFactory, random);
            currentSessionSettingsId = SessionConstants.FIRST_SESSION_SETTINGS_ID;

            boardView.Init((IGameBoard)gameBoard, (IGameBoardEventsSource) gameBoard);

        }

        public void Update()
        {
            var deltaTime = Time.deltaTime;
            gameBoard.CustomUpdate(deltaTime);
            boardView.CustomUpdate(deltaTime);
        }

        public void Restart()
        {
            (gameBoard as IGameBoardDirector).PrepareNewSession(currentSessionSettingsId);            
        }
        
        
    }
}