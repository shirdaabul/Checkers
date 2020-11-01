using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Cell
{
    private eCoinSign m_Sign;
    private eStatus m_Status;
    private eOwner m_Owner;

    public Cell(eCoinSign i_Sign)
    {
        this.m_Sign = i_Sign;
        this.m_Status = eStatus.Illegal;
        if (i_Sign == eCoinSign.PlayerO)
        {
            this.m_Owner = eOwner.Player1;
        }
        else
        {
            this.m_Owner = eOwner.Player2;
        }
    }

    public eCoinSign Sign
    {
        get
        {
            return this.m_Sign;
        }

        set
        {
            this.m_Sign = value;
        }
    }

    public eOwner Owner
    {
        get
        {
            return this.m_Owner;
        }

        set
        {
            this.m_Owner = value;
        }
    }

    public eStatus Status
    {
        get
        {
            return this.m_Status;
        }

        set
        {
            this.m_Status = value;
        }
    }
}