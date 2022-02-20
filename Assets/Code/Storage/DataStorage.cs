using System.Collections.Generic;
using System.Linq;
using Merge.Board;
using UnityEngine;

namespace Merge.Storage
{
    public interface IDataStorage
    {
        SessionSettings GetSessionSettings(string sessionSettingsId);
        PieceData GetPiece(string pieceDataId);
        PieceViewSettings GetPieceViewSettings(string pieceViewSettingsId);
    }
        
    public class DataStorage : IDataStorage
    {
        public void LoadData()
        {
            var mockLoadedSessionData = MockDataSource.GetSessionData();
            sessionSettings = mockLoadedSessionData.ToDictionary(d => d.Id);


            var mockLoadedPieceData = MockDataSource.GetPieceData();
            pieces = mockLoadedPieceData.ToDictionary(p => p.Id);

            
            pieceViewSettings = MockDataSource.GetPieceViewSettings();
        }

        private Dictionary<string, SessionSettings> sessionSettings;
        public SessionSettings GetSessionSettings(string sessionSettingsId)
        {
            return sessionSettings[sessionSettingsId];
        }


        private Dictionary<string, PieceData> pieces;
        public PieceData GetPiece(string pieceDataId)
        {
            return pieces[pieceDataId];
        }

        private Dictionary<string, PieceViewSettings> pieceViewSettings;
        public PieceViewSettings GetPieceViewSettings(string id)
        {
            if (!pieceViewSettings.TryGetValue(id, out var settings))
            {
                Debug.LogError($"[Storage][PieceViewSettings] missing {id}");
            }
            return settings;
        }
    }
}