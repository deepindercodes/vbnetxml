
Imports System.Xml

Partial Class editarticle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Dim id As Int32 = Convert.ToInt32(Request("id"))

            Dim xmlFilePath As String = Server.MapPath("/db/data.xml")

            Dim xmldoc As New XmlDocument

            xmldoc.Load(xmlFilePath)

            Dim objArticle = xmldoc.SelectSingleNode("articles").SelectSingleNode("article[@id=" & id & "]")

            txtarticletitle.Text = objArticle.SelectSingleNode("articletitle").InnerText
            txtarticleauthor.Text = objArticle.SelectSingleNode("articleauthor").InnerText
            txtarticlebody.Text = objArticle.SelectSingleNode("articlebody").InnerText
            hdnarticleimage.Value = objArticle.SelectSingleNode("articleimage").InnerText


        End If

    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)

        Dim id As Int32 = Convert.ToInt32(Request("id"))

        Dim articletitle As String = txtarticletitle.Text

        Dim articleauthor As String = txtarticleauthor.Text

        Dim articlebody As String = txtarticlebody.Text

        Dim articleimage As String = hdnarticleimage.Value

        Dim xmlFilePath As String = Server.MapPath("/db/data.xml")

        Dim xmldoc As New XmlDocument

        xmldoc.Load(xmlFilePath)

        Dim objArticle = xmldoc.SelectSingleNode("articles").SelectSingleNode("article[@id=" & id & "]")

        objArticle.SelectSingleNode("articletitle").ChildNodes(0).InnerText = articletitle
        objArticle.SelectSingleNode("articleauthor").ChildNodes(0).InnerText = articleauthor
        objArticle.SelectSingleNode("articlebody").ChildNodes(0).InnerText = articlebody
        objArticle.SelectSingleNode("articleimage").ChildNodes(0).InnerText = articleimage
        objArticle.SelectSingleNode("modifiedonutc").ChildNodes(0).InnerText = DateTime.UtcNow.ToString()

        xmldoc.Save(xmlFilePath)

        Response.Write("<script type='text/javascript'>parent.ArticleEdited();</script>")
        Response.End()

    End Sub
End Class
