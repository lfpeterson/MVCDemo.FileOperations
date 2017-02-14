$(document).ready(function() {
    $('input.uploadFile').on('change', UploadPdfFile);
    $('[data-toggle="tooltip"]').tooltip();
});

function UploadPdfFile(e) {
    var files = e.target.files;

    if (files.length > 0) {
        if (this.value.lastIndexOf('.pdf') === -1) {
            alert('Only pdf files are allowed!');
            this.value = '';
            return;
        }

        if (window.FormData !== undefined) {
            var file = files[0];
            var data = new FormData();
            data.append("file0", file);
            //for (var x = 0; x < files.length; x++) {
            //    data.append("file" + x, files[x]);
            //}

            $.ajax({
                type: "POST",
                url: '/Home/UploadFile',
                contentType: false,
                processData: false,
                data: data,
                cache: false,
                success: function (result) {
                    $("#requiredDocuments").load(encodeURI("/Home/ReloadDocuments?fileName=" + result));
                },
                error: function (xhr, status, p3, p4) {
                    var err = "Error " + " " + status + " " + p3 + " " + p4;
                    if (xhr.responseText && xhr.responseText[0] === "{")
                        err = JSON.parse(xhr.responseText).Message;
                    console.log(err);
                }
            });
        } else {
            alert("This browser doesn't support HTML5 file uploads!");
        }
    }
}


