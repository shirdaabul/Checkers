using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameProgress
{
    private Board m_GameBoard;
    private Player[] m_Players = new Player[2];
    private eOwner m_CurrentPlayerTurn;

    public GameProgress(int i_BoardSize, string i_FirstPlayerName, string m_SecondPlayerName, int i_NumOfPlayers)
    {
        this.m_GameBoard = new Board(i_BoardSize);
        int i_NumOfCoins = (i_BoardSize / 2) * ((i_BoardSize / 2) - 1);
        this.m_Players[0] = new Player(i_FirstPlayerName, eTypeOfPlayer.Human, i_NumOfCoins, eCoinSign.PlayerO);
        if (i_NumOfPlayers == 2)
        {
            this.m_Players[1] = new Player(m_SecondPlayerName, eTypeOfPlayer.Human, i_NumOfCoins, eCoinSign.PlayerX);
        }
        else
        {
            this.m_Players[1] = new Player(m_SecondPlayerName, eTypeOfPlayer.Computer, i_NumOfCoins, eCoinSign.PlayerX);
        }
        m_CurrentPlayerTurn = eOwner.Player1;
    }

    public Board GameBoard
    {
        get
        {
            return this.m_GameBoard;
        }

        set
        {
            this.m_GameBoard = value;
        }
    }

    public Player[] Players
    {
        get
        {
            return this.m_Players;
        }

        set
        {
            this.m_Players = value;
        }
    }

    public eOwner CurrentPlayerTurn
    {
        get
        {
            return this.m_CurrentPlayerTurn;
        }

        set
        {
            this.m_CurrentPlayerTurn = value;
        }
    }

    public eOwner ChangeTurn()
    {
        return m_CurrentPlayerTurn = (m_CurrentPlayerTurn == eOwner.Player1) ? eOwner.Player2 : eOwner.Player1;
    }

    public bool FillLigalMovesList()
    {
        eCoinSign i_CoinSign;
        this.Players[1].LigalMovesList = new List<SourceAndTargetMove>();

        for (int i = 0; i < this.GameBoard.NumOfRowsAndCols; i++)
        {
            for (int j = 0; j < this.GameBoard.NumOfRowsAndCols; j++)
            {
                i_CoinSign = this.GameBoard.Matrix[i, j].Sign;
                if (i_CoinSign == eCoinSign.PlayerX)
                {
                    checkIfExistRegularMoveAndFillMovesList(i, j);
                    fillMustEatMovesListDownToUp(i, j);
                }

                if (i_CoinSign == eCoinSign.PlayerXKing)
                {
                    checkIfExistRegularMoveAndFillMovesList(i, j);
                    fillMustEatMovesListDownToUp(i, j);
                    fillMustEatMovesListUpToDown(i, j);
                }
            }
        }

        return Players[1].LigalMovesList.Count > 0;
    }

    public eTypeOfMove DoMove(Point i_SourcePoint, Point i_TargetPoint)
    {
        eTypeOfMove i_MoveType = eTypeOfMove.IllegalMove;
        int[] i_Source = { i_SourcePoint.X, i_SourcePoint.Y };
        int[] i_Target = { i_TargetPoint.X, i_TargetPoint.Y };
        eCoinSign i_CoinSign = GameBoard.Matrix[i_Source[0], i_Source[1]].Sign;

        if (i_CoinSign == eCoinSign.PlayerX)
        {
            i_MoveType = moveDownToUp(i_Source, i_Target);
        }
        else if (i_CoinSign == eCoinSign.PlayerO)
        {
            i_MoveType = moveUpToDown(i_Source, i_Target);
        }
        else if ((i_CoinSign == eCoinSign.PlayerOKing) || (i_CoinSign == eCoinSign.PlayerXKing))
        {
            if (i_Source[0] > i_Target[0])
            {
                i_MoveType = moveDownToUp(i_Source, i_Target);
            }
            else
            {
                i_MoveType = moveUpToDown(i_Source, i_Target);
            }
        }

        return i_MoveType;
    }

    public void TryCreateKing(int[] i_Target)
    {
        if ((i_Target[0] == 0) && (GameBoard.Matrix[i_Target[0], i_Target[1]].Sign == eCoinSign.PlayerX))
        {
            GameBoard.Matrix[i_Target[0], i_Target[1]].Sign = eCoinSign.PlayerXKing;
        }
        else if ((i_Target[0] == GameBoard.NumOfRowsAndCols - 1) && (GameBoard.Matrix[i_Target[0], i_Target[1]].Sign == eCoinSign.PlayerO))
        {
            GameBoard.Matrix[i_Target[0], i_Target[1]].Sign = eCoinSign.PlayerOKing;
        }
    }

    public bool CheckIfExistsMoves(Player i_Player)
    {
        eCoinSign i_CoinSign;
        bool v_ThereAreMoves = false;

        for (int i = 0; i < GameBoard.NumOfRowsAndCols; i++)
        {
            for (int j = 0; j < GameBoard.NumOfRowsAndCols; j++)
            {
                i_CoinSign = GameBoard.Matrix[i, j].Sign;
                if ((i_CoinSign == i_Player.CoinSign) || i_CoinSign == i_Player.KingSign)
                {
                    v_ThereAreMoves = checkIfCanMove(GameBoard.Matrix[i, j].Owner, i, j) || v_ThereAreMoves;
                }
            }
        }

        return v_ThereAreMoves;
    }

    public void UpdateScore(eOwner i_TheWinner)
    {
        int i_NumberOfWinner = (int)i_TheWinner;
        int i_PlayerOneScore = 0;
        int i_PlayerTwoScore = 0;

        for (int i = 0; i < GameBoard.NumOfRowsAndCols; ++i)
        {
            for (int j = 0; j < GameBoard.NumOfRowsAndCols; ++j)
            {
                if (GameBoard.Matrix[i, j].Sign == eCoinSign.PlayerX)
                {
                    i_PlayerTwoScore++;
                }
                else if (GameBoard.Matrix[i, j].Sign == eCoinSign.PlayerXKing)
                {
                    i_PlayerTwoScore += 4;
                }
                else if (GameBoard.Matrix[i, j].Sign == eCoinSign.PlayerO)
                {
                    i_PlayerOneScore++;
                }
                else if (GameBoard.Matrix[i, j].Sign == eCoinSign.PlayerOKing)
                {
                    i_PlayerOneScore += 4;
                }
            }
        }

        if (i_PlayerOneScore > i_PlayerTwoScore)
        {
            Players[i_NumberOfWinner].Score += i_PlayerOneScore - i_PlayerTwoScore;
        }

        if (i_PlayerOneScore < i_PlayerTwoScore)
        {
            Players[i_NumberOfWinner].Score += i_PlayerTwoScore - i_PlayerOneScore;
        }
    }

    public eOwner Winner()
    {
        eOwner i_TheWinner = eOwner.None;

        if (!CheckIfExistsMoves(Players[0]) && !CheckIfExistsMoves(Players[1]))
        {
            i_TheWinner = eOwner.None;
        }
        else
        {
            i_TheWinner = CheckIfExistsMoves(Players[0]) ? eOwner.Player1 : eOwner.Player2;
        }

        return i_TheWinner;
    }

    public eTypeOfMove ComputerMove(out SourceAndTargetMove io_SourceAndTargetMove, out SourceAndTargetMove io_MoreSkipMove)
    {
        int i_MoveListIndex = 0;
        int i_MoveListLengh = Players[1].LigalMovesList.Count;
        int[] i_ArrayTarget = new int[2];
        eTypeOfMove i_MoveType;

        io_MoreSkipMove = null;
        do
        {
            i_MoveType = Players[1].LigalMovesList[i_MoveListIndex].TypeOfMove;
            i_MoveListIndex++;
        } while ((i_MoveType != eTypeOfMove.CanMoreSkip) && (i_MoveListIndex < i_MoveListLengh));

        if (i_MoveType == eTypeOfMove.CanMoreSkip)
        {
            makeMove(i_MoveListIndex - 1);
            i_ArrayTarget[0] = Players[1].LigalMovesList[i_MoveListIndex - 1].RowTarget;
            i_ArrayTarget[1] = Players[1].LigalMovesList[i_MoveListIndex - 1].ColTarget;
            io_SourceAndTargetMove = Players[1].LigalMovesList[i_MoveListIndex - 1];
            TryCreateKing(i_ArrayTarget);
            moreSkipComputerMove(i_ArrayTarget[0], i_ArrayTarget[1], out io_MoreSkipMove);
        }
        else
        {
            i_MoveListIndex = 0;
            do
            {
                i_MoveType = Players[1].LigalMovesList[i_MoveListIndex].TypeOfMove;
                i_MoveListIndex++;
            } while ((i_MoveType != eTypeOfMove.MustToEat) && (i_MoveListIndex < i_MoveListLengh));

            if (i_MoveType != eTypeOfMove.MustToEat)
            {
                i_MoveType = eTypeOfMove.RegularMove;
                Random rndom = new Random();
                i_MoveListIndex = rndom.Next(0, i_MoveListLengh - 1) + 1;
            }

            makeMove(i_MoveListIndex - 1);
            io_SourceAndTargetMove = Players[1].LigalMovesList[i_MoveListIndex - 1];
            i_ArrayTarget[0] = io_SourceAndTargetMove.RowTarget;
            i_ArrayTarget[1] = io_SourceAndTargetMove.ColTarget;
            TryCreateKing(i_ArrayTarget);
        }

        return i_MoveType;
    }

    private void makeMove(int i_IndexListMove)
    {
        int i_RowSorcue = Players[1].LigalMovesList[i_IndexListMove].RowSorcue;
        int i_ColSorcue = Players[1].LigalMovesList[i_IndexListMove].ColSorcue;
        int i_RowTarget = Players[1].LigalMovesList[i_IndexListMove].RowTarget;
        int i_ColTarget = Players[1].LigalMovesList[i_IndexListMove].ColTarget;
        int[] i_Sorcue = { i_RowSorcue, i_ColSorcue };
        int[] i_Target = { i_RowTarget, i_ColTarget };

        updateSourceAndTargetCells(i_Sorcue, i_Target);
        if (Players[1].LigalMovesList[i_IndexListMove].TypeOfMove != eTypeOfMove.RegularMove)
        {
            resetCell(Players[1].LigalMovesList[i_IndexListMove].RowEaten, Players[1].LigalMovesList[i_IndexListMove].ColEaten);
        }
    }

    private eTypeOfMove moveUpToDown(int[] i_Source, int[] i_Terget)
    {
        eTypeOfMove i_MoveType = eTypeOfMove.IllegalMove;
        eOwner i_CurPlayerOwner = GameBoard.Matrix[i_Source[0], i_Source[1]].Owner;

        if ((i_Terget[0] - 1 == i_Source[0]) && ((i_Source[1] == i_Terget[1] + 1) || (i_Source[1] == i_Terget[1] - 1)))
        {
            if (checkIfMustToEat(i_CurPlayerOwner))
            {
                i_MoveType = eTypeOfMove.MustToEat;
            }
            else
            {
                i_MoveType = eTypeOfMove.RegularMove;
                updateSourceAndTargetCells(i_Source, i_Terget);
            }
        }
        else if ((i_Terget[0] - 2 == i_Source[0]) && (i_Source[1] == i_Terget[1] - 2))
        {
            eOwner i_EatenOwner = GameBoard.Matrix[(i_Source[0] + 1), (i_Source[1] + 1)].Owner;
            if ((i_EatenOwner != i_CurPlayerOwner) && (i_EatenOwner != eOwner.None))

            {
                i_MoveType = eatAndUpdateCellMoveUpToDown(i_MoveType, i_Source, i_Terget, i_Source[1] + 1);
            }
        }
        else if ((i_Terget[0] - 2 == i_Source[0]) && (i_Source[1] == i_Terget[1] + 2))
        {
            eOwner i_EatenOwner = GameBoard.Matrix[(i_Source[0] + 1), (i_Source[1] - 1)].Owner;
            if ((i_EatenOwner != i_CurPlayerOwner) && (i_EatenOwner != eOwner.None))
            {
                i_MoveType = eatAndUpdateCellMoveUpToDown(i_MoveType, i_Source, i_Terget, i_Source[1] - 1);
            }
        }

        return i_MoveType;
    }

    private eTypeOfMove moveDownToUp(int[] i_Source, int[] i_Terget)
    {
        eTypeOfMove i_MoveType = eTypeOfMove.IllegalMove;
        eOwner i_CurPlayer = GameBoard.Matrix[i_Source[0], i_Source[1]].Owner;

        if ((i_Terget[0] + 1 == i_Source[0]) && ((i_Source[1] == i_Terget[1] + 1) || (i_Source[1] == i_Terget[1] - 1)))
        {
            if (checkIfMustToEat(i_CurPlayer))
            {
                i_MoveType = eTypeOfMove.MustToEat;
            }
            else
            {
                i_MoveType = eTypeOfMove.RegularMove;
                updateSourceAndTargetCells(i_Source, i_Terget);
            }
        }
        else if ((i_Terget[0] + 2 == i_Source[0]) && (i_Source[1] == i_Terget[1] - 2))
        {
            eOwner i_EatenOwner = GameBoard.Matrix[(i_Source[0] - 1), (i_Source[1] + 1)].Owner;
            if ((i_EatenOwner != i_CurPlayer) && (i_EatenOwner != eOwner.None))
            {
                i_MoveType = eatAndUpdateCellMoveDownToUp(i_MoveType, i_Source, i_Terget, i_Source[1] + 1);
            }
        }
        else if ((i_Terget[0] + 2 == i_Source[0]) && (i_Source[1] == i_Terget[1] + 2))
        {
            eOwner i_EatenOwner = GameBoard.Matrix[(i_Source[0] - 1), (i_Source[1] - 1)].Owner;
            if ((i_EatenOwner != i_CurPlayer) && (i_EatenOwner != eOwner.None))
            {
                i_MoveType = eatAndUpdateCellMoveDownToUp(i_MoveType, i_Source, i_Terget, i_Source[1] - 1);
            }
        }

        return i_MoveType;
    }

    private void resetCell(int i_Row, int i_Col)
    {
        GameBoard.Matrix[i_Row, i_Col].Sign = eCoinSign.None;
        GameBoard.Matrix[i_Row, i_Col].Owner = eOwner.None;
        GameBoard.Matrix[i_Row, i_Col].Status = eStatus.NotExistCoin;
    }

    private void updateSourceAndTargetCells(int[] i_Source, int[] i_Terget)
    {
        GameBoard.Matrix[i_Terget[0], i_Terget[1]].Status = eStatus.ExistCoin;
        GameBoard.Matrix[i_Source[0], i_Source[1]].Status = eStatus.NotExistCoin;
        GameBoard.Matrix[i_Terget[0], i_Terget[1]].Sign = GameBoard.Matrix[i_Source[0], i_Source[1]].Sign;
        GameBoard.Matrix[i_Source[0], i_Source[1]].Sign = eCoinSign.None;
        GameBoard.Matrix[i_Terget[0], i_Terget[1]].Owner = GameBoard.Matrix[i_Source[0], i_Source[1]].Owner;
        GameBoard.Matrix[i_Source[0], i_Source[1]].Owner = eOwner.None;
    }

    private void moreSkipComputerMove(int RowSorcue, int colSorcue, out SourceAndTargetMove io_SourceAndTargetMoreMove)
    {
        int i_IndexListMove = 0;
        int i_RowSorcueFromList;
        int i_ColSorcueFromList;
        eTypeOfMove i_TypeOfMoveFromList;

        FillLigalMovesList();
        do
        {
            i_TypeOfMoveFromList = Players[1].LigalMovesList[i_IndexListMove].TypeOfMove;
            i_RowSorcueFromList = Players[1].LigalMovesList[i_IndexListMove].RowSorcue;
            i_ColSorcueFromList = Players[1].LigalMovesList[i_IndexListMove].ColSorcue;
            i_IndexListMove++;
        } while ((i_RowSorcueFromList != RowSorcue) || (i_ColSorcueFromList != colSorcue) || (i_TypeOfMoveFromList == eTypeOfMove.RegularMove));

        makeMove(i_IndexListMove - 1);
        io_SourceAndTargetMoreMove = Players[1].LigalMovesList[i_IndexListMove - 1];
        if (io_SourceAndTargetMoreMove.TypeOfMove == eTypeOfMove.CanMoreSkip)
        {
            moreSkipComputerMove(io_SourceAndTargetMoreMove.RowTarget, io_SourceAndTargetMoreMove.ColTarget, out io_SourceAndTargetMoreMove);
        }

        int[] i_Target = { io_SourceAndTargetMoreMove.RowTarget, io_SourceAndTargetMoreMove.ColTarget };
        TryCreateKing(i_Target);
    }

    private bool checkIfExistRegularMoveAndFillMovesList(int i_Row, int i_Col)
    {
        bool v_CanMove = false;
        eCoinSign i_CurSign = GameBoard.Matrix[i_Row, i_Col].Sign;
        eStatus i_NotExistCoin = eStatus.NotExistCoin;
        eStatus i_UpRightCell = (i_Row > 0 && i_Col < GameBoard.NumOfRowsAndCols - 1) ? GameBoard.Matrix[i_Row - 1, i_Col + 1].Status : eStatus.Illegal;
        eStatus i_UpLeftCell = (i_Row > 0 && i_Col > 0) ? GameBoard.Matrix[i_Row - 1, i_Col - 1].Status : eStatus.Illegal;
        eStatus i_DownRightCell = (i_Row < GameBoard.NumOfRowsAndCols - 1 && i_Col < GameBoard.NumOfRowsAndCols - 1) ? GameBoard.Matrix[i_Row + 1, i_Col + 1].Status : eStatus.Illegal;
        eStatus i_DownLeftCell = (i_Row < GameBoard.NumOfRowsAndCols - 1 && i_Col > 0) ? GameBoard.Matrix[i_Row + 1, i_Col - 1].Status : eStatus.Illegal;

        if (i_CurSign == eCoinSign.PlayerO)
        {
            v_CanMove = i_DownLeftCell == i_NotExistCoin || i_DownRightCell == i_NotExistCoin;
        }

        if (i_CurSign == eCoinSign.PlayerX)
        {
            v_CanMove = i_UpLeftCell == i_NotExistCoin || i_UpRightCell == i_NotExistCoin;
        }

        if ((i_CurSign == eCoinSign.PlayerXKing) || (i_CurSign == eCoinSign.PlayerOKing))
        {
            v_CanMove = i_UpLeftCell == i_NotExistCoin || i_UpRightCell == i_NotExistCoin || i_DownLeftCell == i_NotExistCoin || i_DownRightCell == i_NotExistCoin;
        }

        if ((GameBoard.Matrix[i_Row, i_Col].Owner == eOwner.Player2) && (Players[1].TypeOfPlayer == eTypeOfPlayer.Computer))
        {
            if (i_UpLeftCell == i_NotExistCoin)
            {
                Players[1].LigalMovesList.Add(new SourceAndTargetMove(i_Row, i_Col, i_Row - 1, i_Col - 1, -1, -1, eTypeOfMove.RegularMove));
            }

            if (i_UpRightCell == i_NotExistCoin)
            {
                Players[1].LigalMovesList.Add(new SourceAndTargetMove(i_Row, i_Col, i_Row - 1, i_Col + 1, -1, -1, eTypeOfMove.RegularMove));
            }

            if (i_CurSign == eCoinSign.PlayerXKing)
            {
                if (i_DownLeftCell == i_NotExistCoin)
                {
                    Players[1].LigalMovesList.Add(new SourceAndTargetMove(i_Row, i_Col, i_Row + 1, i_Col - 1, -1, -1, eTypeOfMove.RegularMove));
                }

                if (i_DownRightCell == i_NotExistCoin)
                {
                    Players[1].LigalMovesList.Add(new SourceAndTargetMove(i_Row, i_Col, i_Row + 1, i_Col + 1, -1, -1, eTypeOfMove.RegularMove));
                }
            }
        }

        return v_CanMove;
    }

    private bool checkIfCanMove(eOwner i_CurOwner, int i_Row, int i_Col)
    {
        bool v_CanMove = false;
        eCoinSign i_CurSign = GameBoard.Matrix[i_Row, i_Col].Sign;

        if (i_CurSign == eCoinSign.PlayerO)
        {
            v_CanMove = checkIfMustToEatUpToDown(i_CurOwner, i_Row, i_Col) || checkIfExistRegularMoveAndFillMovesList(i_Row, i_Col);
        }

        if (i_CurSign == eCoinSign.PlayerX)
        {
            v_CanMove = checkIfMustToEatDownToUp(i_CurOwner, i_Row, i_Col) || checkIfExistRegularMoveAndFillMovesList(i_Row, i_Col);
        }

        if ((i_CurSign == eCoinSign.PlayerXKing) || (i_CurSign == eCoinSign.PlayerOKing))
        {
            v_CanMove = checkIfMustToEatUpToDown(i_CurOwner, i_Row, i_Col) || checkIfMustToEatDownToUp(i_CurOwner, i_Row, i_Col) || checkIfExistRegularMoveAndFillMovesList(i_Row, i_Col);
        }

        return v_CanMove;
    }

    private eTypeOfMove eatAndUpdateCellMoveUpToDown(eTypeOfMove i_MoveType, int[] i_Source, int[] i_Terget, int i_ColSource)
    {
        resetCell(i_Source[0] + 1, i_ColSource);
        updateSourceAndTargetCells(i_Source, i_Terget);
        eCoinSign i_CurrentPlayer = GameBoard.Matrix[i_Terget[0], i_Terget[1]].Sign;
        eOwner i_CurrentOwner = GameBoard.Matrix[i_Terget[0], i_Terget[1]].Owner;

        if (i_CurrentPlayer == eCoinSign.PlayerO)
        {
            i_MoveType = checkIfMustToEatUpToDown(i_CurrentOwner, i_Terget[0], i_Terget[1]) ? eTypeOfMove.CanMoreSkip : eTypeOfMove.SkipMove;
        }

        if ((i_CurrentPlayer == eCoinSign.PlayerXKing) || (i_CurrentPlayer == eCoinSign.PlayerOKing))
        {
            i_MoveType = checkIfMustToEatUpToDown(i_CurrentOwner, i_Terget[0], i_Terget[1]) || checkIfMustToEatDownToUp(i_CurrentOwner, i_Terget[0], i_Terget[1]) ? eTypeOfMove.CanMoreSkip : eTypeOfMove.SkipMove;
        }

        return i_MoveType;
    }

    private eTypeOfMove eatAndUpdateCellMoveDownToUp(eTypeOfMove i_MoveType, int[] i_Source, int[] i_Terget, int i_ColSource)
    {
        resetCell(i_Source[0] - 1, i_ColSource);
        updateSourceAndTargetCells(i_Source, i_Terget);
        eCoinSign i_CurrentPlayer = GameBoard.Matrix[i_Terget[0], i_Terget[1]].Sign;
        eOwner i_CurrentOwner = GameBoard.Matrix[i_Terget[0], i_Terget[1]].Owner;

        if (i_CurrentPlayer == eCoinSign.PlayerX) 
        {
            i_MoveType = checkIfMustToEatDownToUp(i_CurrentOwner, i_Terget[0], i_Terget[1]) ? eTypeOfMove.CanMoreSkip : eTypeOfMove.SkipMove;
        }

        if ((i_CurrentPlayer == eCoinSign.PlayerXKing) || (i_CurrentPlayer == eCoinSign.PlayerOKing))
        {
            i_MoveType = checkIfMustToEatUpToDown(i_CurrentOwner, i_Terget[0], i_Terget[1]) || checkIfMustToEatDownToUp(i_CurrentOwner, i_Terget[0], i_Terget[1]) ? eTypeOfMove.CanMoreSkip : eTypeOfMove.SkipMove;
        }

        return i_MoveType;
    }
    private bool checkIfMustToEat(eOwner i_CurPlayer)
    {
        eCoinSign i_CoinSign;
        bool v_MustToEat = false;

        for (int i = 0; i < GameBoard.NumOfRowsAndCols; i++)
        {
            for (int j = 0; j < GameBoard.NumOfRowsAndCols; j++)
            {
                i_CoinSign = GameBoard.Matrix[i, j].Sign;
                if (GameBoard.Matrix[i, j].Owner == i_CurPlayer)
                {
                    if (i_CoinSign == eCoinSign.PlayerX)
                    {
                        v_MustToEat = checkIfMustToEatDownToUp(i_CurPlayer, i, j) || v_MustToEat;
                    }
                    else if (i_CoinSign == eCoinSign.PlayerO)
                    {
                        v_MustToEat = checkIfMustToEatUpToDown(i_CurPlayer, i, j) || v_MustToEat;
                    }
                    else if ((i_CoinSign == eCoinSign.PlayerXKing) || (i_CoinSign == eCoinSign.PlayerOKing))
                    {
                        v_MustToEat = checkIfMustToEatDownToUp(i_CurPlayer, i, j) || checkIfMustToEatUpToDown(i_CurPlayer, i, j) || v_MustToEat;
                    }
                }
            }
        }

        return v_MustToEat;
    }

    private bool checkIfMustToEatUpToDown(eOwner i_CurOwner, int i_Row, int i_Col)
    {
        return checkIfMustToEatUpToDownRight(i_CurOwner, i_Row, i_Col) || checkIfMustToEatUpToDownLeft(i_CurOwner, i_Row, i_Col);
    }

    private bool checkIfMustToEatUpToDownRight(eOwner i_CurOwner, int i_RowSource, int i_ColSource)
    {
        bool v_checkIfMustToEatUpToDownRight = false;

        if ((i_ColSource < GameBoard.NumOfRowsAndCols - 2) && (i_RowSource < GameBoard.NumOfRowsAndCols - 2))
        {
            v_checkIfMustToEatUpToDownRight = checkMustToEatCells(i_CurOwner, i_RowSource + 1, i_ColSource + 1, i_RowSource + 2, i_ColSource + 2);
        }

        return v_checkIfMustToEatUpToDownRight;
    }

    private bool checkIfMustToEatUpToDownLeft(eOwner i_CurOwner, int i_RowSource, int i_ColSource)
    {
        bool v_checkIfMustToEatUpToDownLeft = false;

        if ((i_ColSource > 1) && (i_RowSource < GameBoard.NumOfRowsAndCols - 2))
        {
            v_checkIfMustToEatUpToDownLeft = checkMustToEatCells(i_CurOwner, i_RowSource + 1, i_ColSource - 1, i_RowSource + 2, i_ColSource - 2);
        }

        return v_checkIfMustToEatUpToDownLeft;
    }

    private bool checkIfMustToEatDownToUp(eOwner i_CurOwner, int i_RowSource, int i_ColSource)
    {
        return checkIfMustToEatDownToUpRight(i_CurOwner, i_RowSource, i_ColSource) || checkIfMustToEatDownToUpLeft(i_CurOwner, i_RowSource, i_ColSource);
    }

    private bool checkIfMustToEatDownToUpRight(eOwner i_CurOwner, int i_RowSource, int i_ColSource)
    {
        bool v_checkIfMustToEatDownToUpRight = false;

        if ((i_ColSource < GameBoard.NumOfRowsAndCols - 2) && (i_RowSource >= 2))
        {
            v_checkIfMustToEatDownToUpRight = checkMustToEatCells(i_CurOwner, i_RowSource - 1, i_ColSource + 1, i_RowSource - 2, i_ColSource + 2);
        }

        return v_checkIfMustToEatDownToUpRight;
    }

    private bool checkIfMustToEatDownToUpLeft(eOwner i_CurOwner, int i_RowSource, int i_ColSource)
    {
        bool v_checkIfMustToEatDownToUpLeft = false;

        if ((i_ColSource >= 2) && (i_RowSource >= 2))
        {
            v_checkIfMustToEatDownToUpLeft = checkMustToEatCells(i_CurOwner, i_RowSource - 1, i_ColSource - 1, i_RowSource - 2, i_ColSource - 2);
        }

        return v_checkIfMustToEatDownToUpLeft;
    }

    private bool checkMustToEatCells(eOwner I_CurOwner, int i_EatenCellRow, int i_EatenCellCol, int i_TargetCellRow, int i_TargetCellCol)
    {
        bool v_CheckMustToEatBounds = false;

        if ((I_CurOwner != GameBoard.Matrix[i_EatenCellRow, i_EatenCellCol].Owner) && (GameBoard.Matrix[i_EatenCellRow, i_EatenCellCol].Owner != eOwner.None))
        {
            v_CheckMustToEatBounds = GameBoard.Matrix[i_TargetCellRow, i_TargetCellCol].Status == eStatus.NotExistCoin;
        }

        return v_CheckMustToEatBounds;
    }

    private void fillMustEatMovesListUpToDown(int i_RowSource, int i_ColSource)
    {
        eOwner i_CurOwner = GameBoard.Matrix[i_RowSource, i_ColSource].Owner;
        eTypeOfMove i_MoveType = eTypeOfMove.MustToEat;
        eCoinSign i_CoinSign = GameBoard.Matrix[i_RowSource, i_ColSource].Sign;

        if (checkIfMustToEatUpToDownRight(i_CurOwner, i_RowSource, i_ColSource))
        {
            i_MoveType = checkIfMustToEatDownToUp(i_CurOwner, i_RowSource + 2, i_ColSource + 2) || checkIfMustToEatUpToDown(i_CurOwner, i_RowSource + 2, i_ColSource + 2) ? eTypeOfMove.CanMoreSkip : eTypeOfMove.MustToEat;
            Players[1].LigalMovesList.Add(new SourceAndTargetMove(i_RowSource, i_ColSource, i_RowSource + 2, i_ColSource + 2, i_RowSource + 1, i_ColSource + 1, i_MoveType));
        }

        if (checkIfMustToEatUpToDownLeft(i_CurOwner, i_RowSource, i_ColSource))
        {
            i_MoveType = checkIfMustToEatDownToUp(i_CurOwner, i_RowSource + 2, i_ColSource - 2) || checkIfMustToEatUpToDown(i_CurOwner, i_RowSource + 2, i_ColSource - 2) ? eTypeOfMove.CanMoreSkip : eTypeOfMove.MustToEat;
            Players[1].LigalMovesList.Add(new SourceAndTargetMove(i_RowSource, i_ColSource, i_RowSource + 2, i_ColSource - 2, i_RowSource + 1, i_ColSource - 1, i_MoveType));
        }
    }

    private void fillMustEatMovesListDownToUp(int i_RowSource, int i_ColSource)
    {
        eOwner i_CurOwner = GameBoard.Matrix[i_RowSource, i_ColSource].Owner;
        eTypeOfMove i_MoveType = eTypeOfMove.MustToEat;
        eCoinSign i_CoinSign = GameBoard.Matrix[i_RowSource, i_ColSource].Sign;

        if (checkIfMustToEatDownToUpRight(i_CurOwner, i_RowSource, i_ColSource))
        {
            if (i_CoinSign == eCoinSign.PlayerX)
            {
                i_MoveType = checkIfMustToEatDownToUp(i_CurOwner, i_RowSource - 2, i_ColSource + 2) ? eTypeOfMove.CanMoreSkip : eTypeOfMove.MustToEat;
            }

            if ((i_CoinSign == eCoinSign.PlayerXKing) || (i_RowSource - 2 == 0))
            {
                i_MoveType = checkIfMustToEatDownToUp(i_CurOwner, i_RowSource - 2, i_ColSource + 2) || checkIfMustToEatUpToDown(i_CurOwner, i_RowSource - 2, i_ColSource + 2) ? eTypeOfMove.CanMoreSkip : eTypeOfMove.MustToEat;
            }

            Players[1].LigalMovesList.Add(new SourceAndTargetMove(i_RowSource, i_ColSource, i_RowSource - 2, i_ColSource + 2, i_RowSource - 1, i_ColSource + 1, i_MoveType));
        }

        if (checkIfMustToEatDownToUpLeft(i_CurOwner, i_RowSource, i_ColSource))
        {
            if (i_CoinSign == eCoinSign.PlayerX)
            {
                i_MoveType = checkIfMustToEatDownToUp(i_CurOwner, i_RowSource - 2, i_ColSource - 2) ? eTypeOfMove.CanMoreSkip : eTypeOfMove.MustToEat;
            }

            if ((i_CoinSign == eCoinSign.PlayerXKing) || (i_RowSource - 2 == 0))
            {
                i_MoveType = checkIfMustToEatDownToUp(i_CurOwner, i_RowSource - 2, i_ColSource - 2) || checkIfMustToEatUpToDown(i_CurOwner, i_RowSource - 2, i_ColSource - 2) ? eTypeOfMove.CanMoreSkip : eTypeOfMove.MustToEat;
            }

            Players[1].LigalMovesList.Add(new SourceAndTargetMove(i_RowSource, i_ColSource, i_RowSource - 2, i_ColSource - 2, i_RowSource - 1, i_ColSource - 1, i_MoveType));
        }
    }
}