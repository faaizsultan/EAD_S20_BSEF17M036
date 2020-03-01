<?php
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
        if(isset($_REQUEST["action"]) && !empty($_REQUEST["action"]))
        {
            $action=$_REQUEST["action"];  //checking the type of action o perform;
            if($action=="register")
            {
                $userTable=$_REQUEST["tableName"];
                $name=$_REQUEST["username"];
                $password=$_REQUEST["password"];
                                              // now entering the data to database.
                $query="INSERT INTO assig1.users(uname,pass,usertable) VALUES ('$name','$password','$userTable')";
                if(mysqli_query($con,$query)==true)
                {
                    echo json_encode("Succefully Registered");
                }                              
                else 
                echo json_encode("Didnt registered Succefully");
            }  

        }
    ?>