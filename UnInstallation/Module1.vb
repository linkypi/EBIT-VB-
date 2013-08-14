Module Module1

    Sub Main()
        System.Diagnostics.Process.Start(System.Environment.SystemDirectory + "\\msiexec.exe", "/x {3E4702A7-9175-4BC3-85E0-B64DF3336F63} /qr")
    End Sub

End Module
