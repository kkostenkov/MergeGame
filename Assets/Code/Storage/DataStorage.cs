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
            var mockLoadedSessionData = new SessionSettings[]
            {
                new SessionSettings()
                {
                    Id = SessionConstants.FIRST_SESSION_SETTINGS_ID,
                    BoardData = new BoardData()
                    {
                        Id = "7by7",
                        Height = 7,
                        Width = 7,
                    },
                    StartingPieces = new[]
                    {
                        new PieceData()
                        {
                            Id = "B_3"
                        }
                    }
                }
            };

            sessionSettings = mockLoadedSessionData.ToDictionary(d => d.Id);

            var mockLoadedPieceData = new PieceData[]
            {
                new PieceData()
                {
                    Id = "B_3",
                    ViewSettingsId = "B_3"
                    
                }
            };
            pieces = mockLoadedPieceData.ToDictionary(p => p.Id);

            pieceViewSettings = new Dictionary<string, PieceViewSettings>()
            {
                {
                    "B_3",
                    new PieceViewSettings()
                    {
                        Color = "#102030FF",
                        Codename = "B_3"
                    }
                }
            };
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