
$(document).ready(function () {
    $('.create-employee-modal').click(function () {
        var form = $('#fr_addemployee');
        form.trigger('reset');
        $('#create-employee').modal('show');
        $('.modal-title').text('اضافة موظف');
    });
    //loadMessage();
    $('[placeholder]').focus(function () {

        $(this).attr('data-text', $(this).attr('placeholder'));
        $(this).attr('placeholder', '');
    }).blur(function () {

        $(this).attr('placeholder', $(this).attr('data-text'));
    });
    $("#jobedit").click(function () {

        if ($("#jobImage").val() != "") {
            //Check If The JobImage Is Valid
            var filename = document.getElementById("jobImage").value;
            var extentionImage = filename.substr(filename.lastIndexOf('.') + 1);
            var validExtention = ['jpeg', 'jpg', 'png', 'gif', 'bmp', 'JPEG', 'JPG', 'PNG', 'GIF', 'BMP']
            if ($.inArray(extentionImage, validExtention) == -1) {
                $("#jobEditFormErro").fadeIn();
                $("#jobEditFormErro").html("  غير مسموح برفع هذا النوع من الملفات  رجاءا قم بإختيار ملف صورة");
                return false;
            }
            //Check If The  JobImage Size Is Valid (2 MB) 
            var myFileSize = document.getElementById("jobImage").files[0].size / 1024 / 1024;
            if (myFileSize > 2) {
                $("#jobEditFormErro").fadeIn();
                $("#jobEditFormErro").html("حجم الملف أكبر من الحجم المسموح به رجاءا قم بإختيار ملف حجمه أقل من  2 ميقابايت");
                return false;
            }
        }
        
    });
    //chating ajax method
    $(".send-message").click(function () {
        var form = $("#send-message-form");
        var message = $("#message").val();
        var errorMessage = $("#error-message");
        if(message == ""){
            errorMessage.text("أكتب الرسالة أولا");
            alert("erro selesct message");
            errorMessage.fadeIn(30);
        } else {
            $.ajax({
                url: "/Home/sendMessaged",
                type: "get",
                data: {
                      message: message
                },
                error: function (xhr, error) {

                    alert("An error occured: " + xhr.status + " " + xhr.statusText);
                },
                success: function (data) {
                    var html = "";
                    // $("#searchresults").html(result);
                    if (data != null) {
                        html += "<div class='row '>";
                        html += " <div class='col-md-4'>";
                        html += "<div class='comment-box '>";
                        html += "<div class='sendermessage'>";
                        html += "<i>" + data + "</i><br />";
                        html += "<span>" + message + "</span>";
                        html += " </div>";
                        html += " </div>";
                        html += " </div>";
                        html += " </div>";
                        $(".chatingMessage").append(html);
                        $("#message").val("");

                    }

                }
            });
        }

    });
    //send comment method
    $(".send-comment").click(function () {
      
        var form = $("#send-message-form");
        var message = $("#comment").val();
        var errorMessage = $("#error-message");
        if (message == "") {
            errorMessage.text("أكتب الرسالة أولا");
            alert("erro selesct message");
            errorMessage.fadeIn(30);
        } else {
            $.ajax({
                url: "/Home/sendComment",
                type: "get",
                data: {
                    message: message
                },
                error: function (xhr, error) {

                    alert("An error occured: " + xhr.status + " " + xhr.statusText);
                },
                success: function (data) {
                    var html = "";
                    // $("#searchresults").html(result);
                    if (data != null) {
                        html += "<div class='row '>";
                        html += " <div class='col-md-4'>";
                        html += "<div class='comment-box '>";
                        html += "<div class='lead'>";
                        html += "<i>" + data + "</i><br />";
                        html += "<span>" + message + "</span>";
                        html += " </div>";
                        html += " </div>";
                        html += " </div>";
                        html += " </div>";
                        $(".commentMessage").append(html);
                        $("#comment").val("");

                    }

                }
            });
        }

    });
    
  
    //activateOrDeActivate user status method
 
    //search commment by date
    $("#searchDate").change(function () {

        var AutoSearch = $(this).val();
        if (AutoSearch != "") {
            $.ajax({
                url: "searchCommentByDate",
                type: "GET",
                data: { AutoSearch: AutoSearch },
                error: function (xhr, error) {
                    alert("رجاء إملاء جميع الحقول قبل البحث");
                },
                success: function (data) {
                    // $("#searchresults").html(result);
                    if (data != null) {
                        $(".comment_data").find("tbody").html(data);
                    } 

                }
            });
        }
    });
    // search barrenness
    $("#state_search").change(function () {
        var AutoSearch = $(this).val();
        var CategoryId = $("#Category_Id").val();
        
        if (AutoSearch != "") {
            $.ajax({
                url: "SearchBarrennes",
                type: "GET",
                data: { AutoSearch: AutoSearch, CategoryId: CategoryId },
                error: function (xhr, error) {
                  
                    alert("An error occured: " + xhr.status + " " + xhr.statusText);
                },
                success: function (data) {
                    // $("#searchresults").html(result);
                    if (data != null) {

                        $(".searchResult").html(data);
                    }

                }
            });
        }
    });
    
});

function readUrl(input, post_image_preview) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onloadend = function (e) {
            $(post_image_preview).attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}


/*function loadMessage() {
    $.getJSON('/Home/loadMessageg', {}, function (data) {
        if (data != null) {
            var html = "";
            $.each(data, function (key, value) {
                html += "<div class='row '>";
                html += " <div class='col-md-4'>";
                html += "<div class='comment-box'>";
                html += "<div class='lead'>";
                html += "<i>" + value.sendDate+ "</i><br />";
                html += "<span>"+value.message +"</span>";
                html += " </div>";
                html += " </div>";
                html += " </div>";
                html += " </div>";
            });
            $(".chatingMessage").html(html);
        }

    });

}*/