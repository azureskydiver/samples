﻿' <Snippet1>
Imports System

Public Enum Color
    Red
    Blue
    Green
End Enum

Class Example
   Public Shared Sub Main()
        Dim colorType As Type = GetType(Color)
        Dim enumType As Type = GetType([Enum])
        Console.WriteLine("Is Color an enum? {0}.", colorType.IsEnum)
        Console.WriteLine("Is Color a value type? {0}.", colorType.IsValueType)
        Console.WriteLine("Is Enum an enum type? {0}.", enumType.IsEnum)
        Console.WriteLine("Is Enum a value type? {0}.", enumType.IsValueType)
    End Sub 
End Class
' The example displays the following output:
'     Is Color an enum? True.
'     Is Color a value type? True.
'     Is Enum an enum type? False.
'     Is Enum a value type? False.
' </Snippet1>