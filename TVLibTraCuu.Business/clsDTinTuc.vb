Imports System.Data
Imports System.Data.SqlClient
Imports TruongViet.TVLibTraCuu.Entity
Imports TruongViet.TVLibTraCuu.Data

Namespace TruongViet.TVLibTraCuu.Business
    Public Class clsDTinTuc
        Inherits cBBase

        Private intTinTucID As Integer
        Private strTieuDe As String
        Private intLoai As Integer
        Private intUser As Integer
        Private strURL As String = " "
        Private strTomTat As String = " "
        Private strNoiDung As String = " "

        Public Property TinTucID() As Long
            Get
                Return intTinTucID
            End Get
            Set(ByVal Value As Long)
                intTinTucID = Value
            End Set
        End Property

        Public Property TieuDe() As String
            Get
                Return strTieuDe
            End Get
            Set(ByVal Value As String)
                If Value & "" <> "" Then
                    strTieuDe = Value
                End If
            End Set
        End Property

        Public Property Loai() As Integer
            Get
                Return intLoai
            End Get
            Set(ByVal Value As Integer)
                intLoai = Value
            End Set
        End Property

        Public Property User() As Integer
            Get
                Return intUser
            End Get
            Set(ByVal Value As Integer)
                intUser = Value
            End Set
        End Property

        Public Property URL() As String
            Get
                Return strURL
            End Get
            Set(ByVal Value As String)
                If Value & "" <> "" Then
                    strURL = Value
                End If
            End Set
        End Property

        Public Property TomTat() As String
            Get
                Return strTomTat
            End Get
            Set(ByVal Value As String)
                If Value & "" <> "" Then
                    strTomTat = Value
                End If
            End Set
        End Property

        Public Property NoiDung() As String
            Get
                Return strNoiDung
            End Get
            Set(ByVal Value As String)
                If Value & "" <> "" Then
                    strNoiDung = Value
                End If
            End Set
        End Property
        Public Function GetTopTinTuc() As DataTable
            With sqlCmd
                .CommandText = "[sp_TinTuc_GetTop]"

                Try
                    Dim sqlDA As New SqlDataAdapter
                    sqlDA.SelectCommand = sqlCmd
                    Dim dtbTmp As New DataTable
                    sqlDA.Fill(dtbTmp)
                    GetTopTinTuc = dtbTmp
                Catch ex As SqlException
                    mErrorCode = ex.Number
                    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With

        End Function
        Public Function GetNoidungTinTuc() As DataTable
            With sqlCmd
                .CommandText = "[sp_TinTuc_GetNoiDung]"

                Try
                    .Parameters.Add(New SqlParameter("@TinTucID", SqlDbType.Int)).Value = intTinTucID
                    Dim sqlDA As New SqlDataAdapter
                    sqlDA.SelectCommand = sqlCmd
                    Dim dtbTmp As New DataTable
                    sqlDA.Fill(dtbTmp)
                    GetNoidungTinTuc = dtbTmp
                Catch ex As SqlException
                    mErrorCode = ex.Number
                    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With

        End Function
        Public Function GetTieuDeTinTucByIDParent(ByVal intIDParent As Integer) As DataTable
            With sqlCmd
                .CommandText = "[sp_TinTuc_GetTieuDe_ByIDParent]"

                Try
                    .Parameters.Add(New SqlParameter("@IDParent", SqlDbType.Int)).Value = intIDParent
                    Dim sqlDA As New SqlDataAdapter
                    sqlDA.SelectCommand = sqlCmd
                    Dim dtbTmp As New DataTable
                    sqlDA.Fill(dtbTmp)
                    GetTieuDeTinTucByIDParent = dtbTmp
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With

        End Function

        ' GetTopMain method
        Public Function Get_TomTatTinTuc() As DataTable
            With sqlCmd
                .CommandText = "sp_TinTuc_GetTomTat"

                Try
                    .Parameters.Add(New SqlParameter("@TinTucID", SqlDbType.Int)).Value = intTinTucID
                    Dim sqlDA As New SqlDataAdapter
                    sqlDA.SelectCommand = sqlCmd
                    Dim dtbTmp As New DataTable
                    sqlDA.Fill(dtbTmp)
                    Get_TomTatTinTuc = dtbTmp
                    mErrorCode = 0
                    mErrorMessage = ""
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With
        End Function

        Public Function GetTopMain(Optional ByVal intLang As Integer = 0) As DataTable
            With sqlCmd
                .CommandText = "sp_GetTopMain"

                Try
                    .Parameters.Add(New SqlParameter("@intLang", SqlDbType.Int)).Value = intLang
                    Dim sqlDA As New SqlDataAdapter
                    sqlDA.SelectCommand = sqlCmd
                    Dim dtbTmp As New DataTable
                    sqlDA.Fill(dtbTmp)
                    GetTopMain = dtbTmp
                    mErrorCode = 0
                    mErrorMessage = ""
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With
        End Function

        ' GetTopByMain method
        Public Function GetTopByMain(ByVal intIDTinTuc As Integer) As DataTable
            With sqlCmd
                .CommandText = "sp_GetTopByMain"

                Try
                    .Parameters.Add(New SqlParameter("@ID_Parent", SqlDbType.Int)).Value = intIDTinTuc

                    Dim sqlDA As New SqlDataAdapter
                    sqlDA.SelectCommand = sqlCmd
                    Dim dtbTmp As New DataTable
                    sqlDA.Fill(dtbTmp)
                    GetTopByMain = dtbTmp
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With

        End Function
        ' GetTopByMain method
        Public Function GetByTinTucAndPage(ByVal intIDTinTuc As Integer, ByVal intPage As Integer, ByRef intTotalPage As Integer) As DataTable
            With sqlCmd
                .CommandText = "sp_BanTin_GetByTinTucAndPage"

                Try
                    .Parameters.Add(New SqlParameter("@IDTinTuc", SqlDbType.Int)).Value = intIDTinTuc
                    .Parameters.Add(New SqlParameter("@Page", SqlDbType.Int)).Value = intPage
                    .Parameters.Add(New SqlParameter("@TotalPage", SqlDbType.Int, 4, ParameterDirection.Output)).Value = intTotalPage

                    Dim sqlDA As New SqlDataAdapter
                    sqlDA.SelectCommand = sqlCmd
                    Dim dtbTmp As New DataTable
                    sqlDA.Fill(dtbTmp)
                    GetByTinTucAndPage = dtbTmp
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With

        End Function

        ' GetTieuDe method
        Public Function GetTieuDe(Optional ByVal intUser As Integer = -1, Optional ByVal intLang As Integer = 0) As DataTable
            With sqlCmd
                .CommandText = "sp_GetTieuDe"
                Try
                    .Parameters.Add(New SqlParameter("@intTinTucID", SqlDbType.Int)).Value = intTinTucID
                    .Parameters.Add(New SqlParameter("@intUser", SqlDbType.Int)).Value = intUser
                    .Parameters.Add(New SqlParameter("@intLang", SqlDbType.Int)).Value = intLang
                    Dim sqlDA As New SqlDataAdapter
                    sqlDA.SelectCommand = sqlCmd
                    Dim dtbTmp As New DataTable
                    sqlDA.Fill(dtbTmp)
                    GetTieuDe = dtbTmp
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With

        End Function


        ' GetTinTuc method
        Public Function GetTinTuc(Optional ByVal intUser As Integer = -1, Optional ByVal intLang As Integer = 0, Optional ByVal intIDParent As Integer = -1) As DataTable
            With sqlCmd
                .CommandText = "sp_GetTinTuc"
                Try
                    .Parameters.Add(New SqlParameter("@intTinTucID", SqlDbType.Int)).Value = intTinTucID
                    .Parameters.Add(New SqlParameter("@intUser", SqlDbType.Int)).Value = intUser
                    .Parameters.Add(New SqlParameter("@intNgonNgu", SqlDbType.Int)).Value = intLang
                    .Parameters.Add(New SqlParameter("@intIDParent", SqlDbType.Int)).Value = intIDParent
                    Dim sqlDA As New SqlDataAdapter
                    sqlDA.SelectCommand = sqlCmd
                    Dim dtbTmp As New DataTable
                    sqlDA.Fill(dtbTmp)
                    GetTinTuc = dtbTmp
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With

        End Function

        ' InsertTinTuc method
        Public Function InsertTinTuc(ByVal intIDParent As Integer, Optional ByVal intUser As Integer = -1, Optional ByVal intLang As Integer = 0) As Integer

            With sqlCmd
                .CommandText = "sp_AddTinTuc"
                Try
                    .Parameters.Add(New SqlParameter("@TieuDe", SqlDbType.NVarChar, 300)).Value = strTieuDe
                    .Parameters.Add(New SqlParameter("@Loai", SqlDbType.Int)).Value = intLoai
                    .Parameters.Add(New SqlParameter("@IDUser", SqlDbType.Int)).Value = intUser
                    .Parameters.Add(New SqlParameter("@URL", SqlDbType.VarChar, 200)).Value = strURL
                    .Parameters.Add(New SqlParameter("@TomTat", SqlDbType.NVarChar, 4000)).Value = strTomTat
                    .Parameters.Add(New SqlParameter("@NoiDung", SqlDbType.NText)).Value = strNoiDung
                    .Parameters.Add(New SqlParameter("@IDNgonNgu", SqlDbType.Int)).Value = intLang
                    .Parameters.Add(New SqlParameter("@IDParent", SqlDbType.Int)).Value = intIDParent
                    .Parameters.Add(New SqlParameter("@OutIDTinTuc", SqlDbType.Int)).Direction = ParameterDirection.Output
                    .ExecuteNonQuery()
                    InsertTinTuc = .Parameters("@OutIDTinTuc").Value
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With

        End Function

        ' UpdateTinTuc method
        Public Function UpdateTinTuc(Optional ByVal intUser As Integer = -1) As Integer
            With sqlCmd
                .CommandText = "sp_UpdateTinTuc"
                Try
                    .Parameters.Add(New SqlParameter("@intTinTucID", SqlDbType.Int)).Value = intTinTucID
                    .Parameters.Add(New SqlParameter("@strTieuDe", SqlDbType.NVarChar, 300)).Value = strTieuDe
                    .Parameters.Add(New SqlParameter("@intLoai", SqlDbType.Int)).Value = intLoai
                    .Parameters.Add(New SqlParameter("@intUser", SqlDbType.Int)).Value = intUser
                    .Parameters.Add(New SqlParameter("@strURL", SqlDbType.VarChar, 200)).Value = strURL
                    .Parameters.Add(New SqlParameter("@strTomTat", SqlDbType.NVarChar, 4000)).Value = strTomTat
                    .Parameters.Add(New SqlParameter("@strNoiDung", SqlDbType.NText)).Value = strNoiDung
                    .Parameters.Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                    .ExecuteNonQuery()
                    UpdateTinTuc = .Parameters("@intRetval").Value
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With
        End Function

        ' UpdateViTri method
        Public Sub UpdateViTri(ByVal intUuTien As Integer)
            With sqlCmd
                .CommandText = "sp_UpdateViTriTinTuc"
                Try
                    .Parameters.Add(New SqlParameter("@intTinTucID", SqlDbType.Int)).Value = intTinTucID
                    .Parameters.Add(New SqlParameter("@intUuTien", SqlDbType.Int)).Value = intUuTien
                    .ExecuteNonQuery()
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With
        End Sub

        ' DuyetTinTuc method
        Public Function DuyetTinTuc(ByVal strTinTucCheck As String, ByVal strTinTucUnCheck As String) As Integer
            With sqlCmd
                .CommandText = "sp_DuyetTinTuc"
                Try
                    .Parameters.Add(New SqlParameter("@strTinTucCheck", SqlDbType.VarChar, 4000)).Value = strTinTucCheck
                    .Parameters.Add(New SqlParameter("@strTinTucUnCheck", SqlDbType.VarChar, 4000)).Value = strTinTucUnCheck
                    .ExecuteNonQuery()
                    DuyetTinTuc = 1
                Finally
                    .Parameters.Clear()
                End Try
            End With
        End Function

        ' DeleteTinTuc method
        Public Function DeleteTinTuc() As Integer
            With sqlCmd
                .CommandText = "sp_DelTinTuc"
                Try
                    .Parameters.Add(New SqlParameter("@intTinTucID", SqlDbType.Int)).Value = intTinTucID
                    .Parameters.Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                    .ExecuteNonQuery()
                    DeleteTinTuc = .Parameters("@intRetval").Value
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With
        End Function
        Public Function GetTopDaDua() As DataTable
            With sqlCmd
                .CommandText = "sp_TinTuc_GetTinDaDua"

                Try
                    .Parameters.Add(New SqlParameter("@TinTucID", SqlDbType.Int)).Value = intTinTucID

                    Dim sqlDA As New SqlDataAdapter
                    sqlDA.SelectCommand = sqlCmd
                    Dim dtbTmp As New DataTable
                    sqlDA.Fill(dtbTmp)
                    GetTopDaDua = dtbTmp
                    'Catch ex As SqlException
                    '    mErrorCode = ex.Number
                    '    mErrorMessage = ex.Message
                Finally
                    .Parameters.Clear()
                End Try
            End With
        End Function


    End Class
End Namespace
