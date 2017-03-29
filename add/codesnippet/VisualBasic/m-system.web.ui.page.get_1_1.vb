   Public Class MyControl1
      Inherits Control
      Implements IPostBackEventHandler 
      
      ' Create an integer property that is displayed when
      ' the page that contains this control is requested
      ' and save it to the control's ViewState property.
      Public Property Number() As Integer
         Get
            If Not (ViewState("Number") Is Nothing) Then
               Return CInt(ViewState("Number"))
            End If
            Return 50
         End Get
         
         Set
            ViewState("Number") = value
         End Set
      End Property
      

      ' Implement the RaisePostBackEvent method from the
      ' IPostBackEventHandler interface. If inc is passed
      ' to this method, it increases the Number property by one.      
      Public Sub RaisePostBackEvent(eventArgument As String) Implements IPostBackEventHandler.RaisePostBackEvent

         Number = Number + 1
      End Sub 'RaisePostBackEvent
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub Render(writer As HtmlTextWriter)
         ' Converts the Number property to a string and
	 ' writes it to the containing page.
         writer.Write(("The Number is " + Number.ToString() + " ("))

	 ' Uses the GetPostBackEventReference method to pass
	 ' inc to the RaisePostBackEvent method when the link
	 ' this code creates is clicked.         
         writer.Write(("<a href=""javascript:" + Page.GetPostBackEventReference(Me) + """>Increase Number</a>"))
      End Sub 'Render
   End Class 'MyControl1