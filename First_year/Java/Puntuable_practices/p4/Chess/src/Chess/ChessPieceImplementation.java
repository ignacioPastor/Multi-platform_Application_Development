//Ignacio Pastor Padilla - Entornos de Desarrollo Práctica 4 - DAM Semi A

package Chess;



public class ChessPieceImplementation implements ChessPiece{

    Color aColor;
    Type aType;
   // ChessPiece aPiece;
    boolean moved = false;
    //ChessPiece aPiece = new ChessPieceImplementation();
   // ChessPiece aPiece;
    
    public ChessPieceImplementation(){
      // moved = false;
          
    }
    
    public ChessPieceImplementation(Color aColor, Type aType){
        this.aColor = aColor;
        this.aType = aType;
    }
    
    @Override
    public Color getColor() {
        return aColor;
    }

    @Override
    public Type getType() {
        return aType;
    }
    
    /*
    @Override
    public void setType(Type aType){
        this.aType = aType;
    }
*/

    @Override
    public void notifyMoved() {
        moved = true;
    }

    @Override
    public boolean wasMoved() {
        return moved;
    }

    @Override
    public PiecePosition[] getAvailablePositions(ChessBoard aBoard) {
        PiecePosition[] availablePositions;
        switch(getType()){
            case QUEEN :
                availablePositions = ChessMovementManager.getAvailablePositionsOfQueen( this, aBoard);
                break;
            case PAWN :
                availablePositions = ChessMovementManager.getAvailablePositionsOfPawn( this, aBoard);
                break;
            case KNIGHT :
                availablePositions = ChessMovementManager.getAvailablePositionsOfKnight( this, aBoard);
                break;
            case BISHOP :
                availablePositions = ChessMovementManager.getAvailablePositionsOfBishop( this, aBoard);
                break;
            case KING :
                availablePositions = ChessMovementManager.getAvailablePositionsOfKing( this, aBoard);
                break;
            case ROOK :
                availablePositions = ChessMovementManager.getAvailablePositionsOfRook( this, aBoard);
                break;
            default: availablePositions = null;
        }
        return availablePositions;
    }
    
    
}