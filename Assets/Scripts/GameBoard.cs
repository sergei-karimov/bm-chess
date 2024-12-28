using Chess;
using UnityEngine;
using UnityEngine.UIElements;

public class GameBoard : MonoBehaviour {
    [SerializeField] private GameObject lightSquare;
    [SerializeField] private GameObject darkSquare;
    [SerializeField] private GameObject[] pieces;
    
    private GameObject _itemBeginDragged;
    private Vector3 _startPosition;

    void Start() {
        createGraphicalBoard();

        var board = new Board();
        board.initialState();
        drawPieces(board);
    }

    void Update() {
    }

    private void OnMouseDown() {
        _startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log($"OnMouseDown {_startPosition}");
    }

    private void OnMouseDrag() {
        Debug.Log($"OnMouseDrag {transform.position}");
    }

    private void OnMouseUp() {
        Debug.Log($"OnMouseUp {transform.position}");
    }
    
    void createGraphicalBoard() {
        for (var file = 0; file < 8; file++) {
            for (var rank = 0; rank < 8; rank++) {
                var isLightSquare = (file + rank) % 2 != 0;

                var squareColour = isLightSquare ? lightSquare : darkSquare;
                var position = new Vector2(-3.5f + file, -3.5f + rank);

                drawSquare(position, squareColour);
            }
        }
    }

    private void drawSquare(Vector2 position, GameObject squareColour) {
        Instantiate(squareColour, position, Quaternion.identity);
    }

    private void drawPieces(Board board) {
        for (var i = 0; i < board.squares.Length; i++) {
            var piece = board.squares[i];
            if (piece == 0) {
                continue;
            }

            var figure = Piece.getType(piece);
            var color = Piece.getColor(piece);

            var x = i % 8;
            var y = i / 8;

            drawPiece(new Vector3(x - 3.5f, y - 3.5f, -0.01f), figure, color);
        }
    }

    private void drawPiece(Vector3 position, int figure, int color) {
        switch (color) {
            case Piece.White:
                Instantiate(pieces[figure - 1], position, Quaternion.identity);
            break;
            case Piece.Black:
                Instantiate(pieces[figure + 5], position, Quaternion.identity);
            break;
        }
    }
}