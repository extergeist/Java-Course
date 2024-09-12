Public Class IncomeCalc
    'this is my class
    'this is my variable
    Private m_totalbalance As Double
    'get property for the balanace
    Public ReadOnly Property totalcost() As Double
        Get
            Return m_totalbalance
        End Get
    End Property
    'these are my two subs which add to the income then subtract the expenses
    Sub Income(ByVal amount As Double)
        m_totalbalance = m_totalbalance + amount
    End Sub

    Sub Expense(ByVal amount As Double)
        m_totalbalance = m_totalbalance - amount
    End Sub
End Class
