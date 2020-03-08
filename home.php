<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="jquery.js"></script>
    
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <title>Home</title>
</head>
<style>
	.box {
	 padding:5px;
	 border: solid 1px red;
	 wdith:200px;
	 float:left;
	 margin: 5px;
	}
</style>
<script>
var newFolderLocationId=0;
$(document).ready(function(){
  
    var dataToSend = {"action": "viewParentFolders"};
            
    var settings= {
				type: "POST",
				dataType: "json",
				url: "registerApi.php",
				data: dataToSend,
				success: mainfolders,
				error: OnError
            };
            
			$.ajax(settings);
			console.log('request sent');
        });
function mainfolders(r){
    for (let index = 0; index < r[0].length; index++){
        let btname=r[index+1].folderName;
        let identity=r[index+1].ID;
        let buttons = $('<input></input>').attr({  id:identity,  type: 'button', name:'btn1', value:btname, class:'btn btn-success',onClick:"changeColor(this.id)", ondblclick:"showChild(this.id)" });
        $("#btdiv").append(buttons);
    }
}
function OnError(f){
  console.log(f);
    alert("An error has occured.");
}
</script>
<script>
function changeColor(idofbtn){
    var b=document.getElementById(idofbtn);
}
function showChild(i)
{
 newFolderLocationId=i; //storing the id in global variable to dentify where to make the new folder..
 
 var foldername=document.getElementById("foldernameplace");  //now removeing the folder name..
 while(foldername.firstChild){   
     foldername.removeChild(foldername.lastChild);
   }
var text=document.createElement('p');
text.innerText=$("#"+i).attr("value");
foldername.appendChild(text); //making the child folder as the main folder name..

   var p=document.getElementById("btdiv"); //now removing the child folders..
   console.log(p);
   while(p.firstChild){
     p.removeChild(p.lastChild);
   }

  let datatosend={"action":"showChildFolders","id":i};
  let set= {
				type: "POST",
				dataType: "json",
				url: "registerApi.php",
				data: datatosend,
				success: makenewChild,
				error: OnError
            };
            
			$.ajax(set);
			console.log('request sent for child folders');
}
function makenewChild(childs){
    console.log("Make New Childs");
    for (let index = 0; index < childs[0].length; index++) {
        let btname=childs[index+1].folderName;
        let ident=childs[index+1].ID;
        let butt = $('<input></input>').attr({  id:ident,  type: 'button', name:'btn1', value:btname, class:'btn btn-success',onClick:"changeColor(this.id)", ondblclick:"showChild(this.id)" });
        $("#btdiv").append(butt);
  }
}
</script>
<script> // make  a new folder..
function makefolder(){
  let  newFname=document.getElementById("newFolderName").value;
  console.log(newFname);
  if(newFname=="")
  {
    alert("Name is must for a folder...");
  }
  else
  {
    let datatosend={"action":"makeNewFolder","pFid":newFolderLocationId,"fname":newFname};
    let set= {
				type: "POST",
				dataType: "json",
				url: "registerApi.php",
				data: datatosend,
				success: makefolderSuccess,
				error: OnError
            };
            
			$.ajax(set);
			console.log('request sent for child folders');

  } 
}
function makefolderSuccess(r){
  alert(r);
}

</script>

<?php
session_start();

if(isset($_SESSION["user"])==false)
{
    header('Location:login.php');
}

?>

<body>


<!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" id="mybt">
  + New  Folder
</button>

<!-- Modal -->
<div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalCenterTitle">Add New Folder</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body" id="folderdiv">
       Enter the Name Of your Folder: <input type="text" name="newFolderName" id="newFolderName">
      </div>
      <!-- <div class="modal-footer"> -->
        <!-- <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button> -->
        <button type="button" class="btn btn-primary" id="btnCreateFolder" onClick="makefolder()">Create new Folder</button>
      <!-- </div> -->
    </div>
  </div>
</div>


<div class="container-fluid" id="pdiv">
    <div class="p-3 mb-2 bg-dark text-white" id="divname">
        <h2>Folders</h2>
        <div id="foldernameplace">
        <p>Main Folders<p>
        </div>
    </div>
    <div id="btdiv">
        
    </div>
</div>




















</body>
</html>