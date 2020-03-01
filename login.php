
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
</head>
<body>

<?php
{
        session_start();
        // else 
        //    {
        //     $m = "DB Good";
        //     echo "<script type='text/javascript'>alert('$m');</script>";
        //    
}    

?>


<?php


if(isset($_REQUEST["btnSignup"]) )
{
    header('Location:signup.php');
}
if(isset($_REQUEST["btnSubmit"]))
{
    

    $uname=$_REQUEST["user"];  //getting data from the form filled..
    $pass=$_REQUEST["password"];
    if($uname!="" && $pass!="")
    {
        {
            $host="localhost"; //now connecting to database..
            $port=3306;

            $user="root";
            $password="123456789";
            $dbname="assig1";
        
            $con = new mysqli($host, $user, $password, $dbname, $port);
            if(!$con)
            {
                die ('Could not connect to the database server' . mysqli_connect_error());
            }
        }
        
        
        
        
        echo "<script type='text/javascript'>alert('$uname');</script>";
        echo "<script type='text/javascript'>alert('$pass');</script>";

        $query="Select uname,pass from assig1.users WHERE uname='$uname' AND pass='$pass'"; //getting data from database..
        echo "<script type='text/javascript'>alert('nOW EUERY');</script>";
        echo "<script type='text/javascript'>alert('$query');</script>";
        $result=mysqli_query($con,$query);
        $recordsFound=mysqli_num_rows($result);

        if($recordsFound>0) //records are found..
        {
            $_SESSION["user"]=$uname;
            header('Location:home.php');
        }
        else
        {
            $_SESSION["user"]=null;
            $message = "Invalid User Name or Password";
            echo "<script type='text/javascript'>alert('$message');</script>";
        }
    }
    else
        echo "<script type='text/javascript'>alert('Username And PAssword is MAndatory');</script>";
}

?>


<form  method="POST">
  <label for="fname">User name:</label><br>
  <input type="text" id="uname" name="user"><br>
  <label for="lname">Password:</label><br>
  <input type="text" id="pass"  name="password"><br><br>
  <button type="submit" class="btn btn-primary" name="btnSubmit">Submit</button>
  <button type="submit" class="btn btn-primary" name="btnSignup">Signup</button>
</form>



</body>
</html>