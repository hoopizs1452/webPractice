<?php
	require_once("connMysql.php");
	//會員登入檢查
	session_start();
	if(isset($_SESSION["loginMember"]) && ($_SESSION["loginMember"] != "")){
		if($_SESSION["memberLevel"] == "member"){
			header("Location: member_center.php");
		}
		else{
			header("Location: member_admin.php");
		}
	}

	//會員登入
	if(isset($_POST["username"]) && isset($_POST["passwd"])){
		$query_RecLogin = "SELECT acc, pwd";
	}
?>