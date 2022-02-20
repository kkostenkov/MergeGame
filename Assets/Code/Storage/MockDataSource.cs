using System.Collections.Generic;
using Merge.Board;
using Merge.Board.Abilities;
using Merge.Board.Conditions;

namespace Merge.Storage
{
    public static class MockDataSource
    {
        public static SessionSettings[] GetSessionData()
        {
            return new SessionSettings[]
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
        }

        public static PieceData[] GetPieceData()
        {
            return new PieceData[]
            {
                new PieceData()
                {
                    Id = "B_1",
                    ViewSettingsId = "B_1"
                },
                
                new PieceData()
                {
                    Id = "B_3",
                    ViewSettingsId = "B_3",
                    Abilities = new []
                    {
                        new ProducerAbilityData()
                        {
                            Id = "Spawn_B_1_every_10s",
                            ActivationCondition = new TimerCondition()
                            {
                                IntervalSeconds = 0, // ASAP
                            },
                            SpawnId = "B_1",
                            InitialChargesCount = 1,
                            ChargesCapacity = 2,
                            RechargeCondition = new TimerCondition()
                            {
                                IntervalSeconds = 10,
                            }
                        }
                    }
                }
            };
        }

        public static Dictionary<string, PieceViewSettings> GetPieceViewSettings()
        {
            return new Dictionary<string, PieceViewSettings>()
            {
                {
                    "B_1",
                    new PieceViewSettings()
                    {
                        Color = "#102030FF",
                        Codename = "B_1"
                    }
                },
                {
                    "B_3",
                    new PieceViewSettings()
                    {
                        Color = "#102030FF",
                        Codename = "B_3"
                    }
                },
                
            };
        }
    }
}