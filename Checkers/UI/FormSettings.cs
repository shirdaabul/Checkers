using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishCheckersUI
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            GameProgress i_Game;
            int i_BoardSize = getBoardSize();
            int i_NumOfPlayers = getNumOfPlayers();
            string i_FirstPlayerName = Player1TB.Text;
            string i_SecondPlayerName = i_NumOfPlayers == 1 ? "Computer" : Player2TB.Text;
            if (i_FirstPlayerName != string.Empty && i_SecondPlayerName != string.Empty) 
            {
                i_Game = new GameProgress(i_BoardSize, i_FirstPlayerName, i_SecondPlayerName, i_NumOfPlayers);
                FormBoard formBoard = new FormBoard(i_Game);
                this.Hide();
                formBoard.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Player name is missing!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private int getNumOfPlayers()
        {
            int i_NumOfPlayers = 1;

            if (Player2CB.Checked)
            {
                i_NumOfPlayers = 2;
            }

            return i_NumOfPlayers;
        }

        private int getBoardSize()
        {
            int i_BoardSize = 6;

            if (size6Rb.Checked == true)
            {
                i_BoardSize = 6;
            }
            else if (size8Rb.Checked == true)
            {
                i_BoardSize = 8;
            }
            else if (size10Rb.Checked == true)
            {
                i_BoardSize = 10;
            }

            return i_BoardSize;
        }

        private void Player2CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Player2CB.Checked)
            {
                Player2TB.Enabled = true;
                Player2TB.Text = null;
            }
            else
            {
                Player2TB.Enabled = false;
                Player2TB.Text = "[Computer]";
            }
        }
    }
}