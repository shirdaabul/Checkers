using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Board
{
    private Cell[,] m_BoardMatrix;
    private readonly int m_NumOfRowsAndCols;

    public Board(int i_NumOfRowsAndCols)
    {
        this.m_BoardMatrix = new Cell[i_NumOfRowsAndCols, i_NumOfRowsAndCols];
        this.m_NumOfRowsAndCols = i_NumOfRowsAndCols;
        this.FillStartingMatrix(this);
    }

    public Cell[,] Matrix
    {
        get
        {
            return this.m_BoardMatrix;
        }

        set
        {
            this.m_BoardMatrix = value;
        }
    }

    public int NumOfRowsAndCols
    {
        get
        {
            return this.m_NumOfRowsAndCols;
        }
    }

    public void FillStartingMatrix(Board i_BoardToFill)
    {
        for (int i = 0; i < i_BoardToFill.NumOfRowsAndCols; ++i)
        {
            for (int j = 0; j < i_BoardToFill.NumOfRowsAndCols; ++j)
            {
                if ((i % 2) != (j % 2))
                {
                    if ((i == i_BoardToFill.NumOfRowsAndCols / 2) || (i == (i_BoardToFill.NumOfRowsAndCols / 2) - 1))
                    {
                        this.m_BoardMatrix[i, j].Status = eStatus.NotExistCoin;
                        this.m_BoardMatrix[i, j].Owner = eOwner.None;
                        this.m_BoardMatrix[i, j].Sign = eCoinSign.None;
                }
                else
                {
                    this.m_BoardMatrix[i, j].Status = eStatus.ExistCoin;
                    fillStartingCellSignAndOwner(i_BoardToFill, i, j);
                }
            }
                else
                {
                    this.m_BoardMatrix[i, j].Status = eStatus.Illegal;
                    this.m_BoardMatrix[i, j].Sign = eCoinSign.None;
                    this.m_BoardMatrix[i, j].Owner = eOwner.None;
                }
            }
        }
    }

    private void fillStartingCellSignAndOwner(Board i_BoardToFill, int i_Row, int i_Col)
    {
        if (i_Row < (i_BoardToFill.NumOfRowsAndCols / 2) - 1)
        {
            this.m_BoardMatrix[i_Row, i_Col].Sign = eCoinSign.PlayerO;
            this.m_BoardMatrix[i_Row, i_Col].Owner = eOwner.Player1;
        }
        else if (i_Row > (i_BoardToFill.NumOfRowsAndCols / 2))
        {
            this.m_BoardMatrix[i_Row, i_Col].Sign = eCoinSign.PlayerX;
            this.m_BoardMatrix[i_Row, i_Col].Owner = eOwner.Player2;
        }
    }
}