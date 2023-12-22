
Imports System.Xml

Partial Class delarticle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Dim id As Int32 = Convert.ToInt32(Request("id"))

            Dim xmlFilePath As String = Server.MapPath("/db/data.xml")

            Dim xmldoc As New XmlDocument

            xmldoc.Load(xmlFilePath)

            Dim objArticle = xmldoc.SelectSingleNode("articles").SelectSingleNode("article[@id=" & id & "]")

            objArticle.ParentNode.RemoveChild(objArticle)

            xmldoc.Save(xmlFilePath)

            Response.Redirect("/")


        End If

    End Sub

End Class
