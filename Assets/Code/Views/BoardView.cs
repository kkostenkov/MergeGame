using System;
using System.Collections.Generic;
using Merge.Board;
using Merge.Storage;
using Merge.Views.Cell;
using Merge.Views.Piece;
using UnityEngine;

namespace Merge.Views.Board
{
    public class BoardView : MonoBehaviour
    {
        [SerializeField] private CellView cellPrefab;
        [SerializeField] private RectTransform spawnRoot;

        private IGameBoard gameBoard;
        private IGameBoardEventsSource gameBoardEventsSource;
        private IDataStorage dataStorage;

        private Dictionary<CellCoordinates, CellView> CellViews = new Dictionary<CellCoordinates, CellView>();

        public void Init(IGameBoard gameBoard, IGameBoardEventsSource gameBoardEventsSource,
            IDataStorage dataStorage)
        {
            this.gameBoard = gameBoard;
            this.gameBoardEventsSource = gameBoardEventsSource;
            this.dataStorage = dataStorage;
            Subscribe();
        }

        private void Subscribe()
        {
            gameBoardEventsSource.BoardReset += GameBoardEventsSourceOnBoardReset;
            gameBoardEventsSource.PieceSpawned += GameBoardEventsSourceOnPieceSpawned;
        }

        private void Unsubscribe()
        {
            gameBoardEventsSource.BoardReset -= GameBoardEventsSourceOnBoardReset;
            gameBoardEventsSource.PieceSpawned -= GameBoardEventsSourceOnPieceSpawned ;
        }
        
        
        private void GameBoardEventsSourceOnBoardReset(object sender, EventArgs e)
        {
            ClearAllPieces();
            var (width, height) = gameBoard.GetSize();
            SetVisibleBoardSize(width, height);
        }

        private void ClearAllPieces()
        {
            foreach (var keyValuePair in CellViews)
            {
                var cellView = keyValuePair.Value;
                cellView.ClearPiece();
            }
        }

        private void GameBoardEventsSourceOnPieceSpawned(object sender, PieceSpawnedArgs e)
        {
            var cellView = CellViews[e.Coords];
            cellView.SpawnPiece(e.Piece);
        }
        
        public void CustomUpdate(float deltaTime)
        {
            
        }

        public void OnDestroy()
        {
            Unsubscribe();
            gameBoard = null;
            gameBoardEventsSource = null;
        }
        
        private void SetVisibleBoardSize(int width, int height)
        {
            var totalCellsCount = width * height;
            while (CellViews.Count < totalCellsCount)
            {
                var cellView = GameObject.Instantiate(
                    cellPrefab, Vector3.zero, Quaternion.identity, spawnRoot);
                var currentViewIndex = CellViews.Count + 1;
                var coords = CellCoordinates.CellIndexToCoords(currentViewIndex, width);
                cellView.Init(coords, dataStorage);
                CellViews[coords] = cellView;
            }
            // TODO: hide excessive/show needed
        }
    }
}