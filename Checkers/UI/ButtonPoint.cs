using System.Drawing;
using System.Windows.Forms;

namespace EnglishCheckersUI
{
    public class ButtonPoint : Button
    {
        private readonly Point m_PointLocation;

        public ButtonPoint(int i_Row, int i_Col)
        {
            m_PointLocation = new Point(i_Row, i_Col);
        }

        public Point PointLocation
        {
            get
            {
                return m_PointLocation;
            }
        }

        public void initializeButtonPointDetails(GameProgress m_Game)
        {
            eOwner i_OpposingPlayer = (m_Game.CurrentPlayerTurn == eOwner.Player1) ? eOwner.Player2 : eOwner.Player1;
            int i_Col = this.m_PointLocation.X;
            int i_Row = this.m_PointLocation.Y;

            if (m_Game.GameBoard.Matrix[i_Row, i_Col].Status == eStatus.Illegal)
            {
                this.BackColor = Color.Black;
                this.Enabled = false;
            }
            else
            {
                this.Enabled = true;
                this.BackColor = Color.White;
                if (m_Game.GameBoard.Matrix[i_Col, i_Row].Sign == eCoinSign.PlayerO)
                {
                    this.BackgroundImage = EnglishCheckersUI.Properties.Resources.WhiteCheckerPlayer;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (m_Game.GameBoard.Matrix[i_Col, i_Row].Sign == eCoinSign.PlayerX)
                {
                    this.BackgroundImage = EnglishCheckersUI.Properties.Resources.BlackCheckerPlayer;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (m_Game.GameBoard.Matrix[i_Col, i_Row].Sign == eCoinSign.PlayerOKing)
                {
                    this.BackgroundImage = EnglishCheckersUI.Properties.Resources.WhiteKing;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (m_Game.GameBoard.Matrix[i_Col, i_Row].Sign == eCoinSign.PlayerXKing)
                {
                    this.BackgroundImage = EnglishCheckersUI.Properties.Resources.BlackKing;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (m_Game.GameBoard.Matrix[i_Col, i_Row].Sign == eCoinSign.None) 
                {
                    this.BackgroundImage = null;
                }

                if (m_Game.GameBoard.Matrix[i_Col, i_Row].Owner == i_OpposingPlayer)
                {
                    this.Enabled = false;
                }
            }

            this.Margin = Padding.Empty;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Location = new Point(this.Width * i_Row, this.Height * i_Col);
        }
    }
}