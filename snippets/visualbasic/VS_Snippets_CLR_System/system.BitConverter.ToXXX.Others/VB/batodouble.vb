﻿'<Snippet3>
' Example of the BitConverter.ToDouble method.
Imports System
Imports Microsoft.VisualBasic

Module BytesToDoubleDemo

    Const formatter As String = "{0,5}{1,27}{2,27:E16}"
 
    ' Convert eight Byte array elements to a Double and display it.
    Sub BAToDouble( bytes( ) As Byte, index As Integer )

        Dim value As Double = BitConverter.ToDouble( bytes, index )

        Console.WriteLine( formatter, index, _
            BitConverter.ToString( bytes, index, 8 ), value )
    End Sub 

    ' Display a Byte array, using multiple lines if necessary.
    Sub WriteMultiLineByteArray( bytes( ) As Byte )
       
        Const rowSize As Integer = 20 
        Dim iter As Integer

        Console.WriteLine( "initial Byte array" )
        Console.WriteLine( "------------------" )

        For iter = 0 To bytes.Length - rowSize - 1 Step rowSize
            Console.Write( _
                BitConverter.ToString( bytes, iter, rowSize ) )
            Console.WriteLine( "-" )
        Next iter

        Console.WriteLine( BitConverter.ToString( bytes, iter ) )
        Console.WriteLine( )
    End Sub

    Sub Main( )
        Dim byteArray as Byte( ) = { _
              0,   0,   0,   0,   0,   0,   0,   0, 240,  63, _
              0,   0,   0,   0,   0, 224, 111,  64,   0,   0, _
            224, 255, 255, 255, 239,  65,   0,   0,   0,   0, _
              0,   0, 112,  63,   0,   0,   0,   0,   0,   0, _
            240,  61, 223, 136,  30,  28, 254, 116, 170,   1, _
            250,  89, 140,  66, 202, 192, 243,  63, 251,  89, _
            140,  66, 202, 192, 243,  63, 252,  89, 140,  66, _
            202, 192, 243,  63,  82, 211, 187, 188, 232, 126, _
             61, 126, 255, 255, 255, 255, 255, 255, 239, 255, _
            255, 255, 255, 255, 255, 239, 127,   1,   0,   0, _
              0,   0,   0,   0,   0, 248, 255,   0,   0,   0, _
              0,   0,   0, 240, 255,   0,   0,   0,   0,   0, _
              0, 240, 127 }

        Console.WriteLine( _
            "This example of the BitConverter.ToDouble( Byte( ), " & _
            "Integer ) " & vbCrLf & "method generates the " & _
            "following output. It converts elements " & vbCrLf & _
            "of a Byte array to Double values." & vbCrLf )

        WriteMultiLineByteArray( byteArray )

        Console.WriteLine( formatter, "index", "array elements", _
            "Double" )
        Console.WriteLine( formatter, "-----", "--------------", _
            "------" )
          
        ' Convert Byte array elements to Double values.
        BAToDouble( byteArray, 0 )
        BAToDouble( byteArray, 2 )
        BAToDouble( byteArray, 10 )
        BAToDouble( byteArray, 18 )
        BAToDouble( byteArray, 26 )
        BAToDouble( byteArray, 34 )
        BAToDouble( byteArray, 42 )
        BAToDouble( byteArray, 50 )
        BAToDouble( byteArray, 58 )
        BAToDouble( byteArray, 66 )
        BAToDouble( byteArray, 74 )
        BAToDouble( byteArray, 82 )
        BAToDouble( byteArray, 89 )
        BAToDouble( byteArray, 97 )
        BAToDouble( byteArray, 99 )
        BAToDouble( byteArray, 107 )
        BAToDouble( byteArray, 115 )
    End Sub 
End Module

' This example of the BitConverter.ToDouble( Byte( ), Integer )
' method generates the following output. It converts elements
' of a Byte array to Double values.
' 
' initial Byte array
' ------------------
' 00-00-00-00-00-00-00-00-F0-3F-00-00-00-00-00-E0-6F-40-00-00-
' E0-FF-FF-FF-EF-41-00-00-00-00-00-00-70-3F-00-00-00-00-00-00-
' F0-3D-DF-88-1E-1C-FE-74-AA-01-FA-59-8C-42-CA-C0-F3-3F-FB-59-
' 8C-42-CA-C0-F3-3F-FC-59-8C-42-CA-C0-F3-3F-52-D3-BB-BC-E8-7E-
' 3D-7E-FF-FF-FF-FF-FF-FF-EF-FF-FF-FF-FF-FF-FF-EF-7F-01-00-00-
' 00-00-00-00-00-F8-FF-00-00-00-00-00-00-F0-FF-00-00-00-00-00-
' 00-F0-7F
' 
' index             array elements                     Double
' -----             --------------                     ------
'     0    00-00-00-00-00-00-00-00    0.0000000000000000E+000
'     2    00-00-00-00-00-00-F0-3F    1.0000000000000000E+000
'    10    00-00-00-00-00-E0-6F-40    2.5500000000000000E+002
'    18    00-00-E0-FF-FF-FF-EF-41    4.2949672950000000E+009
'    26    00-00-00-00-00-00-70-3F    3.9062500000000000E-003
'    34    00-00-00-00-00-00-F0-3D    2.3283064365386963E-010
'    42    DF-88-1E-1C-FE-74-AA-01    1.2345678901234500E-300
'    50    FA-59-8C-42-CA-C0-F3-3F    1.2345678901234565E+000
'    58    FB-59-8C-42-CA-C0-F3-3F    1.2345678901234567E+000
'    66    FC-59-8C-42-CA-C0-F3-3F    1.2345678901234569E+000
'    74    52-D3-BB-BC-E8-7E-3D-7E    1.2345678901234569E+300
'    82    FF-FF-FF-FF-FF-FF-EF-FF   -1.7976931348623157E+308
'    89    FF-FF-FF-FF-FF-FF-EF-7F    1.7976931348623157E+308
'    97    01-00-00-00-00-00-00-00    4.9406564584124654E-324
'    99    00-00-00-00-00-00-F8-FF                        NaN
'   107    00-00-00-00-00-00-F0-FF                  -Infinity
'   115    00-00-00-00-00-00-F0-7F                   Infinity
'</Snippet3>