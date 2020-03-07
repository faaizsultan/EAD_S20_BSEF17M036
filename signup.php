<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    <title>Register</title>
    <script src="https://code.jquery.com/jquery-2.1.1.min.js"></script>

<?php

if(isset($_REQUEST["btnLogin"]))
{
    header('Location:login.php');
}
?>
</head>

<?php

if(isset($_REQUEST["btnSubmit"]) == true)
{
  
  
  $uname = $_REQUEST["Name"];   
  $pswd = $_REQUEST["password"];
  $confirmpassword = $_REQUEST["confirmPassword"];
  $userTable = $_REQUEST["userTable"];
  $host="localhost";
  $port=3306;
  
  $user="root";
  $password="123456789";
  $dbname="assig1";
  
  $con = new mysqli($host, $user, $password, $dbname, $port);
  if(!$con)
  {
      die ('Could not connect to the database server' . mysqli_connect_error());
  } 
  if($uname=="" ||  $pswd=="" || $confirmpassword=="" || $userTable=="")
  {
      echo "<script> alert('One of the fields is missing.Please Review')</script>";
  }
  else if($pswd!=$confirmpassword) 
  {
    echo "<script> alert('Passwords donot match.')</script>";
  }
  else
  {
        
        $query="Select '$uname' from assig1.users where uname='$uname'";
                $result=mysqli_query($con,$query);
                $recordsFound=mysqli_num_rows($result);
                if($recordsFound>0)
                {
                    echo    "<script> alert('User is already registerd....')</script>";
                }
                else 
                {
                    $query="INSERT INTO assig1.users(uname,pass,usertable) values('$uname','$pswd','$userTable')";
                    if(mysqli_query($con,$query)==true)
                    {
                        echo "<script> alert('Successfully registered..')</script>";;
                    }
                    else
                    {
                        echo "<script> alert('NOT Registered successfully..Unknown error occured.')</script>";;
                    }                              
                    
                }
    }
}


?>
	


<body>
  <form action="signup.php" method="POST">
  
  <label for="fname">UserTable:</label><br> 
  <input type="text"  name="userTable" id="userT"><br>

  <label for="lname">Name:</label><br>
  <input type="text"   name="Name"><br><br>

  <label for="fname">Password:</label><br>
  <input type="password"   name="password"><br>

  <label for="fname">Confirm Password:</label><br>
  <input type="password"   name="confirmPassword"><br>

  <button type="submit" class="btn btn-primary" name="btnSubmit" id="sub" >Register</button>
  <button type="submit" class="btn btn-primary" name="btnLogin">Login</button>
  
  </form>
  <div id="signup" style="display:none">
  <h1 style="color:red">You have been successfully registered..</h1>
  </div>

</body>
</html>