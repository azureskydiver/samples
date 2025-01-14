﻿'<Snippet1>
Imports System
Imports System.Runtime.Serialization
Imports System.Security.Permissions

Namespace UsageLibrary

   ' <SerializableAttribute> _ 
   Public Class BaseType
      Implements ISerializable
   
      Dim baseValue As Integer

      Sub New()
         baseValue = 3
      End Sub

      Protected Sub New( _ 
         info As SerializationInfo, context As StreamingContext)
      
         baseValue = info.GetInt32("baseValue")

      End Sub

      <SecurityPermissionAttribute(SecurityAction.Demand, _ 
          SerializationFormatter := True)> _ 
      Overridable Sub GetObjectData( _ 
         info As SerializationInfo, context As StreamingContext) _ 
         Implements ISerializable.GetObjectData
      
         info.AddValue("baseValue", baseValue)

      End Sub

   End Class

End Namespace
'</Snippet1>
