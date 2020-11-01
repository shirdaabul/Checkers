using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnglishCheckersUI
{
    public partial class FormBoard : Form
    {
        private const int k_ButtonSize = 60;
        private const int k_MarginWidth = 30;
        private const int k_MarginHeight = 15;
        private readonly GameProgress m_Game;
        private eOwner m_Playerturn;
        private eOwner m_TheWinner;
        private ButtonPoint[,] m_BoardCells = null;
        private ButtonPoint m_PressButton;
        private bool m_IsAnotherButtonPress = false;
        private bool v_CanMoreSkip = false;

        public FormBoard(GameProgress i_gameProgress)
        {
            this.m_Playerturn = eOwner.Player1;
            this.m_Game = i_gameProgress;
            this.InitializeComponent();
            this.LabelScorePlayer1.Text = "0";
            this.LabelScorePlayer2.Text = "0";
            this.Player1Name.Text = m_Game.Players[0].Name;
            this.Player2Name.Text = m_Game.Players[1].Name;
            this.initializeBoard((int)this.m_Game.GameBoard.NumOfRowsAndCols);
        }

        private static string getWinnersString(GameProgress i_Game, eOwner i_TheWinner)
        {
            string i_winnerNameStr;

            if (i_TheWinner == eOwner.None)
            {
                i_winnerNameStr = "Tie!";
            }
            else
            {
                i_winnerNameStr = "The winner is: " + i_Game.Players[(int)i_TheWinner].Name;
            }

            return i_winnerNameStr;
        }

        private void initializeBoard(int i_BoardSize)
        {
            this.m_BoardCells = new ButtonPoint[i_BoardSize, i_BoardSize];
            this.ClientSize = new Size((i_BoardSize * k_ButtonSize) + k_MarginWidth, (i_BoardSize * k_ButtonSize) + k_MarginHeight + panelBoard.Top);
            for (int i_Row = 0; i_Row < i_BoardSize; i_Row++) 
            {
                for (int i_Col = 0; i_Col < i_BoardSize; i_Col++)
                {
                    this.m_BoardCells[i_Row, i_Col] = new ButtonPoint(i_Row, i_Col);
                    this.m_BoardCells[i_Row, i_Col].Size = new Size(k_ButtonSize, k_ButtonSize);
                    this.m_BoardCells[i_Row, i_Col].initializeButtonPointDetails(m_Game);
                    this.m_BoardCells[i_Row, i_Col].Click += doWhenButtonClicked;
                    this.panelBoard.Controls.Add(m_BoardCells[i_Row, i_Col]);
                    if ((m_Game.GameBoard.Matrix[i_Row, i_Col].Owner != m_Playerturn) && (m_Game.GameBoard.Matrix[i_Row, i_Col].Owner != eOwner.None))
                    {
                        this.m_BoardCells[i_Row, i_Col].Enabled = false;
                    }
                }
            }

            m_PressButton = m_BoardCells[1, 0];
        }

        private void doWhenButtonClicked(object sender, EventArgs e)
        {
            eTypeOfMove i_TypeOfMove;
            ButtonPoint i_CurrentBtn = sender as ButtonPoint;

            if (m_IsAnotherButtonPress)
            {
                if (m_Game.GameBoard.Matrix[i_CurrentBtn.PointLocation.X, i_CurrentBtn.PointLocation.Y].Status != eStatus.NotExistCoin)
                {
                    if (i_CurrentBtn != m_PressButton)
                    {
                        if (this.v_CanMoreSkip)
                        {
                            showWarningMessage("You must eat again with the coin that made eating");
                        }
                        else
                        {
                            showWarningMessage("Illegal Target!");
                        }
                    }

                    m_PressButton.BackColor = Color.White;
                }
                else
                {
                    i_TypeOfMove = m_Game.DoMove(m_PressButton.PointLocation, i_CurrentBtn.PointLocation);
                    if (i_TypeOfMove == eTypeOfMove.IllegalMove)
                    {
                        if (this.v_CanMoreSkip)
                        {
                            showWarningMessage("You must eat again with the coin that made eating");
                        }
                        else
                        {
                            showWarningMessage("Illegal Move!");
                        }
                    }
                    else if (i_TypeOfMove == eTypeOfMove.MustToEat)
                    {
                        showWarningMessage("You Must To Eat!");
                    }
                    else if (i_TypeOfMove == eTypeOfMove.CanMoreSkip)
                    {
                        int[] target = { i_CurrentBtn.PointLocation.X, i_CurrentBtn.PointLocation.Y };
                        m_Game.TryCreateKing(target);
                        this.v_CanMoreSkip = true;
                        m_PressButton = i_CurrentBtn;
                    }
                    else
                    {
                        int[] target = { i_CurrentBtn.PointLocation.X, i_CurrentBtn.PointLocation.Y };
                        m_Game.TryCreateKing(target);
                        m_Playerturn = m_Game.ChangeTurn();
                        doMoveIFComputerTurn();
                        updatePlayerTurnLabel();
                        checkEndGame();
                        this.v_CanMoreSkip = false;
                    }

                    updateBoard();
                }

                if (this.v_CanMoreSkip)
                {
                    m_PressButton.BackColor = Color.LightBlue;
                }
                else
                {
                    m_PressButton = null;
                    m_IsAnotherButtonPress = false;
                }
            }
            else
            {
                if (m_Playerturn == m_Game.GameBoard.Matrix[i_CurrentBtn.PointLocation.X, i_CurrentBtn.PointLocation.Y].Owner)
                {
                    m_PressButton = i_CurrentBtn;
                    m_PressButton.BackColor = Color.LightBlue;
                    m_IsAnotherButtonPress = true;
                }
                else
                {
                    showWarningMessage("Not your coin!");
                }
            }
        }

        private void updatePlayerTurnLabel()
        {
            if (m_Playerturn == eOwner.Player1) 
            {
                YourTurnLabel1.Visible = true;
                YourTurnLabel2.Visible = false;
            }
            else
            {
                YourTurnLabel2.Visible = true;
                YourTurnLabel1.Visible = false;
            }
        }

        private void doMoveIFComputerTurn()
        {
            if (m_Game.Players[(int)m_Playerturn].TypeOfPlayer == eTypeOfPlayer.Computer)
            {
                m_Game.FillLigalMovesList();
                SourceAndTargetMove io_SourceAndTargetMove, io_MoreSkipMove;
                m_Game.ComputerMove(out io_SourceAndTargetMove, out io_MoreSkipMove);
                updateBoard();
                m_Playerturn = m_Game.ChangeTurn();
            }
        }

        private void checkEndGame()
        {
            if (!m_Game.CheckIfExistsMoves(m_Game.Players[(int)m_Playerturn]))
            {
                m_TheWinner = m_Game.Winner();
                endGameRound(m_Game, m_TheWinner);
            }
        }

        private void endGameRound(GameProgress m_Game, eOwner m_TheWinner)
        {
            string i_WinnerName = null;
            if (m_TheWinner != eOwner.None)
            {
                m_Game.UpdateScore(m_TheWinner);
            }

            i_WinnerName = getWinnersString(m_Game, m_TheWinner);
            dialogGameRound(i_WinnerName);
        }

        private void updateScoreWinner()
        {
            if (m_TheWinner == eOwner.Player1)
            {
                LabelScorePlayer1.Text = m_Game.Players[0].Score.ToString();
            }
            else if (m_TheWinner == eOwner.Player2)
            {
                LabelScorePlayer2.Text = m_Game.Players[1].Score.ToString();
            }
        }

        private void updateBoard()
        {  
            int i_BoardSize = m_Game.GameBoard.NumOfRowsAndCols;
            for (int i_Row = 0; i_Row < i_BoardSize; i_Row++)
            {
                for (int i_Col = 0; i_Col < i_BoardSize; i_Col++)
                {
                    m_BoardCells[i_Row, i_Col].initializeButtonPointDetails(m_Game);
                }
            }
        }

        private void dialogGameRound(string i_winnerNameStr)
        {
            i_winnerNameStr = string.Format(
                @"{0} 
                Did you want another game? ",
                i_winnerNameStr);
            DialogResult dialogResult = MessageBox.Show(i_winnerNameStr, "Game Over!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                updateScoreWinner();
                m_Game.GameBoard = new Board(m_Game.GameBoard.NumOfRowsAndCols);
                m_Game.CurrentPlayerTurn = eOwner.Player1;
                m_Playerturn = eOwner.Player1;
                updatePlayerTurnLabel();
                updateBoard();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        private void showWarningMessage(string i_MessageString)
        {
            MessageBox.Show(i_MessageString, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}