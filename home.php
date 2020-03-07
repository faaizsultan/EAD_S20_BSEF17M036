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
$(document).ready(function(){
  
    var dataToSend = {"action": "viewParentFolders"};
            
    var settings= {
				type: "POST",
				dataType: "json",
				url: "registerApi.php",
				data: dataToSend,
				success: Mysucfunction,
				error: OnError
            };
            
			$.ajax(settings);
			console.log('request sent');
        });
function Mysucfunction(r){
    console.log(r);
    console.log(r[1].folderName);

    for (let index = 0; index < r[0].length; index++){
        let btname=r[index+1].folderName;
        console.log(btname);
        let identity=r[index+1].ID;
        console.log("PRinting Id ="+identity);
        let buttons = $('<input><br>').attr({  id:identity,  type: 'button', name:'btn1', value:btname, class:'btn btn-success',onClick:"changeColor(this.id)", ondblclick:"showChild(this.id)" });
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
    console.log(idofbtn);
    var b=document.getElementById(idofbtn);
    console.log("Changing color"+b);
}
function showChild(i)
{
 var b=$("#pdiv");
 $("#btdiv").remove();
  var datatosend={"action":"showChildFolders","id":i};
  var set= {
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
    for (let index = 0; index < childs[0].length; index++) {
        let btname=childs[index+1].folderName;
        console.log(btname);
        let ident=childs[index+1].ID;
        
        let butt = $('<input><br>').attr({  id:ident,  type: 'button', name:'btn1', value:btname, class:'btn btn-success',onClick:"changeColor(this.id)", ondblclick:"showChild(this.id)" });
        $("#pdiv").append(butt);
        console.log(butt);
  }
}
</script>

<?php
session_start();

if(isset($_SESSION["user"])==false)
{
    header('Location:login.php');
}

?>
<script>
$("#ch").click(function(){

alert("Clicked");

});
function check(){
    
}
</script>

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
        
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>


<div class="container-fluid" id="pdiv">
    <div class="p-3 mb-2 bg-dark text-white" id="divname">
        <h2>Folders</h2>
    </div>
    <div id="btdiv">

<h2>Here i am </h2>
    </div>
</div>




















</body>
</html>