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
                    echo json_encode("Successfully Registered");
                }                              
                else 
                    echo json_encode("Didnt registered Succefully");
            }       
            else if($action=="makeNewFolder")
            {
                $pid=$_REQUEST["pFid"];
                $fname=$_REQUEST["fname"];
                $query;
                if($pid==0)
                {
                    $query="INSERT INTO assig1.usertable(folderName) VALUES('$fname')";
                }
                else
                {
                    $query="INSERT INTO assig1.usertable(folderName,parentFolderId) VALUES('$fname','$pid')";
                }

                if(mysqli_query($con,$query)==true)
                {
                    echo json_encode("Folder Created Successfully.");
                }                              
                else 
                echo json_encode("Folder Wasnt created.");
            }
            else  if($action=="viewParentFolders")
            {
                $query="Select folderName,folderId from assig1.usertable where parentFolderId is null";
                $result=mysqli_query($con,$query);
                $recordsFound=mysqli_num_rows($result);
                $folders = array();
                $i=1;
                if($recordsFound>0)
                {
                    
                    while($row = mysqli_fetch_assoc($result)) 
                    {	
                        		
                        $fId = $row["folderId"];		
                        $fName=$row["folderName"];
                        $folders[$i]=array("ID"=>$fId,"folderName"=>$fName);
                        $i++;
                    }
                    $folders[0]["length"]=$i-1;
                 echo json_encode($folders);   
                }
                else 
                echo "<script>alert('No folders found')</script>";
            }
            else if($action=="showChildFolders")
            {
                $id=$_REQUEST["id"];
                $query="select folderName,folderId from assig1.usertable where parentFolderId='$id'";
                $result=mysqli_query($con,$query);
                $recordsFound=mysqli_num_rows($result);
                $folders = array();
                $i=1;
                if($recordsFound>0)
                {
                    
                    while($row = mysqli_fetch_assoc($result)) 
                    {	
                        		
                        $fId = $row["folderId"];		
                        $fName=$row["folderName"];
                        $folders[$i]=array("ID"=>$fId,"folderName"=>$fName);
                        $i++;
                    }
                    $folders[0]["length"]=$i-1;
                 echo json_encode($folders);   
                }
                else 
                echo "<script>alert('No folders found')</script>";
            }
        }
    ?>