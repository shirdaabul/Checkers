using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    private string m_PlayerName;
    private int m_Score;
    private eTypeOfPlayer m_TypeOfPlayer;  // 1=player2, 2=computer
    private readonly eCoinSign m_CoinSign;
    private readonly eCoinSign m_KingSign;
    private List<SourceAndTargetMove> m_ListOfLigalMove;

    public Player(string i_Name, eTypeOfPlayer i_TypeOfPlayer, int i_NumOfCoins, eCoinSign i_CoinSign)
    {
        this.m_TypeOfPlayer = i_TypeOfPlayer;
        this.m_PlayerName = i_Name;
        this.m_Score = 0;
        this.m_CoinSign = i_CoinSign;
        if (this.m_CoinSign == eCoinSign.PlayerX)
        {
            this.m_KingSign = eCoinSign.PlayerXKing;
        }
        else if (this.m_CoinSign == eCoinSign.PlayerO)
        {
            this.m_KingSign = eCoinSign.PlayerOKing;
        }

        this.m_ListOfLigalMove = new List<SourceAndTargetMove>();
    }

    public eTypeOfPlayer TypeOfPlayer
    {
        get
        {
            return this.m_TypeOfPlayer;
        }

        set
        {
            this.m_TypeOfPlayer = value;
        }
    }

    public int Score
    {
        get
        {
            return this.m_Score;
        }

        set
        {
            this.m_Score = value;
        }
    }

    public eCoinSign CoinSign
    {
        get
        {
            return this.m_CoinSign;
        }
    }

    public eCoinSign KingSign
    {
        get
        {
            return this.m_KingSign;
        }
    }

    public string Name
    {
        get
        {
            return this.m_PlayerName;
        }

        set
        {
            this.m_PlayerName = value;
        }
    }

    public List<SourceAndTargetMove> LigalMovesList
    {
        get
        {
            return this.m_ListOfLigalMove;
        }

        set
        {
            this.m_ListOfLigalMove = value;
        }
    }
}