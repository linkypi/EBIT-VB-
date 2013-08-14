Public Class Tool

    '''<summary>
    '''ASCII码转字符串（转换为Excel列的形式：A/B/C...AA/AB/AC...BA/BB/......）
    '''</summary>
    '''<param name="asciiCode">最大数字255（即Excel最末列IV）</param>
    '''<returns></returns>
    Public Shared Function Chr(ByVal asciiCode As Integer) As String
        If asciiCode > 0 And asciiCode <= 255 Then

            Dim asciiEncoding As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding()
            Dim strCharacter As String = String.Empty
            Dim byteArray As Byte()
            Dim division As Integer = Math.Floor(asciiCode / 26) 'CType((asciiCode - 64) / 26, Integer)
            Dim mods As Integer = asciiCode Mod 26 '(asciiCode - 64) Mod 26

            If mods = 0 Then
                division = division - 1
                mods = 26
            End If

            If division = 0 And mods <= 26 Then

                byteArray = New Byte() {CType(mods + 64, Byte)}
                strCharacter = strCharacter + asciiEncoding.GetString(byteArray)

            Else
                
                byteArray = New Byte() {CType(division + 64, Byte)}
                strCharacter = strCharacter + asciiEncoding.GetString(byteArray)

                byteArray = New Byte() {CType(mods + 64, Byte)}
                strCharacter = strCharacter + asciiEncoding.GetString(byteArray)

            End If
            Return strCharacter
        Else
            Return "ASCII Code is not valid."
        End If
    End Function

End Class
