﻿using System;
using System.Collections.Generic;
using System.Linq;
using Merge.Storage;

namespace Merge.Board
{
    public interface IGameBoard
    {
        //(int, int) GetSize();
        //CellData GetCell(CellCoordinates coordinates);
        //void ProcessCellSelection(CellCoordinates coordinates);
    }
    
    public interface IGameBoardDirector
    {
        void PrepareNewSession(string sessionSettingsId);
        //object GetSessionSnapshot();
        //void LoadGame(object snapshot);
        void CustomUpdate(float deltaTime);
    }

    public interface IGameBoardEventsSource
    {
        //event EventHandler CoordsClicked;
        event EventHandler PieceSpawned;
        //event EventHandler PieceDestroyed;
        //event EventHandler PieceEvolved;
    }

    public class GameBoard : IGameBoard, IGameBoardDirector, IGameBoardEventsSource
    {
        private BoardData data;
        private BoardInstanceData instanceData;
        
        private IDataStorage dataStorage;
        private IPieceFactory pieceFactory;
        private IRandomProvider random;
        
        private readonly Dictionary<CellCoordinates, CellInstance> cells = 
            new Dictionary<CellCoordinates, CellInstance>();
        private readonly HashSet<CellCoordinates> emptyCells = new HashSet<CellCoordinates>();

        public event EventHandler PieceSpawned;
        
        public GameBoard(IDataStorage dataStorage, IPieceFactory pieceFactory, IRandomProvider random)
        {
            this.dataStorage = dataStorage;
            this.pieceFactory = pieceFactory;
            this.random = random;
        }

        void IGameBoardDirector.PrepareNewSession(string sessionSettingsId)
        {
            RemoveAllPieces();
            var sessionSettings = dataStorage.GetSessionSettings(sessionSettingsId);
            
            InitBoard(sessionSettings);
            
            SpawnStartingPieces(sessionSettings.StartingPieces);
        }

        public void CustomUpdate(float deltaTime)
        {
            
        }

        private void RemoveAllPieces()
        {
            foreach (var kvp in cells)
            {
                var coords = kvp.Key;
                var cell = kvp.Value;
                var piece = cell.RemovePiece();
            }
        }

        private void InitBoard(SessionSettings sessionSettings)
        {
            data = sessionSettings.BoardData;
            instanceData = new BoardInstanceData(data.Id);
            
            cells.Clear();
            emptyCells.Clear();
            for (var x = 0; x < data.Width; x++)
            {
                for (var y = 0; y < data.Height; y++)
                {
                    var coords = new CellCoordinates(x, y);
                    var cellData = new CellData() {Coords = coords};
                    var cellInstanceData = new CellInstanceData();
                    instanceData.Cells.Add(coords, cellInstanceData);
                    var cell = new CellInstance(cellData, cellInstanceData);
                    cells.Add(coords, cell);
                    emptyCells.Add(coords);
                }
            }
        }

        private void SpawnStartingPieces(PieceData[] piecesData)
        {
            var newPieces = pieceFactory.Create(piecesData);
            foreach (var piece in newPieces)
            {
                PlacePiece(piece);
            }
        }

        private void PlacePiece(PieceInstance piece)
        {
            var selectedCoords = GetEmptyCoordinates();
            emptyCells.Remove(selectedCoords);
            var selectedCell = cells[selectedCoords];
            selectedCell.PlacePiece(piece);
            var eventArgs = new PieceSpawnedArgs() {Coords = selectedCoords};
            PieceSpawned?.Invoke(this,  eventArgs);
        }

        private CellCoordinates GetEmptyCoordinates()
        {
            return emptyCells.ElementAt(random.Next(emptyCells.Count));
        }
    }
}