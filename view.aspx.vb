
Imports System.Xml

Partial Class view
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Dim id As Int32 = Convert.ToInt32(Request("id"))

            Dim xmlFilePath As String = Server.MapPath("/db/data.xml")

            Dim xmldoc As New XmlDocument

            xmldoc.Load(xmlFilePath)

            Dim objArticle = xmldoc.SelectSingleNode("articles").SelectSingleNode("article[@id=" & id & "]")

            litarticletitle.Text = objArticle.SelectSingleNode("articletitle").InnerText
            litarticleauthor.Text = objArticle.SelectSingleNode("articleauthor").InnerText
            litarticlebody.Text = objArticle.SelectSingleNode("articlebody").InnerText
            litarticlecreatedonutc.Text = objArticle.SelectSingleNode("createdonutc").InnerText

            If objArticle.SelectSingleNode("articleimage").InnerText & "" <> "" Then
                divimage.Visible = True
                imgarticle.ImageUrl = objArticle.SelectSingleNode("articleimage").InnerText
            End If

            Page.Title = litarticletitle.Text


        End If

    End Sub

End Class
