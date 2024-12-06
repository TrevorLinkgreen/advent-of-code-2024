Imports System

Module Program
    Sub Main(args As String())
        Dim data = ReadInput()

        Dim total As Integer = 0
        ' Get the first layout (how it is in the file)
        total = total + CheckArray(data)

        Console.WriteLine("Rotation 0 has " & total & " XMASes")

        Dim currentData As Char(,) = data
        '' Rotate the grid 3 times, and recount, instead of trying to do every direction at once
        For iRotate As Integer = 1 to 3
            currentData = RotateArray90Degrees(currentData)
            Dim thisTotal = CheckArray(currentData)
            Console.WriteLine("Rotation " & iRotate & " has " & thisTotal & " XMASes")
            total = total + thisTotal
        Next

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

        ' PrintArray(dataArray)
        return dataArray
    End Function

    Public Function CheckArray(ByRef inputArray As Char(,))
        Dim xmasCounter As Integer = 0

        Dim numRows As Integer = inputArray.GetLength(0)
        Dim numCols As Integer = inputArray.GetLength(1)

        'Horizontal
        For lineCounter As Integer = 0 To numRows - 1
            For colCounter As Integer = 0 To numCols - 4
                If inputArray(lineCounter, colCounter) = "X" _ 
                    And inputArray(lineCounter, colCounter + 1) = "M" _
                    And inputArray(lineCounter, colCounter + 2) = "A" _
                    And inputArray(lineCounter, colCounter + 3) = "S" Then
                        xmasCounter = xmasCounter + 1
                End If 
            Next
        Next

        'Diagonal
        For lineCounter As Integer = 0 To numRows - 4
            For colCounter As Integer = 0 To numCols - 4
                If inputArray(lineCounter, colCounter) = "X" _
                        And inputArray(lineCounter + 1, colCounter + 1) = "M" _
                        And inputArray(lineCounter + 2, colCounter + 2) = "A" _
                        And inputArray(lineCounter + 3, colCounter + 3) = "S" Then

                        xmasCounter = xmasCounter + 1
                End If 
            Next
        Next


        CheckArray = xmasCounter
    End Function

    Public Function RotateArray90Degrees(ByVal inputArray As Char(,)) As Char(,)
        ' Get the number of rows and columns in the original array
        Dim numRows As Integer = inputArray.GetLength(0)
        Dim numCols As Integer = inputArray.GetLength(1)

        ' Create a new 2D array for the rotated result
        Dim rotatedArray(numCols - 1, numRows - 1) As Char

        ' Perform the rotation
        For i As Integer = 0 To numRows - 1
            For j As Integer = 0 To numCols - 1
                ' Rotate 90 degrees: element at (i, j) in the original array
                ' moves to position (j, numRows - 1 - i) in the rotated array
                rotatedArray(j, numRows - 1 - i) = inputArray(i, j)
            Next
        Next

        ' Return the rotated array
        Return rotatedArray
    End Function

    Public Sub PrintArray(ByVal array As Char(,))
        Dim numRows As Integer = array.GetLength(0)
        Dim numCols As Integer = array.GetLength(1)

        Console.WriteLine()
        Console.WriteLine()

        For i As Integer = 0 To numRows - 1
            For j As Integer = 0 To numCols - 1
                Console.Write(array(i, j))
            Next
            Console.WriteLine()
        Next
    End Sub
End Module
