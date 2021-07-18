<?php
	$host = "localhost";
	$username = "root";
	$passwd = "Kiftvh39r1vbc970-";
	$db_name = "web";

	$link = @new mysqli($host, $username, $passwd, $db_name);

	if($link->connect_error != ""){ echo "資料庫連接失敗!"; }
	else{ $link->query("SET NAMES 'utf8'"); }
?>