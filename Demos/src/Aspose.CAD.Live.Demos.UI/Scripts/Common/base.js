const VIEWABLE_EXTENSIONS = [
	'DWG', 'DXF', 'DWF', 'IFC', 'STL'
];


// filedrop component
var fileDrop = {};
var fileDrop2 = {};

$.extend($.expr[':'], {
	isEmpty: function (e) {
		return e.value === '';
	}
});

// Restricts input for the set of matched elements to the given inputFilter function.
(function ($) {
	$.fn.inputFilter = function (inputFilter) {
		return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
			if (inputFilter(this.value)) {
				this.oldValue = this.value;
				this.oldSelectionStart = this.selectionStart;
				this.oldSelectionEnd = this.selectionEnd;
			} else if (this.hasOwnProperty("oldValue")) {
				this.value = this.oldValue;
				this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
			} else {
				this.value = "";
			}
		});
	};
}(jQuery));

function showLoader() {
	$('.progress > .progress-bar').html('15%');
	$('.progress > .progress-bar').css('width', '15%');
	$('#loader').removeClass("hidden");
	hideAlert();
}
function sendPageView(url) {
	if ('ga' in window)
		try {
			var tracker = ga.getAll()[0];
			if (tracker !== undefined) {
				tracker.send('pageview', url);
			}
		} catch (e) {
			/**/
		}
}
function hideLoader() {
	$('#loader').addClass("hidden");
}
function generateViewerLink(data) {
	var response = response = data.split('|');
	
		var statusCode = response[0];
		var fileName = response[1];
		var folderName = response[2];
		
	

	//var id = data.FolderName !== undefined ? data.FolderName : data.id;
	return encodeURI(o.ViewerPath +
		'FileName=' +
		fileName +
		'&FolderName=' +
		folderName +
		'&CallbackURL=' +
		o.AppURL);
}




function workSuccess(data, textStatus, xhr) {
	hideLoader();
	var response = data.split('|');
	if (response.length > 0) {
		var statusCode = response[0];
		var fileName = response[1];
		var folderName = response[2];
		if (statusCode === '200') {


			$('#WorkPlaceHolder').addClass('hidden');
			$('#DownloadPlaceHolder').removeClass('hidden');

			var url = encodeURI(o.UIBasePath + `common/download?file=${fileName}&folder=${folderName}`);

			$('#DownloadButton').attr('href', url);
			o.DownloadUrl = url;
		} else {
			showAlert(statusCode);
		}
	}
}

function hideAlert() {
	$('#alertMessage').addClass("hidden");
	$('#alertMessage').text("");
	$('#alertSuccess').addClass("hidden");
	$('#alertSuccess').text("");
}

function showAlert(msg) {
	hideLoader();
	$('#alertMessage').html(msg);
	$('#alertMessage').removeClass("hidden");
	$('#alertMessage').fadeOut(100).fadeIn(100).fadeOut(100).fadeIn(100);
}

function showMessage(msg) {
	hideLoader();
	$('#alertSuccess').text(msg);
	$('#alertSuccess').removeClass("hidden");
}

(function ($) {
	$.QueryString = (function (paramsArray) {
		let params = {};

		for (let i = 0; i < paramsArray.length; ++i) {
			let param = paramsArray[i]
				.split('=', 2);

			if (param.length !== 2)
				continue;

			params[param[0]] = decodeURIComponent(param[1].replace(/\+/g, " "));
		}

		return params;
	})(window.location.search.substr(1).split('&'))
})(jQuery);

function progress(evt) {
	if (evt.lengthComputable) {
		var max = evt.total;
		var current = evt.loaded;

		var percentage = Math.round((current * 100) / max);
		percentage = (percentage < 15 ? 15 : percentage) + '%';

		$('.progress > .progress-bar').html(percentage);
		$('.progress > .progress-bar').css('width', percentage);
	}
}

