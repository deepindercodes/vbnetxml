
Imports System.IO
Imports System.Xml

Partial Class addnewarticle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        diverror.Visible = False
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)

        Dim articletitle As String = txtarticletitle.Text

        Dim articleauthor As String = txtarticleauthor.Text

        Dim articlebody As String = txtarticlebody.Text

        Dim articleimage As String = hdnarticleimage.Value

        Dim articleExists As Boolean = False

        Dim xmlFilePath As String = Server.MapPath("/db/data.xml")

        Dim pk As Int32 = 1

        Dim xmldoc As New XmlDocument

        If File.Exists(xmlFilePath) = True Then

            xmldoc.Load(xmlFilePath)

            pk = Convert.ToInt32(xmldoc.DocumentElement.GetAttribute("pk")) + 1

            xmldoc.DocumentElement.SetAttribute("pk", (pk).ToString())

        Else

            Dim objPI = xmldoc.CreateProcessingInstruction("xml", "version='1.0'")
            xmldoc.InsertBefore(objPI, xmldoc.ChildNodes(0))

            Dim objRoot = xmldoc.CreateElement("articles")

            '//adding the primary key tracking attribute
            Dim objpk = xmldoc.CreateAttribute("pk")
            objpk.Value = pk
            objRoot.SetAttributeNode(objpk)

            xmldoc.AppendChild(objRoot)

        End If

        Dim objParent = xmldoc.DocumentElement

        '//adding the article node
        Dim objnewArticle = xmldoc.CreateElement("article")

        '//setting id
        Dim objid = xmldoc.CreateAttribute("id")
        objid.InnerText = (pk) & ""
        objnewArticle.SetAttributeNode(objid)

        '//setting article title
        Dim objarticletitle = xmldoc.CreateElement("articletitle")
        Dim objarticletitletext = xmldoc.CreateCDataSection(articletitle)
        objarticletitle.AppendChild(objarticletitletext)
        objnewArticle.AppendChild(objarticletitle)

        '//setting article author
        Dim objarticleauthor = xmldoc.CreateElement("articleauthor")
        Dim objarticleauthortext = xmldoc.CreateCDataSection(articleauthor)
        objarticleauthor.AppendChild(objarticleauthortext)
        objnewArticle.AppendChild(objarticleauthor)

        '//setting article body
        Dim objarticlebody = xmldoc.CreateElement("articlebody")
        Dim objarticlebodytext = xmldoc.CreateCDataSection(articlebody)
        objarticlebody.AppendChild(objarticlebodytext)
        objnewArticle.AppendChild(objarticlebody)

        '//setting article image
        Dim objarticleimage = xmldoc.CreateElement("articleimage")
        Dim objarticleimagetext = xmldoc.CreateCDataSection(articleimage)
        objarticleimage.AppendChild(objarticleimagetext)
        objnewArticle.AppendChild(objarticleimage)

        '//setting createdonutc
        Dim objcreatedonutc = xmldoc.CreateElement("createdonutc")
        Dim objcreatedonutctext = xmldoc.CreateCDataSection(DateTime.UtcNow.ToString())
        objcreatedonutc.AppendChild(objcreatedonutctext)
        objnewArticle.AppendChild(objcreatedonutc)

        '//setting modifiedonutc
        Dim objmodifiedonutc = xmldoc.CreateElement("modifiedonutc")
        Dim objmodifiedonutctext = xmldoc.CreateCDataSection("")
        objmodifiedonutc.AppendChild(objmodifiedonutctext)
        objnewArticle.AppendChild(objmodifiedonutc)

        '//setting status
        Dim objstatus = xmldoc.CreateElement("status")
        Dim objstatustext = xmldoc.CreateCDataSection("E")
        objstatus.appendChild(objstatustext)
        objnewArticle.appendChild(objstatus)

        objParent.AppendChild(objnewArticle)

        xmldoc.Save(xmlFilePath)


        Response.Write("<script type='text/javascript'>parent.newArticleAdded();</script>")
        Response.End()


    End Sub

End Class
