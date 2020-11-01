using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SourceAndTargetMove
{
    private readonly int m_RowSorcue;
    private readonly int m_ColSorcue;
    private readonly int m_RowTarget;
    private readonly int m_ColTarget;
    private readonly int m_RowEaten;
    private readonly int m_ColEaten;
    private readonly eTypeOfMove m_TypeOfMove;

    public SourceAndTargetMove(int m_RowSorcue, int m_ColSorcue, int m_RowTarget, int m_ColTarget, int m_RowEaten, int m_ColEaten, eTypeOfMove m_TypeOfMove)
    {
        this.m_RowSorcue = m_RowSorcue;
        this.m_ColSorcue = m_ColSorcue;
        this.m_RowTarget = m_RowTarget;
        this.m_ColTarget = m_ColTarget;
        this.m_RowEaten = m_RowEaten;
        this.m_ColEaten = m_ColEaten;
        this.m_TypeOfMove = m_TypeOfMove;
    }

    public int RowSorcue
    {
        get
        {
            return this.m_RowSorcue;
        }
    }

    public int ColSorcue
    {
        get
        {
            return this.m_ColSorcue;
        }

    }

    public int RowTarget
    {
        get
        {
            return this.m_RowTarget;
        }

    }

    public int ColTarget
    {
        get
        {
            return this.m_ColTarget;
        }

    }

    public int RowEaten
    {
        get
        {
            return this.m_RowEaten;
        }
    }

    public int ColEaten
    {
        get
        {
            return this.m_ColEaten;
        }
    }

    public eTypeOfMove TypeOfMove
    {
        get
        {
            return this.m_TypeOfMove;
        }
    }
}