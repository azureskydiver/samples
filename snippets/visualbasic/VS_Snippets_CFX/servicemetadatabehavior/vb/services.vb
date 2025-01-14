﻿
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.Text
Namespace Microsoft.WCF.Documentation

  <ServiceContractAttribute([Namespace]:="http://microsoft.wcf.documentation")> _
  Public Interface ISampleService

    <OperationContractAttribute(), FaultContractAttribute(GetType(SampleFault))> _
    Function SampleMethod(ByVal msg As String) As String
  End Interface 'ISampleService


  Class SampleService
    Implements ISampleService

    Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
      Console.WriteLine("The caller said: ""{0}""", msg)
      Return "The service greets you: " + msg
    End Function 'SampleMethod
  End Class 'SampleService

  ' The detail type of the specified SOAP fault.
  <DataContractAttribute([Namespace]:="http://microsoft.wcf.documentation")> _
  Public Class SampleFault
    <DataMemberAttribute(Name:="FaultMessage")> _
    Private msg As String


    Public Property FaultMessage() As String
      Get
        Return Me.msg
      End Get
      Set(ByVal value As String)
        Me.msg = Value
      End Set
    End Property
  End Class 'SampleFault
End Namespace