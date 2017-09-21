var script = document.createElement('script');script.src = "https://ajax.googleapis.com/ajax/libs/jquery/1.6.3/jquery.min.js";document.getElementsByTagName('head')[0].appendChild(script);

function url2Base64(img){
  var canvas = document.createElement("canvas");
  canvas.width = img.width;
  canvas.height = img.height;
  var ctx = canvas.getContext("2d");
  ctx.drawImage(img, 0, 0);
  var dataURL = canvas.toDataURL("image/png");
  return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
}


function toDataURL(url, callback) {
  var xhr = new XMLHttpRequest();
  xhr.onload = function() {
    var reader = new FileReader();
    reader.onloadend = function() {
      callback(reader.result);
    }
    reader.readAsDataURL(xhr.response);
  };
  xhr.open('GET', url);
  xhr.responseType = 'blob';
  xhr.send();
}

function toDataURL(src, track, callback) {
  var img = new Image();
  img.crossOrigin = 'Anonymous';
  img.onload = function() {
    var canvas = document.createElement('CANVAS');
    var ctx = canvas.getContext('2d');
    var dataURL;
    canvas.height = this.naturalHeight;
    canvas.width = this.naturalWidth;
    ctx.drawImage(this, 0, 0);
    dataURL = canvas.toDataURL("image/png");
    callback(track, dataURL);
  };
  img.src = src;
  if (img.complete || img.complete === undefined) {
    img.src = "data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///ywAAAAAAQABAAACAUwAOw==";
    img.src = src;
  }
}


function date2SQL(date){
  return date.getFullYear()+"-"+(date.getMonth()+1)+"-"+date.getDate()+" "
      +date.getHours()+":"+date.getMinutes()+":"+date.getSeconds();  
}

function dateInRange(start, end){
  return new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));
}

var lorem = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'.split(' ');
var tracks = [];
var start = new Date(2015, 01, 01);
var end = new Date();
$('.soundList__item').each(
  function(i, el){
    var track = {
      "Title":"",
      "UrlId":"",
      "Description":"",
      "Duration":"",
      "Likes":"",
      "YearReleased":"",
      "Uploader_id":"",
      "Artwork": ""
    };

    track["Title"] = $(el).find('.soundTitle__title').text().trim();
	
	track["UrlId"] = track["Title"].replace(/[^A-Za-z0-9 ]/g, "").toLowerCase().trim().replace(/[\s]+/g, "-");	
    
    track["Description"] = lorem.slice(0, Math.floor(Math.random() * lorem.length-1)).join(' ');
    
    track["DateUploaded"] = date2SQL(dateInRange(start, end));
    
    track["Duration"] = Math.floor(1+Math.random() * 60)*600000000;
    
    track["Uploader_id"] = $(el).find('.soundTitle__username').attr("href").substring(1);
      
    track["Likes"] = parseInt($(el).find('.sc-button-like').text()
      .trim().replace(/,|\./g, "").replace('K', '00')) || 0;
    track["YearReleased"] = 2000 + Math.floor(Math.random() * 18);
      
    var url = $(el).find('.image span').css('background-image');
    if(url.startsWith("linear"))
      url="http://placehold.it/500x500";
    else
      url=url.substring(5,url.indexOf('")')).replace("200x200", "500x500");
    track["Artwork"] = url;
    tracks.push(track);   
  }
);
tracks

var query = "INSERT INTO [dbo].[Track] "+
    "( [Title]"+
    ", [UrlId]"+
    ", [Description]"+
    ", [DateUploaded]"+
    ", [Duration]"+
    ", [Likes]"+
    ", [YearReleased]"+
    ", [Uploader_id]"+
    ", [Artwork])\r\nVALUES\t";
    
$(tracks).each(
    function(i, t){
    var value = "('"
      +t["Title"].replace(/'/g, "''")+"', '"
      +t["UrlId"]+"', '"
      +t["Description"].replace(/'/g, "''")+"', '"
      +t["DateUploaded"]+"', '"
      +t["Duration"]+"', '"
      +t["Likes"]+"', '"
      +t["YearReleased"]+"', "
      +"(SELECT [Id] FROM [User] WHERE [UserName] = '"+t["Uploader_id"]+"'), '"
      +t["Artwork"]+"')";
      query+=value + (i==tracks.length-1?";\r\n":",\r\n\t\t");
    }
);
copy(query);