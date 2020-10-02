$(document).ready(function () {
	var itemsContainer = $("#items");

	loadNewsItems(itemsContainer.data("count"));
	
	$("#allnews").on("click", function (e) {
		e.preventDefault();	
		loadNewsItems(0);
		$(this).fadeOut(130).remove();
	});

	$("#sendfeedback").on("click", function (e) {
        e.preventDefault();
        e.stopPropagation();
		$("#contentlabel").removeClass("required");
        if ($("#content").val() !== "") {
            var form = $("#feedbackform");
			$("#feedbacktype").attr("disabled","disabled");
			$("#content").attr("disabled","disabled");
            $("#sendfeedback").addClass("disabled").html("Sending feedback...");
            $.post(form.attr("action"), form.serialize(), function (data) {
                if (data.success) {
                    $("#sendfeedback").addClass("disabled").html("Thank you!");
                    setTimeout(function () {
                        $('#feedbackmodal').modal('hide');
                    }, 1000);
                }
            });
        }else{
			$("#contentlabel").addClass("required");
		}
	});
	
	function loadNewsItems(count){
		$.get({
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			url: itemsContainer.data("items-url") + "?count=" + count,
			type: "get",
			cache: false,
			success: function(data) {
				if (data.length > 0) {
					var res = [];

					for (var i = 0; i < data.length; i++) {
						res.push(renderItem(data[i]));
					}
	
					$("#items").html(res.join(''));
					
				} else {
					$("#items").html("<li>No items found</li>");
				}
			},
			error: function() {
			}
		});
	}

	function renderItem(item){
		var itemContent = [];
		itemContent.push("<div class=\"col-sm-12 col-md-4 col-lg-3\"><img src=\"" + item.image + "\"></div>");
		itemContent.push("<div class=\"col-sm-12 col-md-8 col-lg-9 text-left\">");
		itemContent.push("<span class=\"pre-heading\">" + item.date + " | " + item.category + "</span>");
		itemContent.push("<h3>" + item.title + "</h3>");
		itemContent.push("<p>" + item.preamble + "</p>");
		itemContent.push("<span class=\"show-item\" data-id=\"" + item.id + "\">Read more</span>");
		itemContent.push("</div>");
		return "<li><div class=\"row\">" + itemContent.join('') + "</row></li>";
	}
});

$(document).on('click', '.show-item', {}, function (e) {
    e.preventDefault();
    e.stopPropagation();
	var $this = $(this);
	var itemsContainer = $("#items");
	
	$.get({
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		url: itemsContainer.data("item-url") + "?id=" + $this.data("id"),
		type: "get",
		cache: false,
		success: function(data) {
			$("#itemmodaltitle").html(data.date + " | " + data.category);
			$("#itemmodalbodyheader").html("<h3>" + data.title + "</h3><br/>");			
			$("#itemmodalbody").html("<img src=\"" + data.image + "\" class=\"image-left\">" + data.content);
			$('#itemmodal').modal('show');
		},
		error: function() {
		}
	});
}); 