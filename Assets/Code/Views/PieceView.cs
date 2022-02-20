using Merge.Board;
using Merge.Storage;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Merge.Views.Piece
{
    public class PieceView : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private TextMeshProUGUI textTMPro;
        
        private IDataStorage dataStorage;
        private PieceInstance piece;

        public void Init(IDataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }

        public void SetInstance(PieceInstance pieceInstance)
        {
            this.piece = pieceInstance;
            RefreshView();
        }

        private void RefreshView()
        {
            var settings = dataStorage.GetPieceViewSettings(piece.ViewSettingsId);
            textTMPro.text = settings.Codename;
            ColorUtility.TryParseHtmlString(settings.Color, out var color);
            image.color = color;
        }
    }
}