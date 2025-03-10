﻿' The following example shows how to implement and use the NameObjectCollectionBase class.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class MyCollection
   Inherits NameObjectCollectionBase

   ' Creates an empty collection.
   Public Sub New()
   End Sub 'New

   ' Adds elements from an IDictionary into the new collection.
   Public Sub New(d As IDictionary, bReadOnly As Boolean)
      Dim de As DictionaryEntry
      For Each de In  d
         Me.BaseAdd(CType(de.Key, String), de.Value)
      Next de
      Me.IsReadOnly = bReadOnly
   End Sub 'New

   ' Gets a key-and-value pair (DictionaryEntry) using an index.
   Default Public ReadOnly Property Item(index As Integer) As DictionaryEntry
      Get
            return new DictionaryEntry( _
                me.BaseGetKey(index), me.BaseGet(index) )
      End Get
   End Property

   ' Gets or sets the value associated with the specified key.
   Default Public Property Item(key As String) As Object
      Get
         Return Me.BaseGet(key)
      End Get
      Set
         Me.BaseSet(key, value)
      End Set
   End Property

   ' Gets a String array that contains all the keys in the collection.
   Public ReadOnly Property AllKeys() As String()
      Get
         Return Me.BaseGetAllKeys()
      End Get
   End Property

   ' Gets an Object array that contains all the values in the collection.
   Public ReadOnly Property AllValues() As Array
      Get
         Return Me.BaseGetAllValues()
      End Get
   End Property

   ' Gets a String array that contains all the values in the collection.
   Public ReadOnly Property AllStringValues() As String()
      Get
         Return CType(Me.BaseGetAllValues(GetType(String)), String())
      End Get
   End Property

   ' Gets a value indicating if the collection contains keys that are not null.
   Public ReadOnly Property HasKeys() As Boolean
      Get
         Return Me.BaseHasKeys()
      End Get
   End Property

   ' Adds an entry to the collection.
   Public Sub Add(key As String, value As Object)
      Me.BaseAdd(key, value)
   End Sub 'Add

   ' Removes an entry with the specified key from the collection.
   Overloads Public Sub Remove(key As String)
      Me.BaseRemove(key)
   End Sub 'Remove

   ' Removes an entry in the specified index from the collection.
   Overloads Public Sub Remove(index As Integer)
      Me.BaseRemoveAt(index)
   End Sub 'Remove

   ' Clears all the elements in the collection.
   Public Sub Clear()
      Me.BaseClear()
   End Sub 'Clear

End Class 'MyCollection


Public Class SamplesNameObjectCollectionBase   

   Public Shared Sub Main()

      ' Creates and initializes a new MyCollection that is read-only.
      Dim d As New ListDictionary()
      d.Add("red", "apple")
      d.Add("yellow", "banana")
      d.Add("green", "pear")
      Dim myROCol As New MyCollection(d, True)

      ' Tries to add a new item.
      Try
         myROCol.Add("blue", "sky")
      Catch e As NotSupportedException
         Console.WriteLine(e.ToString())
      End Try

      ' Displays the keys and values of the MyCollection.
      Console.WriteLine("Read-Only Collection:")
      PrintKeysAndValues(myROCol)

      ' Creates and initializes an empty MyCollection that is writable.
      Dim myRWCol As New MyCollection()

      ' Adds new items to the collection.
      myRWCol.Add("purple", "grape")
      myRWCol.Add("orange", "tangerine")
      myRWCol.Add("black", "berries")
      Console.WriteLine("Writable Collection (after adding values):")
      PrintKeysAndValues(myRWCol)

      ' Changes the value of one element.
      myRWCol("orange") = "grapefruit"
      Console.WriteLine("Writable Collection (after changing one value):")
      PrintKeysAndValues(myRWCol)

      ' Removes one item from the collection.
      myRWCol.Remove("black")
      Console.WriteLine("Writable Collection (after removing one value):")
      PrintKeysAndValues(myRWCol)

      ' Removes all elements from the collection.
      myRWCol.Clear()
      Console.WriteLine("Writable Collection (after clearing the collection):")
      PrintKeysAndValues(myRWCol)

   End Sub 'Main

   ' Prints the indexes, keys, and values.
   Public Shared Sub PrintKeysAndValues(myCol As MyCollection)
      Dim i As Integer
      For i = 0 To myCol.Count - 1
         Console.WriteLine("[{0}] : {1}, {2}", i, myCol(i).Key, myCol(i).Value)
      Next i
   End Sub 'PrintKeysAndValues

   ' Prints the keys and values using AllKeys.
   Public Shared Sub PrintKeysAndValues2(myCol As MyCollection)
      Dim s As String
      For Each s In  myCol.AllKeys
         Console.WriteLine("{0}, {1}", s, myCol(s))
      Next s
   End Sub 'PrintKeysAndValues2

End Class 'SamplesNameObjectCollectionBase


'This code produces the following output.
'
'System.NotSupportedException: Collection is read-only.
'   at System.Collections.Specialized.NameObjectCollectionBase.BaseAdd(String name, Object value)
'   at SamplesNameObjectCollectionBase.Main()
'Read-Only Collection:
'[0] : red, apple
'[1] : yellow, banana
'[2] : green, pear
'Writable Collection (after adding values):
'[0] : purple, grape
'[1] : orange, tangerine
'[2] : black, berries
'Writable Collection (after changing one value):
'[0] : purple, grape
'[1] : orange, grapefruit
'[2] : black, berries
'Writable Collection (after removing one value):
'[0] : purple, grape
'[1] : orange, grapefruit
'Writable Collection (after clearing the collection):

' </snippet1>
