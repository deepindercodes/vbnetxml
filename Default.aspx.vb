
Imports System.Xml

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Dim xmlFilePath As String = Server.MapPath("/db/data.xml")

            Dim xmldoc As New XmlDocument

            xmldoc.Load(xmlFilePath)

            reparticles.DataSource = xmldoc.SelectSingleNode("articles").ChildNodes
            reparticles.DataBind()


        End If

    End Sub

End Class
