<?php
    require_once("connMysql.php");

	$uname = "SELECT id, acc, pwd, email FROM vipvalue";
	$result = $link->query($uname);
	if($result->num_rows > 0){
		echo "<table border=1 align=center>";
			echo "<tr>";
			echo "<th>ID</th>";
			echo "<th>Name</th>";
			echo "<th>Password</th>";
			echo "<th>Email</th>";
		echo "</tr>";
		while($row = $result->fetch_array()){
			echo "<tr>";
				echo "<td>".$row['id']."</td>";
				echo "<td>".$row['acc']."</td>";
				echo "<td>".$row['pwd']."</td>";
				echo "<td>".$row['email']."</td>";
			echo "</tr>";
		}
		echo "</table>";
		$result->free();
	}else{
		echo "error!!";
	}
?>