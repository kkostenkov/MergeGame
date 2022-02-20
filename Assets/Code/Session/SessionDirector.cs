using Merge.Board;
using Merge.Storage;
using UnityEngine;

namespace Merge.Session
{
    public class SessionDirector : MonoBehaviour
    {
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

        }

        public void Update()
        {
            gameBoard.CustomUpdate(Time.deltaTime);
        }

        public void Restart()
        {
            (gameBoard as IGameBoardDirector).PrepareNewSession(currentSessionSettingsId);            
        }
        
        
    }
}