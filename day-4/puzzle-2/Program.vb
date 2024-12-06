Imports System

Module Program
    Sub Main(args As String())
        Dim data = ReadInput()

        Dim total As Integer = 0
        ' Get the first layout (how it is in the file)
        total = total + CheckArray(data)

        Console.WriteLine("Rotation 0 has " & total & " XMASes")

        Console.WriteLine("")
        Console.WriteLine("Total: " & total)
    End Sub


    Function ReadInput() As Char(,)
        Dim lines as String() = System.IO.File.ReadAllLines("input.txt")
        Dim lineLength = lines(0).Length
        Dim dataArray(lines.Length, lineLength) As Char

        For lineCounter As Integer = 0 To lines.Length -1
            For colCounter As Integer = 0 To lineLength - 1
                dataArray(lineCounter, colCounter) = lines(lineCounter)(colCounter)
            Next
        Next

        return dataArray
    End Function

    Public Function CheckArray(ByRef inputArray As Char(,))
        Dim xmasCounter As Integer = 0

        Dim numRows As Integer = inputArray.GetLength(0)
        Dim numCols As Integer = inputArray.GetLength(1)

        'Horizontal
        For lineCounter As Integer = 1 To numRows - 2
            For colCounter As Integer = 1 To numCols - 2
                If inputArray(lineCounter, colCounter) = "A" _ 
                    And _
                        (inputArray(lineCounter - 1, colCounter - 1) = "M" And inputArray(lineCounter + 1, colCounter + 1) = "S" _
                         Or inputArray(lineCounter - 1, colCounter - 1) = "S" And inputArray(lineCounter + 1, colCounter + 1) = "M"
                        ) _
                    And _
                        (inputArray(lineCounter - 1, colCounter + 1) = "M" And inputArray(lineCounter + 1, colCounter - 1) = "S" _
                         Or inputArray(lineCounter - 1, colCounter + 1) = "S" And inputArray(lineCounter + 1, colCounter - 1) = "M"
                        )
                    xmasCounter = xmasCounter + 1
                End If 
            Next
        Next

        CheckArray = xmasCounter
    End Function
End Module
