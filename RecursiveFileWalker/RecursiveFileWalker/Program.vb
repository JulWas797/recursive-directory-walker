Imports System.IO

Module Program
    Sub Main(args As String())
        Console.WriteLine("Resursive File Walker (VB.NET). Please provide path:")
        Dim input As String
        Do While input Is Nothing
            input = Console.ReadLine
        Loop
        WalkThruPath(input)
        Return
    End Sub

    Async Function WalkThruPath(ByVal inputDir As String) As Task
        Try
            For Each fsDir In Directory.GetDirectories(inputDir)
                Await WalkThruPath(fsDir)
            Next
            For Each flEnt In Directory.GetFiles(inputDir)
                Console.WriteLine("Found File Entry: " & flEnt)
            Next
        Catch e As UnauthorizedAccessException
            Console.WriteLine("Access Denied: " & inputDir)
        End Try
    End Function
End Module