function removeAllFileBlocks() {
	fileDrop.droppedFiles.forEach(function (item) {
		$('#fileupload-' + item.id).remove();
	});
	fileDrop.droppedFiles = [];
	hideLoader();
}

function openIframe(url, fakeUrl, pageViewUrl) {
	// push fake state to prevent from going back
	window.history.pushState(null, null, fakeUrl);

	// remove body scrollbar
	$('body').css('overflow-y', 'hidden');

	// create iframe and add it into body
	var div = $('<div id="iframe-wrap"></div>');
	$('<iframe>', {
		src: url,
		id: 'iframe-document',
		frameborder: 0,
		scrolling: 'yes'
	}).appendTo(div);
	div.appendTo('body');
	sendPageView(pageViewUrl);
	
}

function closeIframe() {
	removeAllFileBlocks();
	$('div#iframe-wrap').remove();
	$('body').css('overflow-y', 'auto');
}
function request(url, data) {
	showLoader();
	$.ajax({
		type: 'POST',
		url: url,
		data: data,
		cache: false,
		contentType: false,
		processData: false,
		success: workSuccess,		
		xhr: function () {
			var myXhr = $.ajaxSettings.xhr();
			if (myXhr.upload)
				myXhr.upload.addEventListener('progress', progress, false);
			return myXhr;
		},
		error: function (err) {
			if (err.data !== undefined && err.data.Status !== undefined)
				showAlert(err.data.Status);
			else
				showAlert("Error " + err.status + ": " + err.statusText);
		}
	});
}

function requestConversion() {
	let data = fileDrop.prepareFormData();
	if (data === null)
		return;
	
	let url = o.UIBasePath + 'Conversion/Conversion?outputType=' + $('#saveAs').val() ;
	
	request(url, data);
}



function prepareDownloadUrl() {
	o.AppDownloadURL = o.AppURL;
	var pos = o.AppDownloadURL.indexOf(':');
	if (pos > 0) 
		o.AppDownloadURL = (pos > 0 ? o.AppDownloadURL.substring(pos + 3) : o.AppURL) + '/download';
	pos = o.AppDownloadURL.indexOf('/');
	o.AppDownloadURL = o.AppDownloadURL.substring(pos);
}
function requestViewer(data) {

	var url = generateViewerLink(data);
	openIframe(url, '/cad/viewer', '/cad/view');
}


function checkReturnFromViewer() {
	var query = window.location.search;
	if (query.length > 0) {
		o.ReturnFromViewer = true;
		var data = {
			StatusCode: 200,
			FolderName: $.QueryString['id'],
			FileName: $.QueryString['FileName'],
			FileProcessingErrorCode: 0
		};
		var beforeQueryString = window.location.href.split("?")[0];
		window.history.pushState({}, document.title, beforeQueryString);
		if (!o.UploadAndRedirect)
			workSuccess(data);
	}
}


function getInputType() {
    var defaultType = 'html';
    var pathUrl = window.location.pathname.toLowerCase();
    var conversionPos = pathUrl.indexOf('conversion');
    if (conversionPos < 0) {
        return defaultType;
    }
    var conv = pathUrl.substring(conversionPos + 11);
    if (conv.length === 0) {
        return defaultType;
    }
    var arr = conv.split('-');
    console.log(arr[0]);
    return arr[0];
}

$(document).ready(function () {
	prepareDownloadUrl();

	checkReturnFromViewer();
	fileDrop = $('form#UploadFile').filedrop(Object.assign({
		showAlert: showAlert,
		hideAlert: hideAlert,
		showLoader: showLoader,
		progress: progress
	}, o));

	

	// close iframe if it was opened
	window.onpopstate = function(event) {
		if ($('div#iframe-wrap').length > 0) {
			closeIframe();
		}
	};

	if (!o.UploadAndRedirect) {
		$('#uploadButton').on('click', o.Method);
	}

	
});
