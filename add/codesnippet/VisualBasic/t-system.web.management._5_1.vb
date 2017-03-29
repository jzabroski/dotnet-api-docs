Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management
Imports System.Web.UI
Imports System.Web.UI.WebControls


' Implements a custom WebRequestEvent. 
Public Class SampleWebRequestEvent
    Inherits System.Web.Management.WebRequestEvent
    Private customCreatedMsg, customRaisedMsg As String
    
    
    ' Invoked in case of events identified only 
    ' by their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer)
        MyBase.New(msg, eventSource, eventCode)

        ' Perform custom initialization.
        customCreatedMsg = String.Format( _
        "Event created at: {0}", _
        EventTime.ToString())

    End Sub 'New
    
    
    ' Invoked in case of events identified 
    ' by their event code.and 
    ' related event detailed code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer, _
    ByVal eventDetailCode As Integer)
        MyBase.New(msg, eventSource, _
        eventCode, eventDetailCode)
        ' Perform custom initialization.
        customCreatedMsg = String.Format( _
        "Event created at: {0}", _
        EventTime.ToString())

    End Sub 'New
    

    ' Raises the SampleWebRequestEvent.
    Public Overrides Sub Raise() 
        ' Perform custom processing.
        customRaisedMsg = String.Format( _
        "Event raised at: {0}", _
        EventTime.ToString())
        
        ' Raise the event.
        MyBase.Raise()
    
    End Sub 'Raise
    
    
    'Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter As WebEventFormatter)
        ' Add custom data.
        formatter.AppendLine("")

        formatter.IndentationLevel += 1
        formatter.AppendLine( _
        "* Custom Request Information Start *")

        '// Display custom event timing.
        formatter.AppendLine(customCreatedMsg)
        formatter.AppendLine(customRaisedMsg)

        formatter.AppendLine( _
        "* Custom Request Information End *")

        formatter.IndentationLevel -= 1

    End Sub 'FormatCustomEventDetails 
End Class 'SampleWebRequestEvent