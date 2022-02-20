using Merge.Board;
using Merge.Views.Piece;
using UnityEngine;

namespace Merge.Views.Cell
{
    public class CellView : MonoBehaviour
    {
        [SerializeField]
        private Transform cachedTransform;
        [SerializeField] 
        private PieceView piecePrefab;

        private CellCoordinates coords;
        private PieceView pieceView;

        public void Init(CellCoordinates coords)
        {
            this.coords = coords;
        }
        
        public void ClearPiece()
        {
            if (pieceView)
            {
                pieceView.enabled = false;
                pieceView.gameObject.SetActive(false);
            }
        }

        public void SpawnPiece()
        {
            if (pieceView)
            {
                if (pieceView.gameObject.activeSelf)
                {
                    Debug.LogError($"cell {coords} is already occupied. Can't spawn");    
                }
                pieceView.gameObject.SetActive(true);
                return;
            }

            pieceView = GameObject.Instantiate(piecePrefab, cachedTransform);
        }
    }
}