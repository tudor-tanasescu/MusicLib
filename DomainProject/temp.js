$('.soundList__item').each(
  function(i, el){
    var url = $(el).find('.image span').css('background-image');
    if(url.startsWith("linear"))
      url="http://placehold.it/500x500";
    else
      url=url.substring(5,url.indexOf(')')).replace("200x200", "500x500");
    console.log(i, url);
  }
);


$('.soundList__item').each(
    function(i, el){
        var alias = $(el).find('.soundTitle__username').text().trim();    
        console.log(i, alias);
    }
);

$('.soundList__item').each(
    function(i, el){
        var username = $(el).find('.soundTitle__username').attr("href").substring(1);    
        console.log(i, username);
    }
);

$('.soundList__item').each(
    function(i, el){
        var title = $(el).find('.soundTitle__title').text().trim();    
        console.log(i, title);
    }
);

$('.soundList__item').each(
    function(i, el){
        var likes = parseInt($(el).find('.sc-button-like').text().trim().replace(/,|\./g, "").replace('K', '00')) || 0;
        console.log(i, likes);
    }
);

function date2SQL(date){
  return date.getFullYear()+"-"+(date.getMonth()+1)+"-"+date.getDate()+" "
      +date.getHours()+":"+date.getMinutes()+":"+date.getSeconds();  
}

function dateInRange(start, end){
  return new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));
}


var users = [];
var start = new Date(2015, 01, 01);
var end = new Date();
var usernames = [];
$('.soundList__item').each(
    function(i, el){
    var user = {
      "Alias":"", 
      "UserName":"",
      "Email":"",
      "PasswordHash":"",
      "DateJoined":"",
      "RecievesEmailNotifications":""
    };

        user["Alias"] = $(el).find('.soundTitle__username').text().trim();
    var username = $(el).find('.soundTitle__username').attr("href").substring(1);
    if(usernames.includes(username))
      return;
    usernames.push(username);
        user["UserName"] = username;
    user["Email"] = user["UserName"]+"@gmail.com";
    

    user["PasswordHash"] = "ABtgdITxVqGfE3LkoIRC6fZFPIfcEUwYjBIyw8hBsY/rPHdOKiFw2mnvGms+zRTn2g==";
    user["DateJoined"] = date2SQL(dateInRange(start, end));
      
    user["RecievesEmailNotifications"] = Math.random() >= 0.5;
      
    users.push(user);
    }
);


var query = "INSERT INTO [dbo].[User] "+
               "([Alias]"+
               ",[UserName]"+
               ",[Email]"+
               ",[PasswordHash]"+
               ",[DateJoined]"+
               ",[RecievesEmailNotifications])\r\nVALUES\t";
$(users).each(
  function(i, u){
    var value = "('"+u["Alias"].replace("'","\'\'")+"', '"
      +u["UserName"]+"', '"
      +u["Email"]+"', '"
      +u["PasswordHash"]+"', '"
      +u["DateJoined"]+"', '"
      +u["RecievesEmailNotifications"]+"')";
      query+=value + (i==users.length-1?";\r\n":",\r\n\t\t");
  }
);
copy(query);