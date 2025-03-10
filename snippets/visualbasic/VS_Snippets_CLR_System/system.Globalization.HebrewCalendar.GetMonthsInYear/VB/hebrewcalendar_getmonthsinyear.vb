﻿' The following code example calls GetMonthsInYear for 5 years in each era.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesHebrewCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a HebrewCalendar.
      Dim myCal As New HebrewCalendar()

      ' Displays the header.
      Console.Write("YEAR" + ControlChars.Tab)
      Dim y As Integer
      For y = 5761 To 5765
         Console.Write(ControlChars.Tab + "{0}", y)
      Next y
      Console.WriteLine()

      ' Displays the value of the CurrentEra property.
      Console.Write("CurrentEra:")
      For y = 5761 To 5765
         Console.Write(ControlChars.Tab + "{0}", myCal.GetMonthsInYear(y, HebrewCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Displays the values in the Eras property.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 5761 To 5765
            Console.Write(ControlChars.Tab + "{0}", myCal.GetMonthsInYear(y, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub 'Main 

End Class 'SamplesHebrewCalendar


'This code produces the following output.
'
'YEAR            5761    5762    5763    5764    5765
'CurrentEra:     12      12      13      12      13
'Era 1:          12      12      13      12      13

' </snippet1>
