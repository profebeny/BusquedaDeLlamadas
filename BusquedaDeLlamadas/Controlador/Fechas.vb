Public Class Fechas
    Public Function GetFechaActual()
        Dim Fecha As Date = Date.Now
        Dim resultado As String

        resultado = Format(Fecha, "yyyy-MM-dd")

        Return resultado
    End Function

    Public Function GetHoraActual()
        Dim Fecha As Date = Date.Now
        Dim resultado As String

        resultado = Format(Fecha, "HH:mm:ss")

        Return resultado
    End Function

    Public Function GetFechaHora()
        Dim Fecha As Date = Date.Now
        Dim resultado As String

        resultado = Fecha.ToString()

        Return resultado
    End Function


End Class
