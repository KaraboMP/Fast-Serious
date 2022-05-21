var hosturl = "https://localhost:7099/"


function  ajaxGet(self, url, onSuccess, onFinally) {
  var accessToken = "";
  return axios({
    method: 'get',
    url: hosturl + url,
    headers: { 
		'Authorization': 'Bearer ' + accessToken, 
		}
  }).then(response => {
    if (onSuccess && typeof onSuccess == "function")
      onSuccess(response);
  }).catch(function (error) {
    
  }).finally(onFinally)
}

function doSomething(){
	var self = this;
	var onSuccess = response => {
		debugger
		var t = response.data;
	}
	var onFinally = response => {
		debugger
	}
	ajaxGet(self, 'Users', onSuccess, onFinally);
}