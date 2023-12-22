﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/js/bootstrap.bundle.min.js"></script>
    <script src="/js/jquery-3.7.1.min.js"></script>

    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet" />

    <style type="text/css">
        body {
            font-family: 'Roboto', sans-serif;
        }
    </style>

    <script type="text/javascript">
        function newArticleAdded() {
            var myModalEl = document.getElementById('divAddArticle');
            var modal = bootstrap.Modal.getInstance(myModalEl)
            modal.hide();
            location.href = location.href;
        }

        function ArticleEdited() {
            var myModalEl = document.getElementById('divEditArticle');
            var modal = bootstrap.Modal.getInstance(myModalEl)
            modal.hide();

            document.getElementById('iframeEditArticle').src = "";
            document.getElementById('iframeEditArticle').contentWindow.location.href = document.getElementById('iframeEditArticle').contentWindow.location.href;
            location.href = location.href;
        }

        function confirmDelete() {
            return confirm('Are you sure you want to delete this article?');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="row">
                <div class="col-sm-9">
                    &nbsp;
                </div>
                <div class="col-sm-2 p-3">
                    <a href="javascript:void(0)" data-bs-toggle="modal" data-keyboard="false" data-backdrop="static" data-bs-target="#divAddArticle">Add New Article</a>
                </div>
                <div class="col-sm-1">
                    &nbsp;
                </div>
            </div>
            <div class="row">
                <div class="col-sm-1">
                    &nbsp;
                </div>
                <div class="col-sm-10">
                    <ul class='list-group'>
                        <li class='list-group-item fs-5 p-3 bg-primary text-white'>Article Listing</li>
                        <asp:Repeater ID="reparticles" runat="server">
                            <ItemTemplate>
                                <li class='list-group-item p-2'>
                                    <div class='row'>
                                        <div class='col-sm-10'><%#XPath("articletitle")%></div>
                                        <div class='col-sm-2 text-center'><a href='javascript:void(0)' onclick='openEditingPanel(<%# XPath("@id")%>)'>Edit</a>&nbsp;<a href='delarticle.aspx?id=<%# XPath("@id")%>' onclick='return confirmDelete()'>Delete</a>&nbsp;<a href='view.aspx?id=<%# XPath("@id")%>' target='_blank'>View</a></div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="col-sm-1">
                    &nbsp;
                </div>
            </div>
        </div>

        <!--Add Article Modal-->
        <div class="modal fade" id="divAddArticle" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="staticBackdropLabel">Add New Article</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">

                        <div class="container">

                            <div class="row">

                                <div class="col-sm-12">
                                    <iframe src="addnewarticle.aspx" id="iframeAddArticle" style="width: 100%; height: 750px" border="0"></iframe>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>

        <!--Add Article Modal-->
        <div class="modal fade" id="divEditArticle" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="staticBackdropLabelEdit">Edit Article</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">

                        <div class="container">

                            <div class="row">

                                <div class="col-sm-12">
                                    <iframe src="" id="iframeEditArticle" style="width: 100%; height: 750px" border="0"></iframe>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript">
            var myModalEl = document.getElementById('divAddArticle')
            myModalEl.addEventListener('hidden.bs.modal', function (event) {
                document.getElementById('iframeAddArticle').contentWindow.location.href = document.getElementById('iframeAddArticle').contentWindow.location.href;
            })


            var myModalEditArticle = new bootstrap.Modal(document.getElementById("divEditArticle"), {});
            myModalEditArticle.addEventListener('hidden.bs.modal', function (event) {
                document.getElementById('iframeEditArticle').src = "";
                document.getElementById('iframeEditArticle').contentWindow.location.href = document.getElementById('iframeEditArticle').contentWindow.location.href;
            })

            function openEditingPanel(_id) {
                document.getElementById('iframeEditArticle').src = "editarticle.aspx?id=" + _id;
                myModalEditArticle.show();
            }


        </script>
    </form>
</body>
</html>
