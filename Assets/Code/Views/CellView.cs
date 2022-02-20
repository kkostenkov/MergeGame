using Merge.Board;
using Merge.Storage;
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

        private IDataStorage dataStorage;
        private CellCoordinates coords;
        private PieceView pieceView;
        

        public void Init(CellCoordinates coords, IDataStorage dataStorage)
        {
            this.coords = coords;
            this.dataStorage = dataStorage;
        }
        
        public void ClearPiece()
        {
            if (pieceView)
            {
                pieceView.enabled = false;
                pieceView.gameObject.SetActive(false);
            }
        }

        public void SpawnPiece(PieceInstance piece)
        {
            if (pieceView)
            {
                if (pieceView.gameObject.activeSelf)
                {
                    Debug.LogError($"cell {coords} is already occupied. Can't spawn");
                }
                pieceView.gameObject.SetActive(true);
            }
            else
            {
                pieceView = GameObject.Instantiate(piecePrefab, cachedTransform);
                pieceView.Init(dataStorage);    
            }

            pieceView.SetInstance(piece);
        }
    }
}