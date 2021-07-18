<?php
	$host = "localhost";
	$username = "root";
	$passwd = "Kiftvh39r1vbc970-";
	$db_name = "web";

	$link = @new mysqli($host, $username, $passwd, $db_name);

	if($link->connect_error != ""){ echo "資料庫連接失敗!"; }
	else{
		$link->query("SET NAMES 'utf8'");
		// echo "成功!!";
		$sql = "SELECT m_id, m_name, m_username, m_sex, m_birthday, m_level, m_email, m_phone, m_address FROM memberdata";
		// $upwd = "SELECT pwd From vipvalue";
		// $uemail = "SELECT email From vipvalue";
		// echo "Name:".$uname."\r\nPassword:".$upwd."\r\nEmail:".$uemail;
		$result = $link->query($sql);
		if($result->num_rows > 0){
			echo "<table border=1 align=center vertical-align=middle>";
				echo "<tr>";
					echo "<th>ID</th>";
					echo "<th>Name</th>";
					echo "<th>Username</th>";
					echo "<th>Sex</th>";
					echo "<th>Birthday</th>";
					echo "<th>Level</th>";
					echo "<th>Email</th>";
					echo "<th>Phone</th>";
					echo "<th>Address</th>";
				echo "</tr>";
			while($row = $result->fetch_array()){
				echo "<tr>";
					echo "<td>".$row['m_id']."</td>";
					echo "<td>".$row['m_name']."</td>";
					echo "<td>".$row['m_username']."</td>";
					echo "<td>".$row['m_sex']."</td>";
					echo "<td>".$row['m_birthday']."</td>";
					echo "<td>".$row['m_level']."</td>";
					echo "<td>".$row['m_email']."</td>";
					echo "<td>".$row['m_phone']."</td>";
					echo "<td>".$row['m_address']."</td>";
				echo "</tr>";
			}
			echo "</table>";
			$result->free();
		}else{
			echo "error!!";
		}
		// if ($result->num_rows > 0) {
		// // 輸出每行數據
		// 	while($row = $result->fetch_assoc()) {
		// 		echo "<br> Name: ". $row["acc"];
		// 		echo "<br>Password: ". $row["pwd"];
		// 		echo "<br>Email:" . $row["email"];
		// 	}
		// } else {
		// 	echo "0 個結果";
		// }
	}
?>