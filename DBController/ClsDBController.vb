Imports System.Data
Imports System.Data.SqlClient


Namespace DataAccessLayer

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ClsDBController

#Region "Member variable"

        Private mConnection As SqlConnection
        Private mTransaction As SqlTransaction
        Private Shared mDBController As ClsDBController

        Private mblnUseTransaction As Boolean = False

#End Region

#Region "Constructor"

        Private Sub New()
            Dim strConnectionString As String

            strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("DBConnectionString").ConnectionString()
            mConnection = New SqlConnection(strConnectionString)
        End Sub

#End Region

        Public Shared ReadOnly Property Instance() As ClsDBController
            Get
                If mDBController Is Nothing Then
                    mDBController = New ClsDBController()
                End If

                Return mDBController
            End Get
        End Property

#Region "Public methods"

        Public Sub Close()
            Call CloseConnection()

        End Sub

        Public Sub BeginTransaction(ByVal eIsolationLevel As System.Data.IsolationLevel)
            mTransaction = mConnection.BeginTransaction(eIsolationLevel)
            mblnUseTransaction = True
        End Sub

        Public Sub BeginTransaction()
            mTransaction = mConnection.BeginTransaction()
            mblnUseTransaction = True
        End Sub

        Public Sub CommitTransaction()
            mTransaction.Commit()
            mblnUseTransaction = False

        End Sub

        Public Sub RollBackTransaction()
            mTransaction.Rollback()
            mblnUseTransaction = False

        End Sub

        Public Function ExecuteProcedureNonQuery(ByVal strProcedureName As String, _
                                                  ByVal ParamArray params() As SqlParameter) As Integer
            Return CType(ExecuteProcedure(strProcedureName, True, params), Integer)

        End Function

        Public Function ExecuteProcedure(ByVal strProcedureName As String, _
                                         ByVal ParamArray params() As SqlParameter) As SqlDataReader
            Return CType(ExecuteProcedure(strProcedureName, False, params), SqlDataReader)

        End Function

        Public Function ExecuteNoneQuery(ByVal strCommand As String) As Integer
            Try
                Dim objCommand As System.Data.SqlClient.SqlCommand

                objCommand = CreateSimpleCommand(strCommand)

                OpenConnection()

                Return objCommand.ExecuteNonQuery()

            Catch ex As Exception
                Throw

            End Try
        End Function

        Public Function ExecuteReader(ByVal strCommand As String) As SqlDataReader
            Try
                Dim objCommand As System.Data.SqlClient.SqlCommand
                Dim objReader As SqlDataReader
                Dim dtResult As New Data.DataTable()

                objCommand = CreateSimpleCommand(strCommand)

                OpenConnection()
                
                objReader = objCommand.ExecuteReader()

                ' '' ''While objReader.Read()
                ' '' ''    For iIndex As Integer = 0 To objReader.FieldCount - 1
                ' '' ''        dtResult.= objReader.Item(iIndex)
                ' '' ''    Next

                ' '' ''End While
                Return objReader

            Catch ex As Exception
                Throw

            End Try
        End Function

        Public Function ExecuteQuery(ByVal strQueryString As String) As DataTable
            Try
                Dim objCommand As SqlCommand
                Dim objAdapter As New SqlDataAdapter
                Dim dtResult As New DataTable()

                objCommand = CreateSimpleCommand(strQueryString)
                objAdapter.SelectCommand = objCommand

                OpenConnection()

                objAdapter.Fill(dtResult)

                Return dtResult

            Catch ex As InvalidOperationException
                Throw
            Catch ex As Exception
                Throw

            End Try
        End Function

        Public Function ExecuteScalar(ByVal strCommand As String) As Object
            Try

                Dim objCommand As SqlCommand

                objCommand = CreateSimpleCommand(strCommand)

                OpenConnection()
                Return objCommand.ExecuteScalar()

            Catch ex As Exception
                Throw

            End Try
        End Function

#End Region

#Region "Private methods"

        Private Function ExecuteProcedure(ByVal strProcedureName As String, _
                                          ByVal blnWithoutResult As Boolean, _
                                          ByVal ParamArray params() As SqlParameter) As Object
            Dim objCommand As New System.Data.SqlClient.SqlCommand()

            If mblnUseTransaction Then
                objCommand.Transaction = mTransaction

            End If

            objCommand.CommandType = CommandType.StoredProcedure
            objCommand.Connection = mConnection
            objCommand.CommandText = strProcedureName

            For Each objParam As SqlParameter In params
                objCommand.Parameters.Add(objParam)
            Next

            OpenConnection()

            If blnWithoutResult Then
                Return objCommand.ExecuteNonQuery()
            Else
                Return objCommand.ExecuteReader()
            End If

        End Function

        Private Sub CloseConnection()
            If Not mConnection Is Nothing AndAlso mConnection.State <> ConnectionState.Closed Then
                mConnection.Close()

            End If

        End Sub

        Private Sub OpenConnection()
            If mConnection.State = ConnectionState.Closed Or _
               mConnection.State = ConnectionState.Broken Then

                mConnection.Open()

            ElseIf mConnection.State <> ConnectionState.Open Then
                Throw New Exception("Connection is not in correct state to be openned. State: '" & mConnection.State.ToString() & "'")

            End If

        End Sub

        Private Function CreateSimpleCommand(ByVal strCommand As String) As SqlCommand
            Dim objCommand As New System.Data.SqlClient.SqlCommand()

            If mblnUseTransaction Then
                objCommand.Transaction = mTransaction

            End If

            objCommand.CommandType = CommandType.Text
            objCommand.Connection = mConnection
            objCommand.CommandText = strCommand

            Return objCommand
        End Function

#End Region

        Protected Overrides Sub Finalize()
            Try
                Close()
            Catch ex As Exception

            End Try
        End Sub
    End Class

End Namespace