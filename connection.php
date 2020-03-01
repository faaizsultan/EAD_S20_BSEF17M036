
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
	?>
